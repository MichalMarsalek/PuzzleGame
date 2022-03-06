using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PuzzleGame
{
    public partial class Editor : UserControl
    {
        private string path;

        public string Path
        {
            get => path;
            set
            {
                path = value;
                dotEditor.FileSelector.Path = System.IO.Path.Combine(path, "layout");
                backgroundEditor.FileSelector.Path = System.IO.Path.Combine(path, "bg");
                rulesEditor.FileSelector.Path = System.IO.Path.Combine(path, "rules");
                labelPack.Text = System.IO.Path.GetFileName(path);
                fileSelectorLevel.Path = System.IO.Path.Combine(path, "level");
            }
        }
        public Editor()
        {
            InitializeComponent();
            dotEditor.Grid = grid;
            rulesEditor.Grid = grid;
            backgroundEditor.Grid = grid;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Path = folderBrowserDialog.SelectedPath;
            }
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            Path = @"C:\Users\Michal\Documents\Puzzle game packs\Pack 1";
        }

        private void fileSelectorPack_FileSelected(object sender, EventArgs e)
        {
            var lines = fileSelectorLevel.GetFileContent().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            if(lines.Length == 3)
            {
                backgroundEditor.FileSelector.File = lines[0];
                dotEditor.FileSelector.File = lines[1];
                rulesEditor.FileSelector.File = lines[2];
            }
        }

        private void fileSelectorPack_FileToSave(object sender, EventArgs e)
        {
           
        }
    }
}
