MapHealthChecks
comprueba http://localhost:5285/health
visita http://localhost:5285/healthchecks-ui#/healthchecks para el UI de healthchecks

WatchDog
visita http://localhost:5285/watchdog para el UI de WatchDog


Redis cache
Para montar un contenedor de Redis con Redis Stack, puedes usar el siguiente comando de Docker:
docker image pull redis/redis-stack:latest

Para ejecutar el contenedor, usa el siguiente comando:
docker run -d --name redis-stack -e REDIS_ARGS="--requirepass 123456" -p 6379:6379 -p 8001:8001 redis/redis-stack:latest

Luego puedes acceder a Redis Stack en
http://localhost:8001/ para el UI de Redis. username: default, password: 123456