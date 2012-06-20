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
    let fings = Fing.typeFind search.SearchTerm
    let results = fings |> Seq.map (fun x -> FingWeb.Core.Result(x)) 
    let vm = SearchViewModel(search.SearchTerm, results)
    
    x.View(vm)
