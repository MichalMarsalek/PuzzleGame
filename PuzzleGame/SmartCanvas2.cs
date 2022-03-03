using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace PuzzleGame
{
    public partial class SmartCanvas2 : Panel
    {

        public float scaleQ { get; private set; }                              //Zvětšení
        public float xPadding { get; private set; }                                  //Posun ve vodorovném směru
        public float yPadding { get; private set; }                                  //Posun ve svislém směru
        public PointF MouseLocation { get; private set; }   //Poslední známá pozice myši, ve virtuálních souřadnicích plátna

        private Timer timer;
        private const int fps = 50;

        public SmartCanvas2()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Recalculate();
            Refresh();
            timer = new Timer();
            timer.Interval = 1000 / fps;
            timer.Enabled = true;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        #region Atributy plátna, informace pro Visual Studio
        [Description("Dimensions"), Category("Layout")]
        private SizeF dimensions;
        public SizeF Dimensions
        {
            get
            {
                return dimensions;
            }
            set
            {
                dimensions = value;
                Recalculate();
            }
        }
        public void ResetDimensions()
        {
            Dimensions = new SizeF(1, 1);
        }
        [Description("Origin"), Category("Layout")]
        private PointF origin;
        public PointF Origin
        {
            get
            {
                return origin;
            }
            set
            {
                origin = value;
                Recalculate();
            }
        }
        public void ResetOrigin()
        {
            Origin = new PointF(0, 0);
        }
        #endregion

        #region Změna velikosti, překreslování a záznam kurzoru
        protected override void OnResize(EventArgs eventargs)
        {
            Recalculate();
            base.OnResize(eventargs);
        }

        private void Recalculate()
        {
            scaleQ = Math.Min((float)Width / Dimensions.Width, (float)Height / Dimensions.Height);
            xPadding = (Width / scaleQ - Dimensions.Width) / 2f;
            yPadding = (Height / scaleQ - Dimensions.Height) / 2f;
        }

        //Upraví Graphics plátna tak, aby se pěkně vykreslovalo a převede souřadnice zse skutečných na obrazovce na virtuální na plátně
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.ResetTransform();
            g.ScaleTransform(scaleQ, scaleQ);
            g.TranslateTransform(xPadding - Origin.X, yPadding - Origin.Y);
            base.OnPaint(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            MouseLocation = new PointF(e.X / scaleQ - xPadding + Origin.X, e.Y / scaleQ - yPadding + Origin.Y);
            base.OnMouseMove(e);
        }
        #endregion
    }
}
