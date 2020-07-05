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
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
        }
        public EditForm(string data, string data2, DateTime dateTime) : this()
        {
         
            textBox1.Text = data;
            textBox2.Text = data2;
            dateTimePicker1.Value = dateTime;
        }
        private void EditForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
                {
                    throw new Exception("Eror Save!");
                }
               
                DialogResult = DialogResult.OK;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Please Enter Text!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }
    }
}
