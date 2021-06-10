using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessKrot
{
    public class Point
    {
        private int x;
        private int y;

        public int X
        {
            get => x; set
            {
                if (value <= 0)
                    value = 0;
                x = value;
            }
        }

        public int Y
        {
            get => y;
            set
            {
                if (value <= 0)
                    value = 0;
                y = value;
            }
        }
    }
}
