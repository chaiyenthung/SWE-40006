namespace Task1._3
{
    partial class Form1
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
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtInput1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGrade1 = new System.Windows.Forms.TextBox();
            this.txtWeight1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInput2 = new System.Windows.Forms.TextBox();
            this.txtInput3 = new System.Windows.Forms.TextBox();
            this.txtInput4 = new System.Windows.Forms.TextBox();
            this.txtInput5 = new System.Windows.Forms.TextBox();
            this.txtGrade2 = new System.Windows.Forms.TextBox();
            this.txtGrade3 = new System.Windows.Forms.TextBox();
            this.txtGrade4 = new System.Windows.Forms.TextBox();
            this.txtGrade5 = new System.Windows.Forms.TextBox();
            this.txtWeight2 = new System.Windows.Forms.TextBox();
            this.txtWeight3 = new System.Windows.Forms.TextBox();
            this.txtWeight4 = new System.Windows.Forms.TextBox();
            this.txtWeight5 = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.Plum;
            this.btnCalculate.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.Location = new System.Drawing.Point(438, 579);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(161, 65);
            this.btnCalculate.TabIndex = 8;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtInput1
            // 
            this.txtInput1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInput1.Font = new System.Drawing.Font("Amiri", 10F);
            this.txtInput1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtInput1.Location = new System.Drawing.Point(20, 149);
            this.txtInput1.Multiline = true;
            this.txtInput1.Name = "txtInput1";
            this.txtInput1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtInput1.Size = new System.Drawing.Size(226, 58);
            this.txtInput1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Amiri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 46);
            this.label1.TabIndex = 10;
            this.label1.Text = "Name (Optional) ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Amiri", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(571, 46);
            this.label2.TabIndex = 11;
            this.label2.Text = "Please enter the grade and weight for your assignment. Providing a task name is o" +
    "ptional.";
            // 
            // txtGrade1
            // 
            this.txtGrade1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtGrade1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGrade1.Font = new System.Drawing.Font("Amiri", 10F);
            this.txtGrade1.ForeColor = System.Drawing.Color.Black;
            this.txtGrade1.Location = new System.Drawing.Point(301, 149);
            this.txtGrade1.Multiline = true;
            this.txtGrade1.Name = "txtGrade1";
            this.txtGrade1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtGrade1.Size = new System.Drawing.Size(132, 58);
            this.txtGrade1.TabIndex = 12;
            // 
            // txtWeight1
            // 
            this.txtWeight1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtWeight1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWeight1.Font = new System.Drawing.Font("Amiri", 10F);
            this.txtWeight1.ForeColor = System.Drawing.Color.Black;
            this.txtWeight1.Location = new System.Drawing.Point(469, 149);
            this.txtWeight1.Multiline = true;
            this.txtWeight1.Name = "txtWeight1";
            this.txtWeight1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtWeight1.Size = new System.Drawing.Size(132, 58);
            this.txtWeight1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calisto MT", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 26);
            this.label3.TabIndex = 14;
            this.label3.Text = "Grade Calculator";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Amiri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(331, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 46);
            this.label4.TabIndex = 15;
            this.label4.Text = "Grade ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Amiri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(501, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 46);
            this.label5.TabIndex = 16;
            this.label5.Text = "Weight";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtInput2
            // 
            this.txtInput2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInput2.Font = new System.Drawing.Font("Amiri", 10F);
            this.txtInput2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtInput2.Location = new System.Drawing.Point(20, 233);
            this.txtInput2.Multiline = true;
            this.txtInput2.Name = "txtInput2";
            this.txtInput2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtInput2.Size = new System.Drawing.Size(226, 58);
            this.txtInput2.TabIndex = 17;
            // 
            // txtInput3
            // 
            this.txtInput3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInput3.Font = new System.Drawing.Font("Amiri", 10F);
            this.txtInput3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtInput3.Location = new System.Drawing.Point(20, 316);
            this.txtInput3.Multiline = true;
            this.txtInput3.Name = "txtInput3";
            this.txtInput3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtInput3.Size = new System.Drawing.Size(226, 58);
            this.txtInput3.TabIndex = 18;
            this.txtInput3.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // txtInput4
            // 
            this.txtInput4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInput4.Font = new System.Drawing.Font("Amiri", 10F);
            this.txtInput4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtInput4.Location = new System.Drawing.Point(20, 407);
            this.txtInput4.Multiline = true;
            this.txtInput4.Name = "txtInput4";
            this.txtInput4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtInput4.Size = new System.Drawing.Size(226, 58);
            this.txtInput4.TabIndex = 19;
            // 
            // txtInput5
            // 
            this.txtInput5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInput5.Font = new System.Drawing.Font("Amiri", 10F);
            this.txtInput5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtInput5.Location = new System.Drawing.Point(20, 496);
            this.txtInput5.Multiline = true;
            this.txtInput5.Name = "txtInput5";
            this.txtInput5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtInput5.Size = new System.Drawing.Size(226, 58);
            this.txtInput5.TabIndex = 20;
            // 
            // txtGrade2
            // 
            this.txtGrade2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtGrade2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGrade2.Font = new System.Drawing.Font("Amiri", 10F);
            this.txtGrade2.ForeColor = System.Drawing.Color.Black;
            this.txtGrade2.Location = new System.Drawing.Point(301, 233);
            this.txtGrade2.Multiline = true;
            this.txtGrade2.Name = "txtGrade2";
            this.txtGrade2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtGrade2.Size = new System.Drawing.Size(132, 58);
            this.txtGrade2.TabIndex = 21;
            // 
            // txtGrade3
            // 
            this.txtGrade3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtGrade3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGrade3.Font = new System.Drawing.Font("Amiri", 10F);
            this.txtGrade3.ForeColor = System.Drawing.Color.Black;
            this.txtGrade3.Location = new System.Drawing.Point(301, 316);
            this.txtGrade3.Multiline = true;
            this.txtGrade3.Name = "txtGrade3";
            this.txtGrade3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtGrade3.Size = new System.Drawing.Size(132, 58);
            this.txtGrade3.TabIndex = 22;
            // 
            // txtGrade4
            // 
            this.txtGrade4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtGrade4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGrade4.Font = new System.Drawing.Font("Amiri", 10F);
            this.txtGrade4.ForeColor = System.Drawing.Color.Black;
            this.txtGrade4.Location = new System.Drawing.Point(301, 407);
            this.txtGrade4.Multiline = true;
            this.txtGrade4.Name = "txtGrade4";
            this.txtGrade4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtGrade4.Size = new System.Drawing.Size(132, 58);
            this.txtGrade4.TabIndex = 23;
            // 
            // txtGrade5
            // 
            this.txtGrade5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtGrade5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGrade5.Font = new System.Drawing.Font("Amiri", 10F);
            this.txtGrade5.ForeColor = System.Drawing.Color.Black;
            this.txtGrade5.Location = new System.Drawing.Point(301, 496);
            this.txtGrade5.Multiline = true;
            this.txtGrade5.Name = "txtGrade5";
            this.txtGrade5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtGrade5.Size = new System.Drawing.Size(132, 58);
            this.txtGrade5.TabIndex = 24;
            // 
            // txtWeight2
            // 
            this.txtWeight2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtWeight2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWeight2.Font = new System.Drawing.Font("Amiri", 10F);
            this.txtWeight2.ForeColor = System.Drawing.Color.Black;
            this.txtWeight2.Location = new System.Drawing.Point(469, 233);
            this.txtWeight2.Multiline = true;
            this.txtWeight2.Name = "txtWeight2";
            this.txtWeight2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtWeight2.Size = new System.Drawing.Size(132, 58);
            this.txtWeight2.TabIndex = 25;
            // 
            // txtWeight3
            // 
            this.txtWeight3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtWeight3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWeight3.Font = new System.Drawing.Font("Amiri", 10F);
            this.txtWeight3.ForeColor = System.Drawing.Color.Black;
            this.txtWeight3.Location = new System.Drawing.Point(469, 316);
            this.txtWeight3.Multiline = true;
            this.txtWeight3.Name = "txtWeight3";
            this.txtWeight3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtWeight3.Size = new System.Drawing.Size(132, 58);
            this.txtWeight3.TabIndex = 26;
            // 
            // txtWeight4
            // 
            this.txtWeight4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtWeight4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWeight4.Font = new System.Drawing.Font("Amiri", 10F);
            this.txtWeight4.ForeColor = System.Drawing.Color.Black;
            this.txtWeight4.Location = new System.Drawing.Point(469, 407);
            this.txtWeight4.Multiline = true;
            this.txtWeight4.Name = "txtWeight4";
            this.txtWeight4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtWeight4.Size = new System.Drawing.Size(132, 58);
            this.txtWeight4.TabIndex = 27;
            // 
            // txtWeight5
            // 
            this.txtWeight5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtWeight5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWeight5.Font = new System.Drawing.Font("Amiri", 10F);
            this.txtWeight5.ForeColor = System.Drawing.Color.Black;
            this.txtWeight5.Location = new System.Drawing.Point(469, 496);
            this.txtWeight5.Multiline = true;
            this.txtWeight5.Name = "txtWeight5";
            this.txtWeight5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtWeight5.Size = new System.Drawing.Size(132, 58);
            this.txtWeight5.TabIndex = 28;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.btnReset.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnReset.Location = new System.Drawing.Point(271, 579);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(161, 65);
            this.btnReset.TabIndex = 29;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(668, 670);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtWeight5);
            this.Controls.Add(this.txtWeight4);
            this.Controls.Add(this.txtWeight3);
            this.Controls.Add(this.txtWeight2);
            this.Controls.Add(this.txtGrade5);
            this.Controls.Add(this.txtGrade4);
            this.Controls.Add(this.txtGrade3);
            this.Controls.Add(this.txtGrade2);
            this.Controls.Add(this.txtInput5);
            this.Controls.Add(this.txtInput4);
            this.Controls.Add(this.txtInput3);
            this.Controls.Add(this.txtInput2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWeight1);
            this.Controls.Add(this.txtGrade1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInput1);
            this.Controls.Add(this.btnCalculate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TextBox txtInput1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGrade1;
        private System.Windows.Forms.TextBox txtWeight1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInput2;
        private System.Windows.Forms.TextBox txtInput3;
        private System.Windows.Forms.TextBox txtInput4;
        private System.Windows.Forms.TextBox txtInput5;
        private System.Windows.Forms.TextBox txtGrade2;
        private System.Windows.Forms.TextBox txtGrade3;
        private System.Windows.Forms.TextBox txtGrade4;
        private System.Windows.Forms.TextBox txtGrade5;
        private System.Windows.Forms.TextBox txtWeight2;
        private System.Windows.Forms.TextBox txtWeight3;
        private System.Windows.Forms.TextBox txtWeight4;
        private System.Windows.Forms.TextBox txtWeight5;
        private System.Windows.Forms.Button btnReset;
    }
}

