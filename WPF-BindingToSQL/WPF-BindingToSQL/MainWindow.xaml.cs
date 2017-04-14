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

namespace WPF_BindingToSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Book currentbook = null;
        StoreDB StoreDb = new StoreDB();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void listBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gridMain.DataContext = listBooks.SelectedItems;
        }

        private void buttonGetBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int bookID = Convert.ToInt32(textBoxID.Text);
                currentbook = StoreDb.GetBook(bookID);
                gridMain.DataContext = currentbook;
            }
            catch (Exception)
            {

                MessageBox.Show("There is an query error to the DataBase");
            }
        }

        private void updateBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int bookID = Convert.ToInt32(textBoxID.Text);
                StoreDb.UpdateBook(currentbook, bookID);
            }
            catch (Exception)
            {
                MessageBox.Show("There is an query error to the DataBase");
            }
        }

        bool isCollapsed = true;
        private void buttonShowList_Click(object sender, RoutedEventArgs e)
        {
            if (isCollapsed)
            {
                listBooks.Visibility = System.Windows.Visibility.Visible;
                try
                {
                    listBooks.ItemsSource = StoreDb.GetAllBooks();
                    listBooks.DisplayMemberPath = "Title";
                }
                catch 
                {

                    MessageBox.Show("There is an query error to the DataBase");
                }
            }
            else
            {
                listBooks.Visibility = System.Windows.Visibility.Visible;
            }
            isCollapsed = !isCollapsed;
        }

        
    }
}
