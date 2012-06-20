namespace FingWeb.Core

open System.Web.Mvc

module ModelBinders =
   type OptionModelBinder() =
      interface IModelBinder with
         member x.BindModel (controllerContext: ControllerContext, bindingContext: ModelBindingContext) : obj =
            None :> obj

