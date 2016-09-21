namespace WindowsFormsApplication2
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
            this.label1 = new System.Windows.Forms.Label();
            this.ACCLabel = new System.Windows.Forms.Label();
            this.loadAsseblyButton = new System.Windows.Forms.Button();
            this.nextInstructionButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.PCLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ALabel = new System.Windows.Forms.Label();
            this.BLabel = new System.Windows.Forms.Label();
            this.ZeroLabel = new System.Windows.Forms.Label();
            this.OneLabel = new System.Windows.Forms.Label();
            this.MARLabel = new System.Windows.Forms.Label();
            this.MDRLabel = new System.Windows.Forms.Label();
            this.TEMPLabel = new System.Windows.Forms.Label();
            this.IRLabel = new System.Windows.Forms.Label();
            this.CCLabel = new System.Windows.Forms.Label();
            this.LoadBinaryFile = new System.Windows.Forms.Button();
            this.ResetCPU = new System.Windows.Forms.Button();
            this.RunToComplete = new System.Windows.Forms.Button();
            this.autoLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ACC:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ACCLabel
            // 
            this.ACCLabel.Location = new System.Drawing.Point(52, 34);
            this.ACCLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ACCLabel.Name = "ACCLabel";
            this.ACCLabel.Size = new System.Drawing.Size(137, 19);
            this.ACCLabel.TabIndex = 1;
            this.ACCLabel.Text = "value";
            // 
            // loadAsseblyButton
            // 
            this.loadAsseblyButton.Location = new System.Drawing.Point(12, 5);
            this.loadAsseblyButton.Margin = new System.Windows.Forms.Padding(2);
            this.loadAsseblyButton.Name = "loadAsseblyButton";
            this.loadAsseblyButton.Size = new System.Drawing.Size(101, 27);
            this.loadAsseblyButton.TabIndex = 2;
            this.loadAsseblyButton.Text = "Load ASM File";
            this.loadAsseblyButton.UseVisualStyleBackColor = true;
            this.loadAsseblyButton.Click += new System.EventHandler(this.loadFileButton_Click);
            // 
            // nextInstructionButton
            // 
            this.nextInstructionButton.Location = new System.Drawing.Point(228, 254);
            this.nextInstructionButton.Margin = new System.Windows.Forms.Padding(2);
            this.nextInstructionButton.Name = "nextInstructionButton";
            this.nextInstructionButton.Size = new System.Drawing.Size(90, 19);
            this.nextInstructionButton.TabIndex = 3;
            this.nextInstructionButton.Text = "Next Instruction";
            this.nextInstructionButton.UseVisualStyleBackColor = true;
            this.nextInstructionButton.Click += new System.EventHandler(this.nextInstructionButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "PC:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // PCLabel
            // 
            this.PCLabel.Location = new System.Drawing.Point(52, 46);
            this.PCLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PCLabel.Name = "PCLabel";
            this.PCLabel.Size = new System.Drawing.Size(137, 19);
            this.PCLabel.TabIndex = 5;
            this.PCLabel.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "A:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 72);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "B:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 85);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Zero:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 98);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "One:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 111);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "MAR:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 124);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "MDR:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 137);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "TEMP:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 150);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "IR:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 163);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "CC:";
            // 
            // ALabel
            // 
            this.ALabel.Location = new System.Drawing.Point(52, 59);
            this.ALabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ALabel.Name = "ALabel";
            this.ALabel.Size = new System.Drawing.Size(137, 19);
            this.ALabel.TabIndex = 15;
            this.ALabel.Text = "value";
            // 
            // BLabel
            // 
            this.BLabel.Location = new System.Drawing.Point(52, 72);
            this.BLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BLabel.Name = "BLabel";
            this.BLabel.Size = new System.Drawing.Size(137, 19);
            this.BLabel.TabIndex = 16;
            this.BLabel.Text = "value";
            // 
            // ZeroLabel
            // 
            this.ZeroLabel.Location = new System.Drawing.Point(52, 85);
            this.ZeroLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ZeroLabel.Name = "ZeroLabel";
            this.ZeroLabel.Size = new System.Drawing.Size(137, 19);
            this.ZeroLabel.TabIndex = 17;
            this.ZeroLabel.Text = "value";
            // 
            // OneLabel
            // 
            this.OneLabel.Location = new System.Drawing.Point(52, 98);
            this.OneLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OneLabel.Name = "OneLabel";
            this.OneLabel.Size = new System.Drawing.Size(137, 19);
            this.OneLabel.TabIndex = 18;
            this.OneLabel.Text = "value";
            // 
            // MARLabel
            // 
            this.MARLabel.Location = new System.Drawing.Point(52, 111);
            this.MARLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MARLabel.Name = "MARLabel";
            this.MARLabel.Size = new System.Drawing.Size(137, 19);
            this.MARLabel.TabIndex = 19;
            this.MARLabel.Text = "value";
            // 
            // MDRLabel
            // 
            this.MDRLabel.Location = new System.Drawing.Point(52, 124);
            this.MDRLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MDRLabel.Name = "MDRLabel";
            this.MDRLabel.Size = new System.Drawing.Size(137, 19);
            this.MDRLabel.TabIndex = 20;
            this.MDRLabel.Text = "value";
            // 
            // TEMPLabel
            // 
            this.TEMPLabel.Location = new System.Drawing.Point(52, 137);
            this.TEMPLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TEMPLabel.Name = "TEMPLabel";
            this.TEMPLabel.Size = new System.Drawing.Size(137, 19);
            this.TEMPLabel.TabIndex = 21;
            this.TEMPLabel.Text = "value";
            // 
            // IRLabel
            // 
            this.IRLabel.Location = new System.Drawing.Point(52, 150);
            this.IRLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.IRLabel.Name = "IRLabel";
            this.IRLabel.Size = new System.Drawing.Size(137, 19);
            this.IRLabel.TabIndex = 22;
            this.IRLabel.Text = "value";
            // 
            // CCLabel
            // 
            this.CCLabel.Location = new System.Drawing.Point(52, 163);
            this.CCLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CCLabel.Name = "CCLabel";
            this.CCLabel.Size = new System.Drawing.Size(137, 19);
            this.CCLabel.TabIndex = 23;
            this.CCLabel.Text = "value";
            // 
            // LoadBinaryFile
            // 
            this.LoadBinaryFile.Location = new System.Drawing.Point(217, 5);
            this.LoadBinaryFile.Name = "LoadBinaryFile";
            this.LoadBinaryFile.Size = new System.Drawing.Size(101, 26);
            this.LoadBinaryFile.TabIndex = 24;
            this.LoadBinaryFile.Text = "Load BIN File";
            this.LoadBinaryFile.UseVisualStyleBackColor = true;
            this.LoadBinaryFile.Click += new System.EventHandler(this.LoadBinaryFile_Click);
            // 
            // ResetCPU
            // 
            this.ResetCPU.Location = new System.Drawing.Point(228, 230);
            this.ResetCPU.Name = "ResetCPU";
            this.ResetCPU.Size = new System.Drawing.Size(90, 19);
            this.ResetCPU.TabIndex = 25;
            this.ResetCPU.Text = "Reset CPU";
            this.ResetCPU.UseVisualStyleBackColor = true;
            this.ResetCPU.Click += new System.EventHandler(this.ResetCPU_Click);
            // 
            // RunToComplete
            // 
            this.RunToComplete.Location = new System.Drawing.Point(121, 230);
            this.RunToComplete.Name = "RunToComplete";
            this.RunToComplete.Size = new System.Drawing.Size(101, 42);
            this.RunToComplete.TabIndex = 26;
            this.RunToComplete.Text = "Run To Completion";
            this.RunToComplete.UseVisualStyleBackColor = true;
            this.RunToComplete.Click += new System.EventHandler(this.button1_Click);
            // 
            // autoLoad
            // 
            this.autoLoad.Location = new System.Drawing.Point(217, 33);
            this.autoLoad.Name = "autoLoad";
            this.autoLoad.Size = new System.Drawing.Size(101, 26);
            this.autoLoad.TabIndex = 27;
            this.autoLoad.Text = "Auto Load g.out";
            this.autoLoad.UseVisualStyleBackColor = true;
            this.autoLoad.Click += new System.EventHandler(this.autoLoad_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 284);
            this.Controls.Add(this.autoLoad);
            this.Controls.Add(this.RunToComplete);
            this.Controls.Add(this.ResetCPU);
            this.Controls.Add(this.LoadBinaryFile);
            this.Controls.Add(this.CCLabel);
            this.Controls.Add(this.IRLabel);
            this.Controls.Add(this.TEMPLabel);
            this.Controls.Add(this.MDRLabel);
            this.Controls.Add(this.MARLabel);
            this.Controls.Add(this.OneLabel);
            this.Controls.Add(this.ZeroLabel);
            this.Controls.Add(this.BLabel);
            this.Controls.Add(this.ALabel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PCLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nextInstructionButton);
            this.Controls.Add(this.loadAsseblyButton);
            this.Controls.Add(this.ACCLabel);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Gemini";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ACCLabel;
        private System.Windows.Forms.Button loadAsseblyButton;
        private System.Windows.Forms.Button nextInstructionButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label PCLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label ALabel;
        private System.Windows.Forms.Label BLabel;
        private System.Windows.Forms.Label ZeroLabel;
        private System.Windows.Forms.Label OneLabel;
        private System.Windows.Forms.Label MARLabel;
        private System.Windows.Forms.Label MDRLabel;
        private System.Windows.Forms.Label TEMPLabel;
        private System.Windows.Forms.Label IRLabel;
        private System.Windows.Forms.Label CCLabel;
        private System.Windows.Forms.Button LoadBinaryFile;
        private System.Windows.Forms.Button ResetCPU;
        private System.Windows.Forms.Button RunToComplete;
        private System.Windows.Forms.Button autoLoad;
    }
}

