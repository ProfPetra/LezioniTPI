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

    //! \class Campo
    //! \brief Aggregato di Celle simula il campo di gioco

        
   public class Campo:Canvas
    {
        //! \var matrice
        //! \brief Matrice di celle 
        public Cella[,] matrice;

        public int gran;
        //! \fn Campo
        //! \brief Prende in ingresso la grandezza della matrice
        public Campo(int grandezza) {

            gran = grandezza;

            matrice = new Cella[grandezza, grandezza];
            
            Width = grandezza * 50;
            Height = grandezza * 50;
            HorizontalAlignment = HorizontalAlignment.Left;
            VerticalAlignment = VerticalAlignment.Top;


            for (int x = 0; x < grandezza; x++) {
                for (int y = 0; y < grandezza; y++) {

                    matrice[x, y] = new Cella(x, y);

                    matrice[x, y].Click += Campo_Click;

                   // matrice[x, y].MostraValore();

                    Children.Add(matrice[x, y]);

                }
            }

            
            
        }

        private void Campo_Click(object sender, RoutedEventArgs e)
        {
            Cella c = (Cella)sender;

            c.controllo();
            if (c.valore == 0) { 
            espandi(c.x, c.y);
            }

        }

        public void espandi(int x_,int y_) {

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (x_ + i >= 0 && x_ + i < gran && y_ + j >= 0 && y_ + j < gran)

                    {
                        
                        if (matrice[x_ + i, y_ + j].valore == 0 && matrice[x_ + i, y_ + j].IsEnabled)
                        {

                            matrice[x_ + i, y_ + j].controllo();
                            
                            espandi(x_ + i, y_ + j);

                        }

                        if (matrice[x_ + i, y_ + j].valore > 0 )
                        {

                            matrice[x_ + i, y_ + j].controllo();
                            

                        }




                    }

                }

            }




        }
        public void refresh() {
            Children.Clear();

            for (int x = 0; x < gran; x++)
            {
                for (int y = 0; y < gran; y++)
                {

                

                    Children.Add(matrice[x, y]);

                }
            }

        }
        public void generaBomba(int nBombe,Random rnd) {

            for (int i = 0; i < nBombe; i++) { 
            int xBomba = rnd.Next(gran);
            int yBomba = rnd.Next(gran);

                if (matrice[xBomba, yBomba].valore != -1)
                {

                    matrice[xBomba, yBomba].valore = -1;
                    matrice[xBomba, yBomba].MostraValore();


                }
                else {
                    i--;
                }
              

            }
            //  refresh();


        }
        //! \fn calcolaValore
        //! \brief Una volta assegnata le bombe calcola i valori delle caselle cirdostanti
        public void calcolaValore() {

            //! \note Ciclo su tutte le caselle
            for (int x = 0; x < gran; x++)
            {
                for (int y = 0; y < gran; y++)
                {

                    //! \note verifico che la casella non sia una bomba
                    if (matrice[x, y].valore != -1)
                    {

                        //! \note controllo le caselle adiacenti
                        for (int i = -1; i <= 1; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
                                int XNuova = x + i;
                                int yNuova = y + j;
                                //! \note controllo l'indice della matrice
                                if ((XNuova >= 0 && XNuova < gran) && (yNuova >= 0 && yNuova < gran))
                                {
                                    if (matrice[XNuova, yNuova].valore == -1) {

                                        matrice[x,y].valore++;
                                    }

                                }

                            }

                        }
                    }
                    matrice[x,y].MostraValore();

                }

            }
            

            
            }


      
        

   

}
}

        
 