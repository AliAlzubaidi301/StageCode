﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace StageCode
{
    public partial class FormResize : Form
    {
        private Form1 forme;

        public FormResize(Form1 forme)
        {
            InitializeComponent();
            this.forme = forme;

            // Configurer les ancres pour tous les contrôles
            ConfigureAnchors();

            // Abonner l'événement SizeChanged pour ajuster les tailles des GroupBox
            this.SizeChanged += FormResize_SizeChanged;
        }

        private void ConfigureAnchors()
        {
            // Configuration des ancres pour les GroupBox
            this.groupBoxAvant.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.groupBoxApres.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Configuration des ancres pour les boutons
            this.btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnResize.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            // Configuration des ancres pour les labels et textboxes
            this.label1.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.label2.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.label5.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.label6.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void FormResize_SizeChanged(object sender, EventArgs e)
        {
            // Ajuster la hauteur des GroupBox en fonction de la taille du formulaire
            int groupBoxHeight = (int)(this.ClientSize.Height * 0.34); // 34% de la hauteur du formulaire
            this.groupBoxAvant.Height = groupBoxHeight;
            this.groupBoxApres.Height = groupBoxHeight;

            // Repositionner le deuxième GroupBox sous le premier
            this.groupBoxApres.Top = this.groupBoxAvant.Bottom + 10;

            // Repositionner les boutons en bas du formulaire
            this.btnOK.Top = this.ClientSize.Height - this.btnOK.Height - 20;
            this.btnResize.Top = this.ClientSize.Height - this.btnResize.Height - 20;
        }

        private void FormResize_Load(object sender, EventArgs e)
        {
            this.groupBoxAvant.Text = "Old Size";
            this.groupBoxApres.Text = "New Size";

            this.label1.Text = "Width";
            this.label2.Text = "Height";

            label3.Text = "Width";
            label4.Text = "Height";

            this.label5.Text = forme.Width.ToString();
            this.label6.Text = forme.Height.ToString();

            this.textBox1.Text = forme.Width.ToString();
            this.textBox2.Text = forme.Height.ToString();

            this.btnOK.Text = "OK";
            this.btnResize.Text = "Cancel";
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            // Annuler
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int newWidth) || newWidth <= 0)
            {
                MessageBox.Show("Veuillez entrer une largeur valide (nombre positif).", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBox2.Text, out int newHeight) || newHeight <= 0)
            {
                MessageBox.Show("Veuillez entrer une hauteur valide (nombre positif).", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            forme.Size = new Size(newWidth, newHeight);

            Close();
        }
    }
}