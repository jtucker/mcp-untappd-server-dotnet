[<AutoOpen>]
module McpUntappdAzFunc.Constants

[<Literal>]
let GET_BEER_INFO_FUNC_NAME = "GetBeerInfo"
[<Literal>]
let GET_BEER_INFO_TOOL_NAME = "get_beer_info"
[<Literal>]
let GET_BEER_INFO_DESCRIPTION = "Get information about a specific beer by its ID"


[<CLIMutable>]
type UntappdOptions = 
    {
        ClientId: string
        ClientSecret: string
    }