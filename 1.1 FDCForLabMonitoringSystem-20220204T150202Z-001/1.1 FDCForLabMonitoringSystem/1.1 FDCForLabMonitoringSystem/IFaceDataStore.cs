using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _1._1_FDCForLabMonitoringSystem
{
    interface IFaceDataStore
    {
        String SaveFace(String username, Byte[] faceBlob, int UserId);
        List<Face> CallFaces(String username);
        bool IsUsernameValid(String username);
        String SaveAdmin(String username, String password);
        bool DeleteUser(String username);
        int GetUserId(String username);
        int GenerateUserId();
        String GetUsername(int userId);
        List<String> GetAllUsernames();
    }

    public class Face
    {
        public int GeneralImageId { get; set;}
        public DateTime ArchivedOn { get; set; }
        public String ImageLabel { get; set; }
        public int ImageId { get; set; }
        public byte[] ImageData { get; set; }     
    }
}
