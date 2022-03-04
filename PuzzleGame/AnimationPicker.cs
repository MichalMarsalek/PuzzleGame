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
    public partial class AnimationPicker : UserControl
    {
        [Description("Name of the value"), Category("Animation picker")]
        public string ValueName
        {
            get => labelName.Text;
            set => labelName.Text = value;
        }
        [Description("Unit"), Category("Animation picker")]
        public string Unit
        {
            get => numericUpDownWithUnitBase.Unit;
            set
            {
                numericUpDownWithUnitBase.Unit = numericUpDownWithUnitVariation.Unit = value;
                numericUpDownWithUnitBase.ResetText();
                numericUpDownWithUnitVariation.ResetText();
            }
        }
        [Description("Minimum"), Category("Animation picker")]
        public Decimal Minimum
        {
            get => numericUpDownWithUnitBase.Minimum;
            set => numericUpDownWithUnitBase.Minimum = value;
        }
        [Description("Maximum"), Category("Animation picker")]
        public Decimal Maximum
        {
            get => numericUpDownWithUnitBase.Maximum;
            set => numericUpDownWithUnitBase.Maximum = value;
        }

        public AnimationPicker CopyTo { get;  set; }

        public AnimationPicker()
        {
            InitializeComponent();
            comboBoxAnimation.SelectedIndex = 0;
            SetupVisibility();
        }
        public AnimationPicker(string name, string unit, Decimal min, Decimal max, Decimal defa = 0M)
        {
            InitializeComponent();
            comboBoxAnimation.SelectedIndex = 0;
            ValueName = name;
            Unit = unit;
            Minimum = min;
            Maximum = max;
            numericUpDownWithUnitBase.Value = defa;
            SetupVisibility();
        }

        private void numericUpDownWithUnitBase_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownWithUnitVariation.Maximum = Math.Min(
                numericUpDownWithUnitBase.Value - numericUpDownWithUnitBase.Minimum,
                numericUpDownWithUnitBase.Maximum - numericUpDownWithUnitBase.Value
            );
            if(CopyTo != null && numericUpDownWithUnitVariation.Value == 0 && CopyTo.numericUpDownWithUnitVariation.Value == 0)
            {
                CopyTo.numericUpDownWithUnitBase.Value = numericUpDownWithUnitBase.Value;
            }
        }

        private void SetupVisibility()
        {
            comboBoxAnimation.Visible = labelAnimation.Visible
                = numericUpDownWithUnitVariation.Value != 0;
            labelOver.Visible = labelWait.Visible = numericUpDownWithUnitOver.Visible = checkBoxSynced.Visible
                = numericUpDownWithUnitWait.Visible = comboBoxAnimation.SelectedIndex > 0;
            if (labelAnimation.Visible)
            {
                Width = 354;
            }
            else
            {
                Width = 200;
                Height = 24;
            }
            if(comboBoxAnimation.SelectedIndex > 0)
            {
                Height = 48;
            }
            else
            {
                Height = 24;
            }
        }

        private void numericUpDownWithUnitVariation_ValueChanged(object sender, EventArgs e)
        {
            SetupVisibility();
        }

        private void comboBoxAnimation_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetupVisibility();
        }
    }
}
