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
using System.IO;

/* all angles go clockwise with 0 at 3 o'clock */

namespace Euclid
{
    public class ERuntimeError : System.Exception
    {
        private string fDescription;

        public ERuntimeError(string Description, params object[] DescriptionParams)
        {
            fDescription = String.Format(Description, DescriptionParams);
        }

        public string Description
        {
            get
            {
                return fDescription;
            }
        }
    }

    public class Line : IElement
    {
        private string fLabel;
        private string fComment;
        protected Point fP1, fP2; /* begining and termination points in pixels */
        
        public string Type {
            get {
                return "Line";
            }
        }

        public string Label { 
            get {
                return fLabel;
            }
        }

        public string Comment {
            get {
                return fComment;
            }
        }

        public Line(string Label, string Comment, Point P1, Point P2)
        {
            fLabel = Label;
            fComment = Comment;
            fP1 = P1;
            fP2 = P2;
        }

        public virtual void Execute(IEuclidSite site, ref int Part)
        {
            Graphics graph = site.GetGraphics();
            Pen pen = site.GetPen(PenType.ptLine);
            Point P = new Point(fP1.X + Part * (fP2.X - fP1.X) / 100, fP1.Y + Part * (fP2.Y - fP1.Y) / 100);
            graph.DrawLine(pen, fP1, P);
        }

        public virtual Point GetRelativePoint(IEuclidSite site, string where)
        {
            Point P = new Point();

            switch (where)
            {
                case "LEFT":
                    P.X = Math.Min(fP1.X, fP2.X) / 2;
                    P.Y = (fP1.Y + fP2.Y) / 2;
                    break;
                case "RIGHT":
                    P.X = (Math.Max(fP1.X, fP2.X) + GeneralConfig.DimX) / 2;
                    P.Y = (fP1.Y + fP2.Y) / 2;
                    break;
                case "ABOVE":
                    P.X = (fP1.X + fP2.X) / 2;
                    P.Y = Math.Max(fP1.Y, fP2.Y) / 2;
                    break;
                case "UNDER":
                    P.X = (fP1.X + fP2.X) / 2;
                    P.Y = (Math.Max(fP1.Y, fP2.Y) + GeneralConfig.DimY) / 2;
                    break;
                case "FROM":
                    P = new Point(fP1.X, fP1.Y);
                    break;
            }

            return P;
        }

        public virtual double IsPointOn(IEuclidSite site, Point point)
        {
            if (fP1.X == point.X && fP1.Y == point.Y)
               return 0;
            double a1 = Math.Atan2(fP2.Y - fP1.Y, fP2.X - fP1.X);
            double a2 = Math.Atan2(point.Y - fP1.Y, point.X - fP1.X);
            double len1 = (fP2.Y - fP1.Y) * (fP2.Y - fP1.Y) + (fP2.X - fP1.X) * (fP2.X - fP1.X);
            double len2 = (point.Y - fP1.Y) * (point.Y - fP1.Y) + (point.X - fP1.X) * (point.X - fP1.X);
            if (Math.Abs(a2 - a1) > 0.05 || len2 > len1)
                return -1;
            return Math.Abs(a2 - a1) * len1 + (len2 < len1 ? 0 : len2 - len1);
        }

        public virtual Point GetIntersection(IEuclidSite site, IElement element)
        {
            double angle = 0;
            int x = 0, y = 0;
            int len = 0;

            if (fP2.X == fP1.X)
            {
                angle = Math.PI / 2;
                x = fP1.X;
                y = Math.Min(fP1.Y, fP2.Y);
                len = Math.Max(fP1.Y, fP2.Y) - y;
            }
            else
            {
                angle = Math.Atan2(fP2.Y - fP1.Y, fP2.X - fP1.X);
                x = fP1.X;
                y = fP1.Y;
                len = (int)Math.Sqrt((fP2.Y - fP1.Y) * (fP2.Y - fP1.Y) + (fP2.X - fP1.X) * (fP2.X - fP1.X));
            }

            const double step = 0.005;
            Point RP = new Point(-1, -1);
            double dist = -1;

            for (double i = 0.005; i < len; i += step)
            {
                int cx = (int)(x + i * Math.Cos(angle));
                int cy = (int)(y + i * Math.Sin(angle));
                Point IP = new Point(cx, cy);

                double newdist;

                if ((newdist = element.IsPointOn(site, IP)) >= 0 && (dist < 0 || newdist < dist))
                {
                    RP = IP;
                    dist = newdist;
                }
            }

            if (dist >= 0)
                return RP;

            throw new ERuntimeError("{0} labeled {1} and {2} labeled {3} do not intersect!", Type, Label, element.Type, element.Label);
        }

