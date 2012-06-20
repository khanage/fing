namespace FingWeb.Core

type SearchInput () =
    let mutable search = System.String.Empty

    member x.SearchTerm 
        with get () = search
        and  set v  = search <- v

type Result(result: Fing.Result) =
   member x.FriendlyName
      with get () = result.ent.DisplayName + "." + result.mem.DisplayName
   member x.TypeCode
      with get () = Types.format result.typ
   member x.DocString
      with get () = "Unknown"

type SearchViewModel (searchTerm : string, fingResults : Result seq) =
    member x.SearchTerm 
        with get () = searchTerm
    member x.Results
        with get () = fingResults