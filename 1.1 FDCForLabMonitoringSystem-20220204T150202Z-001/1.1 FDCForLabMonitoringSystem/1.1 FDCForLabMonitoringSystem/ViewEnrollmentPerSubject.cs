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
    public partial class ViewEnrollmentPerSubject : Form
    {
        public ViewEnrollmentPerSubject()
        {
            InitializeComponent();
        }

        private BindingSource bsSubjects = new BindingSource();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //FORM FOR DATA BINDINGS
        private void SetFormDataBindings()
        {            
            DataTable dtSubjects = new DataTable();           
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("select SubjectId, SubjectName from SubjectsTable order by SubjectName asc", connection);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter sa = new SqlDataAdapter(cmd.CommandText, connection.ConnectionString);
                   
                    //for the subjects                    
                    sa.SelectCommand = cmd;
                    sa.Fill(dtSubjects);
                    
                }
                //the actual bindings to combobox
                bsSubjects.DataSource = dtSubjects;
                SubjectIdCombobox.DataSource = bsSubjects;
                SubjectIdCombobox.DisplayMember = "SubjectName";
                SubjectIdCombobox.ValueMember = "SubjectId";               
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL query operation failed.");
            }
            finally
            {

            }
        }

        private void ViewEnrollmentPerSubject_Load(object sender, EventArgs e)
        {
            SetFormDataBindings();
        }

        private void SubjectIdCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _sqlText = "SELECT DISTINCT e.EnrollmentId, s.LastName + ', ' + " +
                "s.FirstName as FullName, e.SchoolYear, e.Semester " + "FROM EnrollmentListTable e " +
                "INNER JOIN StudentsTable s " + "ON e.StudentId = s.StudentNo" +
                " WHERE e.SubjectId = " + SubjectIdCombobox.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = DataAccess.GetDataSqlText(_sqlText);
            EnrollmentListDGV.DataSource = dt;
        }

        private void EnrollmentListDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
