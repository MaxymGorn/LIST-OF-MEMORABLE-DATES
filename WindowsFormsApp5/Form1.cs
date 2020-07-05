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
    public partial class Form1 : Form
    {
        DataList DataLists = new DataList();
        DatManage datManage = new DatManage();
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadEvents()
        {

            DataLists = datManage.DeserializeXML<DataList>("List.xml");
            listBox1.Items.Clear();
            foreach (var el in DataLists.Datas)
            {
                ListViewItem listViewItem = new ListViewItem(el.ZaholEvent);

                listViewItem.Tag = el.ZaholEvent;


                listBox1.Items.Add(listViewItem.Tag);
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadEvents();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndex < 0)
                {
                    throw new Exception("Eror!");
                }
                MessgeText.Visible = false;
                timer1.Stop();
                monthCalendar1.MaxDate = (DataLists.Datas.ToArray()[listBox1.SelectedIndex].DateTime);

                DateTime currentDate = DateTime.Now;
               TimeSpan span = DataLists.Datas.ToArray()[listBox1.SelectedIndex].DateTime -currentDate;
                Day.Text = span.Days.ToString();
                hsec.Text = span.Seconds.ToString();
                hour.Text = span.Hours.ToString();
                minut.Text = span.Minutes.ToString();
             
                timer1.Tick += new EventHandler(timer1_Tick);

                if(Day.Text[0]!='-' && hour.Text[0] != '-' && minut.Text[0] != '-' && hsec.Text[0] != '-')
                {
                    timer1.Start();

                }
                else
                {
                    ShowMesText();
                }
              


            }
            catch (Exception eror)
            {
                MessageBox.Show(eror.Message, "Index eror!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void ShowMesText()
        {
            MessgeText.Visible = true;
            await Task.Delay(2500);
            MessgeText.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            if (DialogResult.OK == form.ShowDialog())
            {
                MessageBox.Show("Соообщение", "Доступ запрещен!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
  
            else 
            {
                LoadEvents();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndex < 0)
                {
                    throw new Exception("Eror!");
                }
                DataLists.Datas.RemoveAt(listBox1.SelectedIndex);
                datManage.SerializeXML(DataLists, "List.xml");
                LoadEvents();

            }
            catch (Exception eror)
            {
                MessageBox.Show(eror.Message, "Index eror!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    if (listBox1.SelectedIndex < 0)
                    {
                        throw new Exception("Eror!");
                    }
                    EditForm editForm = new EditForm(DataLists.Datas.ToArray()[listBox1.SelectedIndex].ZaholEvent, DataLists.Datas.ToArray()[listBox1.SelectedIndex].TextEvent, DataLists.Datas.ToArray()[listBox1.SelectedIndex].DateTime);
                    if (DialogResult.OK == editForm.ShowDialog())
                    {
                        DataLists.Datas.ToArray()[listBox1.SelectedIndex].ZaholEvent = editForm.textBox1.Text.ToString();
                        DataLists.Datas.ToArray()[listBox1.SelectedIndex].TextEvent = editForm.textBox2.Text.ToString();
                      
                        datManage.SerializeXML(DataLists, "List.xml");
                        LoadEvents();
                    }

                }
                catch (Exception eror)
                {
                    MessageBox.Show(eror.Message, "Index eror!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
    


            int tmp = 0;


            int.TryParse(hsec.Text, out tmp);
            tmp--;




            int tmp_s = 0;
            if (Convert.ToInt32(minut.Text) != 0 && (Convert.ToInt32(hour.Text) != 0) || Convert.ToInt32(Day.Text) != 0)
            {
                if (tmp <= 0)
                {

                    int.TryParse(minut.Text, out tmp_s);
                    minut.Text = Convert.ToString(tmp_s - 1);
                    hsec.Text = "59";
                   

                    if (tmp_s == 0)
                    {
                        int tmp_hour = 0;
                        int.TryParse(hour.Text, out tmp_hour);
                        if (Convert.ToInt32(Day.Text) != 0)
                        {
                            if (tmp_hour == 0)
                            {
                                int tmp2 = 0;

                                int.TryParse(Day.Text, out tmp2);
                                Day.Text = Convert.ToString(tmp2 - 1);
                                hour.Text = "59";
                            }
                            else
                            {
                                hour.Text = Convert.ToString(tmp_hour - 1);
                            }
                            minut.Text = Convert.ToString(59);
                        }
                    }

                }
                else
                {
                    this.hsec.Text = tmp.ToString();
                }
            }
            else if (Convert.ToInt32(hour.Text) > 0)
            {
                if (tmp <= 0)
                {

                    int.TryParse(minut.Text, out tmp_s);
                    minut.Text = Convert.ToString(tmp_s - 1);
                    if (tmp_s == 0)
                    {
                        int tmp_hour = 0;
                        int.TryParse(hour.Text, out tmp_hour);
                        hour.Text = Convert.ToString(tmp_hour - 1);
                        minut.Text = "59";


                    }
                    hsec.Text = "99";
              
                }


                this.hsec.Text = tmp.ToString();

            }
            else if (Convert.ToInt32(minut.Text) > 0)
            {

                if (tmp <= 0)
                {
                    int.TryParse(minut.Text, out tmp_s);
                    minut.Text = Convert.ToString(tmp_s - 1);
                    hsec.Text = "59";
                
                }
                else
                    this.hsec.Text = tmp.ToString();


            }
            else if (tmp != -1)
            {

                this.hsec.Text = tmp.ToString();
            }
            else
            {
               
                timer1.Stop();
                timer1.Tag = "Stop";

            }

        }
    }
}
