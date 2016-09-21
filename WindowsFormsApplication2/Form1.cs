/**
 * Trevor Buttrey
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GeminiCore;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public CPU myCPU;

        public Form1()
        {
            myCPU = new CPU();

            InitializeComponent();

#if DEBUG
            //loadFileButton.Text = "Hello";
#endif
        }

        #region Events
        private void loadFileButton_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        var ipe = new IPE(ofd.FileName);
                        ipe.ParseFile();
                    }
                    catch (Exception err)
                    {
                        // show a dialog with error
                    }
                }
            }
        }
        #endregion

        private void nextInstructionButton_Click(object sender, EventArgs e)
        {
            this.myCPU.nextInstruction();
            this.setCPUValuesToView();
        }

        public void setCPUValuesToView()
        {
            this.ACCLabel.Text = this.myCPU.ACC.ToString();
            this.PCLabel.Text = this.myCPU.PC.ToString();
            this.ALabel.Text = this.myCPU.A.ToString();
            this.BLabel.Text = this.myCPU.B.ToString();
            this.ZeroLabel.Text = this.myCPU.Zero.ToString();
            this.OneLabel.Text = this.myCPU.One.ToString();
            this.MARLabel.Text = this.myCPU.MAR.ToString();
            this.MDRLabel.Text = this.myCPU.MDR.ToString();
            this.TEMPLabel.Text = this.myCPU.TEMP.ToString();
            this.IRLabel.Text = this.myCPU.IR.ToString();
            this.CCLabel.Text = this.myCPU.CC.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LoadBinaryFile_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Window: Parser Open...");
            using (var ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        myCPU.loadBinaryFile(ofd.FileName);
                    }
                    catch (Exception err)
                    {
                        // show a dialog with error
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.myCPU.runToComplete();
            this.setCPUValuesToView();
        }

        private void ResetCPU_Click(object sender, EventArgs e)
        {
            this.myCPU.Reset();
            this.setCPUValuesToView();
        }

        private void autoLoad_Click(object sender, EventArgs e)
        {
            myCPU.loadBinaryFile("g.out");
        }
        
    }

}
