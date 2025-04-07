namespace McpUntappdAzFunc.Functions


open Microsoft.Azure.Functions.Worker
open Microsoft.Extensions.Logging
open Microsoft.Azure.Functions.Worker.Extensions.Mcp
open McpUntappdAzFunc

type BeerTools (logger: ILogger<BeerTools>, untappedOptions: UntappdOptions) =

    [<Function(GET_BEER_INFO_FUNC_NAME)>]
    member _.GetBeerInfo(
        [<McpToolTrigger(GET_BEER_INFO_TOOL_NAME, GET_BEER_INFO_DESCRIPTION)>] toolContent: ToolInvocationContext,
        [<McpToolProperty("beer_id", "string", "The ID of the beer")>] beerId: string) =        
        "hello"