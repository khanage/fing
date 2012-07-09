namespace FingWeb.Core.Controllers

open System
open System.Web.Mvc
open System.Reflection
open System.Xml.Linq
open System.Diagnostics

open FingWeb.Core

[<AutoOpen>]
module XmlHelpers = 
  let xname x = XName.op_Implicit x

/// Main controller for ASP.NET MVC pages
[<HandleError>]
type MainController(searcher: FSTypeDb) =
  inherit Controller()

  let filePath = @"C:\Program Files (x86)\Reference Assemblies\Microsoft\FSharp\2.0\Runtime\v4.0\FSharp.Core.xml"
  let doc = XDocument.Load(filePath).Descendants(xname "member") |> Seq.filter (fun elem -> elem.Attribute(xname "name").Value <> "") |> Seq.toList

  let buildVM (search : SearchInput) =
    let fings = Fing.search search.SearchTerm
    
    let matcher (result: Fing.Result) (elem: XElement) = elem.Attribute(xname "name").Value = result.mem.XmlDocSig
    let docString (elem: XElement) = elem.Value

    let findDoc name = doc |> List.tryFind (matcher name) |> Option.map docString

    let results 
      = fings |> Seq.map (fun (x: Fing.Result) -> x.doc <- findDoc x; x)
              |> Seq.map (fun x -> FingWeb.Core.Result(x))
    SearchViewModel(search.SearchTerm, results)

  member x.Index() =
    x.View()

  member x.Search(search : SearchInput) =
    let vm = buildVM search
    
    x.View(vm)
