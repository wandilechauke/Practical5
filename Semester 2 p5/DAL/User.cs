using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
     public class User
    {
        public int RoleID { get; set; }
        public string Status { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RoleDescription { get; set; }
        public string ContentType { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public int CategoryID { get; set; }
        public string CategoryDescription { get; set; }
        public string UploadData { get; set; }
        public int PhotoID { get; set; }
    }
}
