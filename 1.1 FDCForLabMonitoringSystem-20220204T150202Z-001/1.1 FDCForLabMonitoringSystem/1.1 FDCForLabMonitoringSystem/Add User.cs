using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1._1_FDCForLabMonitoringSystem
{
    public partial class Add_User : Form
    {
        public Add_User()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System_Users su = new System_Users();
            this.Hide();
            su.ShowDialog();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("spFR_InsertOneSystemUserRecord", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", UserFirstNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@LastName", UserLastNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@UserName", UserNameTextBox.Text);                    
                    cmd.Parameters.AddWithValue("@UserPassword", UserPasswordTextBox.Text);
                    cmd.Parameters.AddWithValue("@AccessRights", UserAccessComboBox.Text);
                    cmd.Parameters.AddWithValue("@AccessValidUntil", ValidUntilDatePicker.Value);
                    cmd.Parameters.AddWithValue("@UserStatus", UserStatusComboBox.Text);
                    cmd.ExecuteNonQuery();
                
                }
                this.ClearContents();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Insert system user failed.");
            }
            finally
            {
                MessageBox.Show("New system user added", "Successfule record insert operation");
                this.Close();
            }
        }

        private void ClearContents()
        {
            //clear the contents
            UserFirstNameTextBox.Text = string.Empty;
            UserLastNameTextBox.Text = string.Empty;
            UserNameTextBox.Text = string.Empty;
            UserFirstNameTextBox.Text = string.Empty;
            UserPasswordTextBox.Text = string.Empty;
            UserLastNameTextBox.Text = string.Empty;
            UserStatusComboBox.Text = string.Empty;
            UserAccessComboBox.Text = string.Empty;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ClearContents();
        }
    }
 }
