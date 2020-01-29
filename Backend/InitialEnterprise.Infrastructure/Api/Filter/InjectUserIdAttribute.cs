//using Microsoft.AspNetCore.Mvc.Filters;
//using System;
//using System.Linq;
//using InitialEnterprise.Shared.Dtos;

//namespace InitialEnterprise.Infrastructure.Api.Filter
//{      
//    public class InjectUserIdAttribute : ActionFilterAttribute
//    {

    //todo

//        public override void OnActionExecuting(ActionExecutingContext context)
//        {
//            foreach (var argument in context.ActionArguments.Values.Where(v => v is IDataTransferObject))
//            {
//                var model = argument as IDataTransferObject;
//                var controller = context.Controller as BaseController;
//                model.UserId = Guid.Parse(controller.User.Claims.FirstOrDefault(c => c.Type == "Id").Value);              
//            }
//        }
//    }
//}


