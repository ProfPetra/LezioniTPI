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
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    /// 

        /*! \file WpfApplication10
            \author P. P.
            \version 0.0
            \date 10/04/2017
        */
    public partial class MainWindow : Window
    {
        public Cella prova = new Cella(3,3);

        public Random rnd = new Random();

        public Campo c = new Campo(8);
        public MainWindow()
        {
            InitializeComponent();

            c.generaBomba(10,rnd);
            c.calcolaValore();

            grid.Children.Add(c);

        }
    }
}
