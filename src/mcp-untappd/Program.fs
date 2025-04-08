module McpUntappdAzFunc.Program

open System
open Microsoft.Azure.Functions.Worker.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection

let args = Environment.GetCommandLineArgs()

let builder =    
    FunctionsApplication
        .CreateBuilder(args)
        .ConfigureFunctionsWebApplication()

// Setup the MCP SDK Metadata
builder.EnableMcpToolMetadata() |> ignore

// add some options
builder
    .Services
    .Configure<UntappdOptions>(builder.Configuration.GetSection "Untappd")
    |> ignore
    

// Build and run the app
builder
    .Build()
    .RunAsync()
|> Async.AwaitTask
|> Async.RunSynchronously
