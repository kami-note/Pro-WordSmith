using System.Drawing;
using System.Windows.Forms;
using System;

namespace Pro_WordSmith
{
    public partial class Form1 : Form, IDisposable
    {
        private AutoScaleMode AutoScaleMode;
        private Size ClientSize;
        private string Text;
        private FormClosingEventHandler FormClosing;

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
        }

        protected override void Dispose(bool disposing)
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
        ~Form1()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

        #region Código gerado pelo Windows Form Designer

        private void InitializeComponent()
        {
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
        }

        #endregion
    }
}