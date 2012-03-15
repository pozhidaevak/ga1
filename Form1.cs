using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ga1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.RowCount = 2;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = Convert.ToInt32(numericUpDown1.Value); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ICrossover cross = new OnePointCrossover(2);
            IChromosome chr = new DigitalChromosome();
            IChromosome chr2 = new DigitalChromosome();
            chr.GenerateFromArray((int [])dataGridView1.Rows[0]);
            chr2.GenerateFromArray(arr2);

            int[] arr1 = new int[dataGridView1.ColumnCount];
            int[] arr2 = new int[dataGridView1.ColumnCount];
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
			{
			    arr1[i] = Convert.ToInt32(dataGridView1[i, 0].Value);
                arr2[i] = Convert.ToInt32(dataGridView1[i, 1].Value);
			}
            chr.GenerateFromArray(arr1);
            chr2.GenerateFromArray(arr2);
            //chr.Crossover(cross, chr2). ;
            IChromosome[] detki = cross.Crossover(chr, chr2);
            detki[0].ToArray().CopyTo(arr1, 0);
            detki[1].ToArray().CopyTo(arr2, 0);

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1[i, 0].Value = arr1[i];
                dataGridView1[i, 1].Value = arr2[i];
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
