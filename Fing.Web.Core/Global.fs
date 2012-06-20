namespace FingWeb.Core

open System
open System.Collections.Generic
open System.Linq
open System.Web
open System.Web.Mvc
open System.Web.Routing

open FingWeb.Core

/// F# record that can be used for creating route information
type Route = 
  { controller : string
    action : string }

/// Represents the application and registers routes
type Global() =
  inherit System.Web.HttpApplication() 

  static member RegisterRoutes(routes:RouteCollection) =
    routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
    routes.MapRoute
      ( "Default"
      , "{controller}/{action}"
      , { controller = "Main"
        ; action = "Index" })

  member x.Start() =
    AreaRegistration.RegisterAllAreas()
    Global.RegisterRoutes(RouteTable.Routes)