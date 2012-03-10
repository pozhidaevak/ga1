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
            ICrossover cross = new OnePointCrossover(2);
            IChromosome chr = new DigitalChromosome();
            IChromosome chr2 = new DigitalChromosome();
            chr.GenerateFromArray(new int[4] {1,2,3,4});
            chr2.GenerateFromArray(new int[4] {4,3,2,1});
            chr.Crossover(cross, chr2);
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
