using System;
using System.Windows.Forms;

namespace StageCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.btnVersion.Text = "V " + Application.ProductVersion;

            AjouterRaccourcisMenuFile();
            AjouterMenuEdition();
            AjouterbtnQuit();
            AjouterMenuVew();
        }

        #region Ajouter Menu File

        private void AjouterRaccourcisMenuFile()
        {
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
        }

        private void AjouterbtnQuit()
        {
            btnFile.DropDownItems.Add(new ToolStripSeparator());

            ToolStripMenuItem quitMenuItem = new ToolStripMenuItem("Quit")
            {
                ShortcutKeys = Keys.Control | Keys.Q
            };
            quitMenuItem.Click += (sender, e) => Application.Exit();
            btnFile.DropDownItems.Add(quitMenuItem);
        }

        #endregion

        #region Ajouter Menu Edition

        private void AjouterMenuEdition()
        {
            ToolStripMenuItem cutMenuItem = CreerMenuItem("Cut", Keys.Control | Keys.X, Couper);
            ToolStripMenuItem copyMenuItem = CreerMenuItem("Copy", Keys.Control | Keys.C, Copier);
            ToolStripMenuItem pasteMenuItem = CreerMenuItem("Paste", Keys.Control | Keys.V, Coller);
            ToolStripMenuItem deleteMenuItem = CreerMenuItem("Delete", Keys.Delete, Supprimer);
            ToolStripMenuItem resizeMenuItem = CreerMenuItem("Resize synoptique", null, RedimensionnerSynoptique);
            ToolStripMenuItem protectedMenuItem = CreerMenuItem("Protect", null, Proteger);

            ToolStripSeparator Separateur = new ToolStripSeparator();
            ToolStripSeparator Separateur2 = new ToolStripSeparator();

            btnEdition.DropDownItems.AddRange(new ToolStripItem[]
            {
                cutMenuItem,
                copyMenuItem,
                pasteMenuItem,
                Separateur2, 
                deleteMenuItem,
                Separateur,
                resizeMenuItem,
                protectedMenuItem
            });

        }

        #endregion

        #region Ajouter Menu Voir

        private void AjouterMenuVew()
        {
            ToolStripMenuItem resolutionMenuItem = CreerMenuItem("Resolution", null, ChangerResolution);
            ToolStripMenuItem languageMenuItem = CreerMenuItem("Language", null, ChangerLangue);
            ToolStripMenuItem visibilityCheckerMenuItem = CreerMenuItem("Visibility Checker", null, VerifierVisibilite);

            btnView.DropDownItems.AddRange(new ToolStripMenuItem[]
            {
                resolutionMenuItem,
                languageMenuItem,
                visibilityCheckerMenuItem
            });
        }

        #endregion

        #region Méthodes Utilitaires

        private ToolStripMenuItem CreerMenuItem(string text, Keys? shortcutKeys, EventHandler clickEvent)
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem(text);
            if (shortcutKeys.HasValue)
            {
                menuItem.ShortcutKeys = shortcutKeys.Value;
            }
            menuItem.Click += clickEvent;

            return menuItem;
        }

        #endregion

        #region Actions des menus

        private void Couper(object sender, EventArgs e) => MessageBox.Show("Couper");

        private void Copier(object sender, EventArgs e) => MessageBox.Show("Copier");

        private void Coller(object sender, EventArgs e) => MessageBox.Show("Coller");

        private void Supprimer(object sender, EventArgs e) => MessageBox.Show("Supprimer");

        private void RedimensionnerSynoptique(object sender, EventArgs e) => MessageBox.Show("Redimensionner le synoptique");

        private void Proteger(object sender, EventArgs e) => MessageBox.Show("Protégé");

        private void ChangerResolution(object sender, EventArgs e) => MessageBox.Show("Changer la résolution");

        private void ChangerLangue(object sender, EventArgs e) => MessageBox.Show("Changer la langue");

        private void VerifierVisibilite(object sender, EventArgs e) => MessageBox.Show("Vérifier la visibilité");

        #endregion
    }
}
