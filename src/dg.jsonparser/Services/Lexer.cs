using System.Text.RegularExpressions;
using dg.jsonparser.Models;

namespace dg.jsonparser.Services;

public static class JsonLexer
{
    private static readonly Dictionary<string, string> TokenSpec = new()
    {
        { TokenType.LBRACKET, @"\{" },
        { TokenType.RBRACKET, @"\}" },
        { TokenType.STRING, @"""(.*?)"""},
        { TokenType.COLON, ":"},
        { TokenType.COMMA, ","}
    };

    public static IEnumerable<Token> Lex(string input)
    {
        var tokenRegex = string.Join("|", TokenSpec.Select(t => $"(?<{t.Key}>{t.Value})"));
        foreach (Match match in Regex.Matches(input, tokenRegex))
        {
            foreach (var key in TokenSpec.Keys)
            {
                if (match.Groups[key].Success)
                {
                    yield return new Token
                    {
                        TokenType = key,
                        TokenValue = match.Value
                    };
                }
            }
        }
    }
}