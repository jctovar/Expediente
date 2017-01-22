using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expediente.Object_classes
{
    class User
    {
        int varId;
        string varFirstname;
        string varLastname;
        string varEmail;
        DateTime varBirthday;
        int varGender;
        public int Id
        {
            get { return this.varId; }
            set { this.varId = value; }
        }
        public string Firstname
        {
            get { return this.varFirstname; }
            set { this.varFirstname = value; }
        }
        public string Lastname
        {
            get { return this.varLastname; }
            set { this.varLastname = value; }
        }
        public string Email
        {
            get { return this.varEmail; }
            set { this.varEmail = value; }
        }
        public DateTime Birthday
        {
            get { return this.varBirthday; }
            set { this.varBirthday = value; }
        }
        public int Gender
        {
            get { return this.varGender; }
            set { this.varGender = value; }
        }
    }
}
