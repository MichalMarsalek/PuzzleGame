using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleGame
{
    public partial class Form1 : Form
    {

        private GridSetupCode gridSetupCode;

        bool highlighting = false;

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

        private const int WM_USER = 0x0400;
        private const int EM_SETEVENTMASK = (WM_USER + 69);
        private const int WM_SETREDRAW = 0x0b;
        private IntPtr OldEventMask;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        public void BeginUpdate(Control control)
        {
            SendMessage(control.Handle, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);
            OldEventMask = (IntPtr)SendMessage(control.Handle, EM_SETEVENTMASK, IntPtr.Zero, IntPtr.Zero);
        }

        public void EndUpdate(Control control)
        {
            SendMessage(control.Handle, WM_SETREDRAW, (IntPtr)1, IntPtr.Zero);
            SendMessage(control.Handle, EM_SETEVENTMASK, IntPtr.Zero, OldEventMask);
        }

        private void richTextBoxRules_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //var program = new RulesProgram(richTextBoxRules.Text);
                //richTextBoxDebug.Text = String.Join("\n", program.Run());
                //richTextBoxDebug.Text = String.Join("\n", program.Expressions);
                var lexer = new RulesLangLexer();
                List<LexToken> tokens = lexer.GetTokens(richTextBoxRules.Text).ToList();
                Point scroll = richTextBoxRules.AutoScrollOffset;
                int ss = richTextBoxRules.SelectionStart;
                int sl = richTextBoxRules.SelectionLength;
                richTextBoxRules.SuspendLayout();
                BeginUpdate(richTextBoxRules);
                richTextBoxRules.SelectionStart = 0;
                richTextBoxRules.SelectionLength = richTextBoxRules.TextLength;
                richTextBoxRules.SelectionFont = new Font("Courier new", 12, FontStyle.Regular);
                richTextBoxRules.SelectionColor = Color.Black;
                richTextBoxRules.SelectionBackColor = Color.White;
                foreach (LexToken token in tokens)
                {
                    Color color = token.TokenColor();
                    Color bgColor = token.TokenBackgroundColor();
                    bool bold = token.Value == "it" || (token.Type == TokenType.Name && token.Value[0].ToString().ToUpper() == token.Value[0].ToString());
                    bool italic = token.Value == "it";
                    if (color == Color.Black && bgColor == Color.White && !bold && !italic) continue;
                    richTextBoxRules.SelectionStart = token.Position.ToAbsolutePosition(richTextBoxRules);
                    richTextBoxRules.SelectionLength = token.Length;
                    richTextBoxRules.SelectionColor = color;
                    richTextBoxRules.SelectionBackColor = bgColor;
                    if (bold)
                    {
                        if (italic)
                        {
                            richTextBoxRules.SelectionFont = new Font("Courier new", 12, FontStyle.Bold | FontStyle.Italic);
                        }
                        else
                        {
                            richTextBoxRules.SelectionFont = new Font("Courier new", 12, FontStyle.Bold);
                        }
                    }
                    else
                    {
                        richTextBoxRules.SelectionFont = new Font("Courier new", 12, FontStyle.Regular);
                    }
                }
                richTextBoxRules.SelectionStart = ss;
                richTextBoxRules.SelectionLength = sl;
                richTextBoxRules.AutoScrollOffset = scroll;
                EndUpdate(richTextBoxRules);
                richTextBoxRules.ResumeLayout(true);

                try
                {
                    var parser = new RulesLangParser(richTextBoxRules.Text);
                    richTextBoxDebug.Text = parser.Parse().ToString();
                }
                catch(ParsingException ex)
                {
                    richTextBoxDebug.Text = ex.Message;
                }
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
