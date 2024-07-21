using System.Linq;
using dg.jsonparser.Models;
using dg.jsonparser.Services;
using Xunit;

namespace dg.jsonparser.tests;

public class LexerTests
{
    [Theory]
    [InlineData("{vinecoiec}}", 1, 2)]
    public void GivenAString_ReturnsCorrectBrackets(string input, int expectedLeftBrackets, int expectedRightBrackets)
    {
        // Act
        var result = JsonLexer.Lex(input).ToList();

        // Assert
        Assert.Equal(expectedLeftBrackets, result.Count(r => r.TokenType == TokenType.LBRACKET));
        Assert.Equal(expectedRightBrackets, result.Count(r => r.TokenType == TokenType.RBRACKET));
    }

    [Fact]
    public void GivenAString_DetectsColonsAndStrings()
    {
        // Arrange
        var input = "{\"test\":\"test\", \"test2\":\"test2\"}";
        
        // Act 
        var result = JsonLexer.Lex(input).ToList();
        
        // Assert
        Assert.Equal(2, result.Count(r => r.TokenType == TokenType.COLON));
        Assert.Equal(4, result.Count(r => r.TokenType == TokenType.STRING));
    }
    
    [Fact]
    public void GivenAString_DetectsCommas()
    {
        // Arrange
        var input = "{\"test\":\"test\", \"test2\":\"test2\"},,,";
        
        // Act 
        var result = JsonLexer.Lex(input).ToList();
        
        // Assert
        Assert.Equal(4, result.Count(r => r.TokenType == TokenType.COMMA));
    }
}