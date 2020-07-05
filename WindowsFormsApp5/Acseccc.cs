using ConsoleApp4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Acseccc : Form
    {
        public Acseccc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
                if(zaholovok.Text.Length==0 || opisanna.Text.Length==0)
                {
                    //throw new Exception("Eror!");
                }
                Data data = new Data();
                data.DateTime = DateTime.Parse(dateTimePicker1.Value.ToString("dd/MM/yyyy"));
                data.ZaholEvent = zaholovok.Text;
                data.TextEvent = opisanna.Text;
                DataList list_tmp = new DataList();

                DatManage datManage = new DatManage();
            list_tmp = datManage.DeserializeXML<DataList>("List.xml");
            list_tmp.Datas.Add(data);

                datManage.SerializeXML(list_tmp, "List.xml");



                this.DialogResult = DialogResult.OK;
            //}
            //catch (Exception eror)
            //{
            //    MessageBox.Show(eror.Message, "Length tewfewxt=0!",MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            //}
            
        }

        private void Acseccc_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
