namespace FingWeb.Core

open Ninject.Modules

open FingWeb.Core.Controllers

type ContainerModule() =
    inherit NinjectModule()

    override x.Load() =
        x.Bind<FSTypeDb>().To<FingTypeDb>().WhenInjectedInto<MainController>() |> ignore
        x.Bind<MainController>().ToSelf() |> ignore
        ()