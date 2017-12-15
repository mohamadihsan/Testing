using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testing
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username                 = textBoxUsername.Text;
            string password                 = textBoxPassword.Text;
            string pesanGagalLogin          = "Username dan Password Anda Salah!";
            string pesanGagalKoneksi        = "Tidak dapat terhubung dengan server!";

            if (username =="" || password == "")
            {
                MessageBox.Show("Username dan Password wajib diisi", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Login login = new Login();
                if(login.ValidasiLogin(username, password) == "1")
                {
                    this.Hide();
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                }
                else if (login.ValidasiLogin(username, password) == "0")
                {
                    MessageBox.Show(pesanGagalLogin, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(pesanGagalKoneksi, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
                        
        }
        
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        
        private void buttonExit_Click(object sender, EventArgs e)
        {
            string pesanKonfirmasiKeluar = "Anda yakin akan keluar ?";

            var result = MessageBox.Show(pesanKonfirmasiKeluar, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
