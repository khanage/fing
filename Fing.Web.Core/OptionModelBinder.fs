namespace FingWeb.Core

open System.Web.Mvc

module ModelBinders =
   type OptionModelBinder() =
      interface IModelBinder with
         member x.BindModel (controllerContext: ControllerContext, bindingContext: ModelBindingContext) : obj =
            None :> obj

   type AwesomeModelBinder() =
      inherit DefaultModelBinder()

      override x.BindModel (controllerContext: ControllerContext, bindingContext: ModelBindingContext): obj =
         
         base.BindModel(controllerContext, bindingContext)

