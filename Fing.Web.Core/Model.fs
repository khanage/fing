namespace FingWeb.Core

open Fing

type SearchInput () =
    let mutable search = System.String.Empty

    member x.SearchTerm 
        with get () = search
        and  set v  = search <- v

type SearchViewModel (searchTerm : string, fingResults : Fing.Result seq) =
    member x.SearchTerm 
        with get () = searchTerm
    member x.Results
        with get () = fingResults