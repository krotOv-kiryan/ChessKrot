using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessKrot
{
    public class Cell : NotifyPropertyChanged
    {
        private Types _types;
        private bool _active;

        public Types Types
        {
            get => _types;
            set
            {
                _types = value;
                OnPropertyChanged(); // если значение поменялось, то сообщаем интерфейсу, чтобы он перерисовался в этом месте
            }
        }
        public bool Active // ? ячейка выделена пользователем
        {
            get => _active;
            set
            {
                _active = value;
                OnPropertyChanged();
            }
        }
    }
}
