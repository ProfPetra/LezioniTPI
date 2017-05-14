using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Scacchi
{
    public class Casella : Canvas
    {
        //! \class Casella
        //! \brief Classe che simula la casella degli scacchi

        public int x { get; set; }
        public int y { get; set; }
        public Pezzo s { get; set; }

        public Casella(int x_, int y_) {

            x = x_;
            y = y_;


            VerticalAlignment = VerticalAlignment.Top;
            HorizontalAlignment = HorizontalAlignment.Left;
            Width = 50;
            Height = 50;
            // Margin = new Thickness(x*Width,y*Height,0,0);

            //! \note
            int indice = x + (y);

            if (indice % 2 == 0)
            {
                Background = Brushes.White;
            }
            else {
                Background = Brushes.BlanchedAlmond;

            }

            s = new Pezzo(x,y);


        }

        public void resetCasella() {
            int indice = x + (y);

            if (indice % 2 == 0)
            {
                Background = Brushes.White;
            }
            else
            {
                Background = Brushes.BlanchedAlmond;

            }

        }

        public void InserisciPezzo(Pezzo p) {

            Children.Remove(s);
            s = p;
            s.x = x;
            s.y = y;
            Children.Add(s);

        }

        public Pezzo restituisciPezzo() {

            Children.Remove(s);
            return s;
        }

        public void cancellaPezzo()
        {
            Children.Remove(s);
            s = new Pezzo(x,y);
            Children.Add(s);

        }


    }
}
