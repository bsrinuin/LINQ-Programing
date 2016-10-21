namespace WinFormDataBinding
{
    partial class CustomerWin
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
            this.getcustomers = new System.Windows.Forms.Button();
            this.customergrid = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.customergrid)).BeginInit();
            this.SuspendLayout();
            // 
            // getcustomers
            // 
            this.getcustomers.Location = new System.Drawing.Point(796, 27);
            this.getcustomers.Name = "getcustomers";
            this.getcustomers.Size = new System.Drawing.Size(159, 49);
            this.getcustomers.TabIndex = 0;
            this.getcustomers.Text = "Get Customers";
            this.getcustomers.UseVisualStyleBackColor = true;
            this.getcustomers.Click += new System.EventHandler(this.getcustomers_Click);
            // 
            // customergrid
            // 
            this.customergrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customergrid.Location = new System.Drawing.Point(25, 101);
            this.customergrid.Name = "customergrid";
            this.customergrid.Size = new System.Drawing.Size(839, 260);
            this.customergrid.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(77, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // CustomerWin
            // 
            this.ClientSize = new System.Drawing.Size(1017, 373);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.customergrid);
            this.Controls.Add(this.getcustomers);
            this.Name = "CustomerWin";
            this.Load += new System.EventHandler(this.CustomerWin_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.customergrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private System.Windows.Forms.DataGridView CustomerGridView;
        //private System.Windows.Forms.Button button1;
        //private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button getcustomers;
        private System.Windows.Forms.DataGridView customergrid;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

