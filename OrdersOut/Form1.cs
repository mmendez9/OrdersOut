using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdersOut
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string orders;
                StreamReader order = File.OpenText("Z:/Visual Studio 2015/Projects/7Sept16-1/7Sept16-1/bin/Debug/Orders.txt");

                while (!order.EndOfStream)
                {
                    // read line in the text file
                    orders = order.ReadLine();

                    // Add the items to the list box
                    lbordersout.Items.Add(orders);
                }
                order.Close();
            }
            catch (Exception ex)
            {
                // Error open the file
                MessageBox.Show(ex.Message, "Ice Cream", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            StreamWriter orderfile = File.CreateText
                ("Z:/Visual Studio 2015/Projects/7Sept16-1/7Sept16-1/bin/Debug/Orders.txt");

            DialogResult result = MessageBox.Show("Are you sure to CLEAR the orders file?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                
                // Delete content of the file
                orderfile.WriteLine("");
                orderfile.Close();

                lbordersout.Items.Clear();
            }
        }
    }
}
