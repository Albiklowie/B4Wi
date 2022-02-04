using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _1._1_FDCForLabMonitoringSystem
{
    public partial class System_Users : Form
    {
        private int UserId;

        public System_Users()
        {
            InitializeComponent();
            DisplaySystemUsers();
        }

        //LOAD LOAD LOAD LOAD LOAD LOA LOAD LOAD LOAD LOAD LOAD LOAD LOAD LOAD LOAD LOAD LOAD LOAD LOAD
        private void System_Users_Load(object sender, EventArgs e)
        {
            SystemUsersDGV.DataSource = GetData("SystemUsersTable");
        }

        //DATA TABLE
        private DataTable GetData(string TableName)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Select * from " + TableName, connection);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter sa = new SqlDataAdapter(cmd.CommandText, connection.ConnectionString);
                    sa.Fill(dt);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL query operation failed.");
            }
            finally
            {

            }
            return dt;
        }

        //SYSTEM USER SYSTEM USER SYSTEM USER SYSTEM USER SYSTEM USER SYSTEM USER SYSTEM USER SYSTEM USER SYSTEM USER SYSTEM USER SYSTEM USER

        //BTN UPDATE SYSTEM USER
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("spFR_UpdateOneSystemUserRecord", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", UserFirstNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@LastName", UserLastNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@UserName", UserNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@UserPassword", UserPasswordTextBox.Text);
                    cmd.Parameters.AddWithValue("@AccessRights", UserAccessComboBox.Text);
                    cmd.Parameters.AddWithValue("@AccessValidUntil", UserValidUntilDTP.Value);
                    cmd.Parameters.AddWithValue("@UserStatus", UserStatusComboBox.Text);
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.ExecuteNonQuery();
                }
                this.DisplaySystemUsers();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Update system user failed.");
            }
            finally
            {
                MessageBox.Show("Selected system user updated", "Successfule record update operation");

            }
        }

        //BTN DELETE SYSTEM USERS
        private void UserDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("spFR_DeleteOneSystemUserRecord", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.ExecuteNonQuery();

                    SystemUsersDGV.DataSource = GetData("SystemUsersTable");
                }
                this.DisplaySystemUsers();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Delete system user failed.");
            }

        }

        //BTN CLEAR SYSTEM
        private void UserClearButton_Click(object sender, EventArgs e)
        {
            ClearContents();
        }

        //CLEAR SYSTEM UERS
        private void ClearContents()
        {
            UserPasswordTextBox.Text = string.Empty;
            UserFirstNameTextBox.Text = string.Empty;
            UserLastNameTextBox.Text = string.Empty;
            UserNameTextBox.Text = string.Empty;
            UserPasswordTextBox.Text = string.Empty;
            UserRetypePasswordTextBox.Text = string.Empty;
            UserStatusComboBox.Text = string.Empty;
            UserAccessComboBox.Text = string.Empty;
        }

        //DISPLAY SYSTEM USERS
        private void DisplaySystemUsers()
        {
            try
            {
                using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Select * from SystemUsersTable order by UserId ASC", connection);
                    cmd.CommandType = CommandType.Text;
                    DataTable dt = new DataTable();
                    SqlDataAdapter sa = new SqlDataAdapter(cmd.CommandText, connection.ConnectionString);
                    sa.Fill(dt);
                    SystemUsersDGV.DataSource = dt;

                }
                this.ClearContents();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Insert system user failed.");
            }
            finally
            {
                //MessageBox.Show("New system user added", "Successfule record insert operation");

            }
        }

        //DISPLAY SYSTEM USERS TABLE
        private void SystemUsersDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            UserAccessComboBox.Text = SystemUsersDGV.Rows[e.RowIndex].Cells[5].Value.ToString();
            UserFirstNameTextBox.Text = SystemUsersDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
            UserLastNameTextBox.Text = SystemUsersDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
            UserNameTextBox.Text = SystemUsersDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
            UserPasswordTextBox.Text = SystemUsersDGV.Rows[e.RowIndex].Cells[4].Value.ToString();
            UserRetypePasswordTextBox.Text = SystemUsersDGV.Rows[e.RowIndex].Cells[4].Value.ToString();
            UserValidUntilDTP.Value = (DateTime)SystemUsersDGV.Rows[e.RowIndex].Cells[6].Value;
            UserStatusComboBox.Text = SystemUsersDGV.Rows[e.RowIndex].Cells[7].Value.ToString();
            UserId = (int)SystemUsersDGV.Rows[e.RowIndex].Cells[0].Value;
        }

        //BTN CLOSE
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //BTN ADD USER
        private void btn_addUser_Click(object sender, EventArgs e)
        {
            Add_User ad = new Add_User();
            ad.Show();
            SystemUsersDGV.DataSource = GetData("SystemUsersTable");
        }





    }
}
