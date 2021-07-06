# MessageService

HOW TO START:
1) Open solution (MessageService/MessageService.Send.Api/MessageService.sln).
2) Open NPM, select MessageService.Resource.Api project.
3) Input: "update database".
4) Start MessageService.Send.Api project. To send message (AuthToken and AccountSid are needed) you need to register in twilio and link phone, that will receive messages. Also you need to choose in twilio a phone number, that will send a message (Ukraine, USA, Germany, Austria and Poland numbers are available).
5) Start MessageService.Send.Api project and try to get an information.

ABOUT:
That is a service of sending messages and providing common information.
Solution contains:
- Api, that sends a message.
- Api, that providing common information (i.e information about certain number of requests, common statistics, countries information).
- Extra class library.
- Gitignore file.

Used services:
- Auto Mapper.
- Swashbuckle.
- Twilio.
- Entity Framework Core.
