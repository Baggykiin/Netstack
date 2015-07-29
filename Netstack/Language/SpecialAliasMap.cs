using Netstack.Language.Literals;
using System.Text.RegularExpressions;

namespace Netstack.Language
{
    static class SpecialAliasMap
    {
        private static readonly Regex integerRegex = new Regex("^[0-9]*$", RegexOptions.Compiled);
        private static readonly Regex stringRegex = new Regex(@"^\"".*\""$", RegexOptions.Compiled);

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
    }
}
