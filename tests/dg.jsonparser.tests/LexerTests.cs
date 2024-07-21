using System.Linq;
using Xunit;

namespace dg.jsonparser.tests;

public class LexerTests
{
    [Theory]
    [InlineData("{vinecoiec}}", 1, 2)]
    public void GivenAString_ReturnsCorrectTokens(string input, int expectedLeftBrackets, int expectedRightBrackets)
    {
        // Arrange
        var lexer = new JsonLexer();
        
        // Act
        var result = lexer.Lex(input).ToList();

        // Assert
        Assert.Equal(expectedLeftBrackets, result.Count(r => r.TokenType == TokenType.LBRACKET));
        Assert.Equal(expectedRightBrackets, result.Count(r => r.TokenType == TokenType.RBRACKET));
    }
}