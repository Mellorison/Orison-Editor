using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Diagnostics;

namespace OrisonEditor
{
    [XmlRoot("Color")]
    public struct OrisonColor
    {
        static public readonly OrisonColor Black = new OrisonColor(0, 0, 0);
        static public readonly OrisonColor White = new OrisonColor(255, 255, 255);
        static public readonly OrisonColor DefaultBackgroundColor = new OrisonColor(94, 122, 86);
        static public readonly OrisonColor DefaultGridColor = new OrisonColor(255, 240, 90);

        private const string HEX = "0123456789ABCDEF";
        private const string REGEX32 = @"^(#|0x|)([0-9a-fA-F]{8})$";
        private const string REGEX24 = @"^(#|0x|)([0-9a-fA-F]{6})$";

        [XmlAttribute]
        public byte A;
        [XmlAttribute]
        public byte R;
        [XmlAttribute]
        public byte G;
        [XmlAttribute]
        public byte B;

        public OrisonColor(Color color)
        {
            A = color.A;
            R = color.R;
            G = color.G;
            B = color.B;
        }

        public OrisonColor(byte r, byte g, byte b, byte a = 255)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }

        public OrisonColor(string color)
        {
            if (IsValid32(color))
            {
                color = removePrefix(color);

                A = (byte)(hexToByte(color[0]) * 16 + hexToByte(color[1]));
                R = (byte)(hexToByte(color[2]) * 16 + hexToByte(color[3]));
                G = (byte)(hexToByte(color[4]) * 16 + hexToByte(color[5]));
                B = (byte)(hexToByte(color[6]) * 16 + hexToByte(color[7]));
            }
            else if (IsValid24(color))
            {
                color = removePrefix(color);

                A = 255;
                R = (byte)(hexToByte(color[0]) * 16 + hexToByte(color[1]));
                G = (byte)(hexToByte(color[2]) * 16 + hexToByte(color[3]));
                B = (byte)(hexToByte(color[4]) * 16 + hexToByte(color[5]));
            }
            else
                throw new Exception("String was not properly formatted to be converted to a color!");

        }

        static private byte hexToByte(char c)
        {
            return (byte)HEX.IndexOf(char.ToUpper(c));
        }

        static private string removePrefix(string from)
        {
            string color = from;

            if (color[0] == '#')
                color = color.Substring(1);
            else if (color[0] == '0' && color[1] == 'x')
                color = color.Substring(2);

            return color;
        }

        static public bool IsValid24(string color)
        {
            return Regex.IsMatch(color, REGEX24);
        }

        static public bool IsValid32(string color)
        {
            return Regex.IsMatch(color, REGEX32);
        }

        public OrisonColor Invert()
        {
            return new OrisonColor((byte)(255 - R), (byte)(255 - G), (byte)(255 - B), A);
        }

        /*
         *  Operators
         */
        public override string ToString()
        {
            return "#" + R.ToString("X").PadLeft(2, '0') + G.ToString("X").PadLeft(2, '0') + B.ToString("X").PadLeft(2, '0');
        }

        public string ToString(bool alpha)
        {
            if (alpha)
                return "#" + A.ToString("X").PadLeft(2, '0') + R.ToString("X").PadLeft(2, '0') + G.ToString("X").PadLeft(2, '0') + B.ToString("X").PadLeft(2, '0');
            else
                return ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        static public implicit operator OrisonColor(string from)
        {
            return new OrisonColor(from);
        }

        static public implicit operator Color(OrisonColor from)
        {
            return Color.FromArgb(from.A, from.R, from.G, from.B);
        }

        static public explicit operator OrisonColor(Color from)
        {
            return new OrisonColor(from);
        }

        static public bool operator ==(OrisonColor a, OrisonColor b)
        {
            return a.A == b.A && a.R == b.R && a.G == b.G && a.B == b.B;
        }

        static public bool operator !=(OrisonColor a, OrisonColor b)
        {
            return a.A != b.A || a.R != b.R || a.G != b.G || a.B != b.B;
        }   
    }
}
