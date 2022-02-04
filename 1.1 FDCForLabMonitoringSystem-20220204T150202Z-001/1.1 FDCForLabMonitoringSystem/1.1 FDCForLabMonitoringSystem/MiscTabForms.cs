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
    public partial class MiscTabForms : Form
    {
        public MiscTabForms()
        {
            InitializeComponent();
        }

        //create binding sources for comboboxes in the tabs
        private BindingSource bsDepartments = new BindingSource();
        private BindingSource bsCourses = new BindingSource();
        private BindingSource bsFacilities = new BindingSource();
        private BindingSource bsSubjects = new BindingSource();
        private BindingSource bsInstructors = new BindingSource();

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

        //CLOSE BTN
        private void button1_Click(object sender, EventArgs e)
        {            
            this.Close();          
        }

        //LOAD LOAD LOAD LOAD LOAD LOAD LOAD LOAD
        private void MiscTabForms_Load(object sender, EventArgs e)
        {
            MiscTabStudentsDGV.DataSource = GetData("StudentsTable");
            MiscTabInstrutorsDGV.DataSource = GetData("InstructorsTable");
            MiscTabSubjectDGV.DataSource = GetData("SubjectsTable");
            MiscTabLaboratoryStaffDGV.DataSource = GetData("LabStaffTable");
            MiscTabSchedulesDGV.DataSource = GetData("SchedulesTable");
            MiscTabAttendanceDGV.DataSource = GetData("AttendanceTable");
            MiscTabFacilitiesDGV.DataSource = GetData("FacilitiesTable");
            MiscTabCoursesDGV.DataSource = GetData("CollegeCoursesTable");
            MiscTabDepartmentsDGV.DataSource = GetData("DepartmentTable");

            MiscTabSchedulesDGV.DataSource = GetData("SchedulesTable");

            //STUDENT DEPARTMENT BIND
            bsDepartments.DataSource = GetData("DepartmentTable");
            StudentDepartmentCombobox.DataSource = bsDepartments;
            StudentDepartmentCombobox.DisplayMember = "DepartmentName";
            StudentDepartmentCombobox.ValueMember = "DepartmentId";

            //STUDENT COURSE BIND
            bsCourses.DataSource = GetData("CollegeCoursesTable");
            StudentCourseCombobox.DataSource = bsCourses;
            StudentCourseCombobox.DisplayMember = "CourseName";
            StudentCourseCombobox.ValueMember = "CourseId";

            //SUBJECT COURSE BIND
            bsCourses.DataSource = GetData("CollegeCoursesTable");
            SubjectCourseCombobox.DataSource = bsCourses;
            SubjectCourseCombobox.DisplayMember = "CourseName";
            SubjectCourseCombobox.ValueMember = "CourseId";

            //SCHEDULE FACILITY BIND
            bsFacilities.DataSource = GetData("FacilitiesTable");
            ScheduleFacilityCombobox.DataSource = bsFacilities;
            ScheduleFacilityCombobox.DisplayMember = "FacilityName";
            ScheduleFacilityCombobox.ValueMember = "FacilityId";

            //COURSE DEPARTMENT BIND
            bsDepartments.DataSource = GetData("DepartmentTable");
            CourseDepartmentCombobox.DataSource = bsDepartments;
            CourseDepartmentCombobox.DisplayMember = "DepartmentName";
            CourseDepartmentCombobox.ValueMember = "DepartmentId";

            //SCHEDULE SUBJECT BIND
            bsSubjects.DataSource = GetData("SubjectsTable");
            ScheduleSubjectCombobox.DataSource = bsSubjects;
            ScheduleSubjectCombobox.DisplayMember = "SubjectName";
            ScheduleSubjectCombobox.ValueMember = "SubjectId";

            bsInstructors.DataSource = DataAccess.GetDataSqlText("Select InstructorId, LastName + ', ' + FirstName as completename from InstructorsTable order by completename");
            SchedulesInstructorIdCombobox.DataSource = bsInstructors;
            SchedulesInstructorIdCombobox.DisplayMember = "completename";
            SchedulesInstructorIdCombobox.ValueMember = "InstructorId";


            this.MiscTabStudentsDGV.Columns["StudentNo"].Visible = false;
        }

        //STUDENTS STUDENTS STUDENTS STUDENTS STUDENTS STUDENTS STUDENTS STUDENTS STUDENTS STUDENTS STUDENTS STUDENTS STUDENTS STUDENTS STUDENTS

        //BTN ADD STUDENTS
        private void StudentAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (StudentFirstNameTextbox.Text != string.Empty || StudentFirstNameTextbox.Text != null)
                {
                    using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("spFR_InsertOneStudentRecord", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StudentId", StudentIdTextbox.Text);
                        //cmd.Parameters.AddWithValue("@StudentNo", StudentIdTextbox.Text);
                        cmd.Parameters.AddWithValue("@FirstName", StudentFirstNameTextbox.Text);
                        cmd.Parameters.AddWithValue("@LastName", StudentLastNameTextbox.Text);
                        cmd.Parameters.AddWithValue("@MiddleName", StudentMiddleNameTextbox.Text);
                        cmd.Parameters.AddWithValue("@Gender", StudentGenderCombobox.Text);
                        cmd.Parameters.AddWithValue("@DepartmentId", (int)StudentDepartmentCombobox.SelectedValue);
                        cmd.Parameters.AddWithValue("@CourseId", (int)StudentCourseCombobox.SelectedValue);
                        cmd.Parameters.AddWithValue("@CourseLevel", StudentCourseLevelCombobox.Text);
                        cmd.Parameters.AddWithValue("@UserStatus", StudentUserStatusCombobox.Text);
                        cmd.Parameters.AddWithValue("@PC",StudentPCNo.Text);
                        cmd.ExecuteNonQuery();
                        MiscTabStudentsDGV.DataSource = GetData("StudentsTable");
                        MessageBox.Show("Successfully Added Student.");
                    }
                    this.ClearStudentInput();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Insert new student failed.");
            }

        }

        //BTN UPDATE STUDENTS
        private void StudentUpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[spFR_UpdateOneStudentRecord]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentId", StudentIdTextbox.Text);
                    cmd.Parameters.AddWithValue("@FirstName", StudentFirstNameTextbox.Text);
                    cmd.Parameters.AddWithValue("@LastName", StudentLastNameTextbox.Text);
                    cmd.Parameters.AddWithValue("@MiddleName", StudentMiddleNameTextbox.Text);
                    cmd.Parameters.AddWithValue("@Gender", StudentGenderCombobox.Text);
                    cmd.Parameters.AddWithValue("@DepartmentId", StudentDepartmentCombobox.SelectedValue);
                    cmd.Parameters.AddWithValue("@CourseId", StudentCourseCombobox.SelectedValue);
                    cmd.Parameters.AddWithValue("@CourseLevel", StudentCourseLevelCombobox.Text);
                    cmd.Parameters.AddWithValue("@UserStatus", StudentUserStatusCombobox.Text);
                    cmd.Parameters.AddWithValue("@PC", StudentPCNo.Text);
                    cmd.ExecuteNonQuery();
                    MiscTabStudentsDGV.DataSource = GetData("StudentsTable");
                    MessageBox.Show("Successfully Updated Student");
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Update student failed.");
            }
            //finally
            //{
            //    MessageBox.Show("Selected student updated", "Successfull record update operation");
            //}
        }

        //BTN DELETE STUDENTS
        private void StudentDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("spFR_DeleteOneStudentRecord", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentId", StudentIdTextbox.Text);
                    cmd.ExecuteNonQuery();
                    MiscTabStudentsDGV.DataSource = GetData("StudentsTable");
                    MessageBox.Show("Successfully Deleted Student");
                }
                this.ClearStudentInput();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Delete selected student failed.");
            }
            //finally
            //{
            //    MessageBox.Show("Selected student deleted", "Successfull record delete operation");
            //}
        }

        //BTN CLEAR STUDENTS
        private void button4_Click(object sender, EventArgs e)
        {
            ClearStudentInput();
        }

        //CLEAR STUDENTS
        private void ClearStudentInput()
        {
            StudentIdTextbox.Text = string.Empty;
            StudentFirstNameTextbox.Text = string.Empty;
            StudentLastNameTextbox.Text = string.Empty;
            StudentMiddleNameTextbox.Text = string.Empty;
            StudentGenderCombobox.Text = string.Empty;
            StudentUserStatusCombobox.Text = string.Empty;
            StudentGenderCombobox.Text = string.Empty;
            StudentDepartmentCombobox.Text = string.Empty;
            StudentCourseCombobox.Text = string.Empty;
            StudentCourseLevelCombobox.Text = string.Empty;
            StudentPCNo.Text = string.Empty;
        }

        //STUDENT TABLE
        private void MiscTabStudentsDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            StudentIdTextbox.Text = MiscTabStudentsDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
            StudentFirstNameTextbox.Text = MiscTabStudentsDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
            StudentLastNameTextbox.Text = MiscTabStudentsDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
            StudentMiddleNameTextbox.Text = MiscTabStudentsDGV.Rows[e.RowIndex].Cells[4].Value.ToString();
            StudentGenderCombobox.Text = MiscTabStudentsDGV.Rows[e.RowIndex].Cells[5].Value.ToString();
            StudentDepartmentCombobox.SelectedValue = MiscTabStudentsDGV.Rows[e.RowIndex].Cells[6].Value;
            StudentCourseCombobox.SelectedValue = MiscTabStudentsDGV.Rows[e.RowIndex].Cells[7].Value;
            StudentCourseLevelCombobox.Text = MiscTabStudentsDGV.Rows[e.RowIndex].Cells[8].Value.ToString();
            StudentUserStatusCombobox.Text = MiscTabStudentsDGV.Rows[e.RowIndex].Cells[9].Value.ToString();
            StudentPCNo.Text = MiscTabStudentsDGV.Rows[e.RowIndex].Cells[10].Value.ToString();

         
        }

        // INSTRUCTOR INSTRUCTOR INSTRUCTOR INSTRUCTOR INSTRUCTOR INSTRUCTOR INSTRUCTOR INSTRUCTOR INSTRUCTOR INSTRUCTOR INSTRUCTOR INSTRUCTOR INSTRUCTOR

        //BTN ADD INSTRUCTOR
        private void InstructorAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (InstructorFirstNameTextbox.Text == string.Empty)
                {
                    MessageBox.Show("Cannot add blank First Name");
                    return;
                }
                {
                    using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("spFR_InsertOneInstructorRecord", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@InstructorId", InstructorIdTextbox.Text);
                        cmd.Parameters.AddWithValue("@FirstName", InstructorFirstNameTextbox.Text);
                        cmd.Parameters.AddWithValue("@LastName", InstructorLastNameTextbox.Text);
                        cmd.Parameters.AddWithValue("@MiddleName", InstructorMiddleNameTextbox.Text);
                        cmd.Parameters.AddWithValue("@UserStatus", InstructorUserStatusCombobox.Text);
                        cmd.Parameters.AddWithValue("@Position", InstructorPositionTextbox.Text);

                        cmd.ExecuteNonQuery();
                    }
                    this.ClearInstructorInput();
                    MiscTabInstrutorsDGV.DataSource = GetData("InstructorsTable");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Insert new Instructor failed.");
            }
            finally
            {
                MessageBox.Show("New Instructor added", "Successfull record insert operation");
            }
        }

        //BTN UPDATE INSTRUCTOR
        private void InstructorUpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("spFR_UpdateOneInstructorRecord", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@InstructorId", InstructorIdTextbox.Text);
                        cmd.Parameters.AddWithValue("@FirstName", InstructorFirstNameTextbox.Text);
                        cmd.Parameters.AddWithValue("@LastName", InstructorLastNameTextbox.Text);
                        cmd.Parameters.AddWithValue("@MiddleName", InstructorMiddleNameTextbox.Text);
                        cmd.Parameters.AddWithValue("@UserStatus", InstructorUserStatusCombobox.Text);
                        cmd.Parameters.AddWithValue("@Position", InstructorPositionTextbox.Text);
                        cmd.ExecuteNonQuery();
                    }
                    //this.ClearInstructorInput();
                    MiscTabInstrutorsDGV.DataSource = GetData("InstructorsTable");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Insert new Instructor failed.");
            }
            finally
            {
                MessageBox.Show("New Instructor added", "Successfull record insert operation");
            }
        }

        //BTN DELETE INSTRUCTOR
        private void InstructorDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("spFR_DeleteOneInstructorRecord", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@InstructorId", InstructorIdTextbox.Text);

                        cmd.ExecuteNonQuery();
                    }
                    this.ClearInstructorInput();
                    MiscTabInstrutorsDGV.DataSource = GetData("InstructorsTable");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Delete selected Instructor failed.");
            }
            finally
            {
                MessageBox.Show("Selected Instructor deleted", "Successfull record delete operation");
            }
        }

        //BTN CLEAR INSTRUCTOR
        private void InstructorClearButton_Click(object sender, EventArgs e)
        {
            ClearInstructorInput();
        }

        //CLEAR INSTRUCTOR
        private void ClearInstructorInput()
        {
            InstructorFirstNameTextbox.Text = string.Empty;
            InstructorLastNameTextbox.Text = string.Empty;
            InstructorMiddleNameTextbox.Text = string.Empty;
            InstructorUserStatusCombobox.Text = string.Empty;
            InstructorPositionTextbox.Text = string.Empty;
            InstructorIdTextbox.Text = string.Empty;
        }

        //INSTRUCTOR TABLE
        private void MiscTabInstrutorsDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DisplayInstructorDetails();
        }

        //INSTRUCTOR TABLE GRID
        private void DisplayInstructorDetails()
        {
            InstructorIdTextbox.Text = MiscTabInstrutorsDGV.Rows[MiscTabInstrutorsDGV.CurrentRow.Index].Cells[0].Value.ToString();
            InstructorFirstNameTextbox.Text = MiscTabInstrutorsDGV.Rows[MiscTabInstrutorsDGV.CurrentRow.Index].Cells[1].Value.ToString();
            InstructorLastNameTextbox.Text = MiscTabInstrutorsDGV.Rows[MiscTabInstrutorsDGV.CurrentRow.Index].Cells[2].Value.ToString();
            InstructorMiddleNameTextbox.Text = MiscTabInstrutorsDGV.Rows[MiscTabInstrutorsDGV.CurrentRow.Index].Cells[3].Value.ToString();
            InstructorPositionTextbox.Text = MiscTabInstrutorsDGV.Rows[MiscTabInstrutorsDGV.CurrentRow.Index].Cells[5].Value.ToString();
            InstructorUserStatusCombobox.Text = MiscTabInstrutorsDGV.Rows[MiscTabInstrutorsDGV.CurrentRow.Index].Cells[4].Value.ToString();
        }

        //LABORATORY STAFF LABORATORY STAFF LABORATORY STAFF LABORATORY STAFF LABORATORY STAFF LABORATORY STAFF LABORATORY STAFF LABORATORY STAFF LABORATORY STAFF
       
        //BTN ADD LAB STAFF
        private void StaffAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("spFR_InsertOneStaffRecord", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StaffId", StaffIdTextbox.Text);
                        cmd.Parameters.AddWithValue("@FirstName", StaffFirstNameTextbox.Text);
                        cmd.Parameters.AddWithValue("@LastName", StaffLastNameTextbox.Text);
                        cmd.Parameters.AddWithValue("@MiddleName", StaffMiddleNameTextbox.Text);
                        cmd.Parameters.AddWithValue("@UserStatus", StaffUserStatusCombobox.Text);
                        cmd.Parameters.AddWithValue("@Position", StaffPositionTextbox.Text);

                        cmd.ExecuteNonQuery();
                    }
                    this.ClearLabStaffInput();
                    MiscTabLaboratoryStaffDGV.DataSource = GetData("LabStaffTable");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Add new Staff failed.");
            }
            finally
            {
                MessageBox.Show("New Staff added", "Successfull record add operation");
            }
        }

        //BTN UPDATE LAB STAFF
        private void StaffUpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("spFR_UpdateOneStaffRecord", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StaffId", StaffIdTextbox.Text);
                        cmd.Parameters.AddWithValue("@FirstName", StaffFirstNameTextbox.Text);
                        cmd.Parameters.AddWithValue("@LastName", StaffLastNameTextbox.Text);
                        cmd.Parameters.AddWithValue("@MiddleName", StaffMiddleNameTextbox.Text);
                        cmd.Parameters.AddWithValue("@UserStatus", StaffUserStatusCombobox.Text);
                        cmd.Parameters.AddWithValue("@Position", StaffPositionTextbox.Text);

                        cmd.ExecuteNonQuery();
                    }
                    //this.ClearLabStaffInput();
                    MiscTabLaboratoryStaffDGV.DataSource = GetData("LabStaffTable");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Updated selected Staff failed.");
            }
            finally
            {
                MessageBox.Show("Selected Staff Updated", "Successfull record Update operation");
            }
        }

        //BTN DELETE LAB STAFF
        private void StaffDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("spFR_DeleteOneStaffRecord", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StaffId", StaffIdTextbox.Text);

                        cmd.ExecuteNonQuery();
                    }
                    this.ClearLabStaffInput();
                    MiscTabLaboratoryStaffDGV.DataSource = GetData("LabStaffTable");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Delete selected Staff failed.");
            }
            finally
            {
                MessageBox.Show("Selected Staff deleted", "Successfull record delete operation");
            }
        }

        //BTN CLEAR LAB STAFF
        private void StaffClearButton_Click(object sender, EventArgs e)
        {
            ClearLabStaffInput();
        }

        //CLEAR LAB STAFFF
        private void ClearLabStaffInput()
        {
            StaffFirstNameTextbox.Text = string.Empty;
            StaffLastNameTextbox.Text = string.Empty;
            StaffMiddleNameTextbox.Text = string.Empty;
            StaffUserStatusCombobox.Text = string.Empty;
            StaffPositionTextbox.Text = string.Empty;
            StaffIdTextbox.Text = string.Empty;
        }

        //LABORATORY STAFF TABLE
        private void MiscTabLaboratoryStaffDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            StaffIdTextbox.Text = MiscTabLaboratoryStaffDGV.Rows[MiscTabLaboratoryStaffDGV.CurrentRow.Index].Cells[0].Value.ToString();
            StaffFirstNameTextbox.Text = MiscTabLaboratoryStaffDGV.Rows[MiscTabLaboratoryStaffDGV.CurrentRow.Index].Cells[1].Value.ToString();
            StaffLastNameTextbox.Text = MiscTabLaboratoryStaffDGV.Rows[MiscTabLaboratoryStaffDGV.CurrentRow.Index].Cells[2].Value.ToString();
            StaffMiddleNameTextbox.Text = MiscTabLaboratoryStaffDGV.Rows[MiscTabLaboratoryStaffDGV.CurrentRow.Index].Cells[3].Value.ToString();
            StaffPositionTextbox.Text = MiscTabLaboratoryStaffDGV.Rows[MiscTabLaboratoryStaffDGV.CurrentRow.Index].Cells[5].Value.ToString();
            StaffUserStatusCombobox.Text = MiscTabLaboratoryStaffDGV.Rows[MiscTabLaboratoryStaffDGV.CurrentRow.Index].Cells[4].Value.ToString();
        }

        // DEPARTMENT DEPARTMENT DEPARTMENT DEPARTMENT DEPARTMENT DEPARTMENT DEPARTMENT DEPARTMENT DEPARTMENT DEPARTMENT DEPARTMENT DEPARTMENT DEPARTMENT

        //BTN ADD DEPARTMENT
        private void DepartmentAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (DepartmentNameTextbox.Text == string.Empty)
                {
                    MessageBox.Show("Cannot add blank Department name");
                    return;
                }
                {
                    using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("spFR_InsertOneDepartmentRecord", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DepartmentName", DepartmentNameTextbox.Text);
                        cmd.Parameters.AddWithValue("@DepartmentDescription", DepartmentDescriptionTextbox.Text);

                        cmd.ExecuteNonQuery();
                    }
                    this.ClearDepartmentInput();
                    MiscTabDepartmentsDGV.DataSource = GetData("DepartmentTable");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Insert new Department failed.");
            }
            finally
            {
                MessageBox.Show("New Department added", "Successfull record insert operation");
            }
        }

        //BTN UPDATE DEPARTMENT
        private void DepartmentUpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("[spFR_UpdateOneDepartmentRecord]", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DepartmentId", DepartmentIdTextbox.Text);
                        cmd.Parameters.AddWithValue("@DepartmentName", DepartmentNameTextbox.Text);
                        cmd.Parameters.AddWithValue("@DepartmentDescription", DepartmentDescriptionTextbox.Text);

                        cmd.ExecuteNonQuery();
                    }
                    //this.ClearInstructorInput();
                    MiscTabDepartmentsDGV.DataSource = GetData("DepartmentTable");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Update Department failed.");
            }
            finally
            {
                MessageBox.Show("Selected Department updated", "Successfull record update operation");
            }
        }

        //BTN DELETE DEPARTMENT
        private void DepartmentDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("spFR_DeleteOneDepartmentRecord", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DepartmentId", DepartmentIdTextbox.Text);

                        cmd.ExecuteNonQuery();
                    }
                    this.ClearDepartmentInput();
                    MiscTabDepartmentsDGV.DataSource = GetData("DepartmentTable");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Delete new Department failed.");
            }
            finally
            {
                MessageBox.Show("New Department deleted", "Successfull record deletion operation");
            }
        }

        //BTN CLEAR DEPARTMENT
        private void DepartmentClearButton_Click(object sender, EventArgs e)
        {
            DepartmentDescriptionTextbox.Text = string.Empty;
            DepartmentNameTextbox.Text = string.Empty;
            DepartmentIdTextbox.Text = string.Empty;
        }

        //CLEAR DEPARTMENT
        private void ClearDepartmentInput()
        {
            DepartmentDescriptionTextbox.Text = string.Empty;
            DepartmentNameTextbox.Text = string.Empty;
            DepartmentIdTextbox.Text = string.Empty;
        }

        //DEPARTMENT TABLE
        private void MiscTabDepartmentsDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DisplayDepartmentDetails();
        }

        //DEPARTMENT TABLE GRID
        private void DisplayDepartmentDetails()
        {
            DepartmentDescriptionTextbox.Text = MiscTabDepartmentsDGV.Rows[MiscTabDepartmentsDGV.CurrentRow.Index].Cells[2].Value.ToString();
            DepartmentNameTextbox.Text = MiscTabDepartmentsDGV.Rows[MiscTabDepartmentsDGV.CurrentRow.Index].Cells[1].Value.ToString();
            DepartmentIdTextbox.Text = MiscTabDepartmentsDGV.Rows[MiscTabDepartmentsDGV.CurrentRow.Index].Cells[0].Value.ToString();
        }

        //COURSE COURSE COURSE COURSE COURSE COURSE COURSE COURSE COURSE COURSE COURSE COURSE COURSE COURSE COURSE COURSE COURSE COURSE COURSE COURSE COURSE

        //BTN ADD COURSE
        private void CourseAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("spFR_InsertOneCourseRecord", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CourseName", CourseNameTextbox.Text);
                        cmd.Parameters.AddWithValue("@CourseDescription", CourseDescriptionTextbox.Text);
                        cmd.Parameters.AddWithValue("@DepartmentId",CourseDepartmentCombobox.SelectedValue);
                        cmd.Parameters.AddWithValue("@CourseStatus", CourseStatusCombobox.Text);

                        cmd.ExecuteNonQuery();
                    }
                    this.ClearCourseInput();
                    MiscTabCoursesDGV.DataSource = GetData("CollegeCoursesTable");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Add new course failed.");
            }



            finally
            {
                MessageBox.Show("New college course added", "Successfull record add operation");
            }
        }

        //BTN UPDATE COURSE
        private void CourseUpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("spFR_UpdateOneCourseRecord", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CourseId", CourseIdTextbox.Text);
                        cmd.Parameters.AddWithValue("@CourseName", CourseNameTextbox.Text);
                        cmd.Parameters.AddWithValue("@CourseDescription", CourseDescriptionTextbox.Text);
                        cmd.Parameters.AddWithValue("@DepartmentId",CourseDepartmentCombobox.SelectedValue);
                        cmd.Parameters.AddWithValue("@CourseStatus", CourseStatusCombobox.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfully Updated Course.");
                    }
                    //this.ClearCourseInput();
                    MiscTabCoursesDGV.DataSource = GetData("CollegeCoursesTable");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Update selected Course failed.");
            }
            finally
            {
                MessageBox.Show("Selected Course Updated", "Successfull record Update operation");
            }
        }

        //BTN DELETE COURSE
        private void CourseDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("spFR_DeleteOneCourseRecord", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CourseId", CourseIdTextbox.Text);

                        cmd.ExecuteNonQuery();
                    }
                    this.ClearCourseInput();
                    MiscTabCoursesDGV.DataSource = GetData("CollegeCoursesTable");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Delete selected course failed.");
            }
            finally
            {
                MessageBox.Show("Selected course deleted", "Successfull record delete operation");
            }
        }

        //BTN CLEAR COURSE
        private void CourseClearButton_Click(object sender, EventArgs e)
        {
            ClearCourseInput();
        }

        //CLEAR COURSE
        private void ClearCourseInput()
        {
            CourseNameTextbox.Text = string.Empty;
            CourseDepartmentCombobox.Text = string.Empty;
            CourseDepartmentCombobox.Text = string.Empty;
            CourseStatusCombobox.Text = string.Empty;
            CourseIdTextbox.Text = string.Empty;
        }

        //COURSE TABLE
        private void MiscTabCoursesDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DisplayCourseDetails();
        }

        //COURSE TABLE GRID
        private void DisplayCourseDetails()
        {
            CourseIdTextbox.Text = MiscTabCoursesDGV.Rows[MiscTabCoursesDGV.CurrentRow.Index].Cells[0].Value.ToString();
            CourseNameTextbox.Text = MiscTabCoursesDGV.Rows[MiscTabCoursesDGV.CurrentRow.Index].Cells[1].Value.ToString();
            CourseDescriptionTextbox.Text = MiscTabCoursesDGV.Rows[MiscTabCoursesDGV.CurrentRow.Index].Cells[2].Value.ToString();
            CourseDepartmentCombobox.SelectedValue = MiscTabCoursesDGV.Rows[MiscTabCoursesDGV.CurrentRow.Index].Cells[3].Value;
            CourseStatusCombobox.Text = MiscTabCoursesDGV.Rows[MiscTabCoursesDGV.CurrentRow.Index].Cells[4].Value.ToString();
        }

        //SUBJECT SUBJECT SUBJECT SUBJECT SUBJECT SUBJECT SUBJECT SUBJECT SUBJECT SUBJECT SUBJECT SUBJECT SUBJECT SUBJECT SUBJECT SUBJECT SUBJECT SUBJECT

        //BTN ADD SUBJECT
        private void SubjectAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("spFR_InsertOneSubjectRecord", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SubjectId", SubjectIdTextbox.Text);
                        cmd.Parameters.AddWithValue("@SubjectName", SubjectNameTextbox.Text);
                        cmd.Parameters.AddWithValue("@SubjectDescription", SubjectDescriptionTextbox.Text);
                        cmd.Parameters.AddWithValue("@UnitsToComplete", SubjectUnitsToCompleteTextbox.Text);
                        cmd.Parameters.AddWithValue("@CourseId", SubjectCourseCombobox.SelectedValue);

                        cmd.ExecuteNonQuery();
                    }
                    this.ClearSubjectInput();
                    MiscTabSubjectDGV.DataSource = GetData("SubjectsTable");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Delete selected Instructor failed.");
            }
            finally
            {
                MessageBox.Show("Selected Instructor deleted", "Successfull record delete operation");
            }
        }

        //BTN UPDATE SUBJECT
        private void SujectUpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("spFR_UpdateOneSubjectRecord", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SubjectId", SubjectIdTextbox.Text);
                        cmd.Parameters.AddWithValue("@SubjectName", SubjectNameTextbox.Text);
                        cmd.Parameters.AddWithValue("@SubjectDescription", SubjectDescriptionTextbox.Text);
                        cmd.Parameters.AddWithValue("@UnitsToComplete", SubjectUnitsToCompleteTextbox.Text);
                        cmd.Parameters.AddWithValue("@CourseId", SubjectCourseCombobox.SelectedValue);

                        cmd.ExecuteNonQuery();
                    }
                    //this.ClearSubjectInput();
                    MiscTabSubjectDGV.DataSource = GetData("SubjectsTable");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Update selected Subject failed.");
            }
            finally
            {
                MessageBox.Show("Selected Subject updated", "Successfull record update operation");
            }
        }

        //BTN DELETE SUBJECT
        private void SubjectDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("spFR_DeleteOneSubjectRecord", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SubjectId", SubjectIdTextbox.Text);

                        cmd.ExecuteNonQuery();
                    }
                    this.ClearSubjectInput();
                    MiscTabSubjectDGV.DataSource = GetData("SubjectsTable");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Delete selected Subject failed.");
            }
            finally
            {
                MessageBox.Show("Selected Subject deleted", "Successfull record delete operation");
            }
        }

        //BTN CLEAR SUBJECT
        private void SubjectClearButton_Click(object sender, EventArgs e)
        {
            ClearSubjectInput();
        }

        //CLEAR SUBJECT
        private void ClearSubjectInput()
        {
            SubjectIdTextbox.Text = string.Empty;
            SubjectNameTextbox.Text = string.Empty;
            SubjectDescriptionTextbox.Text = string.Empty;
            SubjectUnitsToCompleteTextbox.Text = string.Empty;
            SubjectCourseCombobox.Text = string.Empty;
            SubjectIdTextbox.Text = string.Empty;
        }

        //SUBJECT TABLE
        private void MiscTabSubjectDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SubjectIdTextbox.Text = MiscTabSubjectDGV.Rows[MiscTabSubjectDGV.CurrentRow.Index].Cells[0].Value.ToString();
            SubjectNameTextbox.Text = MiscTabSubjectDGV.Rows[MiscTabSubjectDGV.CurrentRow.Index].Cells[1].Value.ToString();
            SubjectDescriptionTextbox.Text = MiscTabSubjectDGV.Rows[MiscTabSubjectDGV.CurrentRow.Index].Cells[2].Value.ToString();
            SubjectCourseCombobox.SelectedValue = MiscTabSubjectDGV.Rows[MiscTabSubjectDGV.CurrentRow.Index].Cells[4].Value;
            SubjectUnitsToCompleteTextbox.Text = MiscTabSubjectDGV.Rows[MiscTabSubjectDGV.CurrentRow.Index].Cells[3].Value.ToString();
        }

        //FACILITY FACILITY FACILITY FACILITY FACILITY FACILITY FACILITY FACILITY FACILITY FACILITY FACILITY FACILITY FACILITY FACILITY FACILITY FACILITY

        //BTN ADD FACILITY
        private void FacilityAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (FacilityNameTextbox.Text == string.Empty)
                {
                    MessageBox.Show("Cannot insert blank name");
                }
                {
                    using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("spFR_InsertOneFacilityRecord", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FacilityName", FacilityNameTextbox.Text);
                        cmd.Parameters.AddWithValue("@FacilityDescription", FacilityDescriptionTextbox.Text);

                        cmd.ExecuteNonQuery();
                    }
                    this.ClearFacilityInput();
                    MiscTabFacilitiesDGV.DataSource = GetData("FacilitiesTable");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Insert new Facility failed.");
            }
            finally
            {
                MessageBox.Show("New Facility added", "Successfull record add operation");
            }
        }

        //BTN UPDATE FACILITY
        private void FacilityUpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("spFR_UpdateOneFacilityRecord", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FacilityId", FacilityIdTextbox.Text);
                        cmd.Parameters.AddWithValue("@FacilityName", FacilityNameTextbox.Text);
                        cmd.Parameters.AddWithValue("@FacilityDescription", FacilityDescriptionTextbox.Text);

                        cmd.ExecuteNonQuery();
                    }
                    //this.ClearFacilityInput();
                    MiscTabFacilitiesDGV.DataSource = GetData("FacilitiesTable");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Update selected Facility failed.");
            }
            finally
            {
                MessageBox.Show("Selected Facility updated", "Successfull record update operation");
            }
        }

        //BTN DELETE FACILITY
        private void FacilityDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("[spFR_DeleteOneFacilityRecord]", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FacilityId", FacilityIdTextbox.Text);

                        cmd.ExecuteNonQuery();
                    }
                    this.ClearFacilityInput();
                    MiscTabFacilitiesDGV.DataSource = GetData("FacilitiesTable");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Delete selected Facility failed.");
            }
            finally
            {
                MessageBox.Show("Selected Facility deleted", "Successfull record delete operation");
            }
        }

        //BTN CLEAR FACILITY
        private void FacilityClearButton_Click(object sender, EventArgs e)
        {
            ClearFacilityInput();
        }

        //CLEAR FACILITY
        private void ClearFacilityInput()
        {
            FacilityIdTextbox.Text = string.Empty;
            FacilityNameTextbox.Text = string.Empty;
            FacilityDescriptionTextbox.Text = string.Empty;
        }

        //FACILITY TABLE
        private void MiscTabFacilitiesDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DisplayFacilityDetails();
        }

        //FACILITY TABLE GRID
        private void DisplayFacilityDetails()
        {
            FacilityIdTextbox.Text = MiscTabFacilitiesDGV.Rows[MiscTabFacilitiesDGV.CurrentRow.Index].Cells[0].Value.ToString();
            FacilityNameTextbox.Text = MiscTabFacilitiesDGV.Rows[MiscTabFacilitiesDGV.CurrentRow.Index].Cells[1].Value.ToString();
            FacilityDescriptionTextbox.Text = MiscTabFacilitiesDGV.Rows[MiscTabFacilitiesDGV.CurrentRow.Index].Cells[2].Value.ToString();
        }

        //SCHEDULE SCHEDULE SCHEDULE SCHEDULE SCHEDULE SCHEDULE SCHEDULE SCHEDULE SCHEDULE SCHEDULE SCHEDULE SCHEDULE SCHEDULE SCHEDULE SCHEDULE SCHEDULE

        //BTN ADD SCHEDULE
        private void ScheduleAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("spFR_InsertOneScheduleRecord", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FacilityId", ScheduleFacilityCombobox.SelectedValue);
                        cmd.Parameters.AddWithValue("@TimeStart", ScheduleTimeStartDTP.Value.ToString("HH:mm"));
                        cmd.Parameters.AddWithValue("@TimeEnd", ScheduleTimeEndDTP.Value.ToString("HH:mm"));
                        cmd.Parameters.AddWithValue("@ValidOn", ScheduleValidOnDTP.Value.Date);
                        cmd.Parameters.AddWithValue("@ValidUntil", ScheduleValidUntilDTP.Value.Date);
                        cmd.Parameters.AddWithValue("@ScheduleStatus", ScheduleStatusCombobox.Text);
                        cmd.Parameters.AddWithValue("@SubjectId", ScheduleSubjectCombobox.SelectedValue);
                        cmd.Parameters.AddWithValue("@Semester", ScheduleSemesterTextbox.Text);
                        cmd.Parameters.AddWithValue("@InstructorId", SchedulesInstructorIdCombobox.SelectedValue);
                        cmd.ExecuteNonQuery();
                    }
                    this.ClearScheduleInput();
                    MiscTabSchedulesDGV.DataSource = GetData("SchedulesTable");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Add new Schedule failed.");
            }
            finally
            {
                MessageBox.Show("New Schedule added", "Successfull record add operation");
            }
        }

        //BTN UPDATE SCHEDULE
        private void ScheduleUpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("spFR_UpdateOneScheduleRecord", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ScheduleId", ScheduleIdTextbox.Text);
                        cmd.Parameters.AddWithValue("@FacilityId", ScheduleFacilityCombobox.SelectedValue);
                        cmd.Parameters.AddWithValue("@TimeStart", ScheduleTimeStartDTP.Text);
                        cmd.Parameters.AddWithValue("@TimeEnd", ScheduleTimeEndDTP.Text);
                        cmd.Parameters.AddWithValue("@ValidOn", ScheduleValidOnDTP.Text);
                        cmd.Parameters.AddWithValue("@ValidUntil", ScheduleValidUntilDTP.Text);
                        cmd.Parameters.AddWithValue("@ScheduleStatus", ScheduleStatusCombobox.Text);
                        cmd.Parameters.AddWithValue("@SubjectId", ScheduleSubjectCombobox.SelectedValue);
                        cmd.Parameters.AddWithValue("@Semester", ScheduleSemesterTextbox.Text);

                        cmd.ExecuteNonQuery();
                    }
                    //this.ClearScheduleInput();
                    MiscTabSchedulesDGV.DataSource = GetData("SchedulesTable");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Update selected Schedule failed.");
            }
            finally
            {
                MessageBox.Show("Selected Schedule Updated", "Successfull record Update operation");
            }
        }

        //BTN DELETE SCHEDULE
        private void ScheduleDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("spFR_DeleteOneScheduleRecord", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ScheduleId", ScheduleIdTextbox.Text);

                        cmd.ExecuteNonQuery();
                    }
                    this.ClearScheduleInput();
                    MiscTabSchedulesDGV.DataSource = GetData("SchedulesTable");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Delete selected Schedule failed.");
            }
            finally
            {
                MessageBox.Show("Selected Schedule deleted", "Successfull record delete operation");
            }
        }

        //BTN CLEAR SCHEDULE
        private void ScheduleClearButton_Click(object sender, EventArgs e)
        {
            ClearScheduleInput();
        }

        //CLEAR SCHEDULE
        private void ClearScheduleInput()
        {
            ScheduleIdTextbox.Text = string.Empty;
            ScheduleTimeEndDTP.Text = string.Empty;
            ScheduleTimeEndDTP.Text = string.Empty;
            ScheduleValidOnDTP.Text = string.Empty;
            ScheduleValidUntilDTP.Text = string.Empty;
            ScheduleStatusCombobox.Text = string.Empty;
            ScheduleSubjectCombobox.Text = string.Empty;
            ScheduleSemesterTextbox.Text = string.Empty;
        }

        //SCHEDULE TABLE
        private void MiscTabSchedulesDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DisplayScheduleDetails();
        }

        //SCHEDULE TABLE GRID
        private void DisplayScheduleDetails()
        {
            ScheduleIdTextbox.Text = MiscTabSchedulesDGV.Rows[MiscTabSchedulesDGV.CurrentRow.Index].Cells[0].Value.ToString();
            ScheduleFacilityCombobox.Text = MiscTabSchedulesDGV.Rows[MiscTabSchedulesDGV.CurrentRow.Index].Cells[1].Value.ToString();
            ScheduleTimeStartDTP.Text = MiscTabSchedulesDGV.Rows[MiscTabSchedulesDGV.CurrentRow.Index].Cells[2].Value.ToString();
            ScheduleTimeEndDTP.Text = MiscTabSchedulesDGV.Rows[MiscTabSchedulesDGV.CurrentRow.Index].Cells[3].Value.ToString();
            ScheduleValidOnDTP.Text = MiscTabSchedulesDGV.Rows[MiscTabSchedulesDGV.CurrentRow.Index].Cells[4].Value.ToString();
            ScheduleValidUntilDTP.Text = MiscTabSchedulesDGV.Rows[MiscTabSchedulesDGV.CurrentRow.Index].Cells[5].Value.ToString();
            ScheduleStatusCombobox.Text = MiscTabSchedulesDGV.Rows[MiscTabSchedulesDGV.CurrentRow.Index].Cells[6].Value.ToString();
            ScheduleSubjectCombobox.SelectedValue = MiscTabSchedulesDGV.Rows[MiscTabSchedulesDGV.CurrentRow.Index].Cells[7].Value;
            ScheduleSemesterTextbox.Text = MiscTabSchedulesDGV.Rows[MiscTabSchedulesDGV.CurrentRow.Index].Cells[8].Value.ToString();
        }

        //ATTENDANCE ATTENDANCE ATTENDANCE ATTENDANCE ATTENDANCE ATTENDANCE ATTENDANCE ATTENDANCE ATTENDANCE ATTENDANCE ATTENDANCE ATTENDANCE ATTENDANCE

        //SEARCH
        private void AttendanceFindButton_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    using (SqlConnection connection = new SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("[spFR_SearchAttendanceRecords]", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@OwnerId", AttendanceSearchTextbox.Text);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        MiscTabAttendanceDGV.DataSource = dt;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Delete selected Instructor failed.");
            }
            finally
            {
                MessageBox.Show("Selected Instructor deleted", "Successfull record delete operation");
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------//

































    }
}

