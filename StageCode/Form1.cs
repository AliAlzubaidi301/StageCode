using System;
using System.Windows.Forms;

namespace StageCode
{
    public partial class Form1 : Form
    {
        public static int Langue = 1; // 1 = English, 2 = Chinese, 3 = German, 4 = French, 5 = Lithuanian

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
            AppliquerLangue();
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

            ToolStripMenuItem languageMenuItem = new ToolStripMenuItem("Language");
            ToolStripMenuItem englishMenuItem = CreerMenuItem("English", null, (sender, e) => ChangerLangue(1));
            ToolStripMenuItem chineseMenuItem = CreerMenuItem("Chinese", null, (sender, e) => ChangerLangue(2));
            ToolStripMenuItem germanMenuItem = CreerMenuItem("German", null, (sender, e) => ChangerLangue(3));
            ToolStripMenuItem frenchMenuItem = CreerMenuItem("French", null, (sender, e) => ChangerLangue(4));
            ToolStripMenuItem lithuanianMenuItem = CreerMenuItem("Lithuanian", null, (sender, e) => ChangerLangue(5));

            languageMenuItem.DropDownItems.AddRange(new ToolStripMenuItem[]
            {
                englishMenuItem,
                chineseMenuItem,
                germanMenuItem,
                frenchMenuItem,
                lithuanianMenuItem
            });

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

        private void ChangerLangue(int nouvelleLangue)
        {
            Langue = nouvelleLangue;
            AppliquerLangue();
        }

        private void VerifierVisibilite(object sender, EventArgs e) => MessageBox.Show("Vérifier la visibilité");

        #endregion

        #region Appliquer la langue

        private void AppliquerLangue()
        {
            switch (Langue)
            {
                case 1: // English
                    btnFile.Text = "File";
                    btnEdition.Text = "Edit";
                    btnView.Text = "View";
                    newToolStripMenuItem.Text = "New";
                    openToolStripMenuItem.Text = "Open";
                    saveToolStripMenuItem.Text = "Save";
                    btnInfos.Text = "Info"; // Texte pour btnInfos

                    // Menu Edit
                    btnEdition.DropDownItems[0].Text = "Cut";
                    btnEdition.DropDownItems[1].Text = "Copy";
                    btnEdition.DropDownItems[2].Text = "Paste";
                    btnEdition.DropDownItems[4].Text = "Delete";
                    btnEdition.DropDownItems[6].Text = "Resize synoptique";
                    btnEdition.DropDownItems[7].Text = "Protect";

                    // Menu View
                    btnView.DropDownItems[0].Text = "Resolution";
                    btnView.DropDownItems[1].Text = "Language";
                    btnView.DropDownItems[2].Text = "Visibility Checker";
                    break;

                case 2: // Chinese
                    btnFile.Text = "文件";
                    btnEdition.Text = "编辑";
                    btnView.Text = "视图";
                    newToolStripMenuItem.Text = "新建";
                    openToolStripMenuItem.Text = "打开";
                    saveToolStripMenuItem.Text = "保存";
                    btnInfos.Text = "信息"; // Texte pour btnInfos

                    // Menu Edit
                    btnEdition.DropDownItems[0].Text = "剪切";
                    btnEdition.DropDownItems[1].Text = "复制";
                    btnEdition.DropDownItems[2].Text = "粘贴";
                    btnEdition.DropDownItems[4].Text = "删除";
                    btnEdition.DropDownItems[6].Text = "调整大小";
                    btnEdition.DropDownItems[7].Text = "保护";

                    // Menu View
                    btnView.DropDownItems[0].Text = "分辨率";
                    btnView.DropDownItems[1].Text = "语言";
                    btnView.DropDownItems[2].Text = "可见性检查";
                    break;

                case 3: // German
                    btnFile.Text = "Datei";
                    btnEdition.Text = "Bearbeiten";
                    btnView.Text = "Ansicht";
                    newToolStripMenuItem.Text = "Neu";
                    openToolStripMenuItem.Text = "Öffnen";
                    saveToolStripMenuItem.Text = "Speichern";
                    btnInfos.Text = "Info"; // Texte pour btnInfos

                    // Menu Edit
                    btnEdition.DropDownItems[0].Text = "Ausschneiden";
                    btnEdition.DropDownItems[1].Text = "Kopieren";
                    btnEdition.DropDownItems[2].Text = "Einfügen";
                    btnEdition.DropDownItems[4].Text = "Löschen";
                    btnEdition.DropDownItems[6].Text = "Größe ändern";
                    btnEdition.DropDownItems[7].Text = "Schützen";

                    // Menu View
                    btnView.DropDownItems[0].Text = "Auflösung";
                    btnView.DropDownItems[1].Text = "Sprache";
                    btnView.DropDownItems[2].Text = "Sichtbarkeitsprüfung";
                    break;

                case 4: // French
                    btnFile.Text = "Fichier";
                    btnEdition.Text = "Édition";
                    btnView.Text = "Voir";
                    newToolStripMenuItem.Text = "Nouveau";
                    openToolStripMenuItem.Text = "Ouvrir";
                    saveToolStripMenuItem.Text = "Enregistrer";
                    btnInfos.Text = "Infos"; // Texte pour btnInfos

                    // Menu Edit
                    btnEdition.DropDownItems[0].Text = "Couper";
                    btnEdition.DropDownItems[1].Text = "Copier";
                    btnEdition.DropDownItems[2].Text = "Coller";
                    btnEdition.DropDownItems[4].Text = "Supprimer";
                    btnEdition.DropDownItems[6].Text = "Redimensionner synoptique";
                    btnEdition.DropDownItems[7].Text = "Protéger";

                    // Menu View
                    btnView.DropDownItems[0].Text = "Résolution";
                    btnView.DropDownItems[1].Text = "Langue";
                    btnView.DropDownItems[2].Text = "Vérifier visibilité";
                    break;

                case 5: // Lithuanian
                    btnFile.Text = "Byla";
                    btnEdition.Text = "Redaguoti";
                    btnView.Text = "Peržiūra";
                    newToolStripMenuItem.Text = "Naujas";
                    openToolStripMenuItem.Text = "Atidaryti";
                    saveToolStripMenuItem.Text = "Išsaugoti";
                    btnInfos.Text = "Informacija"; // Texte pour btnInfos

                    // Menu Edit
                    btnEdition.DropDownItems[0].Text = "Pjauti";
                    btnEdition.DropDownItems[1].Text = "Kopijuoti";
                    btnEdition.DropDownItems[2].Text = "Įklijuoti";
                    btnEdition.DropDownItems[4].Text = "Ištrinti";
                    btnEdition.DropDownItems[6].Text = "Pakeisti dydį";
                    btnEdition.DropDownItems[7].Text = "Apsaugoti";

                    // Menu View
                    btnView.DropDownItems[0].Text = "Rezoliucija";
                    btnView.DropDownItems[1].Text = "Kalba";
                    btnView.DropDownItems[2].Text = "Matomumo patikrinimas";
                    break;
            }
        }

        #endregion
    }
}
