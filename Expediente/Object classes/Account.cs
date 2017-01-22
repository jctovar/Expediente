using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expediente.Object_classes
{
    class Account
    {
        int varId;
        string varUsername;
        string varFirstname;
        string varLastname;
        string varEmail;
        string varPassword;
        public int Id
        {
            get { return this.varId; }
            set { this.varId = value; }
        }
        public string Username
        {
            get { return this.varUsername; }
            set { this.varUsername = value; }
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
        public string Password
        {
            get { return this.varPassword; }
            set { this.varPassword = value; }
        }
    }
}
