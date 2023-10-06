# V - Proyecto Final (Proyecto Capstone)

# Entregable 1

- Integración de puntuación : 50
- Fecha : 20 de Octubre 2023
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
- Fecha : 3 de Noviembre 2023
- Formato de Envio : GitHub

1. Desarrolla una página de login, que requiera usuario y contraseña
2. Transmite el usuario y la contraseña utilizando AES256 Se deberán almacenar utilizando el hash SHA256
3. Desarrolla funciones que saniticen el usuario y la contraseña utilizando expresiones regulares.
4. Controla los siguientes escenarios:
● Tiempo máximo de sesión
● Tiempo máximo de
inactividad
● Permisos del usuario para
los elementos que tendrá el sitio web (descritos a continuación)
5. Haz una página web tipo foro, donde los visitantes puedan registrar el título de su mensaje y el mensaje
● No deberá poder ser accedido si no hay una sesión activa
● Utiliza sanitización de las entradas
6. Asignar un permiso, de tal forma que no todos los usuarios puedan registrar mensajes
7. Siguiendo la página web tipo foro, haz una página o sección donde los usuarios puedan ver los mensajes que los demás dejaron
● No deberá poder ser accedido si no hay una sesión activa
● Utilizar sanitización antes de reflejar los textos
● Asignar un permiso, de tal forma que no todos los usuarios puedan registrar mensajes

# Entregable 3

- Integración de puntuación : 40
- Fecha : 17 de Noviembre 2023
- Formato de Envio : GitHub

1. Utiliza Microsoft Threat Modelling Tool para replicar tu arquitectura y detectar riesgos
2. Utiliza el navegador MITRE ATT&CK para detectar riesgos de acuerdo a los grupos cibercriminales que pudieran ser de interés para el contexto de tu desarrollo
3. Haz un reporte de acuerdo a los hallazgos que hayas tenido con SonarQube, dependabot y Microsoft Threat Modelling Tool:
● Descarta y justifica los
falsos positivos
● Documenta el detalle de
las vulnerabilidades y
riesgos detectados.
● Identifica si alguno de los
hallazgos de estas herramientas, está relacionado a alguno de los hallazgos que tuviste con MITRE ATT&CK.
● Haz un plan de remediación, priorizando su riesgo de acuerdo a MITRE ATT&CK y la criticidad que las otras herramientas dieron
