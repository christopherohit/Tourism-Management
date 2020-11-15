using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLich_Library.Models
{
    [Serializable]
    public class Client : User
    {
        public string Emails { set; get; }
        public Client(string name , int password, string e_mail)
        {
            Name = name;
            Password = password;
            Emails = e_mail;
        }
    }
}
