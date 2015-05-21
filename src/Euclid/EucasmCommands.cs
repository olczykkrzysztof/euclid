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
using System.Drawing;

namespace Euclid
{
    public abstract class Eucasm_GraphicalCommand
    {
        public abstract string Name { get; }

        protected bool ParamIn(string[] haystack, string needle)
        {
            foreach (string elem in haystack)
                if (elem == needle)
                    return true;
            return false;
        }

        protected enum PositionerType { absolute, relative, precise };

        protected string GetPositioner(ref LinkedListNode<string> currparam, out PositionerType type)
        {
            string[] absolutepositioners = { "C", "LT", "RT", "LB", "RB" };
            string[] relativepositioners = { "ABOVE", "UNDER", "LEFT", "RIGHT", "FROM" };

            if (ParamIn(relativepositioners, currparam.Value))
            {
                type = PositionerType.relative;
            }
            else if (ParamIn(absolutepositioners, currparam.Value))
            {
                type = PositionerType.absolute;
            }
            else if (currparam.Value == "COORD")
            {
                type = PositionerType.precise;
            }
            else
            {
                throw new EucasmParser.EParseError(0, "Unrecognized parameter for {0} command at position 1 - {1}.\r\nThere should be a relative or absolute positioner (e.g. ABOVE).", Name, currparam.Value);
            }

            return currparam.Value;
        }

        protected string GetRelativeTo(ref LinkedListNode<string> currparam)
        {
            if (currparam == null)
            {
                throw new EucasmParser.EParseError(0, "The relative positioner of {0} command should be accompanied by the label of another object.", Name);
            }
            return  currparam.Value;
        }

        protected Point GetPrecisePoint(ref LinkedListNode<string> currparam)
        {
            Point P = new Point();

            if (currparam == null || currparam.Next == null)
            {
                throw new EucasmParser.EParseError(0, "The precise coordinate positioner COORD should be followed by two numbers defining the coordinates.");
            }

            try
            {
                P.X = Convert.ToInt32(currparam.Value) * GeneralConfig.DimX / 100;
                currparam = currparam.Next;
                P.Y = Convert.ToInt32(currparam.Value) * GeneralConfig.DimY / 100;
                
            }
            catch (FormatException)
            {
                throw new EucasmParser.EParseError(0, "{0} is not a valid coordinate for COORD precise coordinate positioner.\r\nIt should be number 0-100 denoting interpreted as percantage of canvas.", currparam.Value);
            }

            return P;
        }

        protected Point GetPointFromPositioner(string positioner)
        {
            Point P = new Point();

            switch (positioner)
            {
                case "C":
                    P.X = GeneralConfig.DimX / 2;
                    P.Y = GeneralConfig.DimY / 2;
                    break;
                case "LT":
                    P.X = GeneralConfig.DimX / 10;
                    P.Y = GeneralConfig.DimY / 10;
                    break;
                case "RT":
                    P.X = 7 * GeneralConfig.DimX / 10;
                    P.Y = GeneralConfig.DimY / 10;
                    break;
                case "LB":
                    P.X = GeneralConfig.DimX / 10;
                    P.Y = 7 * GeneralConfig.DimY / 10;
                    break;
                case "RB":
                    P.X = 7 * GeneralConfig.DimX / 10;
                    P.Y = 7 * GeneralConfig.DimY / 10;
                    break;
            }

            return P;
        }

        protected int GetLength(ref LinkedListNode<string> currparam)
        {
            if (currparam == null)
                return 75;
            else
            {
                try
                {
                    int len = Convert.ToInt32(currparam.Value);
                    if (len < -1 | len > 100)
                    {
                        throw new EucasmParser.EParseError(0, "{0} is an invalid length. It should be percentage of canvas (0-100).", currparam.Value);
                    }
                    return len;
                }
                catch (FormatException)
                {
                    throw new EucasmParser.EParseError(0, "{0} is an invalid length. It should be percentage of canvas (0-100).", currparam.Value);
                }
            }
        }
 
    }

