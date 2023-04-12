##Book Management Microservice Project

## Microservices
* Contact Service  
* Reporting Service 
* Notification Service 

## Database
Postgresql is used as database.
Migration classes were created Contact Service and Reporting Service.


## Message Broker
RabbitMq, MassTransit framework were used together.
RabbitMq Default Port : 5672.
RabbitMq url should be configured in appsettings.json file.

## SignalR
SignalR is used for client notification.


##Note
RabbitMq, SignarR, and Microservices' ports can be changed, in this case, these endpoints should be updated within regarding projects.