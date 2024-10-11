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
    public partial class Form2 : Form
    {
        public MySqlConnection con = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        public Form2()
        {
            InitializeComponent();
            con.ConnectionString = @"server=localhost;database=pizza_system;userid=root;password=;";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Small")
            {
                string query = "Select (prices) From pizza_prices WHERE ID = 1";
                con.Open();
                cmd = new MySqlCommand(query, con);
                Int32 fun = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                con.Close();
                textBox1.Text = fun.ToString();
            }
            else if (comboBox1.SelectedItem.ToString() == "Medium")
            {
                string query = "Select (prices) From pizza_prices WHERE ID = 2";
                con.Open();
                cmd = new MySqlCommand(query, con);
                Int32 fun = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                con.Close();
                textBox1.Text = fun.ToString();
            }
            else if (comboBox1.SelectedItem.ToString() == "Large")
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "UPDATE pizza_prices SET Prices = '" + textBox1.Text + "' WHERE Types = '" + comboBox1.Text + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader rd;
                con.Open();
                rd = cmd.ExecuteReader();
                MessageBox.Show("Data Update");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
