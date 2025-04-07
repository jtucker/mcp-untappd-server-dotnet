# Untappd MCP Server using Azure Functions

A version of the Untappd MCP Server using [Azure Functions and Server Sent Events](https://github.com/Azure-Samples/remote-mcp-functions-dotnet/tree/main). 

Blog post coming soon.
### Configure Claude Desktop

Since Claude Desktop does not currently support SSE configuration you need to include a middle man component to make the calls to the SSE server. 

Edit your `claude_desktop_config.json`:
```json
{
  "mcpServers": {
    "untappddotnet": {
      "command": "npx",
      "args": [
        "mcp-remote",
        "http://localhost:7071/runtime/webhooks/mcp/sse"
      ]
    }
  }
}
```

## Building

### Prerequisites:

- dotnet 9.0
- Docker Desktop


### local.settings.json Setup

```json
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "<CONNECTION_STRING>",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "Untappd:ClientId": "",
        "Untappd:ClientSecret": ""
    }
}
```
