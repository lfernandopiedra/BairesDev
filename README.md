# BairesDev
Joke System

Cómo correr el código:

Para correr este código se requiere IIS y .Net Framework 4.7.2. Se debe instalar IIS en caso de que no lo esté. Copiar el contenido de PUBLISHED
En la carpeta wwwroot del servidor.

Definición del proyecto
El sistema lee de un repositorio externo de bromas (https://icanhazdadjoke.com), realizando una consulta al API; el repositorio retorna
una cadena JSON, la cual podrá ser tratada de la siguiente manera

- Consulta cada 10 segundos de bromas aleatoriamente
- Consulta por parámetro de búsqueda.

En caso de que se realice una búsqueda, el sistema clasifica y muestra las bromas resultantes de la consulta de acuerdo a su longitud. 
Además resalta el término buscado en mayúsculas y negrillas.

El sistema fue pensado siguiendo un modelo MVC; en el cual se estableció una clase padre (Joke) y un servicio de búsqueda, clasificación,
conteo de palabras y resultados de búsqueda (JokeService). Los controladores accionan los métodos y publican los resultados en las vistas.
