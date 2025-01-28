using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StageCode
{
    public partial class FormResize : Form
    {
        public FormResize()
        {
            InitializeComponent();
        }
        private void FormResize_Load(object sender, EventArgs e)
        {
            this.groupBoxAvant.Text = "Old Size";
            this.groupBoxApres.Text = "New Size";

            this.label1.Text = "Width";
            this.label2.Text = "Height";

            this.label5.Text = this.Width.ToString();   
            this.label6.Text = this.Height.ToString(); 

            this.textBox1.Text = this.Width.ToString(); 
            this.textBox2.Text = this.Height.ToString();
        }

    }
}
