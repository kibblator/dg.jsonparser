using System.Text.RegularExpressions;
using dg.jsonparser.Models;

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

        return null;
    }
}