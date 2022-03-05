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
    public partial class ShapeLayerEditor : UserControl
    {
        public ShapeBackgroundLayer Layer { get; private set; }

        public ShapeLayerEditor()
        {
            InitializeComponent();
            Layer = new ShapeBackgroundLayer(BackgroundShapes.Circle, new AnimatedColor(0,100,50,10));
            Layer.Dist = 1;
            Layer.Scale = 1;
            Layer.TransX = 0;
            Layer.TransY = 0;
            Layer.Rotation = 0;
            comboBoxType.SelectedIndex = 0;
            animationPickerDistX.CopyTo = animationPickerDistY;
            animationPickerScaleX.CopyTo = animationPickerScaleY;
            animationPickerTransX.CopyTo = animationPickerTransY;
        }

        private void ColorValueChanged(object sender, EventArgs e)
        {
            Layer.Color = new AnimatedColor(
                animationPickerHue.Value,
                animationPickerSaturation.Value,
                animationPickerLightness.Value,
                animationPickerOpacity.Value
            );
        }

        private void animationPickerDistX_ValueChanged(object sender, EventArgs e)
        {
            Layer.DistX = animationPickerDistX.Value;
        }

        private void animationPickerDistY_ValueChanged(object sender, EventArgs e)
        {
            Layer.DistY = animationPickerDistY.Value;
        }

        private void animationPickerScaleX_ValueChanged(object sender, EventArgs e)
        {
            Layer.ScaleX = animationPickerScaleX.Value;
        }

        private void animationPickerScaleY_ValueChanged(object sender, EventArgs e)
        {
            Layer.ScaleY = animationPickerScaleY.Value;
        }

        private void animationPickerTransX_ValueChanged(object sender, EventArgs e)
        {
            Layer.TransX = animationPickerTransX.Value;
        }

        private void animationPickerTransY_ValueChanged(object sender, EventArgs e)
        {
            Layer.TransY = animationPickerTransY.Value;
        }

        private void animationPickerRotation_ValueChanged(object sender, EventArgs e)
        {
            Layer.Rotation = animationPickerRotation.Value;
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedItem.ToString() == "Circle")
                Layer.Shape = BackgroundShapes.Circle;
            else if (comboBoxType.SelectedItem.ToString() == "Square")
                Layer.Shape = BackgroundShapes.Square;
            else if (comboBoxType.SelectedItem.ToString() == "Triangle")
                Layer.Shape = BackgroundShapes.Triangle;
            else if (comboBoxType.SelectedItem.ToString() == "Hexagon")
                Layer.Shape = BackgroundShapes.Hexagon;
        }
    }
}
