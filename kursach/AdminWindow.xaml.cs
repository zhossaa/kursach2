using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void adminn_Loaded(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=krendelek2;Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM [users]", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("users");
                sda.Fill(dt);
                adminn.ItemsSource = dt.DefaultView;
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=krendelek2;Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand($"INSERT INTO [users] ([role name], [login], [password], [fio]) VALUES ('4', '{login.Text}', '{password.Text}', '7')", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (adminn.SelectedItem != null)
            {
                DataRowView row = (DataRowView)adminn.SelectedItem;
                int id = (int)row["id"];
                string deleteQuery = "DELETE FROM [users] WHERE ID = @id";
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=krendelek2;Integrated Security=True"))
                {
                    SqlCommand command = new SqlCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }

            }
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ; Initial Catalog=krendelek2; Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM [users]", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("users");
                sda.Fill(dt);
                adminn.ItemsSource = dt.DefaultView;
            }
        }

        private void oleg_Loaded(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=krendelek2;Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM [zakazes]", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("zakazes");
                sda.Fill(dt);
                oleg.ItemsSource = dt.DefaultView;
            }
        }

        private void add_Click_2(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=krendelek2;Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand($"INSERT INTO [zakazes] ([zakaz], [count], [status], [fio]) VALUES ( '{zakaz.Text}', '{count.Text}', '1', '7')", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void delete_Click_2(object sender, RoutedEventArgs e)
        {
            if (adminn.SelectedItem != null)
            {
                DataRowView row = (DataRowView)oleg.SelectedItem;
                int id = (int)row["id"];
                string deleteQuery = "DELETE FROM [zakazes] WHERE ID = @id";
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=krendelek2;Integrated Security=True"))
                {
                    SqlCommand command = new SqlCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

           
        }

        private void refresh_Click_2(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ; Initial Catalog=krendelek2; Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM [zakazes]", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("zakazes");
                sda.Fill(dt);
                oleg.ItemsSource = dt.DefaultView;
            }
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-N9AD6FJ; Initial Catalog=krendelek2; Integrated Security=True"))
            {
                string newText = "3"; 
                string query = "UPDATE [zakazes] SET [status] = @NewText "; 

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewText", newText);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