        public int GetLength()
        {
            return (int)Math.Sqrt((fP2.X - fP1.X) * (fP2.X - fP1.X) + (fP2.Y - fP1.Y) * (fP2.Y - fP1.Y));
        }

        public virtual Point GetPointOn(IEuclidSite site, int which)
        {
            Point R = new Point();

            R.X = fP1.X + which * (fP2.X - fP1.X) / 100;
            R.Y = fP1.Y + which * (fP2.Y - fP1.Y) / 100;

            return R;
        }
    }

    public class RelativeLine : Line, IElement
    {
        private string fRelationType; 
        private string fRelativeTo; 
        private double fAngle; /* angle of slope of line in radians */
        private int fLength; /* length in percentage of canvas */
        protected bool fResolved;

        public RelativeLine(string Label, string Comment, string RelationType, string RelativeTo, double Angle, int Length) : base(Label, Comment, new Point(), new Point())
        {
            fResolved = false;
            fRelationType = RelationType;
            fRelativeTo = RelativeTo;
            fAngle = Angle;
            fLength = Length;
        }

        protected virtual void Resolve(IEuclidSite site)
        {
            if (!fResolved)
            {
                IElement relto = site.GetLabeledElement(fRelativeTo);

                if (relto == null)
                    throw new ERuntimeError("Cannot resolve reference to {0} in relative positioning of line!", fRelativeTo);

                fP1 = relto.GetRelativePoint(site, fRelationType);
                fP2 = new Point((int)(fP1.X + Math.Cos(fAngle) * fLength * GeneralConfig.DimX / 100), (int)(fP1.Y + Math.Sin(fAngle) * fLength * GeneralConfig.DimY / 100));
                fResolved = true;
            }
        }

        public override void Execute(IEuclidSite site, ref int Part)
        {
            Resolve(site);
            base.Execute(site, ref Part);
        }

        public override Point GetRelativePoint(IEuclidSite site, string where)
        {
            Resolve(site);
            return base.GetRelativePoint(site, where);
        }

        public override double IsPointOn(IEuclidSite site, Point point)
        {
            Resolve(site);
            return base.IsPointOn(site, point);
        }

        public override Point GetIntersection(IEuclidSite site, IElement element)
        {
            Resolve(site);
            return base.GetIntersection(site, element);
        }

        public override Point GetPointOn(IEuclidSite site, int which)
        {
            Resolve(site);
            return base.GetPointOn(site, which);
        }
    }

    public class LineThroughPoints : RelativeLine
    {
        private string fRelativeP1;
        private string fRelativeP2;

        public LineThroughPoints(string Label, string Comment, string RelativeP1, string RelativeP2) : base(Label, Comment, "", "", 0, 0)
        {
            fRelativeP1 = RelativeP1;
            fRelativeP2 = RelativeP2;
        }

        protected override void Resolve(IEuclidSite site)
        {
            if (!fResolved)
            {
                IElement relto1 = site.GetLabeledElement(fRelativeP1);

                if (relto1 == null)
                    throw new ERuntimeError("Cannot resolve reference to {0} in line through points command!", fRelativeP1);

                fP1 = relto1.GetRelativePoint(site, "FROM");

                IElement relto2 = site.GetLabeledElement(fRelativeP2);

                if (relto2 == null)
                    throw new ERuntimeError("Cannot resolve reference to {0} in line through points command!", fRelativeP2);

                fP2 = relto2.GetRelativePoint(site, "FROM");

                fResolved = true;
            }
        }
    }

