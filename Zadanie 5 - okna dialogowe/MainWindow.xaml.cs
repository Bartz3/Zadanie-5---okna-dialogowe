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
using 
namespace Zadanie_5___okna_dialogowe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Movie> movies;
        public MainWindow()
        {
            InitializeComponent();
            movies= new List<Movie>();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            movies.Add(new Movie());
            MovieListBox.SelectedIndex = movies.Count - 1;

            AddEditMovieWindow addEditFilmWindow = new AddEditMovieWindow();

            if (addEditFilmWindow.ShowDialog() == true)
            {
                movies.Add(addEditFilmWindow);
                RefreshList();
            }

        }

        private void RefreshList()
        {
            MovieListBox.Items.Clear();
            foreach (Movie film in movies)
            {
                MovieListBox.Items.Add(film.Title);
            }

        }
    }
}
