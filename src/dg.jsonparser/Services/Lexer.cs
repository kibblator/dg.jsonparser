using System.Text.RegularExpressions;

public class Token
{
    public string TokenType { get; set; }
    public string TokenValue { get; set; }
}

public static class TokenType
{
    public const string COLON = "COLON";
    public const string STRING = "STRING";
    public const string LBRACKET = "LEFT_BRACKET";
    public const string RBRACKET = "RIGHT_BRACKET";
}

public static class JsonLexer
{
    private static readonly Dictionary<string, string> TokenSpec = new()
    {
        { TokenType.LBRACKET, @"\{" },
        { TokenType.RBRACKET, @"\}" },
        { TokenType.STRING, @"""(.*?)"""},
        { TokenType.COLON, ":"}
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