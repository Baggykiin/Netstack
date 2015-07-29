using Netstack.Language.Literals;
using System.Text.RegularExpressions;

namespace Netstack.Language
{
    static class SpecialAliasMap
    {
        private static readonly Regex integerRegex = new Regex(@"^[0-9]*$", RegexOptions.Compiled);
        private static readonly Regex stringRegex = new Regex(@"^\"".*\""$", RegexOptions.Compiled);
        private static readonly Regex booleanRegex = new Regex(@"^(True|False)$", RegexOptions.Compiled);
        private static readonly Regex labelRegex = new Regex(@"^\.[a-zA-Z][a-zA-Z0-9_\-]*$");

        internal static bool TryParse(string token, out Function result)
        {
            if (integerRegex.IsMatch(token))
            {
                result = ParseInteger(token);
                return true;
            }
            else if (stringRegex.IsMatch(token)) {
                result = ParseString(token);
                return true;
            }
            else if (booleanRegex.IsMatch(token))
            {
                result = ParseBoolean(token);
                return true;
            }
            else if (labelRegex.IsMatch(token))
            {
                result = ParseLabel(token);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }
        private static IntegerLiteral ParseInteger(string literal)
        {
            return new IntegerLiteral(int.Parse(literal));
        }
        private static StringLiteral ParseString(string literal)
        {
            return new StringLiteral(literal.Substring(1,literal.Length-2).Replace(@"\""", @"\"));
        }
        private static BooleanLiteral ParseBoolean(string literal)
        {
            return new BooleanLiteral(bool.Parse(literal));
        }
        private static FunctionLabel ParseLabel(string literal)
        {
            return new FunctionLabel(literal.Substring(1));
        }
    }
}
