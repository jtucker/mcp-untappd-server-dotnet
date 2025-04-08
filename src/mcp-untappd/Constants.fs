[<AutoOpen>]
module McpUntappdAzFunc.Constants

[<Literal>]
let GET_BEER_INFO_FUNC_NAME = "GetBeerInfo"
[<Literal>]
let GET_BEER_INFO_TOOL_NAME = "get_beer_info"
[<Literal>]
let GET_BEER_INFO_DESCRIPTION = "Get information about a specific beer by its ID"
[<Literal>]
let UNTAPPD_API_URI = "https://api.untappd.com/v4"

[<CLIMutable>]
type UntappdOptions = 
    {
        ClientId: string
        ClientSecret: string
    }