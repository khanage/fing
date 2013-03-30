namespace FingWeb.Core

open System
open System.Collections.Generic
open System.Linq
open System.Web
open System.Web.Mvc
open System.Web.Routing

open Ninject
open Ninject.Web.Common
open Ninject.Web.Mvc


/// F# record that can be used for creating route information
type Route = 
  { controller : string
    action : string }

/// Represents the application and registers routes
type Global() =
  inherit NinjectHttpApplication() 

  static member RegisterRoutes(routes:RouteCollection) =
    routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
    routes.MapRoute
      ( "Default"
      , "{controller}/{action}"
      , { controller = "Main"
        ; action     = "Index" })

  override x.OnApplicationStarted() =
    base.OnApplicationStarted()

    AreaRegistration.RegisterAllAreas()

    GlobalFilters.Filters.Add(HandleErrorAttribute())
    Global.RegisterRoutes(RouteTable.Routes) |> ignore
    
    ()

  override x.CreateKernel() =
    let standardKernel = new StandardKernel(new ContainerModule());

    DependencyResolver.SetResolver(new NinjectDependencyResolver(standardKernel))
    standardKernel :> IKernel
