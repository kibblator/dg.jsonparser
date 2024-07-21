using dg.jsonparser.Models;

namespace dg.jsonparser.Services;

public static class Parser
{
    /* Thinking that the best way to proceed with the parser for step 2 is to have some sort of dictionary that has a
    next possible token types when you pass in the current token key, if the next token is not one of those then fail.
    At the end check that the same amount of close brackets exist as open brackets and fail if not*/
    
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