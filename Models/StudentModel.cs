using System;

namespace StudentDetails.Models
{
    public class StudentModel
    {
        public int RollNo { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public bool ShowRequestId()
        { 
            if(RollNo != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
