using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using sec_web_api.Models;

namespace sec_web_api.Controllers
{
    [ApiController]
	[Route("/users")]
	public class UserController: ControllerBase
	{
        private IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private static readonly Random random = new Random();

        private static string GenerateRandomName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return name;
            }

            string[] names = { "Alicia", "Manuel", "Carlos", "David", "Eva", "Francisco", "Juan", "Jaime", "Andrea", "Gabriel" };
            return names[random.Next(names.Length)];
        }

        private static string GenerateRandomLastName()
        {
            string[] names = { "Sanchez", "Perez", "Martinez", "Lopez", "Hernandez", "Osorio", "Reyes", "Medina", "Godinez", "Ramos" };
            return names[random.Next(names.Length)];
        }

        private static string GenerateRandomEmail()
        {
            return $"usuario{random.Next(1000, 9999)}@banco-privado.com.mx";
        }

        private static string GenerateRandomAddress()
        {
            string[] addresses = {
                "Calle 1, Colonia Centro, Ciudad de México, CP 10000",
                "Avenida 2, Colonia Norte, Guadalajara, Jalisco, CP 20000",
                "Calle 3, Colonia Sur, Monterrey, Nuevo León, CP 30000",
                "Avenida 4, Colonia Este, Puebla, Puebla, CP 40000",
                "Calle 5, Colonia Oeste, Tijuana, Baja California, CP 50000",
                "Avenida 6, Colonia Poniente, Cancún, Quintana Roo, CP 60000",
                "Calle 7, Colonia Centro, Mérida, Yucatán, CP 70000",
                "Avenida 8, Colonia Norte, Querétaro, Querétaro, CP 80000",
                "Calle 9, Colonia Sur, Guanajuato, Guanajuato, CP 90000",
                "Avenida 10, Colonia Este, Chihuahua, Chihuahua, CP 100000"
            };
            return addresses[random.Next(addresses.Length)];
        }

        private static decimal GenerateRandomBalance()
        {
            return (decimal)(random.Next(1000, 10000) / 100.0);
        }

        private static string GenerateRandomAccountNumber()
        {
            return $"ACCT-{random.Next(100000, 999999)}";
        }

        private static string GenerateRandomPIN()
        {
            int pin = random.Next(1000, 10000);
            return pin.ToString("D4");
        }

        private static string GenerateRandomCardNumber()
        {
            StringBuilder cardNumber = new StringBuilder();
            for (int i = 0; i < 16; i++)
            {
                cardNumber.Append(random.Next(0, 10));
            }
            return cardNumber.ToString();
        }

        private static User GenerateUser(string name = "")
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = GenerateRandomName(name),
                LastName = GenerateRandomLastName(),
                Email = GenerateRandomEmail(),
                Address = GenerateRandomAddress(),
                Balance = GenerateRandomBalance(),
                AccountNumber = GenerateRandomAccountNumber(),
                PIN = GenerateRandomPIN(),
                CardNumber = GenerateRandomCardNumber(),
            };

            return user;
        }

        private static List<User> GenerateUsers()
        {
            List<User> users = new List<User>();

            for (int i = 0; i < 15; i++)
            {

                users.Add(GenerateUser());
            }

            return users;
        }

        private string EncodeForHtml(string input)
        {
            return input.Replace("<", "&lt;").Replace(">", "&gt;");
        }


        // Lección 5 - Secure Coding Princples:
        /* Validación de entradas: Data Annotations, Regex, Data Types, Esquemas, Remover caracteres especiales
         * Model State Validations, Sanitización, Encoding, Microsoft AntiXSS Library, Fluent Validation Library
         * Secretos: Variables de ambiente, secretos, configuración seguras
         * Fallo de errores: MAnejo de errores, try/catch, logs
         * Authenticación: Login, Políticas de contraseñas seguras, ASP NET Identity
         * Authorización: Roles, políticas, permisos
         * 
         */

        // Lección 6 - Input Validation
        /***************************************************************/
        // Simulando un endpoint que no valida las entradas de datos
        // siendo vulnerable a ataques XSS, SQL, etc.
        [HttpGet]
        [Route("/search")]
        public dynamic getUser([FromQuery] SearchUser searchUser)
        {
            // Simulando un ataque SQL Injection
            if (searchUser.name.Equals("'or '1'='1"))
            {
                return GenerateUsers();
            }

            // Simulando un ataque XLS Injection
            if (searchUser.name.Contains("script"))
            {
                Console.WriteLine("Se registró la búsqueda de un usuario con caracteres especiales: " + EncodeForHtml(searchUser.name));
                return "<script>alert('Transferencia exitosa')</script>";
            }

            var result = new
            {
                Message = "User search successful",
                SearchUser = GenerateUser(searchUser.name)
            };

            return Ok(result);
        }

        // Refactorizando el endpoint para evitar ataques de seguridad
        [HttpGet]
        [Route("/safe-search")]
        public dynamic getSafeUser([FromQuery] SafeSearchUser searchUser)
        {
            // Solo para propósitos de prueba
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Se registró un intento de búsqueda con caracteres no permitidos");
                return BadRequest(ModelState);
            }

            var result = new
            {
                Message = "User search successful",
                SearchUser = GenerateUser(searchUser.name)
            };

            return Ok(result);
        }

        // Lcción 7 - Authentication & Authorization
        /***************************************************************/
        // Simulando un endpoint que no valida los permisos y retorna
        // toda la información, la cuál puede contener data sensible
        [HttpGet]
        [Route("/users")]
        public dynamic getUsers()
        {
            return GenerateUsers();
        }

        // Implementando un endpoint de loging para la generación de JWT Token
        // Configurar en appsettings.json Jwt Property
        // https://datatracker.ietf.org/doc/html/rfc7519#section-4.1
        // Agregar: Microsoft.AspNetCore.Authentication.JwtBearer
        // Agregar: Microsoft.EntityFrameworkCore.Tools
        // Agregar: Newtonsoft.Json
        // Agregar: Swashbuckle.AspNetCore.Swagger
        [HttpPost]
        [Route("/login")]
        public dynamic login([FromBody] System.Object auth)
        {
            List<UserAuth> db = new List<UserAuth>
            {
                new UserAuth
                {
                    email = "user@wizeline.com",
                    password = "password123!",
                    role = "user",
                },
                new UserAuth
                {
                    email = "admin@wizeline.com",
                    password = "password123!",
                    role = "admin",
                },
            };

            var data = JsonConvert.DeserializeObject<dynamic>(auth.ToString());
            string email = data.email;
            Console.WriteLine("email: " + email);
            string password = data.password;
            Console.WriteLine("password: " + password);

            UserAuth user = db.Where(x => x.email == email && x.password == password).FirstOrDefault();

            if (user == null) {
                Console.WriteLine("User: " + email + " not found");
                return BadRequest();
            }

            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();

            Console.WriteLine("role: " + user.role);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("email", email),
                new Claim("role", user.role),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            SigningCredentials signIn = new(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                    jwt.Issuer,
                    jwt.Audience,
                    claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signIn
                );

            return new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
            };
        }


        // Refactorizando el endpoint para evitar ataques de seguridad,
        // retornando información solo a usuarios autenticados y autorizados
        [HttpGet]
        [Route("/safe-users")]
        public dynamic getSafeUsers()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            // Log the user's claims
            foreach (var claim in identity.Claims)
            {
                Console.WriteLine($"Claim Type: {claim.Type}, Claim Value: {claim.Value}");
            }

            try
            {
                var rToken = Jwt.validateToken(identity);
                var user = rToken.result;

                if (user == null)
                {
                    Console.WriteLine("Unauthenticated user");
                    return BadRequest("Unauthenticated");
                }

                if (user.role != "admin")
                {
                    Console.WriteLine("Unauthorized user");
                    return BadRequest("Unauthorized");
                }

                return GenerateUsers();
            } catch(Exception _)
            {
                return BadRequest("Invalid token");
            }
        }

        // Lección 8 - Data Protection Standars
        /***************************************************************/
        // Simulando las políticas de contraseñas de PCI
        [HttpPost]
        [Route("/change-password")]
        public dynamic changePassword(UserPassword userPassword)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string pattern = @"^[a-zA-Z0-9!_-]{8}$";

            if (Regex.IsMatch(userPassword.password, pattern))
            {
                Console.WriteLine("The password provided matches with the password policy");
            }

            Console.WriteLine("Password request change by:" + userPassword.email);

            var result = new
            {
                Message = "Password changed successfully",
                Result = true
            };

            return Ok(result);
        }
    }
}

