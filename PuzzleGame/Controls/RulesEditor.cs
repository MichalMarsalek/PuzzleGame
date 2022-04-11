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
    public partial class RulesEditor : UserControl
    {
        public Grid2 Grid
        {
            get => grid;
            set
            {
                grid = value;
                if(grid != null) grid.StateChanged += Grid_StateChanged;
            }
        }

        private void Grid_StateChanged(object sender, MouseEventArgs e)
        {
            richTextBoxRules_TextChanged(sender, null);
        }

        private Language.Objective objective;
        private Grid2 grid;

        public RulesEditor()
        {
            InitializeComponent();
        }

        private void fileSelector_FileSelected(object sender, EventArgs e)
        {
            richTextBoxRules.Text = FileSelector.GetFileContent();
        }

        private void fileSelector_FileToSave(object sender, EventArgs e)
        {
            FileSelector.SaveToFile(richTextBoxRules.Text);
        }

        private void richTextBoxRules_TextChanged(object sender, EventArgs e)
        {
            List<Type> types;
            try
            {
                objective = new Language.Parser().ParseObjective(richTextBoxRules.Text);
                types = objective.EvaluateTypes();
            }
            catch (Language.Exception ex)
            {
                textBoxOutput.Text = ex.Message;
                objective = null;
                return;
            }
            try
            {
                var res = objective.EvaluateValues(new Language.GridState(Grid));
                textBoxOutput.Text = String.Join("\r\n", res);
                if (types.All(i => i == typeof(bool)))
                    textBoxOutput.Text += "\r\nFinal value: " + objective.IsMet(res).ToString();
            }
            catch (Language.Exception ex)
            {
                textBoxOutput.Text = ex.Message;
                objective = null;
            }
        }

        private void buttonFormat_Click(object sender, EventArgs e)
        {
            if (objective != null)
                richTextBoxRules.Text = objective.ToCode();
        }
    }
}
