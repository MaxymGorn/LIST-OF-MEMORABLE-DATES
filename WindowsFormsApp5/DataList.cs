using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5
{
    [Serializable]
    public class DataList
    {

        public List<Data> Datas { get; set; } = new List<Data>();
        public DataList()
        {

        }


    }
}
