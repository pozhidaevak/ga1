using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Mommo.Data;
using Excel = Microsoft.Office.Interop.Excel;


namespace ga1
{


    public partial class Form1 : Form
    {
        private Population<int> pop;
        int[,] matrix = new int[0, 0];
        BinaryFormatter f = new BinaryFormatter();
        int[,] chromosomes = new int[0, 0];
        double[,] maxF;
        double[,] avgF;
        public Form1()
        {
            InitializeComponent();
        }



        private void generateButton_Click(object sender, EventArgs e)
        {
            int cLength = Convert.ToInt32(chromoLength.Text);
            matrix = new int[cLength, cLength];
            if (isSimetric.Checked)
            {
                for (int i = 0; i < cLength; ++i)
                {
                    for (int j = i + 1; j < cLength; ++j)
                    {
                        matrix[i, j] = matrix[j, i] = Program.rnd.Next(0, 11);
                    }
                }
            }
            else
            {
                for (int i = 0; i < cLength; ++i)
                {
                    for (int j = 0; j < cLength; ++j)
                    {
                        matrix[i, j] = Program.rnd.Next(0, 11);
                    }
                }
            }
            dataGridView1.DataSource = new ArrayDataView(matrix);
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            using (FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open))
            {
                matrix = (int[,])f.Deserialize(fs);
                chromoLength.Text = matrix.GetLength(0).ToString();
            }
            dataGridView1.DataSource = new ArrayDataView(matrix);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create))
            {
                f.Serialize(fs, matrix);
            }
        }

        private void Go_Click(object sender, EventArgs e)
        {


            int cLength = Convert.ToInt32(chromoLength.Text);
            EliteSelection<int> sel2 = new EliteSelection<int>(0);
            RouletteSelection<int> sel1 = new RouletteSelection<int>();
            GreedyCrossover cros = new GreedyCrossover(-1, -1, matrix);
            GoldenMutation<int> mut = new GoldenMutation<int>(cLength);
            pop = new Population<int>(mut, cros, sel1, sel2, x => 1 / cros.CalcFitness(x),
                Convert.ToDouble(mProb.Text), Convert.ToDouble(cProb.Text));
            maxF = new double[Convert.ToInt32(expCount.Text), Convert.ToInt32(iterCount.Text) + 1];
            avgF= new double[Convert.ToInt32(expCount.Text), Convert.ToInt32(iterCount.Text) + 1];
            double max = 100500; // Hi to Max ))
            string bestChromo = null;
            for (int i = 0; i < Convert.ToInt32(expCount.Text); ++i)
            {
                Trace.WriteLine("experiment #" + (i + 1).ToString());
                Trace.Indent();
                ChromosomesFromArray();
                maxF[i, 0] = Math.Round(1/pop.GetMaxFitness());
                avgF[i, 0] = 1 / pop.GetPopulationFitness();
                Trace.WriteLine("initial best fitness = " + Math.Round((1 / pop.GetMaxFitness())).ToString());
                Trace.WriteLine("initial avg fitness = " + (1 / pop.GetPopulationFitness()).ToString());
                Trace.WriteLine("initia;best fitness chromo = " + pop.GetMaxChromo());
                for (int j = 0; j < Convert.ToInt32(iterCount.Text); ++j)
                {
                    Trace.WriteLine("iteration #" + (j + 1).ToString());
                    Trace.Indent();
                    pop.Iteration();
                    maxF[i, j + 1] = Math.Round(1 / pop.GetMaxFitness());
                    avgF[i, j + 1] = 1 / pop.GetPopulationFitness();
                    Trace.WriteLine(" best fitness  = " + Math.Round((1 / pop.GetMaxFitness())).ToString());
                    Trace.WriteLine("avg fitness = " + (1 / pop.GetPopulationFitness()).ToString());
                    Trace.WriteLine("best fitness chromo = " + pop.GetMaxChromo());
                    Trace.Unindent();
                }
                if (Math.Round(1 / pop.GetMaxFitness()) < max)
                {
                    max = Math.Round(1 / pop.GetMaxFitness());
                    bestChromo = pop.GetMaxChromo();
                }
                Trace.Unindent();


            }
            answer.Text = "Best Path: " + bestChromo + "Path Length" + max.ToString();
           


        }

        private void ChromosomesFromArray()
        {
            pop.Chromosomes = new DigitalChromosome[chromosomes.GetLength(0)];
            int[] buffer = new int[chromosomes.GetLength(1)];
            for (int i = 0; i < chromosomes.GetLength(0); ++i)
            {
                System.Buffer.BlockCopy(chromosomes, chromosomes.GetLength(1) * i * sizeof(int), buffer, 0, chromosomes.GetLength(1) *sizeof(int));
                pop.Chromosomes[i] = new DigitalChromosome().GenerateFromArray(buffer);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GeneratePop_Click(object sender, EventArgs e)
        {
            int cLength = Convert.ToInt32(chromoLength.Text);
            int pLength = Convert.ToInt32(popSize.Text);
            chromosomes = new int[pLength,cLength];
            for (int i = 0; i < pLength; ++i)
            {
                System.Buffer.BlockCopy(Enumerable.Range(1, cLength).OrderBy(x => Program.rnd.Next()).ToArray(),
                    0, chromosomes, i * sizeof(int) * cLength, cLength* sizeof(int));
            }
            dataGridView2.DataSource = new ArrayDataView(chromosomes);
        }

        private void SaveChromo_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create))
            {
                f.Serialize(fs, chromosomes);
            }
        }

        private void OpenChromo_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            using (FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open))
            {
                chromosomes = (int[,])f.Deserialize(fs);
                if (matrix == null || matrix.GetLength(0) != chromosomes.GetLength(1))
                {
                    throw new Exception("Matrix must be inputed or wrong chromo length");
                }
                popSize.Text = chromosomes.GetLength(1).ToString();
            }
            dataGridView2.DataSource = new ArrayDataView(chromosomes);
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        private void exportBtn_Click(object sender, EventArgs e)
        {
            
            //if (maxF == null || avgF == null || maxF.Length <= 0 || avgF.Length <= 0)
            //    throw new Exception("nothing to export");
            Excel.Application xlAp = new Excel.Application();
            object misValue = System.Reflection.Missing.Value;
            Excel.Workbook xlWBook = xlAp.Workbooks.Add(misValue);
            Excel.Worksheet xlWSheet = (Excel.Worksheet)xlWBook.Worksheets.get_Item(1);

            //maxF
            xlWSheet.Cells[1,1] = "Max fitness";

            //add experiment numbers for maxF
            for (int i = 0; i < maxF.GetLength(1); ++i)
                xlWSheet.Cells[2, i + 2] = (i).ToString();

            //add iteration numberts
            for (int i = 0; i < maxF.GetLength(0); ++i)
                xlWSheet.Cells[i + 3, 1] = (i+1).ToString();

            //add maxFData
            for (int i = 0; i < maxF.GetLength(0); ++i)
            {
                for (int j = 0; j < maxF.GetLength(1); ++j)
                    xlWSheet.Cells[i + 3, j + 2] = maxF[i, j];
            }

           
            //f by step
            Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWSheet.ChartObjects();
            Excel.ChartObject maxChart = (Excel.ChartObject)xlCharts.Add(10, 17 * (maxF.GetLength(0) + 2), 300, 250);

            maxChart.Chart.ChartType = Excel.XlChartType.xlLine;
            for (int i = 0; i < maxF.GetLength(0); ++i)
            ((Excel.SeriesCollection)maxChart.Chart.SeriesCollection()).NewSeries().Values = xlWSheet.Range[xlWSheet.Cells[i+3,2 ], xlWSheet.Cells[i + 3, maxF.GetLength(1) + 1]];
            ((Excel.Series)maxChart.Chart.SeriesCollection(1)).XValues = xlWSheet.Range[xlWSheet.Cells[2, 2], xlWSheet.Cells[2, maxF.GetLength(1) + 1]];

            //max f by exp
            Excel.ChartObject maxChart2 = (Excel.ChartObject)xlCharts.Add(10, 17 * (maxF.GetLength(0) + 2) + 310, 300, 250);

            maxChart2.Chart.ChartType = Excel.XlChartType.xlLine;
            maxChart2.Chart.SetSourceData(xlWSheet.Range[xlWSheet.Cells[3, maxF.GetLength(1) + 1], xlWSheet.Cells[maxF.GetLength(0) + 3, maxF.GetLength(1) + 1]]);
               

            //AvgF
            int columnDelta = maxF.GetLength(1) + 2;
            xlWSheet.Cells[1, 1 + columnDelta ] = "Avg fitness";

            //add experiment numbers for maxF
            for (int i = 0; i < avgF.GetLength(1); ++i)
                xlWSheet.Cells[2, i + 2 + columnDelta] = (i).ToString();

            //add iteration numberts
            for (int i = 0; i < avgF.GetLength(0); ++i)
                xlWSheet.Cells[i + 3, 1 + columnDelta] = (i + 1).ToString();

            //add maxFData
            for (int i = 0; i < avgF.GetLength(0); ++i)
            {
                for (int j = 0; j < maxF.GetLength(1); ++j)
                    xlWSheet.Cells[i + 3, j + 2 + columnDelta] = avgF[i, j];
            }



            
            Excel.ChartObject avgChart = (Excel.ChartObject)xlCharts.Add(10 + columnDelta * 50, 17 * (avgF.GetLength(0) + 2), 300, 250);

            avgChart.Chart.ChartType = Excel.XlChartType.xlLine;
            for (int i = 0; i < avgF.GetLength(0); ++i)
                ((Excel.SeriesCollection)avgChart.Chart.SeriesCollection()).NewSeries().Values = xlWSheet.Range[xlWSheet.Cells[i + 3, 2 + columnDelta], xlWSheet.Cells[i + 3, maxF.GetLength(1) + 1 + columnDelta]];
            ((Excel.Series)avgChart.Chart.SeriesCollection(1)).XValues = xlWSheet.Range[xlWSheet.Cells[2, 2 + columnDelta], xlWSheet.Cells[2, maxF.GetLength(1) + 1 + columnDelta]];

            //max f by exp
            Excel.ChartObject avgChart2 = (Excel.ChartObject)xlCharts.Add(10 + columnDelta * 50, 17 * (maxF.GetLength(0) + 2) + 310, 300, 250);

            avgChart2.Chart.ChartType = Excel.XlChartType.xlLine;
            avgChart2.Chart.SetSourceData(xlWSheet.Range[xlWSheet.Cells[3, avgF.GetLength(1) + 1 + columnDelta], xlWSheet.Cells[maxF.GetLength(0) + 3, avgF.GetLength(1) + 1 +columnDelta]]);

            xlAp.Visible = true;
            //xlWBook.SaveAs("d:\\temp\\test.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue,
            //    misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive);
            //xlWBook.Close(true);
            //xlAp.Quit();
            releaseObject(xlWSheet);
            releaseObject(xlWBook);
            releaseObject(xlAp);

        }
    }
}