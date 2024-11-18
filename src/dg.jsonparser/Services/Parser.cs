using dg.jsonparser.Models;

namespace dg.jsonparser.Services;

// public static class Parser
// {
//     /* Thinking that the best way to proceed with the parser for step 2 is to have some sort of dictionary that has a
//     next possible token types when you pass in the current token key, if the next token is not one of those then fail.
//     At the end check that the same amount of close brackets exist as open brackets and fail if not*/
//     
//     public static bool Parse(IEnumerable<Token> jsonTokens)
//     {
//         var tokenList = jsonTokens.ToList();
//         
//         if (tokenList.Count == 0)
//             return false;
//
//         var isValidJson = true;
//
//         var numLeftBrackets = tokenList.Count(t => t.TokenType == TokenType.LBRACE);
//         var numRightBrackets = tokenList.Count(t => t.TokenType == TokenType.RBRACE);
//
//         return numLeftBrackets == numRightBrackets;
//     }
// }

public static class Parser
{
    /*
     * Best way to proceed here (scratch the above!) is to take all of the tokens and recursively go through them.
     * It should start with an object (maybe as I know starting with an array is technically possible) and then it
     * should be a case of calling ParseObject which should then either call ParseArray or Parse again recursively unless
     * it either sees something it doesn't like or exits because it reached the end. I guess it should be creating dynamic
     * objects along the way?
     */

    public static dynamic Parse(IEnumerable<string> tokens)
    {
        return null;
    }
}