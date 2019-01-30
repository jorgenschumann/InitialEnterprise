# InitialEnterprise
Initial Enterprise Architecture for a .net core based business critical backend softwaresystem 

### Concepts
* [IntegrationTDD] for RESTApi with TestServer
* [SEEING] for InMemory Database & Testfixtures
* [CQRS] Infrastructure with Dispatcher for Commands & Queries
* [DDD] Infrastructure 
* [QueryHandler] to handle Queries
* [CommandHandler] to handle Commands CurrencyCommandHandler>
* [ValidationHandler] to validate Domain Commands
* [DDDApplication] Layer for the Domain orchestration, Command dispachting & mapping
* [JWTTOKENBUILDER] with JwtAuthentication & Claims 
* [CLEANREST]  


Recources

Domain-Driven Design: Tackling Complexity in the Heart of Software

https://vaughnvernon.co/

https://martinfowler.com/

https://enterprisecraftsmanship.com/

https://github.com/vkhorikov/SpecificationPattern/tree/master/SpecificationPattern


[IntegrationTDD]: <https://github.com/jorgenschumann/InitialEnterprise/tree/master/Backend/InitialEnterprise.Domain.MainBoundedContext.Api.Tests/ApiServices> 
[CQRS]: <https://github.com/jorgenschumann/InitialEnterprise/tree/master/Backend/InitialEnterprise.Infrastructure/CQRS>
[DDD]: <https://github.com/jorgenschumann/InitialEnterprise/tree/master/Backend/InitialEnterprise.Infrastructure/DDD>
[SEEING]: <https://github.com/jorgenschumann/InitialEnterprise/tree/master/Backend/InitialEnterprise.DataSeeding>
[JWTTOKENBUILDER]: <https://github.com/jorgenschumann/InitialEnterprise/blob/master/Backend/InitialEnterprise.Domain.MainBoundedContext/UserModule/Services/JwtSecurityTokenBuilder.cs>
[CLEANREST]: <https://github.com/jorgenschumann/InitialEnterprise/blob/master/Backend/InitialEnterprise.Domain.MainBoundedContext.Api/Controller/CurrencyController.cs>
[DDDApplication]:<https://github.com/jorgenschumann/InitialEnterprise/blob/master/Backend/InitialEnterprise.Domain.MainBoundedContext.Api/Application/CurrencyApplication/CurrencyApplication.cs>
[QueryHandler]:<https://github.com/jorgenschumann/InitialEnterprise/blob/master/Backend/InitialEnterprise.Domain.MainBoundedContext/CurrencyModule/QueryHandler/QueryCurrencyHandlerAsync.cs>
[CommandHandler]:<https://github.com/jorgenschumann/InitialEnterprise/blob/master/Backend/InitialEnterprise.Domain.MainBoundedContext/CurrencyModule/CommandHandler/CurrencyCommandHandler.cs>
[ValidationHandler]:<https://github.com/jorgenschumann/InitialEnterprise/blob/master/Backend/InitialEnterprise.Domain.MainBoundedContext/PersonModule/ValidationHandler/CreatePersonCommandValidationHandler.cs>









