using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChessKrot
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        Figure figure;
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            
            
            InitializeComponent();
            
            DataContext = new MainVM();

            BoardChess.MouseLeftButtonDown += canvasClick;
            

            List<Figure> allFigures = new List<Figure>();
            //
            allFigures.Add(new Figure(Types.BKing, true, new Point { X = 4, Y = 7 }));
            allFigures.Add(new Figure(Types.WKing, true, new Point { X = 4, Y = 0 }));

            //
            allFigures.Add(new Figure(Types.BQueen, true, new Point { X = 3, Y = 7 }));
            allFigures.Add(new Figure(Types.WQueen, true, new Point { X = 3, Y = 0 }));
            
            //
            allFigures.Add(new Figure(Types.BBishop, true, new Point { X = 2, Y = 7 }));
            allFigures.Add(new Figure(Types.BBishop, true, new Point { X = 5, Y = 7 }));

            allFigures.Add(new Figure(Types.WBishop, true, new Point { X = 2, Y = 0 }));
            allFigures.Add(new Figure(Types.WBishop, true, new Point { X = 5, Y = 0 }));

            //
            allFigures.Add(new Figure(Types.BKnight, true, new Point { X = 1, Y = 7 }));
            allFigures.Add(new Figure(Types.BKnight, true, new Point { X = 6, Y = 7 }));

            allFigures.Add(new Figure(Types.WKnight, true, new Point { X = 1, Y = 0 }));
            allFigures.Add(new Figure(Types.WKnight, true, new Point { X = 6, Y = 0 }));

            //
            allFigures.Add(new Figure(Types.BRook, true, new Point { X = 0, Y = 7 }));
            allFigures.Add(new Figure(Types.BRook, true, new Point { X = 7, Y = 7 }));

            allFigures.Add(new Figure(Types.WRook, true, new Point { X = 0, Y = 0 }));
            allFigures.Add(new Figure(Types.WRook, true, new Point { X = 7, Y = 0 }));

            //
            allFigures.Add(new Figure(Types.BPawn, true, new Point { X = 0, Y = 6 }));
            allFigures.Add(new Figure(Types.BPawn, true, new Point { X = 1, Y = 6 }));
            allFigures.Add(new Figure(Types.BPawn, true, new Point { X = 2, Y = 6 }));
            allFigures.Add(new Figure(Types.BPawn, true, new Point { X = 3, Y = 6 }));
            allFigures.Add(new Figure(Types.BPawn, true, new Point { X = 4, Y = 6 }));
            allFigures.Add(new Figure(Types.BPawn, true, new Point { X = 5, Y = 6 }));
            allFigures.Add(new Figure(Types.BPawn, true, new Point { X = 6, Y = 6 }));
            allFigures.Add(new Figure(Types.BPawn, true, new Point { X = 7, Y = 6 }));

            allFigures.Add(new Figure(Types.WPawn, true, new Point { X = 0, Y = 1 }));
            allFigures.Add(new Figure(Types.WPawn, true, new Point { X = 1, Y = 1 }));
            allFigures.Add(new Figure(Types.WPawn, true, new Point { X = 2, Y = 1 }));
            allFigures.Add(new Figure(Types.WPawn, true, new Point { X = 3, Y = 1 }));
            allFigures.Add(new Figure(Types.WPawn, true, new Point { X = 4, Y = 1 }));
            allFigures.Add(new Figure(Types.WPawn, true, new Point { X = 5, Y = 1 }));
            allFigures.Add(new Figure(Types.WPawn, true, new Point { X = 6, Y = 1 }));
            allFigures.Add(new Figure(Types.WPawn, true, new Point { X = 7, Y = 1 }));
            //

            foreach (var f in allFigures)
            {
                UpdateCanvasPosition(f);
                f.Control.MouseLeftButtonDown += Control_MouseLeftButtonDown;
                f.Control.Tag = f;//.Control.Focusable
                BoardChess.Children.Add(f.Control);
                
            }
        }
         
        private void canvasClick(object sender, MouseButtonEventArgs e)
        {
            var point = e.GetPosition((Canvas)sender);
           
            int xId = (int)point.X / 72;
            int yId = (int)point.Y / 72;

            Move(xId, yId);

        }

        void Move(int x, int y)
        {
            if (selected == null) return;

            selected.TablePosition = new Point { X = x, Y = y };
            UpdateCanvasPosition(selected);
            //прописать  условие.если black = true, когда ходят black = false, то есть можно только true. 
            
            selected = null;// оннулирование любой выбранной фигуры при ходе.
        }

        private void UpdateCanvasPosition(Figure f)
        {
            Canvas.SetTop(f.Control, f.CanvasPosition.Y);
            Canvas.SetLeft(f.Control, f.CanvasPosition.X);
        }

        Figure selected = null;
        private void Control_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image img = sender as Image;

            if (img == null)
                return;
            Figure f = (Figure)img.Tag;
            selected = f;
           
            //MessageBox.Show(f.Type.ToString());
            e.Handled = true; // прерывает передачу клика дальнейшим компонентам (канвасу под картинкой)

            
        }

        
    }

}
