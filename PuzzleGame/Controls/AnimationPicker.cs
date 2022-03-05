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
        public AnimatedDouble Value { get; private set; }

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
        [Description("Base value"), Category("Animation picker")]
        public Decimal Base
        {
            get => numericUpDownWithUnitBase.Value;
            set => numericUpDownWithUnitBase.Value = value;
        }


        public event EventHandler ValueChanged;


        public AnimationPicker CopyTo { get;  set; }

        public AnimationPicker()
        {
            InitializeComponent();
            Value = new ConstantDouble((double)Base, 0, 0, false);
            comboBoxAnimation.SelectedIndex = 0;
            SetupVisibility();
            SetupBounds();
        }
        public AnimationPicker(string name, string unit, Decimal min, Decimal max, Decimal defa = 0M)
        {
            InitializeComponent();
            Value = new ConstantDouble((double)Base, 0, 0, false);
            comboBoxAnimation.SelectedIndex = 0;
            ValueName = name;
            Unit = unit;
            Minimum = min;
            Maximum = max;
            numericUpDownWithUnitBase.Value = defa;
            SetupVisibility();
            SetupBounds();
        }

        private void numericUpDownWithUnitBase_ValueChanged(object sender, EventArgs e)
        {
            SetupBounds();
            if(CopyTo != null && numericUpDownWithUnitVariation.Value == 0 && CopyTo.numericUpDownWithUnitVariation.Value == 0)
            {
                CopyTo.numericUpDownWithUnitBase.Value = numericUpDownWithUnitBase.Value;
            }
            Value.Base = (double)numericUpDownWithUnitBase.Value;
            ValueChanged?.Invoke(this, e);
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
            Value.Variation = (double)numericUpDownWithUnitVariation.Value;
            ValueChanged?.Invoke(this, e);
        }

        private void comboBoxAnimation_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetupVisibility();
            SetupBounds();
            if ((comboBoxAnimation.SelectedItem as string) == "Constant")
                Value = new ConstantDouble(
                    (double)numericUpDownWithUnitBase.Value,
                    (double)numericUpDownWithUnitVariation.Value,
                    (int)numericUpDownGroup.Value,
                    checkBoxSynced.Checked
                );
            else if ((comboBoxAnimation.SelectedItem as string) == "Linear")
                Value = new RotateDouble(
                    (double)numericUpDownWithUnitBase.Value,
                    (double)numericUpDownWithUnitVariation.Value,
                    (double)numericUpDownWithUnitOver.Value,
                    (double)numericUpDownWithUnitWait.Value,
                    (int)numericUpDownGroup.Value,
                    checkBoxSynced.Checked
                );
            else if ((comboBoxAnimation.SelectedItem as string) == "Sine")
                Value = new SineDouble(
                    (double)numericUpDownWithUnitBase.Value,
                    (double)numericUpDownWithUnitVariation.Value,
                    (double)numericUpDownWithUnitOver.Value,
                    (double)numericUpDownWithUnitWait.Value,
                    (int)numericUpDownGroup.Value,
                    checkBoxSynced.Checked
                );
            else if ((comboBoxAnimation.SelectedItem as string) == "Half sine")
                Value = new HalfSineDouble(
                    (double)numericUpDownWithUnitBase.Value,
                    (double)numericUpDownWithUnitVariation.Value,
                    (double)numericUpDownWithUnitOver.Value,
                    (double)numericUpDownWithUnitWait.Value,
                    (int)numericUpDownGroup.Value,
                    checkBoxSynced.Checked
                );
            ValueChanged?.Invoke(this, e);
        }

        private void SetupBounds()
        {
            if (Unit == "%")
            {
                numericUpDownWithUnitBase.Minimum = 0;
                numericUpDownWithUnitBase.Maximum = 100;
            }
            if (Unit == "°")
            {
                numericUpDownWithUnitBase.Minimum = 0;
                numericUpDownWithUnitBase.Maximum = 359.9M;
            }
            if(Unit == "%" || Unit == "°") { 
                if (comboBoxAnimation.SelectedItem.ToString() == "Sine")
                {
                    Decimal l = Math.Min(
                        numericUpDownWithUnitBase.Value - numericUpDownWithUnitBase.Minimum,
                        numericUpDownWithUnitBase.Maximum - numericUpDownWithUnitBase.Value
                    );
                    numericUpDownWithUnitVariation.Minimum = -l;
                    numericUpDownWithUnitVariation.Maximum = l;
                }
                else
                {
                    numericUpDownWithUnitVariation.Minimum = numericUpDownWithUnitBase.Minimum - numericUpDownWithUnitBase.Value;
                    numericUpDownWithUnitVariation.Maximum = numericUpDownWithUnitBase.Maximum - numericUpDownWithUnitBase.Value;
                }
            }
        }

        private void numericUpDownWithUnitOver_ValueChanged(object sender, EventArgs e)
        {
            Value.Over = (double)numericUpDownWithUnitOver.Value;
            ValueChanged?.Invoke(this, e);
        }

        private void numericUpDownWithUnitWait_ValueChanged(object sender, EventArgs e)
        {
            Value.Wait = (double)numericUpDownWithUnitWait.Value;
            ValueChanged?.Invoke(this, e);
        }

        private void numericUpDownGroup_ValueChanged(object sender, EventArgs e)
        {
            Value.RandomGroup = (int)numericUpDownGroup.Value;
            ValueChanged?.Invoke(this, e);
        }

        private void checkBoxSynced_CheckedChanged(object sender, EventArgs e)
        {
            Value.IsSynced = checkBoxSynced.Checked;
            ValueChanged?.Invoke(this, e);
        }

        private void AnimationPicker_Load(object sender, EventArgs e)
        {
            Value = new ConstantDouble((double)Base, 0, 0, false);
        }
    }
}
