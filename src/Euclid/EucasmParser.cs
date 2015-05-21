/* Euclid# - Euclidean Geometry Constructions Simulator 
 * 
 * Copyright (c) 2006 Krzysztof Olczyk
 * 
 * Program written for Programming Project Course
 * at Technical University of Lodz, Fall 2006
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Euclid
{
    public interface IEucasmCommand
    {
        string Name { get; }
        IElement Interpret(string Label, LinkedList<string> Params);
    }

    public static class EucasmCommands
    {
        private static Dictionary<string, IEucasmCommand> Commands;

        static EucasmCommands()
        {
            EucasmCommands.Commands = new Dictionary<string, IEucasmCommand>();
            CommandsProvider.Go();
        }

        public static void AddCommand(string Name, IEucasmCommand Implementation)
        {
            EucasmCommands.Commands.Add(Name, Implementation);
        }

        public static bool FindCommand(string Name, out IEucasmCommand Implementation)
        {
            return EucasmCommands.Commands.TryGetValue(Name, out Implementation);
        }
    }

    public static class EucasmParser
    {
        public class EParseError : System.Exception
        {
            private int fLine;
            private string fDescription;

            public EParseError(int Line, string Description, params object[] DescriptionParams)
            {
                fLine = Line;
                fDescription = String.Format(Description, DescriptionParams);
            }

            public int Line {
                get {
                    return fLine;
                }
                set {
                    fLine = value;
                }
            }

            public string Description
            {
                get
                {
                    return fDescription;
                }
            }
        }

        private static void Eatwhitespaces(StringReader code_r)
        {
            while (code_r.Peek() == ' ' || code_r.Peek() == '\t' || code_r.Peek() == ',')
                code_r.Read();
        }

        private static string ParseElement(StringReader code_r, char Terminator, out bool end)
        {
            string res = "";
            bool insideqoutes = false;
            bool specialchar = false;
            end = false;

            Eatwhitespaces(code_r);

            for (int c = code_r.Read(); !(end = (c == -1)) && !(end = (c == '\n')) && (insideqoutes || c != Terminator); c = code_r.Read())
            {
                if (specialchar)
                {
                    if (c == 'n')
                        res += "\r\n";
                    else if (c == 't')
                        res += "\t";
                    else
                        res += (char)c;
                    specialchar = false;
                }
                else if (c == '\\')
                    specialchar = true;
                else if (c == '"')
                    insideqoutes = !insideqoutes;
                else if (c == '{' || c == '}')
                    return new string((char)c, 1);
                else
                    res += (char)c;

                if (code_r.Peek() == '}')
                    return res;
            }

            return res;
        }

        public struct ParsedEucasmCode
        {
            public LinkedList<IElement> elements;
            public Dictionary<string, IElement> labels;

            internal ParsedEucasmCode(LinkedList<IElement> Elements, Dictionary<string, IElement> Labels)
            {
                elements = Elements;
                labels = Labels;
            }
        }

        public static ParsedEucasmCode Parse(string code)
        {
            LinkedList<IElement> elements = new LinkedList<IElement>();
            Dictionary<string, IElement> labels = new Dictionary<string, IElement>();
            int line = 0;

            StringReader code_r = new StringReader(code);

            for (int c = code_r.Read(); c != -1; c = code_r.Read())
            {
                bool end;
                string label = "";

                line++;

                if (c == '@')
                {
                    label = ParseElement(code_r, ':', out end);
                    if (code_r.Peek() == -1)
                        throw new EParseError(line, "Label {0} not followed by instruction", label);
                    else if (code_r.Peek() == '\n')
                        code_r.Read();
                    Eatwhitespaces(code_r);
                    c = code_r.Read();
                }
                else if (c == '*')
                {
                    code_r.ReadLine();
                    continue;
                }
                else if (c == '\n')
                    continue;

                string commandname = new string((char)c, 1) + ParseElement(code_r, ' ', out end);
                LinkedList<string> commandparams = new LinkedList<string>();

                LinkedListNode<string> iterativeparam = null;
                int iterfrom = 1, iterstep = 1, iterto = 1;

                while (!end)
                {
                    string commandparam = ParseElement(code_r, ' ', out end);
                    if (commandparam[0] == '*')
                    {
                        code_r.ReadLine();
                        continue;
                    }
                    else if (commandparam == "{")
                    {
                        try
                        {
                            iterfrom = Convert.ToInt32(ParseElement(code_r, ' ', out end));
                            if (end)
                                throw new FormatException();
                            iterstep = Convert.ToInt32(ParseElement(code_r, ' ', out end));
                            if (end)
                                throw new FormatException();
                            iterto = Convert.ToInt32(ParseElement(code_r, ' ', out end));
                            if (end)
                                throw new FormatException();
                            ParseElement(code_r, ' ', out end); // takes out last }
                        }
                        catch (FormatException)
                        {
                            throw new EParseError(line, "{0}", "Incorrect iteration clause.\r\nThe format is following: {BEGINING_VALUE STEP END_VALUE} and values have to be numerical.");
                        }

                        iterativeparam = commandparams.AddLast(commandparam);
                    }
                    else
                        commandparams.AddLast(commandparam);
                }              
                
                IEucasmCommand cmdimpl;

                if (!EucasmCommands.FindCommand(commandname, out cmdimpl))
                        throw new EParseError(line, "Command {0} is not a valid Eucasm instruction", commandname);

                IElement element = null;

                for (int i = iterfrom; i <= iterto; i += iterstep)
                {
                    string actuallabel = label;
                    if (iterativeparam != null)
                    {
                        iterativeparam.Value = string.Format("{0}", i);
                        if (label != "")
                            actuallabel = string.Format("{0}({1})", label, i);
                    }
                    try
                    {
                        element = cmdimpl.Interpret(actuallabel, commandparams);
                    }
                    catch (EParseError pe)
                    {
                        pe.Line = line;
                        throw pe;
                    }
   
                    elements.AddLast(element);
                    try
                    {
                        if (actuallabel != "")
                            labels.Add(actuallabel, element);
                    }
                    catch (ArgumentException)
                    {
                        throw new EParseError(line, "Label {0} already used for the one of former elements", actuallabel);
                    }
                 }
            }

            return new ParsedEucasmCode(elements, labels);
        }

    }
}
