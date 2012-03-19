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
            dataGridView1.ColumnCount = 3; // Create 3 columns for genes
            dataGridView1.RowCount = 2; // Create 2 rows for father and mother
            comboBox1.SelectedItem = 0; // Set default selected crossover operation One point crossover
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = Convert.ToInt32(numericUpDown1.Value); // Set column count in table like updown value
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //IChromosome<T> chr1 = new DigitalChromosome();
            //IChromosome<T> chr2 = new DigitalChromosome();
            //IChromosome[] childrens; ;
            //switch (comboBox1.SelectedIndex)
            //{
            //    case 0: // if selected One-point crossover
            //    {
            //        ICrossover<T> cross = new OnePointCrossover(2);
            //        chr1.GenerateFromArray(dataGridView1.Rows[0].Cells.ToString().ToArray());
            //        chr2.GenerateFromArray(dataGridView1.Rows[1].Cells.ToString().ToArray());
            //        childrens = cross.Crossover(chr1, chr2);
            //        dataGridView1.Rows.Add();
            //        dataGridView1[0, dataGridView1.RowCount - 1].Value = "One-point crossover";
            //        dataGridView1.Rows.Add(childrens[0]);
            //        dataGridView1.Rows.Add(childrens[1]);
            //        break;
            //    }
            //    default:
            //        break;
            //}
            /*ICrossover<T> cross = new OnePointCrossover(2);
            IChromosome<T> chr = new DigitalChromosome();
            IChromosome<T> chr2 = new DigitalChromosome();
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
            }*/
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close(); // Close programm
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            dataGridView1.Height = this.Height - 147; // Resize dataGridView1 on resize form
        }
    }
}
