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
    public partial class BackgroundEditor : UserControl
    {
        private Grid2 grid;

        public Grid2 Grid
        {
            get => grid;
            set
            {
                grid = value;
                if (grid != null)
                    grid.Backgrounds = Layers;
            }
        }

        public List<BackgroundLayer> Layers { get; private set; }

        public BackgroundEditor()
        {
            InitializeComponent();
            Layers = new List<BackgroundLayer>() { baseLayerEditor.Layer };
        }
        private void buttonNewLayer_Click(object sender, EventArgs e)
        {
            ShapeLayerEditor control = new ShapeLayerEditor();
            flowLayoutPanel.Controls.Add(control);
            Layers.Add(control.Layer);
        }

        private void buttonDeleteLayer_Click(object sender, EventArgs e)
        {
            if (Layers.Count > 1)
            {
                Layers.RemoveAt(Layers.Count - 1);
                flowLayoutPanel.Controls.RemoveAt(Layers.Count);
            }
        }
    }
}
