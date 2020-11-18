using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using QuanLyDuLich_Library.Models;

namespace QuanLyDuLich_Library.DAL
{
    public class Dao
    {
        VietTravel GetVietTravel;
        const string filepath = "store.bin";
        string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"D:\Lesson\RIT\C #\Winform\Newest\Newest\bin");
        public Dao(VietTravel store)
        {
            this.GetVietTravel = store;
        }
        public void Save()
        {
            using (Stream stream = File.Create(path + filepath))
            {
                var serializer = new BinaryFormatter();
                serializer.Serialize(stream, GetVietTravel);
            }
        }
        public void Load()
        {
            void Copy<T>(List<T> from, List<T> to)
            {
                to.Clear();
                to.AddRange(from);
            }

            using ( Stream stream = File.OpenRead(path + filepath))
            {
                var serializer = new BinaryFormatter();
                VietTravel st = (VietTravel)serializer.Deserialize(stream);

                Copy(st.Agencies, GetVietTravel.Agencies);
                Copy(st.Clients , GetVietTravel.Clients);
                Copy(st.Admins, GetVietTravel.Admins);
                Copy(st.Orders, GetVietTravel.Orders);
            }


        }
    }
}
