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
    {/*
        Casella[,] scacchiera = new Casella[8,8];
        Casella partenza;
        Casella Arrivo;*/

        Scacchiera sc = new Scacchiera();
        public MainWindow()
        {
            InitializeComponent();
            
            sc.disposizioneIniziale();

            g.Children.Add(sc);

           /* for (int y = 0; y < 8; y++) {
                for (int x = 0; x < 8; x++)
                {
                    scacchiera[x, y] = new Casella(x, y);
            

                    scacchiera[x, y].MouseDown += MainWindow_MouseDown;

                    pannel.Children.Add(scacchiera[x, y]);
                }
                
            }
            // disposizione Pezzi Neri
            scacchiera[0, 0].InserisciPezzo(new Rook(0,0,"black"));
            scacchiera[1, 0].InserisciPezzo(new Knight(1, 0, "black"));
            scacchiera[2, 0].InserisciPezzo(new Bishop(2, 0, "black"));
            scacchiera[3, 0].InserisciPezzo(new King(3, 0, "black"));
            scacchiera[4, 0].InserisciPezzo(new Queen(4, 0, "black"));
            scacchiera[5, 0].InserisciPezzo(new Bishop(5, 0, "black"));
            scacchiera[6, 0].InserisciPezzo(new Knight(6, 0, "black"));
            scacchiera[7, 0].InserisciPezzo(new Rook(7, 0, "black"));

            for (int i = 0; i < 8; i++)
            {
                scacchiera[i, 1].InserisciPezzo(new Pawn(1, i, "black"));

            }

            //Disposizione Pezzi Bianchi
            scacchiera[0, 7].InserisciPezzo(new Rook(0, 7, "white"));
            scacchiera[1, 7].InserisciPezzo(new Knight(1, 7, "white"));
            scacchiera[2, 7].InserisciPezzo(new Bishop(2, 7, "white"));
            scacchiera[3, 7].InserisciPezzo(new King(3, 7, "white"));
            scacchiera[4, 7].InserisciPezzo(new Queen(4, 7, "white"));
            scacchiera[5, 7].InserisciPezzo(new Bishop(5, 7, "white"));
            scacchiera[6, 7].InserisciPezzo(new Knight(6, 7, "white"));
            scacchiera[7, 7].InserisciPezzo(new Rook(7, 7, "white"));

            for (int i = 0; i < 8; i++)
            {
                scacchiera[i, 6].InserisciPezzo(new Pawn(6, i, "white"));

            }
            */


        }

        
        /*
        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Casella c = sender as Casella;

           // MessageBox.Show("MouseDown e in scacchiera");

            if (Arrivo != null && partenza != null)
            {

                partenza.resetCasella();
                Arrivo.resetCasella();
                //scacchiera[partenza.x,partenza.y].resetCasella();
                //scacchiera[Arrivo.x,Arrivo.y].resetCasella(); 
                partenza = null;
                Arrivo = null;
                
            }


            if (Arrivo == null && partenza != null && partenza.s.colore!=c.s.colore)
            {
                Arrivo = c;

                //if (partenza.s.nome!="vuoto")
                //{
                    List<Point> path = partenza.s.spostamento(Arrivo);

                    if (path.Count > 0 )
                    {
                       // MessageBox.Show("Spostamento Valido");

                        bool libero = true; 
                        for (int i = 0; i < path.Count - 1; i++) {

                            Point posizione = path[i];
                            if (scacchiera[Convert.ToInt32(posizione.X), Convert.ToInt32(posizione.Y)].s.nome != "vuoto") {

                                libero = false;
                                break;
                            }
                            
                        }
                        if (libero)
                        {
                            // Arrivo.InserisciPezzo(partenza.s.DuplicaPezzo());
                            Arrivo.InserisciPezzo(partenza.restituisciPezzo());
                            partenza.cancellaPezzo();
                        }
                    //}
                }

                c.Background = Brushes.Purple;
            }


            if (Arrivo == null && partenza == null && c.s.nome!="vuoto") {
                partenza = c;

                c.Background = Brushes.Gold;
            }
            
        }*/


    }
}
