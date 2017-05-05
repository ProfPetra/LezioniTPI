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
    public class Pezzo:Image
    {
        public string nome { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public string colore;


        public Pezzo(int x_,int y_) {

            nome = "Alfiero";
            colore = "Nero";

            //Settiamo l'immagine
            VerticalAlignment = VerticalAlignment.Top;
            HorizontalAlignment = HorizontalAlignment.Left;
            Width = 50;
            Height = 50;
            Margin = new Thickness(0, 0, 0, 0);
            

            Source = new BitmapImage(new Uri(@"img/Mushroom_1.png", UriKind.Relative));


        }

        public void distruttore() {
            nome = "";
            colore = "";
            Source = null;

        }

        public bool spostamento(int xArrivo,int yArrivo) {
            bool sposta = false;

            if (yArrivo == y + 1) {

                sposta = true;
            }


            return sposta;
        }

    }
}
