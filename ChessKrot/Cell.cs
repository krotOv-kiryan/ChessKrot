using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessKrot
{
    public class Cell : NotifyPropertyChanged
    {
        private State _state;
        private bool _active;

        public State State
        {
            get => _state;
            set
            {
                _state = value;
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
