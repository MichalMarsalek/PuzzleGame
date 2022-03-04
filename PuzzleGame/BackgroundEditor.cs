using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleGame
{
    public partial class BackgroundEditor : UserControl
    {
        public BackgroundEditor()
        {
            InitializeComponent();
            AddBackground();
        }

        private FlowLayoutPanel AddNewPanel(string name)
        {
            FlowLayoutPanel inner = new FlowLayoutPanel();
            inner.MaximumSize = new Size(400, 100000000);
            inner.AutoSize = true;
            inner.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            inner.Location = new Point(10, 20);
            inner.MinimumSize = new Size(415, 0);
            GroupBox group = new GroupBox();
            group.MinimumSize = new Size(415, 0);
            group.Text = name;
            group.AutoSize = true;
            group.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            group.Controls.Add(inner);
            flowLayoutPanel.Controls.Add(group);
            return inner;
        }

        private void AddBackground()
        {
            var panel = AddNewPanel("Background");
            panel.Controls.Add(new AnimationPicker("Hue", "°", 0, 359.9M));
            panel.Controls.Add(new AnimationPicker("Saturation", "%", 0, 100M, 50));
            panel.Controls.Add(new AnimationPicker("Lightness", "%", 0, 100M, 50));
            panel.Controls.Add(new AnimationPicker("Opacity", "%", 0, 100M, 10));
        }

        private Panel Breaker()
        {
            Panel panel = new Panel();
            panel.Width = 354;
            panel.Height = 1;
            return panel;
        }

        private void AddLayer()
        {
            var panel = AddNewPanel($"Layer {flowLayoutPanel.Controls.Count}");
            var combo = new ComboBox();
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.Items.Add("Square");
            combo.Items.Add("Triangle");
            combo.Items.Add("Hexagon");
            combo.Items.Add("Circle");
            combo.Width = 70;
            combo.SelectedIndex = 0;
            panel.Parent.Controls.Add(combo);
            combo.Location = new Point(0, 0);
            combo.BringToFront();
            panel.Controls.Add(Breaker());
            panel.Controls.Add(new AnimationPicker("Hue", "°", 0, 359.9M));
            panel.Controls.Add(new AnimationPicker("Saturation", "%", 0, 100M, 50));
            panel.Controls.Add(new AnimationPicker("Lightness", "%", 0, 100M, 50));
            panel.Controls.Add(new AnimationPicker("Opacity", "%", 0, 100M, 50));
            panel.Controls.Add(Breaker());
            var dx = new AnimationPicker("Dist x", "", 0, 100M, 1);
            var dy = new AnimationPicker("Dist y", "", 0, 100M, 1);
            dx.CopyTo = dy;
            panel.Controls.Add(dx);
            panel.Controls.Add(dy);
            panel.Controls.Add(Breaker());
            var sx = new AnimationPicker("Scale x", "", 0, 100M, 1);
            var sy = new AnimationPicker("Scale y", "", 0, 100M, 1);
            sx.CopyTo = sy;
            panel.Controls.Add(sx);
            panel.Controls.Add(sy);
            panel.Controls.Add(Breaker());
            var tx = new AnimationPicker("Trans x", "", 0, 100M);
            var ty = new AnimationPicker("Trans y", "", 0, 100M);
            tx.CopyTo = ty;
            panel.Controls.Add(tx);
            panel.Controls.Add(ty);
            panel.Controls.Add(Breaker());
            panel.Controls.Add(new AnimationPicker("Rotation", "°", 0, 359.9M));
        }

        private void RemoveLastLayer()
        {
            flowLayoutPanel.Controls.RemoveAt(flowLayoutPanel.Controls.Count - 1);
        }

        private void buttonNewLayer_Click(object sender, EventArgs e)
        {
            AddLayer();
        }

        private void buttonDeleteLayer_Click(object sender, EventArgs e)
        {
            RemoveLastLayer();
        }
    }
}
