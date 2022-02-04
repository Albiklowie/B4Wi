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
using Microsoft.Reporting;
using Microsoft.Reporting.WinForms;

namespace _1._1_FDCForLabMonitoringSystem
{
    public partial class ReportAttendance : Form
    {
        public ReportAttendance()
        {
            InitializeComponent();
        }
        
        private BindingSource bsSubjects = new BindingSource();
        private BindingSource bsSchedules = new BindingSource();        
        private BindingSource bsInstructors = new BindingSource();

        private void ReportAttendance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'FaceRecognitionDBDataSet2.spFR_StudentAttendanceReport' table. You can move, or remove it, as needed.
            SetFormDataBindings();
            GetReportDataSource();
        }

        private void PreviewButton_Click(object sender, EventArgs e)
        {
            GetReportDataSource();           
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
                    //for the subjects
                    SqlCommand cmd = new SqlCommand("select SubjectId, SubjectName from SubjectsTable order by SubjectName asc", connection);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter sa = new SqlDataAdapter(cmd.CommandText, connection.ConnectionString);
                    sa.SelectCommand = cmd;
                    sa.Fill(dtSubjects);
                    //for schedules
                    cmd.CommandText = "select scheduleid, concat('ROOM-',cast(FacilityId as nchar(5)),' IN',cast([TimeStart] as nvarchar(7)),' OUT ' ,cast([TimeEnd] as nvarchar(7))) as TimeDetails   from SchedulesTable";
                    sa.SelectCommand = cmd;
                    sa.Fill(dtSchedules);
                    //bind instructors
                    cmd.CommandText = "select InstructorId, lastname + ', ' + Firstname as completename  from InstructorsTable order by completename asc";
                    sa.SelectCommand = cmd;
                    sa.Fill(dtInstructors);
                }
                

                bsSubjects.DataSource = dtSubjects;
                SubjectCombobox.DataSource = bsSubjects;
                SubjectCombobox.DisplayMember = "SubjectName";
                SubjectCombobox.ValueMember = "SubjectId";

                bsSchedules.DataSource = dtSchedules;
                ScheduleCombobox.DataSource = bsSchedules;
                ScheduleCombobox.DisplayMember = "TimeDetails";
                ScheduleCombobox.ValueMember = "ScheduleId";

                bsInstructors.DataSource = dtInstructors;
                InstructorCombobox.DataSource = bsInstructors;
                InstructorCombobox.DisplayMember = "completename";
                InstructorCombobox.ValueMember = "InstructorId";

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL query operation failed.");
            }
            finally
            {

            }
        }

        private void GetReportDataSource()
        {
            try
            {
                using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                {
                    List<ReportParameter> repParams = new List<ReportParameter>();
                    repParams.Add(new ReportParameter("paramEDPCode", EDPCodeTextbox.Text));
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("spFR_StudentAttendanceReport", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubjectId", SubjectCombobox.SelectedValue);
                    cmd.Parameters.AddWithValue("@InstructorId", InstructorCombobox.SelectedValue);
                    cmd.Parameters.AddWithValue("@Start_Date", AttendanceDTP.Text);
                    //Try
                    cmd.Parameters.AddWithValue("@End_Date", AttendanceDTP2.Text);
                    //Try

                    cmd.Parameters.AddWithValue("@ScheduleId", ScheduleCombobox.SelectedValue);
                    FaceRecognitionDBDataSetReport1 ds2 = new FaceRecognitionDBDataSetReport1();
                    DataTable dt = new DataTable("Attendance");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    
                    ReportDataSource rds = new ReportDataSource("AttendanceDataSet", dt);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(rds);
                    reportViewer1.LocalReport.SetParameters(repParams);
                    reportViewer1.RefreshReport();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Getting report data records failed.");
            }            
        }

        private void Back_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
