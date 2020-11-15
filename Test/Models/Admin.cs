using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLich_Library.Models
{
    // Admin = Name + Password
    [Serializable]
    public class Admin : User
    {
        public Admin(string name, int password)
        {
            Name = name;
            Password = password;
        }
    }
}
