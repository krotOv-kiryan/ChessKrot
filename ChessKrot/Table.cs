using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessKrot
{
    public class Table : IEnumerable<Cell>
{
    private readonly Cell[,] _area;

    public Types this[int row, int column]
    {
        get => _area[row, column].State;
        set => _area[row, column].State = value;
    }

    public Table()
    {
        _area = new Cell[8, 8];
        for (int i = 0; i < _area.GetLength(0); i++)
            for (int j = 0; j < _area.GetLength(1); j++)
                _area[i, j] = new Cell();
    }

    public IEnumerator<Cell> GetEnumerator()
        => _area.Cast<Cell>().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => _area.GetEnumerator();
       }
}

