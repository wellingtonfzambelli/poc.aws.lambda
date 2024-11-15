using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Moq;

namespace poc.cloud.aws.lambda.tests;

public sealed class HttpFunctionTets
{
    private readonly Mock<ILambdaContext> _contextMock;
    private readonly Mock<ILambdaLogger> _loggerMock;

    public HttpFunctionTets()
    {
        _contextMock = new Mock<ILambdaContext>();
        _loggerMock = new Mock<ILambdaLogger>();
    }

    [Fact]
    public async Task ExtractNameFromQuerystringAsync_ReturnsSuccessResponse_WhenNameProvided()
    {
        // Arrange
        var request = new APIGatewayProxyRequest
        {
            QueryStringParameters = new Dictionary<string, string>
            {
                { "name", "John" }
            }
        };

        
        _contextMock.Setup(c => c.Logger).Returns(_loggerMock.Object);

        var function = new HttpFunction();

        // Act
        var response = await function.ExtractNameFromQuerystringAsync(request, _contextMock.Object);

        // Assert
        Assert.NotNull(response);
        Assert.Equal(200, response.StatusCode);
        Assert.Equal("Welcome to AWS Lambda, John!", response.Body);
        Assert.Equal("text/plain", response.Headers["Content-Type"]);
    }

    [Fact]
    public async Task ExtractNameFromQuerystringAsync_ReturnsBadRequest_WhenNameIsMissing()
    {
        // Arrange
        var request = new APIGatewayProxyRequest
        {
            QueryStringParameters = null // No parameters
        };

        _contextMock.Setup(c => c.Logger).Returns(_loggerMock.Object);

        var function = new HttpFunction();

        // Act
        var response = await function.ExtractNameFromQuerystringAsync(request, _contextMock.Object);

        // Assert
        Assert.NotNull(response);
        Assert.Equal(400, response.StatusCode);
        Assert.Equal("Please provide a name in the query string with ?name=yourname", response.Body);
        Assert.Equal("text/plain", response.Headers["Content-Type"]);
    }
}