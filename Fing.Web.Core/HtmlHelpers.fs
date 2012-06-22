namespace FingWeb.Core

open System.Web.Mvc

[<System.Runtime.CompilerServices.Extension>]
module HtmlHelpers =   
    [<System.Runtime.CompilerServices.Extension>]   
    let OptionalContent<'a,'m>(helper: 'm HtmlHelper, opt : 'a option, def: 'a) 
      = if Option.isSome opt then opt.Value else def            

