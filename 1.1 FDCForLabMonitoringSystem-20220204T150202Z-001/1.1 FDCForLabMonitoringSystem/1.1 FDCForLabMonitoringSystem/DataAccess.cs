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
    public class DataAccess
    {
        //DONE
        public static DataTable GetData(string TableName)
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

        //DONE
        public static DataTable GetDataSqlText(string SqlQueryText)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlQueryText, connection);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter sa = new SqlDataAdapter();
                    sa.SelectCommand = cmd;
                    sa.Fill(dt);
                }
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.Message, "SQL query operation failed.");
            }
            finally
            {

            }
            return dt;
        }

        //DONE
        public static bool IsInstructorIn(int instructorId, int scheduleId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("spFR_SearchAttendanceRecords", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OwnerId", instructorId);                    
                    cmd.Parameters.AddWithValue("@ScheduleId", scheduleId);
                    SqlDataAdapter sa = new SqlDataAdapter();
                    sa.SelectCommand = cmd;
                    sa.Fill(dt);                    
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL search instructor failed.");
            }
            finally
            {
                
            }
            return dt.Rows.Count > 0;
        }

        //On going
        public static DataTable GetAvailableSchedule()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("spFR_SelectAvailableSchedule", connection);
                    cmd.CommandType = CommandType.StoredProcedure; ;
                    cmd.Parameters.AddWithValue("@CurrentDate", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("@TimeStart", DateTime.Now.ToString("HH:mm"));
                    SqlDataAdapter sa = new SqlDataAdapter();
                    sa.SelectCommand = cmd;
                    sa.Fill(dt);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL insert operation failed.");
            }
            finally
            {

            }
            return dt;
        }

        public static DataTable GetStudentSchedules()
        {
            DataTable dt = new DataTable();

            return dt;
        }

        public static bool IsStudent(string Id)
        {
            DataTable dt = new DataTable();
            dt = GetDataSqlText("Select * from StudentsTable where [StudentId]=" + Id.ToString());
            return dt.Rows.Count > 0;
        }

        public static bool IsLabStaff(string Id)
        {
            DataTable dt = new DataTable();
            dt = GetDataSqlText("Select * from LabStaffTable where [StaffId]=" + Id.ToString());
            return dt.Rows.Count > 0;
        }

        public static bool IsInstructor(string Id)
        {
            DataTable dt = new DataTable();
            dt = GetDataSqlText("Select * from InstructorsTable where [InstructorId]=" + Id.ToString());
            return dt.Rows.Count > 0;
        }

        
        //ATOA NI
        public static void WriteAttendanceIN(int OwnerId, DateTime AttendanceDate, DateTime TimeIn, DateTime TimeOut, int ScheduleId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                {
                    connection.Open();
                    DataTable dtSched = new DataTable();
                    dtSched = GetDataSqlText("SELECT FORMAT(CAST(TimeStart as time), 'hh\\:mm') as TimeStart, FORMAT(CAST(TimeEnd as time), 'hh\\:mm') as TimeEnd FROM SchedulesTable WHERE ScheduleId = " + ScheduleId.ToString());
                    SqlCommand cmd = new SqlCommand("spFR_InsertOneAttendanceRecord", connection);
                    cmd.CommandType = CommandType.StoredProcedure; ;
                    cmd.Parameters.AddWithValue("@OwnerId", OwnerId);
                    cmd.Parameters.AddWithValue("@AttendanceDate", AttendanceDate.Date);
                    cmd.Parameters.AddWithValue("@TimeIn", TimeIn.ToString("HH:mm"));
                    //cmd.Parameters.AddWithValue("@TimeOut", "00:00");
                    if (dtSched.Rows.Count > 0 && dtSched != null)
                    {
                        cmd.Parameters.AddWithValue("@TimeOut", dtSched.Rows[0][1].ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@TimeOut", "00:00");
                    }
                    cmd.Parameters.AddWithValue("@ScheduleId", ScheduleId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL insert operation failed.");
            }
            finally
            {

            }
        }

        //public static void WriteAttendanceIN(int OwnerId, DateTime AttendanceDate, DateTime TimeIn, DateTime TimeOut, int ScheduleId)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
        //        {
        //            connection.Open();
        //            SqlCommand cmd = new SqlCommand("spFR_InsertOneAttendanceRecord", connection);
        //            cmd.CommandType = CommandType.StoredProcedure; ;
        //            cmd.Parameters.AddWithValue("@OwnerId", OwnerId);
        //            cmd.Parameters.AddWithValue("@AttendanceDate", AttendanceDate.Date);
        //            cmd.Parameters.AddWithValue("@TimeIn", TimeIn.ToString("HH:mm"));
        //            cmd.Parameters.AddWithValue("@TimeOut", "00:00");
        //            cmd.Parameters.AddWithValue("@ScheduleId", ScheduleId);
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show(ex.Message, "SQL insert operation failed.");
        //    }
        //    finally
        //    {

        //    }
        //}

        public static void WriteAttendanceOut(int OwnerId, DateTime AttendanceDate, DateTime TimeIn, DateTime TimeOut, int ScheduleId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("spFR_InsertOneAttendanceRecord", connection);
                    cmd.CommandType = CommandType.StoredProcedure; ;
                    cmd.Parameters.AddWithValue("@OwnerId", OwnerId);
                    cmd.Parameters.AddWithValue("@AttendanceDate", AttendanceDate.Date);
                    cmd.Parameters.AddWithValue("@TimeOut", TimeOut.ToString("HH:mm"));
                    cmd.Parameters.AddWithValue("@TimeIn", "00:00");
                    cmd.Parameters.AddWithValue("@ScheduleId", ScheduleId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL insert operation failed.");
            }
            finally
            {

            }
        }

        public class FaceDataStore:IFaceDataStore
        {
            private SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString"));
            
            public FaceDataStore()
            {
                SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString"));
            }
            public String SaveFace(string username, Byte[] faceBlob, int UserId)
            {
                try
                {
                    //var exisitingUserId = GetUserId(username);
                    //if (exisitingUserId == 0) exisitingUserId = GenerateUserId();
                    //_connection.Open();
                    // var insertQuery = "INSERT INTO ImagesRepoTable(StudentId,ImageData, ArchivedOn";

                    //var cmd = new SqlCommand(insertQuery, _connection);                    
                    using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("FaceRecognitionDBConnectionString")))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("spFR_InsertOneImageRepoRecord", connection);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@GeneralImageId", UserId);
                        cmd.Parameters.AddWithValue("@ArchivedOn", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("@ImageLabel", username);
                        //cmd.Parameters.Add("@ImageData", SqlDbType.VarBinary, faceBlob.Length).Value = faceBlob;
                        cmd.Parameters.AddWithValue("@ImageData", faceBlob as Byte[]);
                        
                        var result = cmd.ExecuteNonQuery();
                        return String.Format("{0} face(s) saved successfully", username);
                    }                   
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    
                }

            }

            public List<Face> CallFaces(string username)
            {
                List<Face> faces = new List<Face>();
                try
                {
                    connection.Open();
                    var query = username.ToLower().Equals("ALL_USERS".ToLower()) ? "SELECT * FROM ImagesRepoTable" : "SELECT * FROM ImagesRepoTable WHERE username=@username";
                    var cmd = new SqlCommand(query, connection);
                    if (!username.ToLower().Equals("ALL_USERS".ToLower())) cmd.Parameters.AddWithValue("username", username);
                    var result = cmd.ExecuteReader();
                    if (!result.HasRows) return null;

                    while (result.Read())
                    {
                        var face = new Face();
                        face.GeneralImageId = Convert.ToInt32(result["GeneralImageId"]);
                        face.ArchivedOn = Convert.ToDateTime(result["ArchivedOn"]);
                        face.ImageLabel = (String)result["ImageLabel"];
                        //face.ImageId = Convert.ToInt32(result["ImageId"]);
                        face.ImageData = (byte[])result["ImageData"];
                        
                        faces.Add(face);
                    }
                    faces = faces.OrderBy(f => f.GeneralImageId).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
                finally
                {
                    connection.Close();
                }
                return faces;
            }

            public int GetUserId(string username)
            {
                var userId = 0;
                try
                {
                    connection.Open();
                    var selectQuery = "SELECT userId FROM faces WHERE username=@username LIMIT 1";
                    var cmd = new SqlCommand(selectQuery, connection);
                    cmd.Parameters.AddWithValue("username", username);
                    var result = cmd.ExecuteReader();
                    if (!result.HasRows) return 0;
                    while (result.Read())
                    {
                        userId = Convert.ToInt32(result["userId"]);

                    }
                }
                catch
                {
                    return userId;
                }
                finally
                {
                    connection.Close();
                }
                return userId; ;
            }

            public string GetUsername(int userId)
            {
                var username = "";
                try
                {
                    connection.Open();
                    var selectQuery = "SELECT username FROM faces WHERE userId=@userId LIMIT 1";
                    var cmd = new SqlCommand(selectQuery, connection);
                    cmd.Parameters.AddWithValue("userId", userId);
                    var result = cmd.ExecuteReader();
                    if (!result.HasRows) return username;
                    while (result.Read())
                    {
                        username = (String)result["username"];

                    }
                }
                catch
                {
                    return username;
                }
                finally
                {
                    connection.Close();
                }
                return username; ;
            }

            public List<string> GetAllUsernames()
            {
                var usernames = new List<string>();
                try
                {
                    connection.Open();
                    var query = "SELECT DISTINCT username FROM faces";
                    var cmd = new SqlCommand(query, connection);
                    var result = cmd.ExecuteReader();
                    while (result.Read())
                    {
                        usernames.Add((String)result["username"]);
                    }
                    usernames.Sort();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
                finally
                {
                    connection.Close();
                }
                return usernames;
            }


            public bool DeleteUser(string username)
            {
                var toReturn = false;
                try
                {
                    connection.Open();
                    var query = "DELETE FROM faces WHERE username=@username";
                    var cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("username", username);
                    var result = cmd.ExecuteNonQuery();
                    if (result > 0) toReturn = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return toReturn;
                }
                finally
                {
                    connection.Close();
                }
                return toReturn;
            }

            public int GenerateUserId()
            {
                var date = DateTime.Now.ToString("MMddHHmmss");
                return Convert.ToInt32(date);
            }

            public bool IsUsernameValid(string username)
            {
                throw new NotImplementedException();
            }

            public string SaveAdmin(string username, string password)
            {
                throw new NotImplementedException();
            }             

        }
    }
}
