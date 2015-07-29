using Netstack.Language.Framework.Control;
using Netstack.Language.Framework.IO;
using Netstack.Language.Framework.Math;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Netstack.Language
{
    class Parser
    {
        private static readonly Regex validIdentifiers = new Regex(@"^[a-zA-Z][a-zA-Z0-9_\-]*$");

        private Dictionary<string, Function> aliasMap = new Dictionary<string, Function>
        {
            { "+", new Add() },
            { "=", new Equals() },
            { "if", new If() },
            { "exec", new Exec() },
            { "read", new Read() }
        };

        private List<string> Lex(string inputString)
        {
            List<string> lexemes = new List<string>();
            List<char> nextLexeme = new List<char>();
            bool inQuotes = false;
            bool control = false;
            foreach (var c in inputString)
            {
                // First check if we're in the middle of an escape sequence
                if (control)
                {
                    nextLexeme.Add(ProcessEscapeSequence(c));
                    control = false;
                }
                // Now check if we're starting or ending a string literal
                else if (c == '"')
                {
                    nextLexeme.Add(c);
                    inQuotes = !inQuotes;
                }
                // Now check if we're starting an escape sequence
                else if (c == '\\')
                {
                    control = true;
                }
                // Now check if we're in the middle of a string literal
                else if (inQuotes)
                {
                    nextLexeme.Add(c);
                }
                // Now check if we've hit a parenthesis character
                else if (c == '(' || c == ')')
                {
                    if (nextLexeme.Count > 0)
                    {
                        lexemes.Add(new string(nextLexeme.ToArray()));
                        nextLexeme = new List<char>();
                    }
                    lexemes.Add(c.ToString());
                }
                // Not the case, we can split on whitespace characters now
                else if (c == '\n' || c == ' ' || c == '\r')
                {
                    if (nextLexeme.Count > 0)
                    {
                        lexemes.Add(new string(nextLexeme.ToArray()));
                        nextLexeme = new List<char>();
                    }
                }
                // add the current character to the next lexeme.
                else
                {
                    nextLexeme.Add(c);
                }
            }
            if(nextLexeme.Count > 0)
            {
                lexemes.Add(new string(nextLexeme.ToArray()));
            }
            return lexemes;
        }
        private char ProcessEscapeSequence(char value)
        {
            switch (value)
            {
                case 'n':
                    return '\n';
                case '"':
                    return '\"';
                default:
                    throw new ArgumentException("Unknown control character: " + value);
            }
        }

        private Statement BuildStatementTree(List<string> lexemes)
        {
            var statement = new Statement();
            var innerStatement = new List<string>();
            var depth = 0;
            foreach(var lexeme in lexemes)
            {
                if(lexeme == "(")
                {
                    if (depth > 0)
                    {
                        innerStatement.Add(lexeme);
                    }
                    depth++;
                    
                }
                else if(lexeme == ")")
                {
                    depth--;
                    if(depth > 0)
                    {
                        innerStatement.Add(lexeme);
                    }
                    else
                    {
                        statement.Tokens.Add(BuildStatementTree(innerStatement));
                        innerStatement = new List<string>();
                    }
                }
                else if(depth > 0)
                {
                    innerStatement.Add(lexeme);
                }
                else
                {
                    var function = GetFunction(lexeme);
                    statement.Tokens.Add(function);
                }
                
            }
            return statement;
        }


        private Function GetFunction(string lexeme)
        {
            Function result;

            // Look for a special alias first. This covers all literals.
            if (SpecialAliasMap.TryParse(lexeme, out result))
            {
                return result;
            }
            // Then look for a function alias. This covers operators.
            else if (aliasMap.ContainsKey(lexeme))
            {
                return aliasMap[lexeme];
            }
            // Function not found, throw an error.
            else
            {
                throw new ArgumentException(string.Format("Syntax error for \"{0}\": Unknown function.", lexeme));
            }
        }

        public Statement Parse(string statement)
        {
            var lexemes = Lex(statement);
            var tree = BuildStatementTree(lexemes);
            return tree;
        }
    }
}
