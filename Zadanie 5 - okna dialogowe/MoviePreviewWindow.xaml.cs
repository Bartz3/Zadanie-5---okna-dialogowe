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
    /// Interaction logic for MoviePreviewWindow.xaml
    /// </summary>
    public partial class MoviePreviewWindow : Window
    {
        public Movie Movie
        {
            get { return (Movie)GetValue(MovieProperty); }
            set { SetValue(MovieProperty, value); }
        }
        public Movie movie2 { get; set; }

        public static readonly DependencyProperty MovieProperty =
            DependencyProperty.Register("Movie", typeof(Movie), typeof(MoviePreviewWindow), new PropertyMetadata(null, OnMovieChanged));

        public MoviePreviewWindow()
        {
            InitializeComponent();
        }

        public MoviePreviewWindow(Movie movie)
        {
            InitializeComponent();

            movieTitleTB.Text = movie.Title;
            movieDescriptionTB.Text = movie.Description;
            yearOfProductionTB.SelectedDate = movie.ReleaseDate;

            //movie2 = new Movie();
            //movie2.Title = movie.Title;
            //movie2.Description = movie.Description;
            //movie2.ReleaseDate = movie.ReleaseDate;

            //movieTitleTB.Text = movie2.Title;
            //movieDescriptionTB.Text = movie2.Description;
            //yearOfProductionTB.SelectedDate = movie2.ReleaseDate;
        }
        public void ChangeMovie(Movie movie)
        {
            Movie = movie;

            this.Title = movie.Title;
            movieTitleTB.Text = movie.Title;
            movieDescriptionTB.Text = movie.Description;
            yearOfProductionTB.SelectedDate = movie.ReleaseDate;
        }
        private static void OnMovieChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MoviePreviewWindow window)
            {
                Movie movie = (Movie)e.NewValue;
                window.Title = movie.Title;
                window.movieTitleTB.Text = movie.Title;
                window.movieDescriptionTB.Text = movie.Description;
                window.yearOfProductionTB.Text = movie.ReleaseDate.ToShortDateString();
            }
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
