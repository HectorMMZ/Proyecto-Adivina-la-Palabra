using System;
using System.Windows.Forms;

namespace Proyecto_Adivina_la_Palabra
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                MessageBox.Show("¡Por favor ingresa un nombre para jugar!", "Atención");
                return;
            }

            // Ocultamos el menú y abrimos el juego pasando el nombre del jugador
            Form1 juego = new Form1(txtNombreUsuario.Text);
            this.Hide();
            juego.ShowDialog(); // Abre el juego y espera a que se cierre
            this.Show(); // Vuelve a mostrar el menú cuando el juego termina
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVerPuntuaciones_Click(object sender, EventArgs e)
        {
            // Aquí mostraremos la "base de datos" de puntuaciones
            try
            {
                if (System.IO.File.Exists("puntuaciones.txt"))
                {
                    string scores = System.IO.File.ReadAllText("puntuaciones.txt");
                    MessageBox.Show(scores, "Mejores Puntuaciones");
                }
                else
                {
                    MessageBox.Show("Aún no hay puntuaciones registradas.", "Vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer puntuaciones: " + ex.Message);
            }
        }
    }
}