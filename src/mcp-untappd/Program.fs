module McpUntappdAzFunc.Program

open Microsoft.Azure.Functions.Worker.Builder
open Microsoft.Extensions.Hosting

let args = System.Environment.GetCommandLineArgs()

let builder =    
    FunctionsApplication
        .CreateBuilder(args)                
        .ConfigureFunctionsWebApplication()

// Setup the MCP SDK Metadata
builder.EnableMcpToolMetadata() |> ignore
builder
    .Build()
    .RunAsync()
|> Async.AwaitTask
|> Async.RunSynchronously
