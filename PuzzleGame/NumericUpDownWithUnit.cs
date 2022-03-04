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
    public partial class NumericUpDownWithUnit : NumericUpDown
    {
        [Description("Unit"), Category("Unit")]
        public string Unit { get; set; }
        protected override void UpdateEditText()
        {
            ChangingText = true;
            Text = $"{Value} {Unit}";
        }
    }
}
