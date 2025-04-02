***Minimal API in ASP.NET Core***

Minimal API are architected to create HTTP API with minimal dependencies. They are ideal for microservices and apps that wants to include only the minimum files, features and dependencies in ASP.NET Core.

Endpoints created :


Type	API	Description

GET	/todoitems	Get all to-do items

GET	/todoitems/complete	Get Completed to-do items

GET	/todoitems/{id}	Get an Item by id

POST	/todoitems	Add a new item

PUT	/todoitems/{id}	Update an existing item

DELETE	/todoitems/{id}	Delete an item

Reference : https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-9.0&tabs=visual-studio
