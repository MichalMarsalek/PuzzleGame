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
    public partial class BaseLayerEditor : UserControl
    {
        public BackgroundLayer Layer { get; private set; }

        public BaseLayerEditor()
        {
            InitializeComponent();
            Layer = new BackgroundLayer(new AnimatedColor(0, 100, 50, 10));
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ValueChanged(object sender, EventArgs e)
        {
            Layer.Color = new AnimatedColor(
                animationPickerHue.Value,
                animationPickerSaturation.Value,
                animationPickerLightness.Value,
                animationPickerOpacity.Value
            );
        }
    }
}
