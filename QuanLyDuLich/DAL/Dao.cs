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
        VietTravel store;
        const string filepath = "store.bin";
        string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Quan_Tri_Vien\bin\Debug");
        public Dao(VietTravel store)
        {
            this.store = store;
        }
        public void Save()
        {
            using (Stream stream = File.Create(path + filepath))
            {
                var serializer = new BinaryFormatter();
                serializer.Serialize(stream, store);
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

                Copy(st.Agencies, store.Agencies);
                Copy(st.Clients , store.Clients);
                Copy(st.Admins, store.Admins);
                Copy(st.Orders, store.Orders);
            }


        }
    }
}
