using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PuzzleGame
{
    public partial class DotEditor : UserControl
    {
        public Grid2 Grid { get; set; }
        private GridSetupCode gridSetupCode;
        public DotEditor()
        {
            InitializeComponent();
            gridSetupCode = new GridSetupCode(richTextBox);
        }
        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            Grid?.SetGrid(gridSetupCode); //TODO change it so that this doesn't get called on every key press, but only on real changes
        }

        private void fileSelector_FileSelected(object sender, EventArgs e)
        {
            richTextBox.Text = FileSelector.GetFileContent();
        }

        private void fileSelector_FileToSave(object sender, EventArgs e)
        {
            FileSelector.SaveToFile(richTextBox.Text);
        }
    }
}
