/* Euclid# - Euclidean Geometry Constructions Simulator 
 * 
 * Copyright (c) 2006 Krzysztof Olczyk
 * 
 * Program written for Programming Project Course
 * at Technical University of Lodz, Fall 2006
 * 
 */

using System.Configuration;
using System.Drawing;

namespace Euclid
{

    public static class GeneralConfig
    {
        public static int DimX = 500;
        public static int DimY = 500;
    }

    public sealed class EuclidesConfigGeneral : ConfigurationSection
    {
        public EuclidesConfigGeneral()
        {
            SectionInformation.ForceSave = true;
            SectionInformation.AllowDefinition = ConfigurationAllowDefinition.Everywhere;
            SectionInformation.AllowExeDefinition = ConfigurationAllowExeDefinition.MachineToApplication;
        }

        [ConfigurationProperty("animdelay", DefaultValue = 900)]
        public int AnimDelay
        {
            get
            {
                return (int)this["animdelay"];
            }
            set
            {
                this["animdelay"] = value;
            }
        }

        [ConfigurationProperty("lastopened", DefaultValue = "", IsRequired = true)]
        public string LastOpened
        {
            get
            {
                return (string)this["lastopened"];
            }
            set
            {
                this["lastopened"] = value;
            }
        }

        [ConfigurationProperty("animated", DefaultValue = true, IsRequired = true)]
        public bool Animated
        {
            get
            {
                return (bool)this["animated"];
            }
            set
            {
                this["animated"] = value;
            }
        }

        string FontToStr(Font font)
        {
            return string.Format("{0}:{1}:{2}:{3}:{4}:{5}", font.FontFamily.GetName(0), font.Size, font.Bold, font.Italic, font.Strikeout, font.Underline);
        }

        FontStyle MaskStyle(FontStyle fs, string mask)
        {
            return System.Convert.ToBoolean(mask) ? fs : FontStyle.Regular;
        }

        Font StrToFont(string str)
        {
            if (str == "")
                return new Font("Verdana", 12);
            string[] elements = str.Split(':');
            return new Font(elements[0], (float)System.Convert.ToDouble(elements[1]),
                MaskStyle(FontStyle.Bold, elements[2]) | 
                MaskStyle(FontStyle.Italic, elements[3]) | 
                MaskStyle(FontStyle.Strikeout, elements[4]) |
                MaskStyle(FontStyle.Underline, elements[5]));
        }

        [ConfigurationProperty("label_font", DefaultValue = "", IsRequired = true)]
        private string _LabelFont
        {
            get
            {
                return (string)this["label_font"];
            }
            set
            {
                this["label_font"] = value;
            }
        }

        public Font LabelFont
        {
            get
            {
                return StrToFont(_LabelFont);
            }
            set
            {
                _LabelFont = FontToStr(value);
            }
        }

        [ConfigurationProperty("label_color", DefaultValue = null, IsRequired = true)]
        public Color LabelColor
        {
            get
            {
                return ((Color)(this["label_color"]) != Color.Empty) ? (Color)this["label_color"] : Color.Navy;
            }
            set
            {
                this["label_color"] = value;
            }
        }

        [ConfigurationProperty("comment_font", DefaultValue = "Arial:12:True:False:False:False", IsRequired = true)]
        private string _CommentFont
        {
            get
            {
                return (string)this["comment_font"];
            }
            set
            {
                this["comment_font"] = value;
            }
        }

        public Font CommentFont
        {
            get
            {
                return StrToFont(_CommentFont);
            }
            set
            {
                _CommentFont = FontToStr(value);
            }
        }

        [ConfigurationProperty("comment_color", DefaultValue = null, IsRequired = true)]
        public Color CommentColor
        {
            get
            {
                return ((Color)(this["comment_color"]) != Color.Empty) ? (Color)this["comment_color"] : Color.Black;
            }
            set
            {
                this["comment_color"] = value;
            }
        }

        [ConfigurationProperty("line_color", DefaultValue = null, IsRequired = true)]
        public Color LineColor
        {
            get
            {
                return ((Color)(this["line_color"]) != Color.Empty) ? (Color)this["line_color"] : Color.Black;
            }
            set
            {
                this["line_color"] = value;
            }
        }

        [ConfigurationProperty("line_width", DefaultValue = 2, IsRequired = true)]
        public int LineWidth
        {
            get
            {
                return (int)this["line_width"];
            }
            set
            {
                this["line_width"] = value;
            }
        }

        [ConfigurationProperty("arc_color", DefaultValue = null, IsRequired = true)]
        public Color ArcColor
        {
            get
            {
                return ((Color)(this["arc_color"]) != Color.Empty) ? (Color)this["arc_color"] : Color.Black;
            }
            set
            {
                this["arc_color"] = value;
            }
        }

        [ConfigurationProperty("arc_width", DefaultValue = 2, IsRequired = true)]
        public int ArcWidth
        {
            get
            {
                return (int)this["arc_width"];
            }
            set
            {
                this["arc_width"] = value;
            }
        }

        [ConfigurationProperty("point_color", DefaultValue = null, IsRequired = true)]
        public Color PointColor
        {
            get
            {
                return ((Color)(this["point_color"]) != Color.Empty) ? (Color)this["point_color"] : Color.Red;
            }
            set
            {
                this["point_color"] = value;
            }
        }

        [ConfigurationProperty("point_width", DefaultValue = 4, IsRequired = true)]
        public int PointWidth
        {
            get
            {
                return (int)this["point_width"];
            }
            set
            {
                this["point_width"] = value;
            }
        }

    }
}
