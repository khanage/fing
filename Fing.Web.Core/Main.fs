namespace FingWeb.Core.Controllers

open System
open System.Web.Mvc
open System.Reflection

open FingWeb.Core

/// Main controller for ASP.NET MVC pages
[<HandleError>]
type MainController(searcher: FSTypeDb) =
  inherit Controller()

  //new() = MainController(FingTypeDb())

  member x.Index(search: SearchInput) =
    let results = searcher.Search(search.SearchTerm)

    let vm = SearchViewModel(search.SearchTerm, results)

    x.View(vm)