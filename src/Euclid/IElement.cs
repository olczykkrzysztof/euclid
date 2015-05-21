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

namespace Euclid
{
    public enum PenType { ptLine, ptCurve, ptPoint, ptLabel }
    public enum FontType { ftLabel }

    public interface IEuclidSite
    {
        Graphics GetGraphics();
        Pen GetPen(PenType type);
        Font GetFont(FontType type);
        void OutputText(string Text);
        IElement GetLabeledElement(string Label);

        int Radius { get; set; }
    }

    public interface IAskableEuclidSide : IEuclidSite
    {
        void AskForLine(IElement me);
    }

    public interface IElement
    {
        string Type{get;}
        string Label{get;}
        string Comment { get;}

        void Execute(IEuclidSite site, ref int Part);
        Point GetRelativePoint(IEuclidSite site, string where);
        Point GetPointOn(IEuclidSite site, int which); /* gets point and which% of object */
        double IsPointOn(IEuclidSite site, Point point);
        Point GetIntersection(IEuclidSite site, IElement element);
        int GetLength();
    }

    public interface ILineAskingElement : IElement
    {
        void ResponseWithLine(Point P1, Point P2);
    }
}
