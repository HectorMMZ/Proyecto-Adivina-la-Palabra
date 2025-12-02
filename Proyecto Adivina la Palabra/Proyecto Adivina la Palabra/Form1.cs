using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_Adivina_la_Palabra
{
    public partial class Form1 : Form
    {
        List<string> words = new List<string>();
        string newText;
        int i = 0;
        int guessed = 0;

        public Form1()
        {
            InitializeComponent();
            Setup();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // Si la tecla presionada es enter se ejecuta lo siguiente
            {
                if (words[i].ToLower() == textBox1.Text.ToLower()) // Asegurarnos que las palabras esten en minusculas
                {
                    if (i < words.Count - 1) // Asegurarnos de estan en los limites de la lista
                    {
                        //MessageBox.Show("Correcto!", "Hector dice: ");
                        textBox1.Text = "";
                        i++;
                        newText = Scramble(words[i]);
                        lblWord.Text = newText;
                        lblInfo.Text = "Palabras: " + (i + 1) + " de " + words.Count;
                        guessed = 0;
                        lblGuessed.Text = "Adivinado: " + guessed + " veces.";
                    }
                    else
                    {
                        lblWord.Text = "Ganaste!, bien hecho";
                        return;
                    }
                }
                else
                {
                    guessed += 1;
                    lblGuessed.Text = "Invitado: " + guessed + " veces.";
                }
                e.Handled = true; // Para evitar alertar alertar al sistema y que no suene
            }
        }

        private void Setup() // Metodo que cargara las palabras de la lista
        {
            words = File.ReadLines("words.txt").ToList(); // Reccore las palabras de words.txt
            newText = Scramble(words[i]); // Metodo que desordenara las palabras en el array
            lblWord.Text = newText; // Le agrega al label las palabras 
            lblInfo.Text = "Palabras: " + (i + 1) + " de " + words.Count; // Le agrega al otro label el numero de la palabra usada
        }

        /* La función scramble rompe la palabra en letras, le asigna a cada letra un "número aleatorio" temporal (un Guid),
           ordena las letras basándose en esos números aleatorios y, finalmente, vuelve a unir las letras desordenadas para formar la nueva palabra. */
        private string Scramble(string text) // Metodo que desordenara las palabras de la lista
        {
            return new string(text.ToCharArray().OrderBy(x => Guid.NewGuid()).ToArray());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
