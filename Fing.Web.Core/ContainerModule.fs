namespace FingWeb.Core

open Ninject.Modules

open FingWeb.Core
open FingWeb.Core.Controllers

#nowarn "0020"
type ContainerModule() =
    inherit NinjectModule()

    override x.Load() =
        x.Bind<FSTypeDb>().To<FingTypeDb>().WhenInjectedInto<MainController>()
        x.Bind<MainController>().ToSelf()
        x.Bind<DocumentationRepository>().To<SingleFileDocRepo>()
        ()