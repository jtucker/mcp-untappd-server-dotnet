namespace McpUntappdAzFunc.Functions

open Microsoft.Extensions.Logging
open Microsoft.Extensions.Options
open Microsoft.Azure.Functions.Worker
open Microsoft.Azure.Functions.Worker.Extensions.Mcp
open McpUntappdAzFunc
open FsHttp
open System.Net
open System.Threading.Tasks

type BeerTools (logger: ILogger<BeerTools>, untappedOptions: IOptions<UntappdOptions>) =

    let untappdSettings = untappedOptions.Value

    [<Function(GET_BEER_INFO_FUNC_NAME)>]
    member _.GetBeerInfo(
        [<McpToolTrigger(GET_BEER_INFO_TOOL_NAME, GET_BEER_INFO_DESCRIPTION)>] toolContent: ToolInvocationContext,
        [<McpToolProperty("beer_id", "string", "The ID of the beer")>] beerId: string) =        
        task {
            logger.LogInformation("Getting Beer information for Beer Id {BeerId}", beerId)

            let! resp =
                http {
                    GET $"{UNTAPPD_API_URI}/beer/info/{beerId}"
                    query [
                        "client_id", untappdSettings.ClientId
                        "client_secret", untappdSettings.ClientSecret 
                    ]
                }
                |> Request.sendTAsync
            
            return!
                match resp.statusCode with
                | HttpStatusCode.OK -> 
                    resp.content.ReadAsStringAsync()
                | _ -> Task.FromResult "Error retrieving the beer from Untappd"
        }

    [<Function(SEARCH_BEER_FUNC_NAME)>]
    member _.SearchForBeer(
        [<McpToolTrigger(SEARCH_BEER_TOOL_NAME, SEARCH_BEER_DESCRIPTION)>] toolContent: ToolInvocationContext,
        [<McpToolProperty("query", "string", "The brewery and/or beer to search for.")>] untappdQuery: string) =
        task {
            logger.LogInformation("Search for {UntappdQuery}", query)

            let! resp =
                http {
                    GET $"{UNTAPPD_API_URI}/search/beer"
                    query [
                        "client_id", untappdSettings.ClientId
                        "client_secret", untappdSettings.ClientSecret
                        "q", untappdQuery
                    ]
                }
                |> Request.sendTAsync
            
            return!
                match resp.statusCode with
                | HttpStatusCode.OK ->
                    resp.content.ReadAsStringAsync()
                | _ -> Task.FromResult "Error searching Untappd"
        }