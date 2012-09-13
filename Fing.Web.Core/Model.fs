namespace FingWeb.Core

open Fing

open System.Xml.Linq

type SearchInput () =
    let mutable search = System.String.Empty

    member x.SearchTerm 
        with get () = search
        and  set v  = search <- v

type Result(result: Fing.Result) =
  let fromAbstractDoc (doc: AbstractDocumentation) =
    let elemMaker (name, inner) = XElement(xname "div", XAttribute(xname "data-doc", name), inner)
    let elems = doc |> Seq.map elemMaker
    System.String.Join("", elems)

  member x.FriendlyName
    with get () = result.ent.DisplayName + "." + result.mem.DisplayName
  member x.TypeCode
    with get () = Types.format result.typ
  member x.DocString
    with get () = result.doc |> Option.maybe Seq.empty

type SearchViewModel (searchTerm : string, fingResults : Result seq) =
    member x.SearchTerm 
        with get () = searchTerm
    member x.Results
        with get () = fingResults