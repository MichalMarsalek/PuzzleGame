﻿using System;
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

        private Language.Objective objective;

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
            grid.Backgrounds = backgroundLayerEditor.Layers;
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
            //richTextBoxDebug.Text = String.Join("|", new Language.Parser().GetTokens(richTextBoxRules.Text));
            //richTextBoxDebug.Text += "\n" + objective.EvaluateTypes().ToShortString();
            //richTextBoxDebug.Text += "\n" + String.Join("\n", Language.QueryParam.GetAllValuesStartingWith(richTextBoxRules.Text).Take(50));
            List<Type> types;
            try
            {
                objective = new Language.Parser().ParseObjective(richTextBoxRules.Text);
                types = objective.EvaluateTypes();
            }
            catch (Language.Exception ex)
            {
                richTextBoxDebug.Text = ex.Message;
                objective = null;
                return;
            }
            try
            {
                var res = objective.EvaluateValues(new Language.GridState(grid));
                richTextBoxDebug.Text = String.Join("\r\n", res);
                if (types.All(i => i == typeof(bool)))
                    richTextBoxDebug.Text += "\r\nFinal value: " + objective.IsMet(res).ToString();
            }
            catch (Language.Exception ex)
            {
                richTextBoxDebug.Text = ex.Message;
                objective = null;
            }
        }

        private void richTextBoxGridSetup_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBoxGridSetup_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void buttonFormat_Click(object sender, EventArgs e)
        {
            if (objective != null)
                richTextBoxRules.Text = objective.ToCode();
            grid.Backgrounds = backgroundLayerEditor.Layers;
        }

        private void grid_MouseMove_1(object sender, MouseEventArgs e)
        {
            Text = grid.MouseLocation.ToString();
        }
    }
}