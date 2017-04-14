using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace WPF_SoccerData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Show(object sender, RoutedEventArgs e)
        {
            int ID = int.Parse(IDnumber.Text);
            SqlDataReader reader = null;
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[Table] WHERE ID=@id", connection);
                command.Parameters.AddWithValue("id",ID);
                connection.Open();
                
                    reader = command.ExecuteReader();
                    reader.Read();
                    PlayerName.Text = reader[1].ToString();
                    AboutName.Text = reader[2].ToString();
                reader.Close();
            }
        }

        private void Button_ShowList(object sender, RoutedEventArgs e)
        {
            listBox.Visibility = Visibility.Visible;
            SqlDataReader reader = null;
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                SqlCommand command = new SqlCommand("Select * from [dbo].[Table]", connection);
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listBox.Items.Add(reader[1]);
                }
                reader.Close();
            }
        }

        
    }
}
