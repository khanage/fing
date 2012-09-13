namespace FingWeb.Core

[<AutoOpen>]
module XmlHelpers = 
  open System.Xml.Linq

  let xname x = XName.op_Implicit x

module Option =
  let maybe (a: 'a) (ma : 'a option): 'a =
    if Option.isSome ma then ma.Value else a
