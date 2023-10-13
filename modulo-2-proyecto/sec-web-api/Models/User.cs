using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace sec_web_api.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal Balance { get; set; }
        public string AccountNumber { get; set; }
        public string PIN { get; set; }
        public string CardNumber { get; set; }
    }

    public class SearchUser
    {
        public string name { get; set; }
    }

    public class SafeSearchUser
    {
        [Required(ErrorMessage = "The 'name' parameter is required.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Invalid name format")]
        public string name { get; set; }
    }

    public class UserAuth
    {
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }

    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public static dynamic validateToken(ClaimsIdentity identity)
        {
            try
            {
                if (identity == null || !identity.Claims.Any())
                {
                    throw new Exception("Invalid Token: Identity claims are missing.");
                }

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
                        password = "password1123!",
                        role = "admin",
                    },
                };

                var emailClaim = identity.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
                Console.WriteLine("Email from claim: " + emailClaim);
                var user = db.FirstOrDefault(x => x.email == emailClaim);

                return new
                {
                    result = user
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in validateToken: " + e.ToString());
                throw new Exception("Invalid Token: An error occurred while processing the token.", e);
            }
        }
    }

    public class UserPassword
    {
        [Required(ErrorMessage = "The 'email' parameter is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string email { get; set; }
        [Required(ErrorMessage = "The 'password' parameter is required.")]
        [RegularExpression("^[a-zA-Z0-9!-_]{8}$", ErrorMessage = "Invalid password policy")]
        public string password { get; set; }
        [Required(ErrorMessage = "The 'confirmPassword' parameter is required.")]
        [RegularExpression("^[a-zA-Z0-9!-_]{8}$", ErrorMessage = "Invalid password policy")]
        [Compare("password", ErrorMessage = "Passwords do not match.")]
        public string confirmPassword { get; set; }
    }
}
