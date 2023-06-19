namespace KitapListeleme
{
    partial class FormSil
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textSilinecek = new System.Windows.Forms.TextBox();
            this.buttonSil = new System.Windows.Forms.Button();
            this.dataGridViewSil = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.textArananKitap = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSil)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 61);
            this.button1.TabIndex = 2;
            this.button1.Text = "KAPAT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(140, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Silinecek Kitabın Adı : ";
            // 
            // textSilinecek
            // 
            this.textSilinecek.Location = new System.Drawing.Point(396, 128);
            this.textSilinecek.Name = "textSilinecek";
            this.textSilinecek.Size = new System.Drawing.Size(573, 22);
            this.textSilinecek.TabIndex = 4;
            this.textSilinecek.TextChanged += new System.EventHandler(this.textSilinecek_TextChanged);
            // 
            // buttonSil
            // 
            this.buttonSil.FlatAppearance.BorderSize = 0;
            this.buttonSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSil.Font = new System.Drawing.Font("Trebuchet MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSil.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSil.Location = new System.Drawing.Point(907, 1);
            this.buttonSil.Name = "buttonSil";
            this.buttonSil.Size = new System.Drawing.Size(213, 72);
            this.buttonSil.TabIndex = 5;
            this.buttonSil.Text = "SİL";
            this.buttonSil.UseVisualStyleBackColor = true;
            this.buttonSil.Click += new System.EventHandler(this.buttonSil_Click);
            // 
            // dataGridViewSil
            // 
            this.dataGridViewSil.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSil.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSil.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(5)))), ((int)(((byte)(90)))));
            this.dataGridViewSil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSil.Location = new System.Drawing.Point(16, 218);
            this.dataGridViewSil.Name = "dataGridViewSil";
            this.dataGridViewSil.RowHeadersWidth = 51;
            this.dataGridViewSil.RowTemplate.Height = 24;
            this.dataGridViewSil.Size = new System.Drawing.Size(1035, 323);
            this.dataGridViewSil.TabIndex = 6;
            this.dataGridViewSil.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSil_CellClick);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label13.Location = new System.Drawing.Point(292, 156);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 24);
            this.label13.TabIndex = 44;
            this.label13.Text = "Arama : ";
            // 
            // textArananKitap
            // 
            this.textArananKitap.Location = new System.Drawing.Point(396, 156);
            this.textArananKitap.Name = "textArananKitap";
            this.textArananKitap.Size = new System.Drawing.Size(573, 22);
            this.textArananKitap.TabIndex = 43;
            this.textArananKitap.TextChanged += new System.EventHandler(this.textArananKitap_TextChanged);
            // 
            // FormSil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(5)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(1132, 553);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textArananKitap);
            this.Controls.Add(this.dataGridViewSil);
            this.Controls.Add(this.buttonSil);
            this.Controls.Add(this.textSilinecek);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "FormSil";
            this.Text = "FormSil";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textSilinecek;
        private System.Windows.Forms.Button buttonSil;
        private System.Windows.Forms.DataGridView dataGridViewSil;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textArananKitap;
    }
}