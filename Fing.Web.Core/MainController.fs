namespace FingWeb.Core.Controllers

open System
open System.Web.Mvc
open System.Reflection
open System.Xml.Linq
open System.Diagnostics

open FingWeb.Core

/// Main controller for ASP.NET MVC pages
[<HandleError>]
type MainController(searcher: FSTypeDb, docRepo: DocumentationRepository) =
  inherit Controller()


  member private x.buildVM (search : SearchInput) =
    let fings = Fing.search search.SearchTerm

    let setDocs (result: Fing.Result) =
      let doc = docRepo.FindDoc result |> Option.map AbstractDocumentation.fromXElem
      result.doc <- doc
      result

    let results 
      = fings |> Seq.map setDocs
              |> Seq.map (fun x -> FingWeb.Core.Result(x))
    SearchViewModel(search.SearchTerm, results)

  member x.Index() =
    x.View()

  member x.Search(search : SearchInput) =
    let vm = x.buildVM search
    
    x.View(vm)
