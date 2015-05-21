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
using System.Drawing;

namespace Euclid
{
    class HTMLexporter : IEuclidSite
    {
        private EucasmParser.ParsedEucasmCode construction;
        private LinkedListNode<IElement> current_element;
        private StreamWriter htmlwriter;
        private int fRadius;
        private Bitmap fCanvas;
        private bool fTextRecently;
        private int fImageCounter;
        private string SubDir;
        private string SubDirFull;
        private EuclidesConfigGeneral ecg;

        public HTMLexporter(string AFileName, string ATitle, EucasmParser.ParsedEucasmCode AConstruction, EuclidesConfigGeneral ECG)
        {
            string[] PName = AFileName.Split(new char[] {'\\', '/', '.'});
            string StemName = PName[PName.Length - 2];
            string Path = String.Join("/", PName, 0, PName.Length - 2);
            SubDir = String.Format("{0}_files", StemName);
            SubDirFull = String.Format("{0}/{1}/", Path, SubDir);

            Directory.CreateDirectory(SubDirFull);

            using (StreamWriter style = new StreamWriter(SubDirFull + "style.css"))
            {
                style.Write(global::Euclid.Properties.Resources.css_style);
                style.Close();
            }

            htmlwriter = new StreamWriter(AFileName);
            htmlwriter.WriteLine(String.Format(global::Euclid.Properties.Resources.html_top, ATitle, SubDir));
            htmlwriter.Flush();

            fCanvas = new Bitmap(GeneralConfig.DimX, GeneralConfig.DimY);
            fImageCounter = 0;

            construction = AConstruction;
            current_element = construction.elements.First;
            if (current_element != null && current_element.Value.Type == "Text")
                current_element = current_element.Next;
            fTextRecently = true;

            ecg = ECG;
        }

        public void Go()
        {
            while (current_element != null)
            {
                int partlevel = 100;
                current_element.Value.Execute(this as IEuclidSite, ref partlevel);
                current_element = current_element.Next;
            }

            htmlwriter.Write(String.Format(global::Euclid.Properties.Resources.step, "<br/><h2> Final result: </h2>"));
            OutputImage();
            AboutBox ab = new AboutBox();
            htmlwriter.WriteLine(String.Format(global::Euclid.Properties.Resources.html_bottom, ab.AssemblyProduct, ab.AssemblyVersion));
            htmlwriter.Flush();
            htmlwriter.Close();
        }

        private void OutputImage()
        {
            fCanvas.Save(String.Format("{0}/step{1}.png", SubDirFull, fImageCounter));
            htmlwriter.Write(String.Format(global::Euclid.Properties.Resources.step, String.Format("<img src=\"{0}/step{1}.png\" class=\"img\" />", SubDir, fImageCounter)));
            fImageCounter++;
        }

        public Graphics GetGraphics()
        {
            fTextRecently = false;
            return Graphics.FromImage(fCanvas);
        }

        public Pen GetPen(PenType type)
        {
            switch (type)
            {
                case PenType.ptPoint:
                    return new Pen(ecg.PointColor, ecg.PointWidth);
                case PenType.ptLabel:
                    return new Pen(ecg.LabelColor, 1);
                case PenType.ptLine:
                    return new Pen(ecg.LineColor, ecg.LineWidth);
                case PenType.ptCurve:
                    return new Pen(ecg.ArcColor, ecg.ArcWidth);
                default:
                    return new Pen(Color.Black, 2);
            }
        }

        public Font GetFont(FontType type)
        {
            return ecg.LabelFont;
        }

        public void OutputText(string Text)
        {
            if (!fTextRecently)
                OutputImage();

            htmlwriter.Write(String.Format(global::Euclid.Properties.Resources.step, Text));

            fTextRecently = true;
        }

        public IElement GetLabeledElement(string Label)
        {
            IElement res;
            if (construction.labels.TryGetValue(Label, out res))
               return res;
            else
               return null;
        }

        public int Radius 
        {
            get
            {
                return fRadius;
            }
            set
            {
                fRadius = value;
            }
        }

    }
}
