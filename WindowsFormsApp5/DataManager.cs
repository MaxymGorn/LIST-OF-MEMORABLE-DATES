using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WindowsFormsApp5;

namespace ConsoleApp4
{
    public class DatManage
    {


        public void SerializeXML<T>(T users, string path) where T : class
        {
            XmlSerializer xml = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                xml.Serialize(fs, users);
            }
        }
        public T DeserializeXML<T>(string SelectedPath) where T : class
        {
            XmlSerializer xml = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(SelectedPath, FileMode.OpenOrCreate))
            {
                return (T)xml.Deserialize(fs);
            }

             
            
           
        }
        //public object DeserializeBinary(string SelectedPath) 
        //{
        //    BinaryFormatter binaryFormatter = new BinaryFormatter();
        //    FileStream fs = new FileStream(SelectedPath, FileMode.Open, FileAccess.Read);
        //    return binaryFormatter.Deserialize(fs);
        //}

        //public void WriteBinary<T>(T obj, string path) where T : class
        //{
        //    BinaryFormatter bf = new BinaryFormatter();
        //    FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
        //    bf.Serialize(fs, obj);
        //    fs.Close();
        //}
    }
}
