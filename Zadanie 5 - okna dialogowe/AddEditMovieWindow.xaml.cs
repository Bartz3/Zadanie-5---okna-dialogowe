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
        public Movie addEditMovie { get; set; }

        public AddEditMovieWindow()
        {
            InitializeComponent();
            addEditMovie = new Movie();
            DataContext= addEditMovie;
        }

        public AddEditMovieWindow(Movie movie)
        {
            InitializeComponent();

            addEditMovie= new Movie();
            addEditMovie.Title=movie.Title;
            addEditMovie.Description=movie.Description;
            addEditMovie.ReleaseDate=movie.ReleaseDate;

            txtTitle.Text = addEditMovie.Title;
            txtDescription.Text = addEditMovie.Description;
            dtReleaseDate.SelectedDate = addEditMovie.ReleaseDate;

            //DataContext = movie;
        }



        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            addEditMovie.Title = txtTitle.Text;
            addEditMovie.Description = txtDescription.Text;
            addEditMovie.ReleaseDate = dtReleaseDate.SelectedDate ??  DateTime.MinValue;
     
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
