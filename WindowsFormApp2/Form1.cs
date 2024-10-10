
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public MySqlConnection con = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        private object st_item;
        private object list;

        public Form1()
        {
            InitializeComponent();
            con.ConnectionString = @"server=localhost;database=pizza_system;userid=root;password=;";
        }

        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() == "Small")
            {
                string query = "Select (prices) From pizza_prices WHERE ID = 1";
                con.Open();
                cmd = new MySqlCommand(query, con);
                Int32 fun = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                con.Close();
                textBox1.Text = fun.ToString();
            }
            else if(comboBox1.SelectedItem.ToString() == "Medium")
            {
                string query = "Select (prices) From pizza_prices WHERE ID = 2";
                con.Open();
                cmd = new MySqlCommand(query, con);
                Int32 fun = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                con.Close();
                textBox1.Text = fun.ToString();
            }
            else if(comboBox1.SelectedItem.ToString() == "Large")
            {
                string query = "Select (prices) From pizza_prices WHERE ID = 3";
                con.Open();
                cmd = new MySqlCommand(query, con);
                Int32 fun = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                con.Close();
                textBox1.Text = fun.ToString();
            }
            else
            {
                textBox1.Text = "0";
            }

                
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text.Length > 0)
                {
                    double total= (Convert.ToInt16(textBox1.Text) *Convert.ToInt16(textBox2.Text));
                    textBox3.Text = total.ToString();
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message); 
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(textBox3.Text.Length > 0)
            {
                string[] arr = new string[4];
                arr[0] = comboBox1.Text;
                arr[1] = textBox1.Text; 
                arr[2]=textBox2.Text;
                arr[3]=textBox3.Text;
                ListViewItem Lview = new ListViewItem(arr);
                listView1.Items.Add(Lview);

                textBox4.Text=(Convert.ToInt16(textBox4.Text)+Convert.ToInt16(textBox3.Text)).ToString();

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if(textBox5.Text.Length > 0)
            {
                textBox6.Text=(Convert.ToInt16(textBox4.Text)-Convert.ToInt16(textBox5.Text)).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                for(int i=0;i<listView1.Items.Count;i++)
                {
                    if (listView1.Items[i].Selected)
                    {
                        textBox4.Text = (Convert.ToInt16(textBox4.Text) - Convert.ToInt16(listView1.Items[i].SubItems[3].Text)).ToString();
                        listView1.Items[i].Remove();
                    }
                }
            }
        }

       
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics gp = e.Graphics;
            Font font = new Font("Courier New", 14);
            float fontHeight=font.GetHeight();
            int startx = 190;
            int starty = 40;
            int offset = 30;
            float leftmargin = e.MarginBounds.Left;
            float topmargin = e.MarginBounds.Top;
            gp.DrawString("WELCOME TO PIZZA SHOP", new Font("Courier New", 20), new SolidBrush(Color.Black), startx, starty);
            string top = "DATE:" + dateTimePicker1.Text.PadRight(5);
            gp.DrawString(top, font, new SolidBrush(Color.Black), startx, starty + offset);
            offset = offset + (int)FontHeight;
            gp.DrawString("----------------------",font, new SolidBrush(Color.Black), startx, starty + offset);
            offset = offset + 20;
            gp.DrawString("Types\tPrices\tQuantity Total",font,new SolidBrush(Color.Black),startx, starty + offset);
            offset = offset + 20;
            for(int x = 0; x<listView1.Items.Count; x++)
            {
                gp.DrawString(listView1.Items[x].SubItems[0].Text + "\t" + listView1.Items[x].SubItems[1].Text + "\t" + listView1.Items[x].SubItems[2].Text + "\t" + listView1.Items[x].SubItems[3].Text + "\t", new Font("Courier New",15), new SolidBrush(Color.Black), startx, starty + offset);
                offset = offset + 20;
            }
            offset = offset + (int)FontHeight + 5;
            gp.DrawString("------------------------", font, new SolidBrush(Color.Black), startx, starty + offset);
            offset = offset + 15;

            gp.DrawString("Sub Total = " + textBox4.Text + ".00", font, new SolidBrush(Color.Black), startx, starty + offset);
            offset = offset + 20;
            gp.DrawString("Paid      = " + textBox5.Text + ".00", font, new SolidBrush(Color.Black), startx, starty + offset);
            offset = offset + 20;
            gp.DrawString("Refund      = " + textBox6.Text + ".00", font, new SolidBrush(Color.Black), startx, starty + offset);
            offset = offset + 20;
            gp.DrawString("---------------------------- ", font, new SolidBrush(Color.Black), startx, starty + offset);
            offset = offset + 20;
            gp.DrawString("Thank You For Visit!!", font, new SolidBrush(Color.Black), startx, starty + offset);

         
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                for(int i = 0; i < listView1.Items.Count;i++)
                {
                    if (listView1.Items[i].Selected)
                    {
                        textBox4.Text = (Convert.ToInt16(textBox4.Text) - Convert.ToInt16(listView1.Items[i].SubItems[3].Text)).ToString();
                        listView1.Items[i].Remove();
                    }
                }
            }
        }

        
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem first_item in listView1.Items)
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO items (Types, Prices, Quantity, Total, Date) VALUES (@Types, @Prices, @Quantity, @Total, '" + dateTimePicker1.Text + "')", con);
                cmd.Parameters.AddWithValue("@Types", first_item.SubItems[0].Text);
                cmd.Parameters.AddWithValue("@Prices", first_item.SubItems[1].Text);
                cmd.Parameters.AddWithValue("@Quantity", first_item.SubItems[2].Text);
                cmd.Parameters.AddWithValue("@Total", first_item.SubItems[3].Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Save Data");

                printDialog1.Document = printDocument1;
                DialogResult result = printDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }
    }
}