    public abstract class Eucasm_LineCommand : Eucasm_GraphicalCommand
    {
        /* reads the orientation angle from parametr given in degrees and returns it in radians */
        protected double GetOrientationAngle(ref LinkedListNode<string> currparam)
        {
            if (currparam == null || currparam.Value == "HORIZ")
                return 0;
            else if (currparam.Value == "VERT")
                return Math.PI / 2;
            else if (currparam.Value == "SLOPED")
            {
                currparam = currparam.Next;
                if (currparam == null)
                    throw new EucasmParser.EParseError(0, "The SLOPED orientation specifier should be accompanied by the angular slope measure in degrees.");

                try
                {
                    return Math.PI * Convert.ToInt32(currparam.Value) / 180;
                }
                catch (FormatException)
                {
                    throw new EucasmParser.EParseError(0, "The value {0} does not represent valid angular measure of slope for SLOPE specifier.", currparam.Value);
                }
                catch (OverflowException)
                {
                    throw new EucasmParser.EParseError(0, "The value {0} does overflow. It is suggested to use sane measure of angle - between 0 and 360 degrees.", currparam.Value);
                }
            }
            else
                throw new EucasmParser.EParseError(0, "Instead of orientation specifier (HORIZ | VERT | SLOPED) unrecognized token found: {0}.", currparam.Value);
        }
    }

    public class Eucasm_LIN : Eucasm_LineCommand, IEucasmCommand
    {
        public override string Name { 
            get {
                return "LIN";
            }
        }
               
        public IElement Interpret(string Label, LinkedList<string> Params)
        {
            if (Params.Count == 0)
               return new Line(Label, "Line", new Point(GeneralConfig.DimX / 5, GeneralConfig.DimY / 2), new Point(4 * GeneralConfig.DimX / 5, GeneralConfig.DimY / 2));

            LinkedListNode<string> currparam = Params.First;
            PositionerType positionertype;

            GetPositioner(ref currparam, out positionertype);

            if (positionertype == PositionerType.relative)
            {
                string positioner = currparam.Value;
                currparam = currparam.Next;
                string relativeto = GetRelativeTo(ref currparam);
                currparam = currparam.Next;
                double angle = GetOrientationAngle(ref currparam);
                if (currparam != null)
                    currparam = currparam.Next;
                int length = GetLength(ref currparam);

                return new RelativeLine(Label, "line", positioner, relativeto, angle, length);
            }
            else if (positionertype == PositionerType.absolute)
            {
                string positioner = currparam.Value;
                currparam = currparam.Next;
                
                double angle = GetOrientationAngle(ref currparam);
                
                if (currparam != null)
                    currparam = currparam.Next;
                int length = GetLength(ref currparam);

                Point P = GetPointFromPositioner(positioner);

                Point P2 = new Point((int)(P.X + Math.Cos(angle) * length * GeneralConfig.DimX / 100), (int)(P.Y + Math.Sin(angle) * length * GeneralConfig.DimY / 100));

                return new Line(Label, "Line", P, P2);
            }
            else if (positionertype == PositionerType.precise)
            {
                currparam = currparam.Next;
                Point P = GetPrecisePoint(ref currparam);
                currparam = currparam.Next;
                double angle = GetOrientationAngle(ref currparam);

                if (currparam != null)
                    currparam = currparam.Next;
                int length = GetLength(ref currparam);

                Point P2 = new Point((int)(P.X + Math.Cos(angle) * length * GeneralConfig.DimX / 100), (int)(P.Y + Math.Sin(angle) * length * GeneralConfig.DimY / 100));

                return new Line(Label, "Line", P, P2);
            }
                        
            return null;
        }
    }

    public class Eucasm_PNT : Eucasm_GraphicalCommand, IEucasmCommand
    {
        public override string Name
        {
            get
            {
                return "PNT";
            }
        }

        public IElement Interpret(string Label, LinkedList<string> Params)
        {
            LinkedListNode<string> currparam = Params.First;
            PositionerType positionertype;

            GetPositioner(ref currparam, out positionertype);

            if (positionertype == PositionerType.relative)
            {
                string positioner = currparam.Value;
                currparam = currparam.Next;
                string relativeto = GetRelativeTo(ref currparam);

                return new RelativePoint(Label, "point", positioner, relativeto);
            }
            else if (positionertype == PositionerType.absolute)
            {
                string positioner = currparam.Value;
                currparam = currparam.Next;

                Point P = GetPointFromPositioner(positioner);

                return new SinglePoint(Label, "point", P);
            }
            else if (positionertype == PositionerType.precise)
            {
                currparam = currparam.Next;
                Point P = GetPrecisePoint(ref currparam);

                return new SinglePoint(Label, "point", P);
            }

            return null;
        }
    }

