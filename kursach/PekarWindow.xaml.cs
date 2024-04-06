using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace kursach
{
    /// <summary>
    /// Логика взаимодействия для PekarWindow.xaml
    /// </summary>
    public partial class PekarWindow : Window
    {
        public PekarWindow()
        {
            InitializeComponent();
        }

        private void pekar_Loaded(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=krendelek2;Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM [zakazes]", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("zakazes");
                sda.Fill(dt);
                pekar.ItemsSource = dt.DefaultView;
            }
        }

        private void done_click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-N9AD6FJ; Initial Catalog=krendelek2; Integrated Security=True"))
            {
                DataRowView row = (DataRowView)pekar.SelectedItem;
                string newText = "3";
                int id = (int)row["id"];
                string query = "UPDATE [zakazes] SET [status] = @NewText WHERE ID = @id "; 

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewText", newText);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void prepare_click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-N9AD6FJ; Initial Catalog=krendelek2; Integrated Security=True"))
            {
                DataRowView row = (DataRowView)pekar.SelectedItem;
                string newText = "2";
                int id = (int)row["id"];
                string query = "UPDATE [zakazes] SET [status] = @NewText WHERE ID = @id "; 
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewText", newText);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void refreh_click(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ; Initial Catalog=krendelek2; Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM [zakazes]", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("zakazes");
                sda.Fill(dt);
                pekar.ItemsSource = dt.DefaultView;
            }
        }
    }
}
