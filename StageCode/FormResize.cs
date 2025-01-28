using System;
using System.Drawing;
using System.Windows.Forms;

namespace StageCode
{
    public partial class FormResize : Form
    {
        public Size OldSize
        {
            get
            {
                return new Size(int.Parse(lblOldWidth.Text), int.Parse(lblOldHeight.Text));
            }
            set
            {
                lblOldWidth.Text = value.Width.ToString();
                lblOldHeight.Text = value.Height.ToString();
            }
        }

        public Size NewSize
        {
            get
            {
                return new Size(int.Parse(tbNewWidth.Text), int.Parse(tbNewHeight.Text));
            }
            set
            {
                tbNewWidth.Text = value.Width.ToString();
                tbNewHeight.Text = value.Height.ToString();
            }
        }

        private Label lblOldWidth;
        private Label lblOldHeight;
        private Label lblNewWidth;
        private Label lblNewHeight;
        private TextBox tbNewWidth;
        private TextBox tbNewHeight;
        private Button btnOK;
        private Button btnCancel;
        private GroupBox groupBoxBefore;
        private GroupBox groupBoxAfter;

#pragma warning disable CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
        public FormResize()
#pragma warning restore CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            this.Text = "Resize Form";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Resize += new EventHandler(this.FormResize_Resize);  

            groupBoxBefore = new GroupBox()
            {
                Text = "Old Size",
                Location = new Point(10, 10),
                Size = new Size(360, 100)
            };
            this.Controls.Add(groupBoxBefore);

            lblOldWidth = new Label()
            {
                Text = "Width: ",
                Location = new Point(10, 30),
                Size = new Size(100, 20)
            };
            groupBoxBefore.Controls.Add(lblOldWidth);

            lblOldHeight = new Label()
            {
                Text = "Height: ",
                Location = new Point(10, 60),
                Size = new Size(100, 20)
            };
            groupBoxBefore.Controls.Add(lblOldHeight);

            groupBoxAfter = new GroupBox()
            {
                Text = "New Size",
                Location = new Point(10, 120),
                Size = new Size(360, 120)
            };
            this.Controls.Add(groupBoxAfter);

            lblNewWidth = new Label()
            {
                Text = "New Width: ",
                Location = new Point(10, 30),
                Size = new Size(100, 20)
            };
            groupBoxAfter.Controls.Add(lblNewWidth);

            tbNewWidth = new TextBox()
            {
                Location = new Point(120, 30),
                Size = new Size(100, 20)
            };
            groupBoxAfter.Controls.Add(tbNewWidth);

            lblNewHeight = new Label()
            {
                Text = "New Height: ",
                Location = new Point(10, 60),
                Size = new Size(100, 20)
            };
            groupBoxAfter.Controls.Add(lblNewHeight);

            tbNewHeight = new TextBox()
            {
                Location = new Point(120, 60),
                Size = new Size(100, 20)
            };
            groupBoxAfter.Controls.Add(tbNewHeight);

            btnOK = new Button()
            {
                Text = "OK",
                Location = new Point(220, 250),
                Size = new Size(75, 30)
            };
            btnOK.Click += new EventHandler(this.btnOK_Click);
            this.Controls.Add(btnOK);

            btnCancel = new Button()
            {
                Text = "Cancel",
                Location = new Point(300, 250),
                Size = new Size(75, 30)
            };
            btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.Controls.Add(btnCancel);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FormResize_Resize(object sender, EventArgs e)
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Ajuster la taille des GroupBox
            groupBoxBefore.Width = (int)(formWidth * 0.9);
            groupBoxAfter.Width = (int)(formWidth * 0.9);
            groupBoxBefore.Height = (int)(formHeight * 0.25);
            groupBoxAfter.Height = (int)(formHeight * 0.25);

            groupBoxBefore.Location = new Point(10, 10);
            groupBoxAfter.Location = new Point(10, groupBoxBefore.Bottom + 10);

            lblOldWidth.Width = (int)(formWidth * 0.2);
            lblOldHeight.Width = (int)(formWidth * 0.2);
            lblNewWidth.Width = (int)(formWidth * 0.2);
            lblNewHeight.Width = (int)(formWidth * 0.2);

            float labelFontSize = formHeight * 0.02f;  
            lblOldWidth.Font = new Font(lblOldWidth.Font.FontFamily, labelFontSize);
            lblOldHeight.Font = new Font(lblOldHeight.Font.FontFamily, labelFontSize);
            lblNewWidth.Font = new Font(lblNewWidth.Font.FontFamily, labelFontSize);
            lblNewHeight.Font = new Font(lblNewHeight.Font.FontFamily, labelFontSize);

            lblOldWidth.Location = new Point(10, 30);
            lblOldHeight.Location = new Point(10, 60);
            lblNewWidth.Location = new Point(10, 30);
            lblNewHeight.Location = new Point(10, 60);

            tbNewWidth.Width = (int)(formWidth * 0.2);
            tbNewHeight.Width = (int)(formWidth * 0.2);
            tbNewWidth.Location = new Point(120, 30);
            tbNewHeight.Location = new Point(120, 60);

            btnOK.Location = new Point(formWidth - 180, formHeight - 70);
            btnCancel.Location = new Point(formWidth - 100, formHeight - 70);
        }

        private void FormResize_Load(object sender, EventArgs e)
        {
            this.OldSize = new Size(800, 600); 
            this.NewSize = new Size(1024, 768); 
        }
    }
}