    public abstract class Eucasm_ArcCommand : Eucasm_LineCommand
    {
        protected int GetAngle(ref LinkedListNode<string> currparam, int def)
        {
            if (currparam == null)
                return def;

            try
            {
                return Convert.ToInt32(currparam.Value);
            }
            catch (FormatException)
            {
                throw new EucasmParser.EParseError(0, "An angle must be between 0 and 360 degrees");
            }
        }
    }

    public class Eucasm_ARC : Eucasm_ArcCommand, IEucasmCommand
    {
        public override string Name
        {
            get
            {
                return "ARC";
            }
        }

        public IElement Interpret(string Label, LinkedList<string> Params)
        {
            if (Params.Count == 0)
                return new Arc(Label, "arc", new Point(GeneralConfig.DimX / 2, GeneralConfig.DimY / 2), -1, 0, 360); 

            LinkedListNode<string> currparam = Params.First;
            PositionerType positionertype;

            GetPositioner(ref currparam, out positionertype);

            if (positionertype == PositionerType.relative)
            {
                string positioner = currparam.Value;
                currparam = currparam.Next;
                string relativeto = GetRelativeTo(ref currparam);
                currparam = currparam.Next;
                
                int radius = GetLength(ref currparam);
                if (currparam != null)
                    currparam = currparam.Next;
                int angle1 = GetAngle(ref currparam, 0);
                if (currparam != null)
                    currparam = currparam.Next;
                int angle2 = GetAngle(ref currparam, 360);

                return new RelativeArc(Label, "arc", positioner, relativeto, (radius != -1) ? radius * GeneralConfig.DimX / 100 : -1, angle1, angle2);
            }
            else if (positionertype == PositionerType.absolute)
            {
                string positioner = currparam.Value;
                currparam = currparam.Next;

                int radius = GetLength(ref currparam);

                if (currparam != null)
                    currparam = currparam.Next;
                int angle1 = GetAngle(ref currparam, 0);
                if (currparam != null)
                    currparam = currparam.Next;
                int angle2 = GetAngle(ref currparam, 360);

                Point P = GetPointFromPositioner(positioner);

                return new Arc(Label, "arc", P, (radius != -1) ? radius * GeneralConfig.DimX / 100 : -1, angle1, angle2);
            }
            else if (positionertype == PositionerType.precise)
            {
                currparam = currparam.Next;
                Point P = GetPrecisePoint(ref currparam);

                currparam = currparam.Next;

                int radius = GetLength(ref currparam);

                if (currparam != null)
                    currparam = currparam.Next;
                int angle1 = GetAngle(ref currparam, 0);
                if (currparam != null)
                    currparam = currparam.Next;
                int angle2 = GetAngle(ref currparam, 360);

                return new Arc(Label, "arc", P, (radius != -1) ? radius * GeneralConfig.DimX / 100 : -1, angle1, angle2);
            }

            return null;
        }
    }

    public class Eucasm_ABP : Eucasm_ArcCommand, IEucasmCommand
    {
        public override string Name
        {
            get
            {
                return "ABP";
            }
        }

        public IElement Interpret(string Label, LinkedList<string> Params)
        {
            LinkedListNode<string> currparam = Params.First;

            if (Params.Count < 2)
                throw new EucasmParser.EParseError(0, "Command ABP (arc by points) takes at least two parameters - two points' references");

            string pref1 = currparam.Value;
            currparam = currparam.Next;
            string pref2 = currparam.Value;
            currparam = currparam.Next;

            int angle1 = GetAngle(ref currparam, 0);
            
            if (currparam != null)
                currparam = currparam.Next;
            int angle2 = GetAngle(ref currparam, 360);

            return new ArcByPoints(Label, "arc", pref1, pref2, angle1, angle2);
        }
    }

    public class Eucasm_TXT : IEucasmCommand
    {
        public string Name
        {
            get
            {
                return "TXT";
            }
        }
        public IElement Interpret(string Label, LinkedList<string> Params)
        {
            if (Params.Count < 1)
                throw new EucasmParser.EParseError(0, "Command TXT takes one parameter: Text to be output");

            string txt = Params.First.Value;

            return new TextComment(Label, txt, txt);
        }
    }

