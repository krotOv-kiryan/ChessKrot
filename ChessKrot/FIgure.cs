using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ChessKrot
{
    public class Figure
    {
        public Point CanvasPosition 
        { get => new Point { X = TablePosition.X * 72,
            Y = TablePosition.Y * 72 }; }

        public Point TablePosition { get; set; }
        public Types Type { get; set; }
        public bool Black { get; set; }

        public System.Windows.Controls.Image Control { get; set; } 
            = new System.Windows.Controls.Image();

        public Figure(Types type, bool black, Point point)
        {
            Type = type;
            Black = black;
            TablePosition = point;

            string path = Environment.CurrentDirectory;

            switch (Type)
            {
                case Types.BQueen: path += "/Images/bqueen.png"; break;
                case Types.BRook: path += "/Images/brook.png"; break;
                case Types.BKnight: path += "/Images/bknight.png"; break;
                case Types.BBishop: path += "/Images/bbishop.png"; break;
                case Types.BKing: path += "/Images/bking.png"; break;
                case Types.BPawn: path += "/Images/bpawn.png"; break;

                case Types.WQueen: path += "/Images/wqueen.png"; break;
                case Types.WKing: path += "/Images/wking.png"; break;
                case Types.WRook: path += "/Images/wrook.png"; break;
                case Types.WKnight: path += "/Images/wknight.png"; break;
                case Types.WPawn: path += "/Images/wpawn.png"; break;
                case Types.WBishop: path += "/Images/wbishop.png"; break;
            }
            Control.Width = 72;
            Control.Height = 72;
            Control.Stretch = Stretch.Uniform;
            Control.Source = new BitmapImage(new Uri(path));
            
        }
    }
}
