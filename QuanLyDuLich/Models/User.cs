using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLich_Library.Models
{
    // La Lop Cha Cho Admin va Client
    [Serializable]
    public abstract class User
    {
        public string Name { set; get; }
        public int Password { set; get; }
    }
}
