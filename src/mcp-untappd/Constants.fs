[<AutoOpen>]
module McpUntappdAzFunc.Constants

[<Literal>]
let GET_BEER_INFO_FUNC_NAME = "GetBeerInfo"
[<Literal>]
let GET_BEER_INFO_TOOL_NAME = "get_beer_info"
[<Literal>]
let GET_BEER_INFO_DESCRIPTION = "Get information about a specific beer from untappd by its ID"
[<Literal>]
let SEARCH_BEER_FUNC_NAME = "SearchForBeer"
[<Literal>]
let SEARCH_BEER_TOOL_NAME = "search_beer"
[<Literal>]
let SEARCH_BEER_DESCRIPTION = "Search untappd for beers by the name. The best way to search is always 'Brewery Name + Beer Name', such as 'Dogfish 60 Minute'"

[<Literal>]
let UNTAPPD_API_URI = "https://api.untappd.com/v4"

[<CLIMutable>]
type UntappdOptions = 
    {
        ClientId: string
        ClientSecret: string
    }