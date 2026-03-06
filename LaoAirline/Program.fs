module Program

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection
open Giraffe
open LaoAirline.Handlers

let routes =
    choose [
        GET >=> route "/" >=> AppHandlers.home
        GET >=> route "/search" >=> AppHandlers.search
        GET >=> route "/profile" >=> AppHandlers.profile
        
        setStatusCode 404 >=> text "Not Found"
    ]

let configureApp (app : IApplicationBuilder) =
    app.UseStaticFiles().UseGiraffe(routes)

let configureServices (services : IServiceCollection) =
    services.AddGiraffe() |> ignore

[<EntryPoint>]
let main args =
    let hostBuilder = Host.CreateDefaultBuilder(args)
    
    hostBuilder.ConfigureWebHostDefaults(fun webHostBuilder ->
        webHostBuilder.Configure(configureApp) |> ignore
        webHostBuilder.ConfigureServices(configureServices) |> ignore
    ) |> ignore

    let app = hostBuilder.Build()
    app.Run()
    0
