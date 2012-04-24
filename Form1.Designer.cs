namespace ga1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.iterCount = new System.Windows.Forms.TextBox();
            this.popSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mProb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cProb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.openBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.chromoLength = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.generateButton = new System.Windows.Forms.Button();
            this.isSimetric = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Go = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.SaveChromo = new System.Windows.Forms.Button();
            this.OpenChromo = new System.Windows.Forms.Button();
            this.GeneratePop = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.expCount = new System.Windows.Forms.TextBox();
            this.exportBtn = new System.Windows.Forms.Button();
            this.answer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.NullValue = "1";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Location = new System.Drawing.Point(306, 85);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(346, 172);
            this.dataGridView1.TabIndex = 0;
            
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 432);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Generation count";
            // 
            // iterCount
            // 
            this.iterCount.Location = new System.Drawing.Point(239, 429);
            this.iterCount.Name = "iterCount";
            this.iterCount.Size = new System.Drawing.Size(33, 20);
            this.iterCount.TabIndex = 2;
            this.iterCount.Text = "5";
            // 
            // popSize
            // 
            this.popSize.Location = new System.Drawing.Point(110, 6);
            this.popSize.Name = "popSize";
            this.popSize.Size = new System.Drawing.Size(33, 20);
            this.popSize.TabIndex = 4;
            this.popSize.Text = "8";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Population size";
            // 
            // mProb
            // 
            this.mProb.Location = new System.Drawing.Point(398, 432);
            this.mProb.Name = "mProb";
            this.mProb.Size = new System.Drawing.Size(33, 20);
            this.mProb.TabIndex = 6;
            this.mProb.Text = "0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(303, 435);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "M. probability";
            // 
            // cProb
            // 
            this.cProb.Location = new System.Drawing.Point(537, 432);
            this.cProb.Name = "cProb";
            this.cProb.Size = new System.Drawing.Size(33, 20);
            this.cProb.TabIndex = 8;
            this.cProb.Text = "0.5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(442, 435);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "C. probability";
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(451, 6);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(58, 24);
            this.openBtn.TabIndex = 9;
            this.openBtn.Text = "Open";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(529, 6);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(61, 24);
            this.saveBtn.TabIndex = 10;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // chromoLength
            // 
            this.chromoLength.Location = new System.Drawing.Point(398, 6);
            this.chromoLength.Name = "chromoLength";
            this.chromoLength.Size = new System.Drawing.Size(33, 20);
            this.chromoLength.TabIndex = 12;
            this.chromoLength.Text = "8";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Chromo length";
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(306, 38);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 13;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // isSimetric
            // 
            this.isSimetric.AutoSize = true;
            this.isSimetric.Location = new System.Drawing.Point(398, 42);
            this.isSimetric.Name = "isSimetric";
            this.isSimetric.Size = new System.Drawing.Size(87, 17);
            this.isSimetric.TabIndex = 14;
            this.isSimetric.Text = "symmetrically";
            this.isSimetric.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Go
            // 
            this.Go.Location = new System.Drawing.Point(588, 430);
            this.Go.Name = "Go";
            this.Go.Size = new System.Drawing.Size(75, 23);
            this.Go.TabIndex = 15;
            this.Go.Text = "Go!";
            this.Go.UseVisualStyleBackColor = true;
            this.Go.Click += new System.EventHandler(this.Go_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(300, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Graph Matrix";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.ColumnHeadersVisible = false;
            this.dataGridView2.Location = new System.Drawing.Point(12, 86);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(280, 171);
            this.dataGridView2.TabIndex = 17;
            // 
            // SaveChromo
            // 
            this.SaveChromo.Location = new System.Drawing.Point(227, 6);
            this.SaveChromo.Name = "SaveChromo";
            this.SaveChromo.Size = new System.Drawing.Size(61, 24);
            this.SaveChromo.TabIndex = 19;
            this.SaveChromo.Text = "Save";
            this.SaveChromo.UseVisualStyleBackColor = true;
            this.SaveChromo.Click += new System.EventHandler(this.SaveChromo_Click);
            // 
            // OpenChromo
            // 
            this.OpenChromo.Location = new System.Drawing.Point(149, 6);
            this.OpenChromo.Name = "OpenChromo";
            this.OpenChromo.Size = new System.Drawing.Size(58, 24);
            this.OpenChromo.TabIndex = 18;
            this.OpenChromo.Text = "Open";
            this.OpenChromo.UseVisualStyleBackColor = true;
            this.OpenChromo.Click += new System.EventHandler(this.OpenChromo_Click);
            // 
            // GeneratePop
            // 
            this.GeneratePop.Location = new System.Drawing.Point(12, 38);
            this.GeneratePop.Name = "GeneratePop";
            this.GeneratePop.Size = new System.Drawing.Size(75, 23);
            this.GeneratePop.TabIndex = 13;
            this.GeneratePop.Text = "Generate";
            this.GeneratePop.UseVisualStyleBackColor = true;
            this.GeneratePop.Click += new System.EventHandler(this.GeneratePop_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Start Population";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 432);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Expirement count";
            // 
            // expCount
            // 
            this.expCount.Location = new System.Drawing.Point(107, 429);
            this.expCount.Name = "expCount";
            this.expCount.Size = new System.Drawing.Size(33, 20);
            this.expCount.TabIndex = 2;
            this.expCount.Text = "5";
            // 
            // exportBtn
            // 
            this.exportBtn.Location = new System.Drawing.Point(557, 393);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(106, 22);
            this.exportBtn.TabIndex = 20;
            this.exportBtn.Text = "Export to excel";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // answer
            // 
            this.answer.AutoSize = true;
            this.answer.Location = new System.Drawing.Point(59, 372);
            this.answer.Name = "answer";
            this.answer.Size = new System.Drawing.Size(0, 13);
            this.answer.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 465);
            this.Controls.Add(this.answer);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.SaveChromo);
            this.Controls.Add(this.OpenChromo);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Go);
            this.Controls.Add(this.isSimetric);
            this.Controls.Add(this.GeneratePop);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.chromoLength);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.cProb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mProb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.popSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.expCount);
            this.Controls.Add(this.iterCount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.MinimumSize = new System.Drawing.Size(320, 330);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GA. (c) apozhidaev";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox iterCount;
        private System.Windows.Forms.TextBox popSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox mProb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cProb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox chromoLength;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.CheckBox isSimetric;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button Go;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button SaveChromo;
        private System.Windows.Forms.Button OpenChromo;
        private System.Windows.Forms.Button GeneratePop;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox expCount;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.Label answer;


    }
}

