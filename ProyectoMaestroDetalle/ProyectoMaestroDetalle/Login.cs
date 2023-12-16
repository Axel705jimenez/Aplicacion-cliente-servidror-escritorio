using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ProyectoMaestroDetalle
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        MenuOpciones menu = new MenuOpciones();

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario, contraseña;
            usuario = txtUsuario.Text;
            contraseña = txtContraseña.Text;
            if (usuario == "Administrador" && contraseña == "tec123")
            {
                MessageBox.Show("BIENVENIDO");
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Acceso denegado", "Advertencia");
                txtUsuario.Clear();
                txtContraseña.Clear();
                txtUsuario.Focus();
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMazimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMazimizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMazimizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;    
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
