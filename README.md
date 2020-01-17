# InitialEnterprise ( domain driven design)
Initial Enterprise Architecture for a .net core based business critical backend softwaresystem 

The goals of this project are:

  * shows a complex implementation of all DDD modules and techniques without any technical compromise      
  * demonstrate advanced techniques       
  * Representation of well-developed code that you can use in production            
        

### Concepts Backend
* [IntegrationTDD] for RESTApi with TestServer
* [UnitTest] with Mocking
* [SEEDING] for InMemory Database & Testfixtures
* [CQRS] Infrastructure with Dispatcher for Commands & Queries
* [DDD] Infrastructure 
* [QueryHandler] to handle Queries
* [CommandHandler] to handle Commands CurrencyCommandHandler>
* [ValidationHandler] to validate Domain Commands
* [DDDApplication] Layer for the Domain orchestration, Command dispachting & mapping
* [JWTTOKENBUILDER] with JwtAuthentication & Claims 
* [CLEANREST]  
* [BLAZOR]  

### Concepts Frontend
* [BLAZOR]  
* [WebAssembly]
* [Flux Architecture]



Recources

Domain-Driven Design: Tackling Complexity in the Heart of Software

https://vaughnvernon.co/

https://martinfowler.com/

https://enterprisecraftsmanship.com/

https://github.com/vkhorikov/SpecificationPattern/tree/master/SpecificationPattern


[IntegrationTDD]: <https://github.com/jorgenschumann/InitialEnterprise/tree/master/Backend/InitialEnterprise.Domain.MainBoundedContext.Api.Tests/ApiServices> 
[CQRS]: <https://github.com/jorgenschumann/InitialEnterprise/tree/master/Backend/InitialEnterprise.Infrastructure/CQRS>
[DDD]: <https://github.com/jorgenschumann/InitialEnterprise/tree/master/Backend/InitialEnterprise.Infrastructure/DDD>
[SEEDING]: <https://github.com/jorgenschumann/InitialEnterprise/tree/master/Backend/InitialEnterprise.DataSeeding>
[JWTTOKENBUILDER]: <https://github.com/jorgenschumann/InitialEnterprise/blob/master/Backend/InitialEnterprise.Domain.MainBoundedContext/UserModule/Services/JwtSecurityTokenBuilder.cs>
[CLEANREST]: <https://github.com/jorgenschumann/InitialEnterprise/blob/master/Backend/InitialEnterprise.Domain.MainBoundedContext.Api/Controller/CurrencyController.cs>
[DDDApplication]:<https://github.com/jorgenschumann/InitialEnterprise/blob/master/Backend/InitialEnterprise.Domain.MainBoundedContext.Api/Application/CurrencyApplication/CurrencyApplication.cs>
[QueryHandler]:<https://github.com/jorgenschumann/InitialEnterprise/blob/master/Backend/InitialEnterprise.Domain.MainBoundedContext/CurrencyModule/QueryHandler/QueryCurrencyHandlerAsync.cs>
[CommandHandler]:<https://github.com/jorgenschumann/InitialEnterprise/blob/master/Backend/InitialEnterprise.Domain.MainBoundedContext/CurrencyModule/CommandHandler/CurrencyCommandHandler.cs>
[ValidationHandler]:<https://github.com/jorgenschumann/InitialEnterprise/blob/master/Backend/InitialEnterprise.Domain.MainBoundedContext/PersonModule/ValidationHandler/CreatePersonCommandValidationHandler.cs>
[UnitTest]:<https://github.com/jorgenschumann/InitialEnterprise/blob/master/Backend/InitialEnterprise.Domain.MainBoundedContext.Tests/CurrencyModule/CurrencyCommandHanderTests.cs>
[BLAZOR]:<https://github.com/jorgenschumann/InitialEnterprise/tree/master/Frontend/InitialEnterprise.Frontend/InitialEnterprise.Blazor.Frontend>
[WebAssembly]:<https://github.com/jorgenschumann/InitialEnterprise/tree/master/Frontend/InitialEnterprise.Frontend/InitialEnterprise.Blazor.Frontend>








