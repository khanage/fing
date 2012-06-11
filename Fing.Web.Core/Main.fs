namespace FingWeb.Core.Controllers

open System
open System.Web.Mvc
open System.Reflection

open FingWeb.Core

/// Main controller for ASP.NET MVC pages
[<HandleError>]
type MainController() =
  inherit Controller()

  member x.Index() =
    x.View()

  member x.Search(search : SearchInput) =
    let results = Fing.typeFind search.SearchTerm
    let vm = SearchViewModel(search.SearchTerm, results)

    x.View(vm)
