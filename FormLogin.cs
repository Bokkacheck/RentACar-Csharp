using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatProba
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.FormClosed += Login.ugasiProgram;
            txtLozinka.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Logovanje.ulogujSe(txtKorisnickoIme.Text, txtLozinka.Text))
            {
                this.Close();
            }
            else
            {
                txtKorisnickoIme.Text = "";
                txtLozinka.Text = "";
            }
        }
        public static void ugasiProgram(object sender, FormClosedEventArgs e)
        {
            if(Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtLozinka.UseSystemPasswordChar = false;
            }
            else
            {
                txtLozinka.UseSystemPasswordChar = true;
            }
        }
    }
}
