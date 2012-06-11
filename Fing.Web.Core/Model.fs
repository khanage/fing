namespace Fing.Web.Core

type SearchInput () =
    let mutable search = System.String.Empty

    member x.SearchTerm 
        with get () = search
        and  set v  = search <- v

type SearchViewModel (searchTerm : string) =
    member x.SearchTerm 
        with get () = searchTerm