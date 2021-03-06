using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleGame
{
    public partial class Form1 : Form
    {

        private GridSetupCode gridSetupCode;

        public Form1()
        {
            InitializeComponent();
            gridSetupCode = new GridSetupCode(richTextBoxGridSetup);
            richTextBoxGridSetup.TextChanged += textBoxGridSetup_TextChanged;
            //grid.MouseUp += grid_MouseUp;
        }

        private void textBoxGridSetup_TextChanged(object sender, EventArgs e)
        {
            grid.SetGrid(gridSetupCode); //TODO change it so that this doesn't get called on every key press, but only on real changes
        }

        private void comboBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxGridSetup.Text = File.ReadAllText((string)comboBoxFiles.SelectedItem);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string file in Directory.GetFiles("grids"))
            {
                comboBoxFiles.Items.Add(file);
            }
            comboBoxFiles.SelectedItem = "grids\\default.txt";
        }

        private void grid_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Vector v = gridSetupCode.ToCurrentCoordinates(grid.GetClosestDotOrNew(grid.MouseLocation, grid.snap));
                richTextBoxGridSetup.AppendText(" " + v.ToString());
            }
        }

        private void richTextBoxRules_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var program = new RulesProgram(richTextBoxRules.Text);
                richTextBoxDebug.Text = String.Join("\n", program.Run());
                //richTextBoxDebug.Text = String.Join("\n", program.Expressions);
            }
            catch (ParsingException ex)
            {
                richTextBoxDebug.Text = "Parsing error\n" + ex.Message;
            }
            catch (ExecutionException ex)
            {
                richTextBoxDebug.Text = "Execution error\n" + ex.Message;
            }
        }

        private void richTextBoxGridSetup_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBoxGridSetup_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
