using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Moq;

namespace poc.cloud.aws.lambda.tests;

public class UnitTest1
{
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

        var loggerMock = new Mock<ILambdaLogger>();
        var contextMock = new Mock<ILambdaContext>();
        contextMock.Setup(c => c.Logger).Returns(loggerMock.Object);

        var function = new HttpFunction();

        // Act
        var response = await function.ExtractNameFromQuerystringAsync(request, contextMock.Object);

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

        var loggerMock = new Mock<ILambdaLogger>();
        var contextMock = new Mock<ILambdaContext>();
        contextMock.Setup(c => c.Logger).Returns(loggerMock.Object);

        var function = new HttpFunction();

        // Act
        var response = await function.ExtractNameFromQuerystringAsync(request, contextMock.Object);

        // Assert
        Assert.NotNull(response);
        Assert.Equal(400, response.StatusCode);
        Assert.Equal("Please provide a name in the query string with ?name=yourname", response.Body);
        Assert.Equal("text/plain", response.Headers["Content-Type"]);
    }
}