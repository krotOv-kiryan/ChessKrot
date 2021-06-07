using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace ChessKrot
{
    internal class MainVM : NotifyPropertyChanged
    {
        private Table _board = new Table();
      

        private void SetupTable()
        {
            Table table = new Table();

            table[0, 0] = Types.BlackRook;
            table[0, 1] = Types.BlackKnight;
            table[0, 2] = Types.BlackBishop;
            table[0, 3] = Types.BlackQueen;
            table[0, 4] = Types.BlackKing;
            table[0, 5] = Types.BlackBishop;
            table[0, 6] = Types.BlackKnight;
            table[0, 7] = Types.BlackRook;

            for (int i = 0; i < 8; i++)
            {
                table[1, i] = Types.BlackPawn;
                table[6, i] = Types.WhitePawn;
            }

            table[7, 0] = Types.WhiteRook;
            table[7, 1] = Types.WhiteKnight;
            table[7, 2] = Types.WhiteBishop;
            table[7, 3] = Types.WhiteQueen;
            table[7, 4] = Types.WhiteKing;
            table[7, 5] = Types.WhiteBishop;
            table[7, 6] = Types.WhiteKnight;
            table[7, 7] = Types.WhiteRook;

            table = table;
        }

        public MainVM()
        {


        }
    }
}