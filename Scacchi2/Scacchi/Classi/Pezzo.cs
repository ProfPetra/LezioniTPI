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

        public Pezzo()
        {

            nome = "vuoto";
            colore = "vuoto";
            

            //Settiamo l'immagine
            VerticalAlignment = VerticalAlignment.Top;
            HorizontalAlignment = HorizontalAlignment.Left;
            Width = 50;
            Height = 50;
            Margin = new Thickness(0, 0, 0, 0);


            Source = null;

        }

        public Pezzo(int x_,int y_) {

            nome = "vuoto";
            colore = "vuoto";

            x = x_;
            y = y_;

            //Settiamo l'immagine
            VerticalAlignment = VerticalAlignment.Top;
            HorizontalAlignment = HorizontalAlignment.Left;
            Width = 50;
            Height = 50;
            Margin = new Thickness(0, 0, 0, 0);


            Source = null;

        }




        

        public virtual List<Point> spostamento(Casella Arrivo) {
            List<Point> percorso = new List<Point>();
            

            return percorso;


        }

    }

    public class Bishop : Pezzo
    {
        public Bishop(int x_, int y_,string c_)
        {

            x = x_;
            y = y_;
            nome = "bishop";
            colore = c_;

            VerticalAlignment = VerticalAlignment.Top;
            HorizontalAlignment = HorizontalAlignment.Left;
            Width = 50;
            Height = 50;
            Margin = new Thickness(0, 0, 0, 0);
            Source = new BitmapImage(new Uri(@"img/chess_piece_2_" + colore + "_" + nome + ".png", UriKind.Relative));


        }
        
        public override List<Point> spostamento(Casella Arrivo)
        {
            List<Point> percorso = new List<Point>();
            //Percorso Alfiere

            int dx = 0;
            if (Arrivo.x > x)
            {
                dx = 1;
            }
            else {
                dx = -1;
            }

            int dy = 0;
            if (Arrivo.y > y)
            {
                dy = 1;
            }
            else
            {
                dy = -1;
            }

            if (Math.Abs(x - Arrivo.x) == Math.Abs(y - Arrivo.y))
            {
                int minY = Math.Min(y, Arrivo.y);
                int maxY = Math.Max(y, Arrivo.y);


                int minX = Math.Min(x, Arrivo.x);
                int maxX = Math.Max(x, Arrivo.x);

                for (int i = 1; i <= Math.Abs(x - Arrivo.x); i++)
                {

                    Point punto = new Point(x+(i* dx), y+(i* dy));
                    percorso.Add(punto);

                }


            }
            

            return percorso;

        }


    }


    public class Knight : Pezzo
    {
        public Knight(int x_, int y_, string c_)
        {

            x = x_;
            y = y_;
            nome = "knight";
            colore = c_;

            VerticalAlignment = VerticalAlignment.Top;
            HorizontalAlignment = HorizontalAlignment.Left;
            Width = 50;
            Height = 50;
            Margin = new Thickness(0, 0, 0, 0);
            Source = new BitmapImage(new Uri(@"img/chess_piece_2_" + colore + "_" + nome + ".png", UriKind.Relative));


        }

        public override List<Point> spostamento(Casella Arrivo)
        {
            List<Point> percorso = new List<Point>();
            //Percorso Cavallo
            int dx = Math.Abs(Arrivo.x - x);
            int dy = Math.Abs(Arrivo.y - y);


            if (dx > 0 && dx < 4 && dy > 0 && dy < 4) {

                
                percorso.Add(new Point(Arrivo.x,Arrivo.y));



            }

            return percorso;

        }


    }

    public class King : Pezzo
    {
        public King(int x_, int y_, string c_)
        {

            x = x_;
            y = y_;
            nome = "king";
            colore = c_;

            VerticalAlignment = VerticalAlignment.Top;
            HorizontalAlignment = HorizontalAlignment.Left;
            Width = 50;
            Height = 50;
            Margin = new Thickness(0, 0, 0, 0);
            Source = new BitmapImage(new Uri(@"img/chess_piece_2_" + colore + "_" + nome + ".png", UriKind.Relative));


        }

        public override List<Point> spostamento(Casella Arrivo)
        {
            List<Point> percorso = new List<Point>();
            //Percorso Re
            int dx = Math.Abs(Arrivo.x - x);
            int dy = Math.Abs(Arrivo.y - y);


            if (dx<=1 && dy <=1)
            {
                percorso.Add(new Point(Arrivo.x, Arrivo.y));
            }

            return percorso;

        }


    }

    public class Pawn : Pezzo
    {
        int direzione { get; set; }
        bool primoSpostamento { get; set; }
        public Pawn(int x_, int y_, string c_)
        {

            x = x_;
            y = y_;
            nome = "pawn";
            colore = c_;

            if (colore == "white")
            {
                direzione = -1;
            }
            else {
                direzione = 1;
            }


            primoSpostamento = true;
            


            VerticalAlignment = VerticalAlignment.Top;
            HorizontalAlignment = HorizontalAlignment.Left;
            Width = 50;
            Height = 50;
            Margin = new Thickness(5, 0, 0, 0);
            Source = new BitmapImage(new Uri(@"img/chess_piece_2_" + colore + "_" + nome + ".png", UriKind.Relative));


        }

        public override List<Point> spostamento(Casella Arrivo)
        {
            List<Point> percorso = new List<Point>();
            //Percorso Pedone
            int dx = Math.Abs(Arrivo.x - x);
            int dy = (Arrivo.y - y);


            if (dy == direzione && dx == 0 && Arrivo.s.nome=="vuoto")
            {
                percorso.Add(new Point(Arrivo.x, Arrivo.y));
            }

            if (dy == direzione*2 && dx == 0 && primoSpostamento)
            {
                percorso.Add(new Point(x, y+direzione));

                percorso.Add(new Point(Arrivo.x, Arrivo.y));
            }

            if (dy == direzione && dx == 1 && Arrivo.s.nome!="vuoto")
            {
                percorso.Add(new Point(Arrivo.x, Arrivo.y));
            }


            if (primoSpostamento)
            {
                primoSpostamento = false;
            }


            return percorso;

        }


    }


    public class Queen : Pezzo
    {
        public Queen(int x_, int y_, string c_)
        {

            x = x_;
            y = y_;
            nome = "queen";
            colore = c_;

            VerticalAlignment = VerticalAlignment.Top;
            HorizontalAlignment = HorizontalAlignment.Left;
            Width = 50;
            Height = 50;
            Margin = new Thickness(0, 0, 0, 0);
            Source = new BitmapImage(new Uri(@"img/chess_piece_2_" + colore + "_" + nome + ".png", UriKind.Relative));


        }

        public override List<Point> spostamento(Casella Arrivo)
        {
            List<Point> percorso = new List<Point>();
            //Percorso Regina= Percorso torre + percorso alfiere

            //Percorso Torre
            if (x == Arrivo.x)
            {


                int min = Math.Min(y, Arrivo.y);
                int max = Math.Max(y, Arrivo.y);

                for (int i = min + 1; i <= max; i++)
                {

                    Point punto = new Point(x, i);
                    percorso.Add(punto);

                }

            }
            //Percorso Orizzontale
            if (y == Arrivo.y)
            {


                int min = Math.Min(x, Arrivo.x);
                int max = Math.Max(x, Arrivo.x);

                for (int i = min + 1; i <= max; i++)
                {

                    Point punto = new Point(i, y);
                    percorso.Add(punto);

                }

            }


            //Percorso Alfiere
            int dx = 0;
            if (Arrivo.x > x)
            {
                dx = 1;
            }
            else
            {
                dx = -1;
            }

            int dy = 0;
            if (Arrivo.y > y)
            {
                dy = 1;
            }
            else
            {
                dy = -1;
            }

            if (Math.Abs(x - Arrivo.x) == Math.Abs(y - Arrivo.y))
            {
                int minY = Math.Min(y, Arrivo.y);
                int maxY = Math.Max(y, Arrivo.y);


                int minX = Math.Min(x, Arrivo.x);
                int maxX = Math.Max(x, Arrivo.x);

                for (int i = 1; i <= Math.Abs(x - Arrivo.x); i++)
                {

                    Point punto = new Point(x + (i * dx), y + (i * dy));
                    percorso.Add(punto);

                }


            }


            return percorso;

        }


    }





    public class Rook : Pezzo
    {
        public Rook(int x_,int y_, string c_) {

            x = x_;
            y = y_;
            nome = "rook";
            colore = c_;

            VerticalAlignment = VerticalAlignment.Top;
            HorizontalAlignment = HorizontalAlignment.Left;
            Width = 50;
            Height = 50;
            Margin = new Thickness(0, 0, 0, 0);
            Source = new BitmapImage(new Uri(@"img/chess_piece_2_"+colore+"_"+nome+".png",UriKind.Relative));


        }

       

        public override List<Point> spostamento(Casella Arrivo)
        {
            List<Point> percorso = new List<Point>();
              //Percorso torre
              if (x == Arrivo.x) {


                  int min = Math.Min(y, Arrivo.y);
                  int max = Math.Max(y, Arrivo.y);

                      for (int i = min+1; i <= max; i++) {

                          Point punto = new Point(x,i);
                          percorso.Add(punto);

                      }

              }
              //Percorso Orizzontale
              if (y == Arrivo.y)
              {


                  int min = Math.Min(x, Arrivo.x);
                  int max = Math.Max(x, Arrivo.x);

                  for (int i = min + 1; i <= max; i++)
                  {

                      Point punto = new Point(i, y);
                      percorso.Add(punto);

                  }

              }
    
            return percorso;
            
        }


    }
}


