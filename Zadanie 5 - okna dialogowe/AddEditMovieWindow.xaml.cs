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
using System.Windows.Shapes;

namespace Zadanie_5___okna_dialogowe
{
    /// <summary>
    /// Interaction logic for AddEditMovieWindow.xaml
    /// </summary>
    public partial class AddEditMovieWindow : Window
    {
        private Movie movieToAdd { get; set; }

        public AddEditMovieWindow()
        {
            InitializeComponent();
        }

        public AddEditMovieWindow(Movie movie)
        {

        }
    }
}
