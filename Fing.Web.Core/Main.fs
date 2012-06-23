namespace FingWeb.Core.Controllers

open System
open System.Web.Mvc
open System.Reflection

open FingWeb.Core

/// Main controller for ASP.NET MVC pages
[<HandleError>]
type MainController(searcher: FSTypeDb) =
  inherit Controller()

  member x.Index(search: SearchInput) =
    x.View()

  member x.Search(search : SearchInput) =
    let fings = Fing.search search.SearchTerm
    
    let results 
      = fings |> Seq.map (fun (x: Fing.Result) -> x)
              |> Seq.map (fun x -> FingWeb.Core.Result(x))
    let vm = SearchViewModel(search.SearchTerm, results)
    
    x.View(vm)
