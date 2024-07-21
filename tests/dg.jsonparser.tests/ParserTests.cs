using System.IO;
using System.Text;
using dg.jsonparser.Services;
using Xunit;

namespace dg.jsonparser.tests;

public class ParserTests
{
    [Theory]
    [InlineData("step1/invalid.json", false)]
    [InlineData("step1/valid.json", true)]
    public void ValidateStep1_ReturnsCorrectValidationStatus(string testJsonPath, bool expectedValidationResult)
    {
        //Arrange
        var pathToTestJson = $"test_data/{testJsonPath}";
        var jsonText = File.ReadAllText(pathToTestJson, Encoding.UTF8);

        //Act
        var tokens = JsonLexer.Lex(jsonText);
        var result = Parser.Parse(tokens);

        //Assert
        Assert.Equal(expectedValidationResult, result);
    }
    
    [Theory]
    [InlineData("step2/valid.json", true)]
    [InlineData("step2/invalid.json", false)]
    [InlineData("step2/valid2.json", true)]
    [InlineData("step2/invalid2.json", false)]
    public void ValidateStep2_ReturnsCorrectValidationStatus(string testJsonPath, bool expectedValidationResult)
    {
        //Arrange
        var pathToTestJson = $"test_data/{testJsonPath}";
        var jsonText = File.ReadAllText(pathToTestJson, Encoding.UTF8);
    
        //Act
        var tokens = JsonLexer.Lex(jsonText);
        var result = Parser.Parse(tokens);
    
        //Assert
        Assert.Equal(expectedValidationResult, result);
    }
    
    [Theory]
    [InlineData("step3/valid.json", true)]
    [InlineData("step3/invalid.json", false)]
    public void ValidateStep3_ReturnsCorrectValidationStatus(string testJsonPath, bool expectedValidationResult)
    {
        //Arrange
        var pathToTestJson = $"test_data/{testJsonPath}";
        var jsonText = File.ReadAllText(pathToTestJson, Encoding.UTF8);
    
        //Act
        var tokens = JsonLexer.Lex(jsonText);
        var result = Parser.Parse(tokens);
    
        //Assert
        Assert.Equal(expectedValidationResult, result);
    }
    
    [Theory]
    [InlineData("step4/valid.json", true)]
    [InlineData("step4/invalid.json", false)]
    [InlineData("step4/valid2.json", true)]
    public void ValidateStep4_ReturnsCorrectValidationStatus(string testJsonPath, bool expectedValidationResult)
    {
        //Arrange
        var pathToTestJson = $"test_data/{testJsonPath}";
        var jsonText = File.ReadAllText(pathToTestJson, Encoding.UTF8);
    
        //Act
        var tokens = JsonLexer.Lex(jsonText);
        var result = Parser.Parse(tokens);
    
        //Assert
        Assert.Equal(expectedValidationResult, result);
    }
}