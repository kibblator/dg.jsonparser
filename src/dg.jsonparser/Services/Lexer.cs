namespace dg.jsonparser.Services;

public static class JsonLexer
{
    public static IEnumerable<string> Lex(string input)
    {
        /* The plan is to loop through the string and parse whilst there's still characters left.
        Have individual methods for parsing string and number and another method for parsing bool.
        Ignore any whitespace
        If its just things like comma etc that are single char tokens, just add them to the list
        Return all tokens at the end of the parser in a string array (has to be string since words are multi character
        as are bools and integers
        */
        var tokens = new List<string>();
        
        while (input.Length > 0)
        {
            if (input.StartsWith("\""))
            {
                var parsedResult = ParseString(input);
                input = parsedResult.remainingInput;
                tokens.Add(parsedResult.token);
            }
            else if (char.IsDigit(input[0]))
            {
                var parsedResult = ParseNumber(input);
                input = parsedResult.remainingInput;
                tokens.Add(parsedResult.token);
            }
            else if (input.StartsWith("true") || input.StartsWith("false"))
            {
                var parsedResult = ParseBoolean(input);
                input = parsedResult.remainingInput;
                tokens.Add(parsedResult.token);
            }
            else
            {
                throw new Exception("Blah");
            }
        }

        return tokens;
    }

    private static (string remainingInput, string token) ParseBoolean(string input)
    {
        throw new NotImplementedException();
    }

    private static (string remainingInput, string token) ParseNumber(string input)
    {
        throw new NotImplementedException();
    }

    private static (string remainingInput, string token) ParseString(string input)
    {
        throw new NotImplementedException();
    }
}