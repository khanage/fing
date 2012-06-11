namespace Fing.Web.Core.Controllers

open System
open System.Web.Mvc
open System.Reflection

open Fing.Web.Core

/// Main controller for ASP.NET MVC pages
[<HandleError>]
type MainController() =
  inherit Controller()

  member x.Index() =
    x.View()

  member x.Search(search : SearchInput) =
    let vm = SearchViewModel(search.SearchTerm)
    x.View(vm)
