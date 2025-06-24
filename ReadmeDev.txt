MapHealthChecks
comprueba http://localhost:5285/health
visita http://localhost:5285/healthchecks-ui#/healthchecks para el UI de healthchecks



Redis cache
Para montar un contenedor de Redis con Redis Stack, puedes usar el siguiente comando de Docker:
>docker image pull redis/redis-stack:latest

Para ejecutar el contenedor, usa el siguiente comando:
>docker run -d --restart=always --name redis-stack -e REDIS_ARGS="--requirepass 123456" -p 6379:6379 -p 8001:8001 redis/redis-stack:latest

Luego puedes acceder a Redis Stack en
http://localhost:8001/ para el UI de Redis. username: default, password: 123456



EntityFramework
Instalar y comprobar el CLI de EF Core:
>dotnet tool install --global dotnet-ef
>dotnet ef

Para ejecutar migraciones, el proyecto debe compilar correctamente y debe estar en la carpeta del proyecto. Por ejemplo:
>cd A:\GitProjects\Lab\Company1.Ecommerce

Luego, puedes ejecutar el siguiente comando para aplicar las migraciones:
>dotnet ef migrations add InitialCreateSchme --project Company1.Ecommerce.Persistence --startup-project Company1.Ecommerce.Service.WebApi --output-dir Migrations --context ApplicationDbContext

A continuación, puedes aplicar las migraciones a la base de datos con el siguiente comando:
>dotnet ef database update --project Company1.Ecommerce.Persistence --startup-project Company1.Ecommerce.Service.WebApi --context ApplicationDbContext



RabbitMQ
Para montar un contenedor de RabbitMQ, puedes usar el siguiente comando de Docker:
>docker run -d -it --restart=always --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:4-management

Luego puedes acceder a RabbitMQ en 
http://localhost:15672/ 
con el usuario y contraseña por defecto: guest / guest