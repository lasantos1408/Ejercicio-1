# Sistema Académico
El Sistema Académico implementa una solución que gestiona los cursos y calificaciones de una institución. El sistema cuenta con dos módulos Gestionar usuarios para el manejo de usuarios y roles y Gestionar cursos que permite gesrionar los cursos, estudiantes y notas. Además los estudiantes pueden inscribirse en un curso y ver las notas del curso.

# Dependencias 
Instalar los siguientes programas en caso de no tener para el correcto funcionamiento de la aplicación.

- Visual Studio 2019 URL: https://visualstudio.microsoft.com/es/thank-you-downloading-visual-studio/?sku=Community&rel=16  
- .NET Framework 4.8 URL: https://dotnet.microsoft.com/download/dotnet-framework/net48

# Como ejecutar la aplicación

- Abrir la aplicacion desde el archivo AppAcademico.sln
- En explorador de soluciones clic derecho sobre la aplicación y luego hacer clic en la opción Compilar.
- En las opciones de Visual Studio hacer clic en Herramientas, luego Administrador de paquetes NuGet y en el submenú  que aparece hacer clic en la opción (Consola de administración de paquetes).
- Dentro de la consola de administración de paquetes ejecutar los siguientes comandos uno a continuación de otro:
 Add-Migration "Actualizacion" 
 Update-Database
- A continuación ejecutar solución presionando la combinación de teclas (Ctrl + F5)
- Para acceder a la aplicación hacerlo con el usuario y password predeterminados que se proporcionan a continuación:

 Usuario: admin
 Password: 123Pa$$word.
 
 - El usuario admin tiene rol de administrador por lo que con este se podrá acceder a todas las funcionalidades, crear nuevos usuarios y asignarle un rol.
 
