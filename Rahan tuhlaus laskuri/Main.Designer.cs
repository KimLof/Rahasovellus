namespace Rahan_tuhlaus_laskuri
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelIncome = new System.Windows.Forms.Label();
            this.labelExpenses = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.btnIncome = new System.Windows.Forms.Button();
            this.btnExpenses = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.labelDate = new System.Windows.Forms.Label();
            this.btnModify = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.asdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.muokkaaKategToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 97);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 100;
            this.dataGridView1.Size = new System.Drawing.Size(718, 329);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(12, 449);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(102, 37);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Lisää";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(785, 97);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(324, 329);
            this.listBox1.Sorted = true;
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // labelIncome
            // 
            this.labelIncome.AutoSize = true;
            this.labelIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIncome.Location = new System.Drawing.Point(387, 36);
            this.labelIncome.Name = "labelIncome";
            this.labelIncome.Size = new System.Drawing.Size(60, 25);
            this.labelIncome.TabIndex = 3;
            this.labelIncome.Text = "Tulot";
            // 
            // labelExpenses
            // 
            this.labelExpenses.AutoSize = true;
            this.labelExpenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExpenses.Location = new System.Drawing.Point(658, 36);
            this.labelExpenses.Name = "labelExpenses";
            this.labelExpenses.Size = new System.Drawing.Size(72, 25);
            this.labelExpenses.TabIndex = 4;
            this.labelExpenses.Text = "Menot";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.Location = new System.Drawing.Point(928, 36);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(104, 25);
            this.labelTotal.TabIndex = 5;
            this.labelTotal.Text = "Yhteensä";
            // 
            // btnIncome
            // 
            this.btnIncome.Enabled = false;
            this.btnIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncome.Location = new System.Drawing.Point(392, 449);
            this.btnIncome.Name = "btnIncome";
            this.btnIncome.Size = new System.Drawing.Size(102, 37);
            this.btnIncome.TabIndex = 6;
            this.btnIncome.Text = "Tulot";
            this.btnIncome.UseVisualStyleBackColor = true;
            this.btnIncome.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnExpenses
            // 
            this.btnExpenses.Enabled = false;
            this.btnExpenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpenses.Location = new System.Drawing.Point(628, 449);
            this.btnExpenses.Name = "btnExpenses";
            this.btnExpenses.Size = new System.Drawing.Size(102, 37);
            this.btnExpenses.TabIndex = 7;
            this.btnExpenses.Text = "Menot";
            this.btnExpenses.UseVisualStyleBackColor = true;
            this.btnExpenses.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(1007, 449);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(102, 37);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.Location = new System.Drawing.Point(12, 36);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(87, 25);
            this.labelDate.TabIndex = 9;
            this.labelDate.Text = "Aikaväli";
            // 
            // btnModify
            // 
            this.btnModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.Location = new System.Drawing.Point(12, 523);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(102, 37);
            this.btnModify.TabIndex = 10;
            this.btnModify.Text = "Uusi";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asdToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1192, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // asdToolStripMenuItem
            // 
            this.asdToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.muokkaaKategToolStripMenuItem});
            this.asdToolStripMenuItem.Name = "asdToolStripMenuItem";
            this.asdToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.asdToolStripMenuItem.Text = "Menu";
            // 
            // muokkaaKategToolStripMenuItem
            // 
            this.muokkaaKategToolStripMenuItem.Name = "muokkaaKategToolStripMenuItem";
            this.muokkaaKategToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.muokkaaKategToolStripMenuItem.Text = "Muokkaa kategorioita";
            this.muokkaaKategToolStripMenuItem.Click += new System.EventHandler(this.muokkaaKategToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 617);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnExpenses);
            this.Controls.Add(this.btnIncome);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.labelExpenses);
            this.Controls.Add(this.labelIncome);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Rahan_tuhlaus_laskuri";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelIncome;
        private System.Windows.Forms.Label labelExpenses;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Button btnIncome;
        private System.Windows.Forms.Button btnExpenses;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem asdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem muokkaaKategToolStripMenuItem;
    }
}

