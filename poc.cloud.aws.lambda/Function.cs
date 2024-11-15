using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace poc.cloud.aws.lambda;

public sealed class HttpFunction
{
    public async Task<APIGatewayProxyResponse> ExtractNameFromQuerystringAsync
    (
        APIGatewayProxyRequest request,
        ILambdaContext context
    )
    {
        context.Logger.LogLine("C# Lambda HTTP trigger processed a request.");

        // Get the params from querystring
        string name = request.QueryStringParameters != null && request.QueryStringParameters.TryGetValue("name", out var nameParam)
            ? nameParam
            : null;

        // Verify is the param "name" was passed
        if (string.IsNullOrEmpty(name))
        {
            return new APIGatewayProxyResponse
            {
                StatusCode = 400,
                Body = "Please provide a name in the query string with ?name=yourname",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };
        }

        // Generates the message response
        string responseMessage = $"Welcome to AWS Lambda, {name}!";
        return new APIGatewayProxyResponse
        {
            StatusCode = 200,
            Body = responseMessage,
            Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
        };
    }
}
