using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textoTelegrama;
            char tipoTelegrama = 'o';
            int numPalabras;
            double coste;

            // Leo el telegrama
            textoTelegrama = txtTelegrama.Text;

            // Compruebo si el telegrama es urgente
            if (cbUrgente.Checked)
                tipoTelegrama = 'u';

            // Obtengo el número de palabras del telegrama
            textoTelegrama = textoTelegrama.Trim();

            if (textoTelegrama == "")
                numPalabras = 0;
            else
                numPalabras = textoTelegrama.Split(
                    new char[] { ' ', '\n', '\r', '\t' },
                    StringSplitOptions.RemoveEmptyEntries
                ).Length;

            // Si el telegrama es ordinario
            if (tipoTelegrama == 'o')
            {
                if (numPalabras <= 10)
                    coste = 25;
                else
                    coste = 0.5 * numPalabras;
            }
            // Si el telegrama es urgente
            else
            {
                if (numPalabras <= 10)
                    coste = 5;
                else
                    coste = 5 + 0.75 * (numPalabras - 10);
            }

            // Muestro el precio
            txtPrecio.Text = coste.ToString("0.00") + " euros";
        }
    }
}