    public class Eucasm_SCR : IEucasmCommand
    {
        public string Name
        {
            get
            {
                return "SCR";
            }
        }
        public IElement Interpret(string Label, LinkedList<string> Params)
        {
            if (Params.Count < 1)
                throw new EucasmParser.EParseError(0, "Command SCR takes one parameter: Radius as a number beeing percentage of canvas or other object's label to get length from; or two parameters: points between which length to get");

            string par1 = Params.First.Value;

            if (Params.First.Next != null)
            {
                string par2 = Params.First.Next.Value;
                return new CompassRadiusSetterByPoints(Label, "Compass radius setter", par1, par2);
            }

            return new CompassRadiusSetter(Label, "Compass radius setter", par1);
        }
    }

    public class Eucasm_INS : IEucasmCommand
    {
        public string Name
        {
            get
            {
                return "INS";
            }
        }
        public IElement Interpret(string Label, LinkedList<string> Params)
        {
            if (Params.Count < 2)
                throw new EucasmParser.EParseError(0, "Command INS takes two parameters: the curves on whoose intersection the point is to be placed");

            string par1 = Params.First.Value;
            string par2 = Params.First.Next.Value;

            return new IntersectionPoint(Label, "intersection", par1, par2);
        }
    }

    public class Eucasm_LTP : IEucasmCommand
    {
        public string Name
        {
            get
            {
                return "LTP";
            }
        }
        public IElement Interpret(string Label, LinkedList<string> Params)
        {
            if (Params.Count < 2)
                throw new EucasmParser.EParseError(0, "Command LTP takes two parameters: the points through which to trace a line");

            string par1 = Params.First.Value;
            string par2 = Params.First.Next.Value;

            return new LineThroughPoints(Label, "line through points", par1, par2);
        }
    }

    public class Eucasm_POC : IEucasmCommand
    {
        public string Name
        {
            get
            {
                return "POC";
            }
        }
        public IElement Interpret(string Label, LinkedList<string> Params)
        {
            if (Params.Count < 2)
                throw new EucasmParser.EParseError(0, "Command POC (point on curve) takes two parameters: the curve on which point is localized and percentage of the curve in which it lie");

            string par1 = Params.First.Value;
            string par2 = Params.First.Next.Value;

            try
            {
                int par2i = Convert.ToInt32(par2);
                return new PointOnCurve(Label, "Point on curve", par1, par2i);
            }
            catch (FormatException)
            {
                throw new EucasmParser.EParseError(0, "Second argument of the POC command must be the number 0-100 representing the percentage of the curve");
            }
        }
    }

    public class Eucasm_LBL : IEucasmCommand
    {
        public string Name
        {
            get
            {
                return "POC";
            }
        }
        public IElement Interpret(string Label, LinkedList<string> Params)
        {
            if (Params.Count < 1)
                throw new EucasmParser.EParseError(0, "Command LBL (label) takes at least one parameter - object to be labeled and optionally second parameter - text to be labelled if other than label");

            string par1 = Params.First.Value;
            string par2 = "";
            if (Params.First.Next != null)
                par2 = Params.First.Next.Value;

            return new ObjectLabel(Label, "label", par1, par2);
        }
    }

    public static class CommandsProvider
    {
        static CommandsProvider()
        {
            EucasmCommands.AddCommand("LIN", new Eucasm_LIN());
            EucasmCommands.AddCommand("PNT", new Eucasm_PNT());
            EucasmCommands.AddCommand("TXT", new Eucasm_TXT());
            EucasmCommands.AddCommand("ARC", new Eucasm_ARC());
            EucasmCommands.AddCommand("ABP", new Eucasm_ABP());
            EucasmCommands.AddCommand("SCR", new Eucasm_SCR());
            EucasmCommands.AddCommand("INS", new Eucasm_INS());
            EucasmCommands.AddCommand("LTP", new Eucasm_LTP());
            EucasmCommands.AddCommand("POC", new Eucasm_POC());
            EucasmCommands.AddCommand("LBL", new Eucasm_LBL());
        }

        public static void Go()
        { }
    }
}
