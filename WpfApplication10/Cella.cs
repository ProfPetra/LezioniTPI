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



namespace WpfApplication10
{
    //! \class Cella
    //! \brief classe del bottono elementare del campo minato
   public  class Cella:Button
    {
        //! \var value
        //! \brief Variabile che indica il valore delle bombe vicine. Il valore -1 indica una bomba

        //! \var x
        //! \brief variabile che indica la posizione x nella matrice

        //! \var y
        //! \brief variabile che indica la posizione y nella matrice


        public int valore { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        //! \fn Cella
        //! \brief Costruttore imposta il valore della cella a 0 e le dimensioni del bottone a 50:50.
        public Cella(int x_,int y_) {

            Width = 50;
            Height = 50;
            valore = 0;
            x = x_;
            y = y_;
            Content = "";
            VerticalAlignment = VerticalAlignment.Top;
            HorizontalAlignment = HorizontalAlignment.Left;
            Margin = new Thickness(x*Width,y*Height,0,0);

        }

        public void MostraValore() {

            Content = valore;
        }

        //! \fn controllo
        //| \brief Controllo il bottone quando viene schiacciat0

        public void controllo()
        {
            //! \brief Disabilita il bottone e ne mostra il contenuto

            IsEnabled = false;
            MostraValore();

            if (valore == -1)
            {

                MessageBox.Show("hai perso");
            }
        }


    }
}
