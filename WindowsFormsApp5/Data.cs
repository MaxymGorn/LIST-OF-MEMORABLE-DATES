using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5
{
    [Serializable]
    public class Data
    {
        public DateTime DateTime { get; set; } = new DateTime();
        public string TextEvent { get; set; } 
        public string ZaholEvent { get; set; }
        public Data()
        {

        }

    }
}