    public class SinglePoint : IElement
    {
        private string fLabel;
        private string fComment;
        internal protected Point fP1; /* point's position in pixels */

        public string Type
        {
            get
            {
                return "Point";
            }
        }

        public string Label
        {

            get
            {
                return fLabel;
            }
        }

        public string Comment
        {
            get
            {
                return fComment;
            }
        }

        public SinglePoint(string Label, string Comment, Point P1)
        {
            fLabel = Label;
            fComment = Comment;
            fP1 = P1;
        }

        public virtual void Execute(IEuclidSite site, ref int Part)
        {
            Graphics graph = site.GetGraphics();
            Pen pen = site.GetPen(PenType.ptPoint);
            Brush brush = new SolidBrush(pen.Color);


            graph.FillEllipse(brush, fP1.X - pen.Width, fP1.Y - pen.Width, pen.Width * 2, pen.Width * 2);
        }

        public virtual Point GetRelativePoint(IEuclidSite site, string where)
        {
            Point P = new Point();

            switch (where)
            {
                case "LEFT":
                    P.X = fP1.X / 2;
                    P.Y = fP1.Y;
                    break;
                case "RIGHT":
                    P.X = (fP1.X + GeneralConfig.DimX) / 2;
                    P.Y = fP1.Y;
                    break;
                case "ABOVE":
                    P.X = fP1.X;
                    P.Y = fP1.Y / 2;
                    break;
                case "UNDER":
                    P.X = fP1.X;
                    P.Y = (fP1.Y + GeneralConfig.DimY) / 2;
                    break;
                case "FROM":
                    P = new Point(fP1.X, fP1.Y);
                    break;
            }
            return P;
        }

        public virtual double IsPointOn(IEuclidSite site, Point point)
        {
            double dist = (point.X - fP1.X) * (point.X - fP1.X) + (point.Y - fP1.Y) * (point.Y - fP1.Y);
            return dist < 200 ? dist : -1;
        }

        public virtual Point GetIntersection(IEuclidSite site, IElement element)
        {
            if (element.IsPointOn(site, fP1) >= 0)
                return fP1;

            throw new ERuntimeError("{0} labeled {1} and {2} labeled {3} do not intersect!", Type, Label, element.Type, element.Label);
        }

        public int GetLength()
        {
            throw new ERuntimeError("Cannot get length of point!");
        }

        public virtual Point GetPointOn(IEuclidSite site, int which)
        {
            return fP1;
        }

    }

    public class RelativePoint : SinglePoint, IElement
    {
        private string fRelationType;
        private string fRelativeTo;
        protected bool fResolved;

        public RelativePoint(string Label, string Comment, string RelationType, string RelativeTo)
            : base(Label, Comment, new Point())
        {
            fResolved = false;
            fRelationType = RelationType;
            fRelativeTo = RelativeTo;
        }

        protected virtual void Resolve(IEuclidSite site)
        {
            if (!fResolved)
            {
                IElement relto = site.GetLabeledElement(fRelativeTo);

                if (relto == null)
                    throw new ERuntimeError("Cannot resolve reference to {0} in relative positioning of a point!", fRelativeTo);

                fP1 = relto.GetRelativePoint(site, fRelationType);
                fResolved = true;
            }
        }

        public override void Execute(IEuclidSite site, ref int Part)
        {
            Resolve(site);
            base.Execute(site, ref Part);
        }

        public override Point GetRelativePoint(IEuclidSite site, string where)
        {
            Resolve(site);
            return base.GetRelativePoint(site, where);
        }

        public override double IsPointOn(IEuclidSite site, Point point)
        {
            Resolve(site);
            return base.IsPointOn(site, point);
        }

        public override Point GetIntersection(IEuclidSite site, IElement element)
        {
            Resolve(site);
            return base.GetIntersection(site, element);
        }

        public override Point GetPointOn(IEuclidSite site, int which)
        {
            Resolve(site);
            return base.GetPointOn(site, which);
        }
    }

