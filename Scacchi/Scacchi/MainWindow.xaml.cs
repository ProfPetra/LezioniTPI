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
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Casella[,] scacchiera = new Casella[8,8];
        Casella partenza;
        Casella Arrivo;
        
        public MainWindow()
        {
            InitializeComponent();

            for (int y = 0; y < 8; y++) {
                for (int x = 0; x < 8; x++)
                {
                    scacchiera[x, y] = new Casella(x, y);

                    scacchiera[x, y].MouseDown += MainWindow_MouseDown;

                    pannel.Children.Add(scacchiera[x, y]);
                }
                
            }

            scacchiera[4, 3].InserisciPezzo(new Pezzo(4,3));

        }

        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Casella c = sender as Casella;

            MessageBox.Show("MouseDown e in scacchiera");

            if (Arrivo != null && partenza != null)
            {
                
                partenza = null;
                Arrivo = null;
                
            }


            if (Arrivo == null && partenza != null)
            {
                Arrivo = c;

                c.Background = Brushes.Purple;
            }


            if (Arrivo == null && partenza == null) {
                partenza = c;

                c.Background = Brushes.Gold;
            }
            

            /*if (c.s != null)
            {
                c.s.distruttore();
            }*/




        }
    }
}
