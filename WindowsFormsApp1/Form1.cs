using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public class Menu_Data
        {
            public string name { get; set; }
            public string price { get; set; }
            public string cooking_time { get; set; }
            public string gram { get; set; }
            public string kitchen { get; set; }
        }

        private static string FileName = "Data.json";
        private static string FilePath = @"Data.json";
        public Form1()
        {
            InitializeComponent();
            EditLabel(0);
        }


        void add_menu(string Name, string Price, string Cooking_time, string Gram, string Kitchen)
        {
            var data = JsonConvert.DeserializeObject<List<Menu_Data>>(File.ReadAllText(FilePath));

            data.Add(new Menu_Data { name = Name, price = Price, cooking_time = Cooking_time, gram = Gram, kitchen = Kitchen });
            string serialize = JsonConvert.SerializeObject(data, Formatting.Indented);
            if (serialize.Count() > 1)
            {
                if (!File.Exists(FileName))
                {
                    File.Create(FileName).Close();
                }
                File.WriteAllText(FilePath, serialize, Encoding.UTF8);
            }
            EditLabel(0);
            MainButton(1);

        }

        void delete_menu(string Name)
        {
            var data = JsonConvert.DeserializeObject<List<Menu_Data>>(File.ReadAllText(FilePath));
            data.RemoveAll(x => x.name == Name);
            string serialize = JsonConvert.SerializeObject(data, Formatting.Indented);
            if (serialize.Count() > 1)
            {
                if (!File.Exists(FileName))
                {
                    File.Create(FileName).Close();
                }
                File.WriteAllText(FilePath, serialize, Encoding.UTF8);
            }
            EditLabel(0);
            MainButton(1);
        }

        void search_menu(string Name)
        {
            textBox1.Text = "";
            var data = JsonConvert.DeserializeObject<List<Menu_Data>>(File.ReadAllText(FilePath));
            Menu_Data FoundData = data.Find(found => found.name == Name);
            string info = "     " + FoundData.name + "\t\t" + FoundData.price + "     \t   " + FoundData.cooking_time + "\t\t" + FoundData.gram + "                 " + FoundData.kitchen;

            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("      Name     │   price     │ cooking_time │    gram    │ kitchen");
            textBox1.AppendText(Environment.NewLine);

            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText(info);
            textBox1.AppendText(Environment.NewLine);


            string serialize = JsonConvert.SerializeObject(data, Formatting.Indented);
            if (serialize.Count() > 1)
            {
                if (!File.Exists(FileName))
                {
                    File.Create(FileName).Close();
                }
                File.WriteAllText(FilePath, serialize, Encoding.UTF8);
            }
            EditLabel(0);
            MainButton(1);
        }

        void MainButton(int check)
        {
            if (check == 0)
            {
                button1.Enabled = false;
                button4.Enabled = false;
                button3.Enabled = false;
                button2.Enabled = false;
            }
            if (check == 1)
            {
                button1.Enabled = true;
                button4.Enabled = true;
                button3.Enabled = true;
                button2.Enabled = true;
            }
        }

        void EditLabel(int check)
        {
            if (check == 0)
            {
                label1.Hide();
                label2.Hide();
                label3.Hide();
                label4.Hide();
                label5.Hide();
                textBox2.Hide();
                textBox3.Hide();
                textBox4.Hide();
                textBox5.Hide();
                textBox6.Hide();
                SortName.Hide();
                button8.Hide();
                button7.Hide();
                button6.Hide();

                SortName.Hide();
                SortPrice.Hide();
                Sortkitchen.Hide();
            }
            if (check == 1)
            {
                label1.Show();
                label2.Show();
                label3.Show();
                label4.Show();
                label5.Show();
                textBox2.Show();
                textBox3.Show();
                textBox4.Show();
                textBox5.Show();
                textBox6.Show();
                SortName.Show();
                
                SortName.Hide();
                SortPrice.Hide();
                Sortkitchen.Hide();
            }
            if (check == 2)
            {
               
                label1.Show();
                label2.Hide();
                label3.Hide();
                label4.Hide();
                label5.Hide();
                textBox2.Show();
                textBox3.Hide();
                textBox4.Hide();
                textBox5.Hide();
                textBox6.Hide();
                SortName.Hide();

                SortName.Hide();
                SortPrice.Hide();
                Sortkitchen.Hide();
            }
            if (check == 3)
            {

                label1.Show();
                label2.Hide();
                label3.Hide();
                label4.Hide();
                label5.Hide();
                textBox2.Show();
                textBox3.Hide();
                textBox4.Hide();
                textBox5.Hide();
                textBox6.Hide();
                SortName.Hide();
               
                SortName.Hide();
                SortPrice.Hide();
                Sortkitchen.Hide();
            }
            if (check == 4)
            {

                label1.Hide();
                label2.Hide();
                label3.Hide();
                label4.Hide();
                label5.Hide();
                textBox2.Hide();
                textBox3.Hide();
                textBox4.Hide();
                textBox5.Hide();
                textBox6.Hide();
                SortName.Hide();
                button8.Hide();
                SortName.Show();
                SortPrice.Show();
                Sortkitchen.Show();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            EditLabel(1);
            MainButton(0);
            button8.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            EditLabel(4);
            var data = JsonConvert.DeserializeObject<List<Menu_Data>>(File.ReadAllText(FilePath));
            textBox1.Text = "";
       
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("     Name      │       price     │ cooking_time │\tgram    │\tkitchen");
            textBox1.AppendText(Environment.NewLine);
    
            for (int i = 0; i < data.Count; i++)
            {
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("     " + data[i].name + "\t\t" + data[i].price + "     \t   " + data[i].cooking_time + "\t\t" + data[i].gram + "             " + data[i].kitchen);
                textBox1.AppendText(Environment.NewLine);
              
            }
            textBox1.AppendText(Environment.NewLine);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            var data = JsonConvert.DeserializeObject<List<Menu_Data>>(File.ReadAllText(FilePath));
            List<Menu_Data> SortData = data.OrderBy(o => o.kitchen).ToList();
            textBox1.Text = "";

            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("     Name      │       price     │ cooking_time │\tgram    │ \tkitchen");
            textBox1.AppendText(Environment.NewLine);

            for (int i = 0; i < data.Count; i++)
            {
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("     " + SortData[i].name + "\t\t" + SortData[i].price + "     \t   " + SortData[i].cooking_time + "\t\t" + SortData[i].gram + "                 " + SortData[i].kitchen);
                textBox1.AppendText(Environment.NewLine);
            }
            textBox1.AppendText(Environment.NewLine);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainButton(0);
            EditLabel(2);
            button6.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            MainButton(0);
            EditLabel(2);
            button7.Show();
        }

        private void SortName_Click(object sender, EventArgs e)
        {
            var data = JsonConvert.DeserializeObject<List<Menu_Data>>(File.ReadAllText(FilePath));
            List<Menu_Data> SortData = data.OrderBy(o => o.name).ToList();
            textBox1.Text = "";
            
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("     Name      │       price     │ cooking_time │\tgram    │ \tkitchen");
            textBox1.AppendText(Environment.NewLine);
           
            for (int i = 0; i < data.Count; i++)
            {
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("     " + SortData[i].name + "\t\t" + SortData[i].price + "     \t   " + SortData[i].cooking_time + "\t\t" + SortData[i].gram + "                 " + SortData[i].kitchen);
                textBox1.AppendText(Environment.NewLine);
            }
            textBox1.AppendText(Environment.NewLine);
           
        }

        private void SortPrice_Click(object sender, EventArgs e)
        {
            var data = JsonConvert.DeserializeObject<List<Menu_Data>>(File.ReadAllText(FilePath));
            List<Menu_Data> SortData = data.OrderBy(o => o.gram).ToList();
            textBox1.Text = "";

            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("     Name      │       price     │ cooking_time │\tgram    │ \tkitchen");
            textBox1.AppendText(Environment.NewLine);

            for (int i = 0; i < data.Count; i++)
            {
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("     " + SortData[i].name + "\t\t" + SortData[i].price + "     \t   " + SortData[i].cooking_time + "\t\t" + SortData[i].gram + "                 " + SortData[i].kitchen);
                textBox1.AppendText(Environment.NewLine);
            }
            textBox1.AppendText(Environment.NewLine);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EditLabel(0);
            MainButton(1);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            add_menu(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            delete_menu(textBox2.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
           search_menu(textBox2.Text);
        }
    }
}

