using System.IO;
using System.Text;
using Xunit;

namespace dg.jsonparser.tests;

public class JsonValidatorServiceTests
{
    [Theory]
    [InlineData("step1/invalid.json", false)]
    [InlineData("step1/valid.json", true)]
    [InlineData("step2/valid.json", true)]
    [InlineData("step2/invalid.json", false)]
    [InlineData("step2/valid2.json", true)]
    [InlineData("step2/invalid2.json", false)]
    [InlineData("step3/valid.json", true)]
    [InlineData("step3/invalid.json", false)]
    [InlineData("step4/valid.json", true)]
    [InlineData("step4/invalid.json", false)]
    [InlineData("step4/valid2.json", true)]
    public void Validate_ReturnsCorrectValidationStatus(string testJsonPath, bool expectedValidationResult)
    {
        //Arrange
        var pathToTestJson = $"test_data/{testJsonPath}";
        var jsonText = File.ReadAllText(pathToTestJson, Encoding.UTF8);

        //Act
        var result = JsonValidatorService.Validate(jsonText);

        //Assert
        Assert.Equal(expectedValidationResult, result);
    }
}