    public class IntersectionPoint : RelativePoint, IElement
    {
        private string fCurve1;
        private string fCurve2;

        public IntersectionPoint(string Label, string Comment, string Curve1, string Curve2)
            : base(Label, Comment, "", "")
        {
            fCurve1 = Curve1;
            fCurve2 = Curve2;
        }

        protected override void Resolve(IEuclidSite site)
        {
            if (!fResolved)
            {
                IElement rel1 = site.GetLabeledElement(fCurve1);
                if (rel1 == null)
                    throw new ERuntimeError("Cannot resolve reference to {0} in intersection point!", fCurve1);

                IElement rel2 = site.GetLabeledElement(fCurve2);
                if (rel2 == null)
                    throw new ERuntimeError("Cannot resolve reference to {0} in intersection point!", fCurve2);

                fP1 = rel1.GetIntersection(site, rel2);
                fResolved = true;
            }
        }
    }

    public class PointOnCurve : RelativePoint, IElement
    {
        private string fCurve;
        private int fWhich;

        public PointOnCurve(string Label, string Comment, string Curve, int Which)
            : base(Label, Comment, "", "")
        {
            fCurve = Curve;
            fWhich = Which;
        }

        protected override void Resolve(IEuclidSite site)
        {
            if (!fResolved)
            {
                IElement rel = site.GetLabeledElement(fCurve);
                if (rel == null)
                    throw new ERuntimeError("Cannot resolve reference to {0} in point on curve (POC) command!", fCurve);

                fP1 = rel.GetPointOn(site, fWhich);
                fResolved = true;
            }
        }
    }

    public class Arc : IElement
    {
        private string fLabel;
        private string fComment;
        protected Point fP; /* point of center in pixels */
        protected int fR; /* radius in pixels */
        protected double fArc1, fArc2; /* begining angle and angular length (in degrees) */

        public string Type
        {
            get
            {
                return "Arc";
            }
        }

        public string Label
        {
            get
            {
                return fLabel;
            }
        }

        public string Comment
        {
            get
            {
                return fComment;
            }
        }

        public Arc(string Label, string Comment, Point P, int R, double Arc1, double Arc2)
        {
            fLabel = Label;
            fComment = Comment;
            fP = P;
            fR = R;
            fArc1 = Arc1;
            fArc2 = Arc2;
        }

        public virtual void Execute(IEuclidSite site, ref int Part)
        {
            Graphics graph = site.GetGraphics();
            Pen pen = site.GetPen(PenType.ptCurve);
            if (fR == -1)
                fR = site.Radius;
            graph.DrawArc(pen, new Rectangle(fP.X - fR, fP.Y - fR, 2 * fR, 2 * fR), (float)fArc1, (float)(Part * fArc2 / 100)); 
        }

        public virtual Point GetRelativePoint(IEuclidSite site, string where)
        {
            Point P = new Point();

            switch (where)
            {
                case "LEFT":
                    P.X = (fP.X - fR) / 2;
                    P.Y = fP.Y;
                    break;
                case "RIGHT":
                    P.X = (GeneralConfig.DimX + fP.X + fR) / 2;
                    P.Y = fP.Y;
                    break;
                case "ABOVE":
                    P.X = fP.X;
                    P.Y = (fP.Y - fR) / 2;
                    break;
                case "UNDER":
                    P.X = fP.X;
                    P.Y = (GeneralConfig.DimX + fP.X + fR) / 2;
                    break;
                case "FROM":
                    P = new Point(fP.X, fP.Y);
                    break;
            }

            return P;
        }

