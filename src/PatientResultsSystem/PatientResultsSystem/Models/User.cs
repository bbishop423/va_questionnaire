using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientResultsSystem.Models
{
    public class User
    {
        public string UserName { get; set; }
        public UserTypes Type { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        
        public User(string name, UserTypes type, string firstName, string lastname)
        {
            this.UserName = name;
            this.Type = type;
            this.FirstName = firstName;
            this.Lastname = lastname;
        }
    }
}
