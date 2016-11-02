using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharpcon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string address = textBox1.Text;
            string port = textBox2.Text;
            string password = textBox3.Text;

            if (Helpers.Empty(address))
            {
                MessageBox.Show("Please enter an address.", "Sharpcon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (Helpers.Empty(port))
            {
                MessageBox.Show("Please enter a port.", "Sharpcon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (Helpers.Empty(password))
            {
                MessageBox.Show("Please enter a password.", "Sharpcon", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            Connection.Initialise(Connection.ConnectionString(textBox1.Text, textBox2.Text, textBox3.Text));
            Connection.Connect();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Enter)
                button1_Click(null, null);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Enter)
                button1_Click(null, null);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Enter)
                button1_Click(null, null);
        }
    }
}