        public virtual double IsPointOn(IEuclidSite site, Point point)
        {
            double angle1 = fArc1 * Math.PI / 180 % (Math.PI * 2);
            double angle2 = (fArc2 + fArc1) * Math.PI / 180 % (Math.PI * 2);
            int W1 = point.X - fP.X;
            int W2 = point.Y - fP.Y;

            double point_angle = Math.Atan2(W2, W1);

            /* normalize angles */
            angle1 -= angle1 > Math.PI ? Math.PI * 2 : 0;
            angle2 -= angle2 > Math.PI ? Math.PI * 2 : 0;
            angle1 += angle1 < -Math.PI ? Math.PI * 2 : 0;
            angle2 += angle2 < -Math.PI ? Math.PI * 2 : 0;

            bool angular_condition;

            if (angle1 < angle2)
                angular_condition = point_angle >= angle1 && point_angle <= angle2;
            else
                angular_condition = point_angle <= angle2 || point_angle >= angle1;

            double dist = Math.Abs(W1 * W1 + W2 * W2 - fR * fR);
            if (angular_condition && dist < 500)
                return dist;
            else
                return -1;            
        }

        public virtual Point GetIntersection(IEuclidSite site, IElement element)
        {
            double angle1 = fArc1 * Math.PI / 180;
            double angle2 = fArc2 * Math.PI / 180;
            const int stepcount = 1000000;

            Point RP = new Point(-1, -1);
            double dist = -1;

            for (int i = 0; i < stepcount; i++)
            {
                double angle = angle1 + i * angle2 / stepcount;
                Point point = new Point((int)(fP.X + fR * Math.Cos(angle)), (int)(fP.Y + fR * Math.Sin(angle)));
                double newdist;
                if ((newdist = element.IsPointOn(site, point)) >= 0 && (dist < 0 || newdist < dist))
                {
                    RP = point;
                    dist = newdist;
                }
            }

            if (dist >= 0)
                return RP;

            throw new ERuntimeError("{0} labeled {1} and {2} labeled {3} do not intersect!", Type, Label, element.Type, element.Label);
        }

        public int GetLength()
        {
            return (int)fR;
        }

        public virtual Point GetPointOn(IEuclidSite site, int which)
        {
            Point R = new Point();

            double angle = which * (fArc2 - fArc1) * Math.PI / 18000;

            R.X = (int)(fP.X + fR * Math.Cos(angle));
            R.Y = (int)(fP.Y + fR * Math.Sin(angle));

            return R;
        }

    }

    public class RelativeArc : Arc, IElement
    {
        private string fRelationType;
        private string fRelativeTo;
        protected bool fResolved;

        public RelativeArc(string Label, string Comment, string RelationType, string RelativeTo, int R, double Angle1, double Angle2)
            : base(Label, Comment, new Point(), R, Angle1, Angle2)
        {
            fResolved = false;
            fRelationType = RelationType;
            fRelativeTo = RelativeTo;
        }

        protected virtual void Resolve(IEuclidSite site)
        {
            if (!fResolved)
            {
                IElement relto = site.GetLabeledElement(fRelativeTo);

                if (relto == null)
                    throw new ERuntimeError("Cannot resolve reference to {0} in relative positioning of an arc!", fRelativeTo);

                fP = relto.GetRelativePoint(site, fRelationType);
                fResolved = true;
            }
        }

        public override void Execute(IEuclidSite site, ref int Part)
        {
            Resolve(site);
            base.Execute(site, ref Part);
        }

        public override Point GetRelativePoint(IEuclidSite site, string where)
        {
            Resolve(site);
            return base.GetRelativePoint(site, where);
        }

        public override double IsPointOn(IEuclidSite site, Point point)
        {
            Resolve(site);
            return base.IsPointOn(site, point);
        }

        public override Point GetIntersection(IEuclidSite site, IElement element)
        {
            Resolve(site);
            return base.GetIntersection(site, element);
        }

        public override Point GetPointOn(IEuclidSite site, int which)
        {
            Resolve(site);
            return base.GetPointOn(site, which);
        }

    }

    public class ArcByPoints : RelativeArc, IElement
    {
        private string fRef1;
        private string fRef2;


        public ArcByPoints(string Label, string Comment, string Ref1, string Ref2, double Angle1, double Angle2)
            : base(Label, Comment, "", "", 0, Angle1, Angle2)
        {
            fRef1 = Ref1;
            fRef2 = Ref2;
        }

