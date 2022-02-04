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
    public partial class EnrollmentList : Form
    {
        public EnrollmentList()
        {
            InitializeComponent();            
        }

        private BindingSource bsStudents = new BindingSource();
        private BindingSource bsSubjects = new BindingSource();
        private BindingSource bsSchedules = new BindingSource();
        private BindingSource bsEnrollments = new BindingSource();
        private BindingSource bsInstructors = new BindingSource();

        //BTN CLOSE
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetFormDataBindings()
        {

            DataTable dtStudents = new DataTable();
            DataTable dtSubjects = new DataTable();
            DataTable dtSchedules = new DataTable();
            DataTable dtInstructors = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("select StudentId , lastname + ', '+ FirstName as completename from StudentsTable order by completename asc", connection);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter sa = new SqlDataAdapter(cmd.CommandText, connection.ConnectionString);
                    sa.Fill(dtStudents);
                    //for the subjects
                    cmd.CommandText = "select SubjectId, SubjectName from SubjectsTable order by SubjectName asc";
                    sa.SelectCommand = cmd;
                    sa.Fill(dtSubjects);
                    //for schedules
                    cmd.CommandText = "select scheduleid, concat('ROOM-',cast(FacilityId as nchar(5)),' IN ',cast([TimeStart] as nvarchar(7)),' OUT ' ,cast([TimeEnd] as nvarchar(7))) as TimeDetails   from SchedulesTable";
                    sa.SelectCommand = cmd;
                    sa.Fill(dtSchedules);
                    //bind instructors
                    cmd.CommandText = "select InstructorId, lastname + ', ' + Firstname as completename  from InstructorsTable order by completename asc";
                    sa.SelectCommand = cmd;
                    sa.Fill(dtInstructors);
                }

                //the actual bindings to combobox
                bsStudents.DataSource = dtStudents;
                StudentIdCombobox.DataSource = bsStudents;
                StudentIdCombobox.DisplayMember = "completename";
                StudentIdCombobox.ValueMember = "StudentId";

                bsSubjects.DataSource = dtSubjects;
                SubjectIdCombobox.DataSource = bsSubjects;
                SubjectIdCombobox.DisplayMember = "SubjectName";
                SubjectIdCombobox.ValueMember = "SubjectId";

                bsSchedules.DataSource = dtSchedules;
                ScheduleIdCombobox.DataSource = bsSchedules;
                ScheduleIdCombobox.DisplayMember = "TimeDetails";
                ScheduleIdCombobox.ValueMember = "ScheduleId";

                bsInstructors.DataSource = dtInstructors;
                InstructorIdCombobox.DataSource = bsInstructors;
                InstructorIdCombobox.DisplayMember = "completename";
                InstructorIdCombobox.ValueMember = "InstructorId";
               
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL query operation failed.");
            }
            finally
            {

            }            
        }

        //LOAD LOAD LOAD LOAD LOAD LOAD LOAD LOAD LOAD LOAD LOAD LOAD
        private void EnrollmentList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'faceRecognitionDBDataSet.StudentsTable' table. You can move, or remove it, as needed.
            //this.studentsTableTableAdapter.Fill(this.faceRecognitionDBDataSet.StudentsTable);
            EnrollmentListDGV.AutoGenerateColumns = true;
            SetFormDataBindings();           
            bsEnrollments.DataSource = DataAccess.GetData("EnrollmentListTable");
            EnrollmentListDGV.DataSource = bsEnrollments;


            //CLEAR TEXT BTN
            ClearEnrollment();

        }

        //ENROLLMENT ENROLLMENT ENROLLMENT ENROLLMENT ENROLLMENT ENROLLMENT ENROLLMENT ENROLLMENT ENROLLMENT ENROLLMENT ENROLLMENT

        //BTN ADD ENROLLMENT
        private void EnrollmentAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("spFR_InsertOneEnrollmentListRecord", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentId", StudentIdCombobox.SelectedValue);
                    cmd.Parameters.AddWithValue("@SubjectId", SubjectIdCombobox.SelectedValue);
                    cmd.Parameters.AddWithValue("@ScheduleId", ScheduleIdCombobox.SelectedValue);
                    cmd.Parameters.AddWithValue("@InstructorId", InstructorIdCombobox.SelectedValue);
                    cmd.Parameters.AddWithValue("@Semester", SemesterTextbox.Text);
                    cmd.Parameters.AddWithValue("@SchoolYear", SchoolYearTextbox.Text);

                    cmd.ExecuteNonQuery();
                    EnrollmentListDGV.DataSource = DataAccess.GetData("EnrollmentListTable");
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Insert Enrollment record failed.");
            }
            finally
            {
                MessageBox.Show("New enrollment record added", "Successfule record insert operation");
            }
        }

        //BTN UPDATE ENROLLMENT
        private void EnrollmentUpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("spFR_UpdateOneEnrollmentListRecord", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentId", StudentIdCombobox.SelectedValue);
                    cmd.Parameters.AddWithValue("@SubjectId", SubjectIdCombobox.SelectedValue);
                    cmd.Parameters.AddWithValue("@ScheduleId", ScheduleIdCombobox.SelectedValue);
                    cmd.Parameters.AddWithValue("@InstructorId", InstructorIdCombobox.SelectedValue);
                    cmd.Parameters.AddWithValue("@Semester", SemesterTextbox.Text);
                    cmd.Parameters.AddWithValue("@SchoolYear", SchoolYearTextbox.Text);

                    cmd.ExecuteNonQuery();
                    EnrollmentListDGV.DataSource = DataAccess.GetData("EnrollmentListTable");
                    MessageBox.Show("Successfully Updated Enrollment record.");
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Update Enrollment record failed.");
            }

        }

        //BTN DELETE ENROLLMENT
        private void EnrollmentDeleteButton_Click(object sender, EventArgs e)
        {

        }

        //BTN CLEAR ENROLLMENT
        private void EnrollmentClearButton_Click(object sender, EventArgs e)
        {
            ClearEnrollment();
        }

        //CLEAR ENROLLMENT
        private void ClearEnrollment()
        {
            EnrollmentIdTextbox.Text = string.Empty;
            StudentIdCombobox.Text = string.Empty;
            SubjectIdCombobox.Text = string.Empty;
            ScheduleIdCombobox.Text = string.Empty;
            SemesterTextbox.Text = string.Empty;
            SchoolYearTextbox.Text = string.Empty;
            InstructorIdCombobox.Text = string.Empty;
        }

        //DISPLY ENROLLMENT
        private void EnrollmentListDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EnrollmentIdTextbox.Text = EnrollmentListDGV.Rows[EnrollmentListDGV.CurrentRow.Index].Cells[0].Value.ToString();
            StudentIdCombobox.Text = EnrollmentListDGV.Rows[EnrollmentListDGV.CurrentRow.Index].Cells[1].Value.ToString();
            SubjectIdCombobox.Text = EnrollmentListDGV.Rows[EnrollmentListDGV.CurrentRow.Index].Cells[2].Value.ToString();
            ScheduleIdCombobox.Text = EnrollmentListDGV.Rows[EnrollmentListDGV.CurrentRow.Index].Cells[3].Value.ToString();
            InstructorIdCombobox.Text = EnrollmentListDGV.Rows[EnrollmentListDGV.CurrentRow.Index].Cells[4].Value.ToString();
            SemesterTextbox.Text = EnrollmentListDGV.Rows[EnrollmentListDGV.CurrentRow.Index].Cells[5].Value.ToString();
            SchoolYearTextbox.Text = EnrollmentListDGV.Rows[EnrollmentListDGV.CurrentRow.Index].Cells[6].Value.ToString();
        }

        //WALA NI LABOT
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
