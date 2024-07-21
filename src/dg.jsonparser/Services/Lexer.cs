using System.Text.RegularExpressions;

public class Token
{
    public string TokenType { get; set; }
    public string TokenValue { get; set; }
}

public static class TokenType
{
    public const string LBRACKET = "LEFT_BRACKET";
    public const string RBRACKET = "RIGHT_BRACKET";
}

public class JsonLexer
{
    private Dictionary<string, string> _tokenSpec = new()
    {
        { TokenType.LBRACKET, @"\{" },
        { TokenType.RBRACKET, @"\}" }
    };

    public IEnumerable<Token> Lex(string input)
    {
        var tokenRegex = string.Join("|", _tokenSpec.Select(t => $"(?<{t.Key}>{t.Value})"));
        foreach (Match match in Regex.Matches(input, tokenRegex))
        {
            foreach (var key in _tokenSpec.Keys)
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