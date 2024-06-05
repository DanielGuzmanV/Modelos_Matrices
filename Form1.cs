using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelos_De_Examen
{
    public partial class Form1 : Form
    {
        clasematriz m1, m2, m3;

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m1.cargar(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
        }

        private void descargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox5.Text = m1.descargar();
        }

        private void pregunta1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m1.pregunta1();
            textBox6.Text = m1.descargar();
        }

        private void pregunta2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m1.pregunta2();
            textBox6.Text = m1.descargar();
        }

        private void pregunta3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m1.pregunta3();
            textBox6.Text = m1.descargar();
        }

        private void pregunta4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //m1.ampliacolum();
            m1.pregunta4();
            textBox6.Text = m1.descargar();
        }

        private void filaNumEleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox7.Text = string.Concat(m1.numelem(int.Parse(textBox1.Text)));
        }

        private void filPriimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox7.Text = string.Concat(m1.numPrimo(int.Parse(textBox1.Text)));
        }

        private void pregunta5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m1.pregunta5();
            textBox6.Text = m1.descargar();
        }

        private void pregunta6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m1.pregunta6();
            textBox6.Text = m1.descargar();
        }

        private void pregunta7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m1.pregunta7();
            textBox6.Text = m1.descargar();
        }

        private void numEleDifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox7.Text = string.Concat(m1.numElemDifer(int.Parse(textBox1.Text)));
        }

        private void pregunta8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m1.pregunta8();
            textBox6.Text = m1.descargar();
        }

        private void pregunta9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m1.filamplia();
            m1.pregunta9();
            textBox6.Text = m1.descargar();
        }

        private void numEleColToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox7.Text = string.Concat(m1.elemFrecuCol(int.Parse(textBox1.Text)));
        }

        private void pregunta10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m1.pregunta10();
            textBox6.Text = m1.descargar();
        }

        private void frecuEleFilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox7.Text = string.Concat(m1.elemento(int.Parse(textBox1.Text)));
        }

        private void pregunta11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m1.pregunta11();
            textBox6.Text = m1.descargar();
        }

        private void frecuFilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox7.Text = string.Concat(m1.frecuencia(int.Parse(textBox1.Text)));
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            m1 = new clasematriz();
            m2 = new clasematriz();
            m3 = new clasematriz();
        }
    }
}
