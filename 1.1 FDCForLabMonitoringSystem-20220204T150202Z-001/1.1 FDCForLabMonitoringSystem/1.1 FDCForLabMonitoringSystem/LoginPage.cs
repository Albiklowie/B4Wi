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
    public partial class LoginPage : Form
    {
     

        public LoginPage()
        {
            InitializeComponent();
           
        }

        private string _accessRights;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsLoginOk())
            {
                MainMenu main = new MainMenu();
                main.Tag = _accessRights;   //to know if this is an admistrator
                //this.Hide();
                main.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid user name or password.");
            }
        }

        private bool IsLoginOk()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("spFR_SelectLoginUser", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", userNameTextbox.Text);
                    cmd.Parameters.AddWithValue("@Password", userPasswordTextbox.Text);
                    SqlDataAdapter sa = new SqlDataAdapter();
                    sa.SelectCommand = cmd;
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
            if(dt.Rows.Count > 0)
            {
                _accessRights = dt.Rows[0][1].ToString();
            }
            return (dt.Rows.Count > 0);
        }

        private void LoginPage_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
       
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
