# V - Proyecto Final (Proyecto Capstone)

- Puedes encontrar el documento con el desglose del Proyecto Final y las fechas de entrega [AQUÍ](https://github.com/wizelineacademy/DSA-Carrix-SecureCoding-2023/files/12885648/DSA-Carrix._.Proyecto.Final._.Devs.pdf)
- Formulario de envio de Entregables [AQUI](https://docs.google.com/forms/d/e/1FAIpQLScdGI8T8lnX_QrIqqGGfq5czKqWQokK8vx3AW1nYpwi6s4KlA/viewform)
- Plantilla de Reporte de Vulnerabilidades [AQUI](https://github.com/wizelineacademy/DSA-Carrix-SecureCoding-2023/files/12969450/Reporte.de.Vulnerabilidad.docx)

# Entregable 1

- Integración de puntuación : 50
- Fecha : 24 de Octubre 2023
- Formato de Envio : GitHub

1. Escanea el código https://github.com/TsuyoshiUshio/ VulnerableApp con SonarQube
2. Analizar a detalle los hallazgos de SonarQube, utiliza las secciones Cual es el riesgo,¿Estás en riesgo? y ¿Cómo puedes solucionarlo? para desarrollar un reporte con la siguiente información:
● Descripción de las 3 vulnerabilidades que consideres más importantes.
● Líneas de código afectadas por las vulnerabilidades afectadas
● Propuesta de remediación
● Justificación de 3 falsos
positivos (Hallazgos que en realidad son falsos positivos)
3. Instalar y configurar correctamente Sonarlint en un entorno de Visual Studio
4. Automatiza el análisis en el repositorio que utilizarás para el proyecto final con SonarQube utilizando GitHub Actions
5. Habilita Dependabot en tu repositorio de GitHub

# Entregable 2

- Integración de puntuación : 10
- Fecha : 14 de Noviembre 2023
- Formato de Envio : GitHub

1. Desarrolla una aplicación con el lenguaje de tu preferencia, donde le des la oportunidad al usuario de introducir cadenas de texto.
2. Desarrolla una función para sanitizar el texto introducido por el usuario, permitiendo solo caracteres no maliciosos. Es sugerible utilizar expresiones regulares.
3. Detecta números de tarjetas de crédito/débito en la cadena isanitizada y enmascáralos, permitiendo ver solo los últimos 4 números.
4. Desarrolla un a función para calcular el hash en SHA256 de la cadena sanitizada y enmascarada.
5. Desarrolla una función para cifrar en AES256 la cadena sanitizada y enmascarada.
6. Desarrolla una función para descifrar la cadena cifrada, utiliza la función para calcular el hash y confirma que la cadena descifrada siga resultando en el mismo hash.

# Entregable 3

- Integración de puntuación : 40
- Fecha : 1 de Diciembre 2023
- Formato de Envio : FVR

1. Utiliza Microsoft Threat Modelling Tool para detectar riesgos en la arquitectura compartida por Wizeline.
2. Utiliza el navegador MITRE ATT&CK para detectar riesgos de acuerdo a los grupos cibercriminales que pudieran ser de interés para el contexto de tu desarrollo
3. Haz un reporte de acuerdo a los hallazgos que hayas tenido con SonarQube, dependabot y Microsoft Threat Modelling Tool:
● Descarta y justifica los falsos positivos.
● Documenta el detalle de las vulnerabilidades y riesgos detectados.
● Identifica si alguno de los hallazgos de estas herramientas, está relacionado a alguno de los hallazgos que tuviste con MITRE ATT&CK.
● Haz un plan de remediación, priorizando su riesgo de acuerdo a MITRE ATT&CK y la criticidad que las otras herramientas dieron
