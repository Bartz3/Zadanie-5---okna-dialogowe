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

namespace Zadanie_5___okna_dialogowe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Movie> movies;
        public MoviePreviewWindow previewWindow;

        public MainWindow()
        {
            InitializeComponent();
            movies= new List<Movie>();
            InitializeData();

        }

        public void InitializeData()
        {
            var movie1 = new Movie() { Title = "Test123", Description = "DESCRIPTION", ReleaseDate = new DateTime(2022, 1, 1) };
            var movie2 = new Movie() { Title = "GoodMovie", Description = "BestMovie", ReleaseDate = new DateTime(2013, 5, 7) };
            var movie3 = new Movie() { Title = "halo", Description = "dfdfd", ReleaseDate = new DateTime(2012, 12, 9) };
            movies.Add(movie1);
            movies.Add(movie2);
            movies.Add(movie3);
            RefreshList();
        }
        private void RefreshList()
        {
            MovieListBox.Items.Clear();
            foreach (Movie film in movies)
            {
                MovieListBox.Items.Add(film.Title);
            }

        }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            movies.Add(new Movie());
            MovieListBox.SelectedIndex = movies.Count - 1;

            AddEditMovieWindow addEditFilmWindow = new AddEditMovieWindow();

            if (addEditFilmWindow.ShowDialog() == true)
            {
                movies.Add((Movie)addEditFilmWindow.DataContext);
                RefreshList();
            }

        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            if (MovieListBox.SelectedIndex >= 0)
            {
                Movie selectedMovie = movies[MovieListBox.SelectedIndex];
                MessageBoxResult result = MessageBox.Show($"Czy na pewno chcesz usunąć film \"{selectedMovie.Title}\"?",
                    "Potwierdzenie usunięcia", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    movies.RemoveAt(MovieListBox.SelectedIndex);
                    RefreshList();
                }
            }

        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            if (MovieListBox.SelectedIndex >= 0)
            {
                Movie selectedMovie = movies[MovieListBox.SelectedIndex];
                AddEditMovieWindow addEditFilmWindow = new AddEditMovieWindow(selectedMovie);

                if (addEditFilmWindow.ShowDialog() == true)
                {
                    selectedMovie.Title = addEditFilmWindow.txtTitle.Text;
                    selectedMovie.Description= addEditFilmWindow.txtDescription.Text;
                    selectedMovie.ReleaseDate = addEditFilmWindow.dtReleaseDate.SelectedDate ?? selectedMovie.ReleaseDate;

                    RefreshList();
                }
            }
            
        }

        public void PreviewClick(object sender, RoutedEventArgs e)
        {
            if (MovieListBox.SelectedIndex >= 0)
            {
                Movie selectedMovie = movies[MovieListBox.SelectedIndex];

                if (previewWindow == null)
                {
                    previewWindow = new MoviePreviewWindow(selectedMovie);
                    //previewWindow.Closed += PreviewWindowClosed;
                    //previewWindow.Owner = this;
                    previewWindow.Title = selectedMovie.Title;
                    previewWindow.Show();
                }
                else
                {
                    previewWindow.ChangeMovie(selectedMovie);
                }

            }
        }

        private void PreviewWindowClosed(object sender, EventArgs e)
        {
            previewWindow.Closed -= PreviewWindowClosed;
            previewWindow = null;
        }
    }
}
