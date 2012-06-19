namespace FingWeb.Core

type FSTypeDb =
    abstract member Search: string -> Fing.Result seq

type FingTypeDb() =
    interface FSTypeDb with
        member x.Search(searchTerm : string) : Fing.Result seq =
            if System.String.IsNullOrWhiteSpace(searchTerm) 
                then Seq.empty
                else Fing.typeFind(searchTerm)

