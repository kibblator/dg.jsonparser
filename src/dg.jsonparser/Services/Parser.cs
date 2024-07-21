namespace dg.jsonparser.Services;

public static class Parser
{
    public static bool Parse(IEnumerable<Token> jsonTokens)
    {
        var tokenList = jsonTokens.ToList();
        
        if (tokenList.Count == 0)
            return false;

        var isValidJson = true;

        var numLeftBrackets = tokenList.Count(t => t.TokenType == TokenType.LBRACKET);
        var numRightBrackets = tokenList.Count(t => t.TokenType == TokenType.RBRACKET);

        return numLeftBrackets == numRightBrackets;
    }
}