        protected override void Resolve(IEuclidSite site)
        {
            if (!fResolved)
            {
                IElement relto1 = site.GetLabeledElement(fRef1);

                if (relto1 == null)
                    throw new ERuntimeError("Cannot resolve reference to {0} in ABP (arc by points) command!", fRef1);

                IElement relto2 = site.GetLabeledElement(fRef2);

                if (relto2 == null)
                    throw new ERuntimeError("Cannot resolve reference to {0} in ABP (arc by points) command!", fRef2);

                fP = relto1.GetRelativePoint(site, "FROM");
                Point P2 = relto2.GetRelativePoint(site, "FROM");

                int dx = P2.X - fP.X;
                int dy = P2.Y - fP.Y;

                fR = (int)Math.Sqrt(dx * dx + dy * dy);

                double ang = Math.Atan2(dy, dx) * 180 / Math.PI;

                fArc1 += ang;

                fResolved = true;
            }
        }
    }

    public class TextComment : IElement
    {
        private string fLabel;
        private string fComment;
        private string fContent;

        public string Type
        {
            get
            {
                return "Text";
            }
        }

        public string Label
        {
            get
            {
                return fLabel;
            }
        }

        public string Comment
        {
            get
            {
                return fComment;
            }
        }

        public TextComment(string Label, string Comment, string Content)
        {
            fLabel = Label;
            fComment = Comment;
            fContent = Content;
        }

        public void Execute(IEuclidSite site, ref int Part)
        {
            Part = 100;
            site.OutputText(fContent);
        }

        public Point GetRelativePoint(IEuclidSite site, string where)
        {
            throw new ERuntimeError("Text of comment (TXT) is not a graphical object, so it cannot be used for positioning another object.");
        }

        public double IsPointOn(IEuclidSite site, Point point)
        {
            throw new ERuntimeError("Text of comment (TXT) is not a graphical object, so it cannot be used to locate point on.");
        }

        public Point GetIntersection(IEuclidSite site, IElement element)
        {
            throw new ERuntimeError("Text of comment (TXT) is not a graphical object, so it does not intersect");
        }

        public int GetLength()
        {
            throw new ERuntimeError("Text of comment (TXT) is not a graphical object, so it cannot be got length of");
        }

        public virtual Point GetPointOn(IEuclidSite site, int which)
        {
            throw new ERuntimeError("Text of comment (TXT) is not a graphical object, so it does not contain points");
        }
    }

    public class CompassRadiusSetter : IElement
    {
        private string fLabel;
        private string fComment;
        protected string fRadiusSpec;

        public string Type
        {
            get
            {
                return "Compass radius";
            }
        }

        public string Label
        {
            get
            {
                return fLabel;
            }
        }

        public string Comment
        {
            get
            {
                return fComment;
            }
        }

        public CompassRadiusSetter(string Label, string Comment, string RadiusSpec)
        {
            fLabel = Label;
            fComment = Comment;
            fRadiusSpec = RadiusSpec;
        }

        public virtual void Execute(IEuclidSite site, ref int Part)
        {
            Part = 100;

            try
            {
                site.Radius = Convert.ToInt32(fRadiusSpec) * GeneralConfig.DimX / 100;
            }
            catch (FormatException)
            {
                IElement elem = site.GetLabeledElement(fRadiusSpec);
                if (elem == null)
                    throw new ERuntimeError("Cannot find element {0} to take the compass length from.", fRadiusSpec);
                site.Radius = elem.GetLength();
                fRadiusSpec = string.Format("{0}", (int)((double)site.Radius / GeneralConfig.DimX * 100));
            }
        }

        public Point GetRelativePoint(IEuclidSite site, string where)
        {
            throw new ERuntimeError("Setting the radius of compass (SCR) is not a graphical object, so it cannot be used to position other object.");
        }

        public double IsPointOn(IEuclidSite site, Point point)
        {
            throw new ERuntimeError("Setting the radius of compass (SCR) is not a graphical object, so it cannot be used to locate point on.");
        }

        public Point GetIntersection(IEuclidSite site, IElement element)
        {
            throw new ERuntimeError("Setting the radius of compass (SCR) is not a graphical object, so it does not intersect");
        }

