namespace FingWeb.Core

open Fing

open System
open System.IO
open System.Xml.Linq

module AbstractDocumentation =
  let fromXElem (elem: XElement): AbstractDocumentation =
    elem.Elements() |> Seq.map (fun (node: XElement) -> (node.Name.LocalName, node.Value))

type DocumentationRepository =
  abstract member FindDoc: Fing.Result -> XElement option

type SingleFileDocRepo() =
  static member private filePath = @"C:\Program Files (x86)\Reference Assemblies\Microsoft\FSharp\2.0\Runtime\v4.0\FSharp.Core.xml"
  static member private doc = 
    let notEmptyElem (elem: XElement) = elem.Attribute(xname "name").Value <> ""

    XDocument.Load(SingleFileDocRepo.filePath).Descendants(xname "member") 
      |> Seq.filter notEmptyElem 
      |> Seq.toList

  interface DocumentationRepository with
    member x.FindDoc res = 
      let matcher (result: Fing.Result) (elem: XElement) = elem.Attribute(xname "name").Value = result.mem.XmlDocSig
      let docString (elem: XElement) = elem

      SingleFileDocRepo.doc |> List.tryFind (matcher res)
