namespace dg.jsonparser.Models;

public static class TokenType
{
    public const char LBRACKET = '[';
    public const char RBRACKET = ']';
    public const char COMMA = ',';
    public const char COLON = ':';
    public const char LBRACE = '{';
    public const char RBRACE = '}';
    public const char QUOTE = '"';
    public static char[] WHITESPACE = { ' ', '\t', '\n', '\r' };
}