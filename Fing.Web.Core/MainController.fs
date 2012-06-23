namespace FingWeb.Core.Controllers

open System
open System.Web.Mvc
open System.Reflection

open FingWeb.Core

/// Main controller for ASP.NET MVC pages
[<HandleError>]
type MainController(searcher: FSTypeDb) =
  inherit Controller()

  let buildVM (search : SearchInput) =
    let fings = Fing.search search.SearchTerm
    
    let results 
      = fings |> Seq.map (fun (x: Fing.Result) -> x)
              |> Seq.map (fun x -> FingWeb.Core.Result(x))
    SearchViewModel(search.SearchTerm, results)

  member x.Index() =
    x.View()

  member x.Search(search : SearchInput) =
    let vm = buildVM search
    
    x.View(vm)