        public int GetLength()
        {
            try
            {
                return Convert.ToInt32(fRadiusSpec);
            }
            catch (FormatException)
            {
                throw new ERuntimeError("Error copying radius from other SCR");
            }
        }

        public virtual Point GetPointOn(IEuclidSite site, int which)
        {
            throw new ERuntimeError("Setting the radius of compass (SCR) is not a graphical object, so it does not contain points");
        }
    }

    public class CompassRadiusSetterByPoints : CompassRadiusSetter, IElement
    {
        private string fPoint1;
        private string fPoint2;

        public CompassRadiusSetterByPoints(string Label, string Comment, string Point1, string Point2)
            : base(Label, Comment, "")
        {
            fPoint1 = Point1;
            fPoint2 = Point2;
        }

        public override void Execute(IEuclidSite site, ref int Part)
        {
            try
            {
                if (fRadiusSpec == "")
                {
                    SinglePoint p1 = site.GetLabeledElement(fPoint1) as SinglePoint;
                    SinglePoint p2 = site.GetLabeledElement(fPoint2) as SinglePoint;
                    double r = Math.Sqrt((p2.fP1.X - p1.fP1.X) * (p2.fP1.X - p1.fP1.X) + (p2.fP1.Y - p1.fP1.Y) * (p2.fP1.Y - p1.fP1.Y));
                    fRadiusSpec = String.Format("{0}", (int)(r / GeneralConfig.DimX * 100));
                }
                base.Execute(site, ref Part);
            }
            catch (Exception)
            {
                throw new ERuntimeError("Error getting radius from points");
            }
        }
    }

    public class ObjectLabel : IElement
    {
        private string fLabel;
        private string fComment;
        private string fLabelOf;
        private string fLabelTxt;
        private Point fPos;
        protected bool fResolved;
        IElement relto;

        public string Type
        {
            get
            {
                return "Label";
            }
        }

        public string Label
        {
            get
            {
                return fLabel;
            }
        }

        public string Comment
        {
            get
            {
                return fComment;
            }
        }

        public ObjectLabel(string Label, string Comment, string LabelOf, string LabelTxt)
        {
            fLabel = Label;
            fComment = Comment;
            fResolved = false;
            fLabelOf = LabelOf;
            fLabelTxt = LabelTxt;
        }

        protected virtual void Resolve(IEuclidSite site)
        {
            if (!fResolved)
            {
                relto = site.GetLabeledElement(fLabelOf);

                if (relto == null)
                    throw new ERuntimeError("Cannot resolve reference to {0} in label (LBL)!", fLabelOf);

                fPos = relto.GetRelativePoint(site, "FROM");
                fPos.Offset(0, 7);
                if (fLabelTxt == "")
                    fLabelTxt = relto.Label;
                fResolved = true;
            }
        }

        public virtual void Execute(IEuclidSite site, ref int Part)
        {
            Resolve(site);
            Graphics grp = site.GetGraphics();

            Point p = fPos;
            Font f = site.GetFont(FontType.ftLabel);
            SizeF sz = grp.MeasureString(fLabelTxt, f);
            Pen pn = site.GetPen(PenType.ptLabel);

            p.Offset((int)(-sz.Width / 2), 0);

            grp.DrawString(fLabelTxt, f, new SolidBrush(pn.Color), p);
        }

        public virtual Point GetRelativePoint(IEuclidSite site, string where)
        {
            Resolve(site);
            return relto.GetRelativePoint(site, where);
        }

        public virtual double IsPointOn(IEuclidSite site, Point point)
        {
            Resolve(site);
            return relto.IsPointOn(site, point);
        }

        public virtual Point GetIntersection(IEuclidSite site, IElement element)
        {
            Resolve(site);
            return relto.GetIntersection(site, element);
        }

        public virtual Point GetPointOn(IEuclidSite site, int which)
        {
            Resolve(site);
            return relto.GetPointOn(site, which);
        }

        public int GetLength()
        {
            return 0;            
        }

    }


};

