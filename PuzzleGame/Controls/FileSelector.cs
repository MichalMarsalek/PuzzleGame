using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleGame
{
    public partial class FileSelector : UserControl
    {
        private string path;
        public string Path {
            get => path;
            set
            {
                path = value;
                comboBoxFiles.Items.Clear();
                foreach(string file in Util.GetFiles(path))
                {
                    comboBoxFiles.Items.Add(System.IO.Path.GetFileName(file));
                }
                if (comboBoxFiles.Items.Count > 0)
                    comboBoxFiles.SelectedIndex = 0;
            }
        }
        public string File
        {
            get => comboBoxFiles.SelectedItem as string;
            set => comboBoxFiles.SelectedItem = value;
        }
        public FileSelector()
        {
            InitializeComponent();
        }

        public event EventHandler FileSelected;
        public event EventHandler FileToSave;

        private void comboBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileSelected?.Invoke(this, EventArgs.Empty);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            FileToSave?.Invoke(this, EventArgs.Empty);
        }

        public string GetFileContent()
        {
            return System.IO.File.ReadAllText(System.IO.Path.Combine(Path, File));
        }

        public void SaveToFile(string content)
        {
            System.IO.File.WriteAllText(System.IO.Path.Combine(Path, File), content);
        }
    }
}
