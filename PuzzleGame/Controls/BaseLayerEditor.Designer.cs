namespace PuzzleGame
{
    partial class BaseLayerEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.animationPickerHue = new PuzzleGame.AnimationPicker();
            this.animationPickerSaturation = new PuzzleGame.AnimationPicker();
            this.animationPickerLightness = new PuzzleGame.AnimationPicker();
            this.animationPickerOpacity = new PuzzleGame.AnimationPicker();
            this.groupBox.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.AutoSize = true;
            this.groupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox.Controls.Add(this.flowLayoutPanel1);
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(425, 87);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Background";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.animationPickerHue);
            this.flowLayoutPanel1.Controls.Add(this.animationPickerSaturation);
            this.flowLayoutPanel1.Controls.Add(this.animationPickerLightness);
            this.flowLayoutPanel1.Controls.Add(this.animationPickerOpacity);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(7, 20);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(420, 1000000);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(412, 48);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // animationPickerHue
            // 
            this.animationPickerHue.BackColor = System.Drawing.SystemColors.Control;
            this.animationPickerHue.Base = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.animationPickerHue.CopyTo = null;
            this.animationPickerHue.Location = new System.Drawing.Point(3, 0);
            this.animationPickerHue.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.animationPickerHue.Maximum = new decimal(new int[] {
            3599,
            0,
            0,
            65536});
            this.animationPickerHue.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.animationPickerHue.Name = "animationPickerHue";
            this.animationPickerHue.Size = new System.Drawing.Size(200, 24);
            this.animationPickerHue.TabIndex = 0;
            this.animationPickerHue.Unit = "°";
            this.animationPickerHue.ValueName = "Hue";
            this.animationPickerHue.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // animationPickerSaturation
            // 
            this.animationPickerSaturation.BackColor = System.Drawing.SystemColors.Control;
            this.animationPickerSaturation.Base = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.animationPickerSaturation.CopyTo = null;
            this.animationPickerSaturation.Location = new System.Drawing.Point(209, 0);
            this.animationPickerSaturation.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.animationPickerSaturation.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.animationPickerSaturation.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.animationPickerSaturation.Name = "animationPickerSaturation";
            this.animationPickerSaturation.Size = new System.Drawing.Size(200, 24);
            this.animationPickerSaturation.TabIndex = 1;
            this.animationPickerSaturation.Unit = "%";
            this.animationPickerSaturation.ValueName = "Saturation";
            this.animationPickerSaturation.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // animationPickerLightness
            // 
            this.animationPickerLightness.BackColor = System.Drawing.SystemColors.Control;
            this.animationPickerLightness.Base = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.animationPickerLightness.CopyTo = null;
            this.animationPickerLightness.Location = new System.Drawing.Point(3, 24);
            this.animationPickerLightness.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.animationPickerLightness.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.animationPickerLightness.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.animationPickerLightness.Name = "animationPickerLightness";
            this.animationPickerLightness.Size = new System.Drawing.Size(200, 24);
            this.animationPickerLightness.TabIndex = 2;
            this.animationPickerLightness.Unit = "%";
            this.animationPickerLightness.ValueName = "Lightness";
            this.animationPickerLightness.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // animationPickerOpacity
            // 
            this.animationPickerOpacity.BackColor = System.Drawing.SystemColors.Control;
            this.animationPickerOpacity.Base = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.animationPickerOpacity.CopyTo = null;
            this.flowLayoutPanel1.SetFlowBreak(this.animationPickerOpacity, true);
            this.animationPickerOpacity.Location = new System.Drawing.Point(209, 24);
            this.animationPickerOpacity.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.animationPickerOpacity.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.animationPickerOpacity.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.animationPickerOpacity.Name = "animationPickerOpacity";
            this.animationPickerOpacity.Size = new System.Drawing.Size(200, 24);
            this.animationPickerOpacity.TabIndex = 3;
            this.animationPickerOpacity.Unit = "%";
            this.animationPickerOpacity.ValueName = "Opacity";
            this.animationPickerOpacity.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // BaseLayerEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.groupBox);
            this.Name = "BaseLayerEditor";
            this.Size = new System.Drawing.Size(428, 90);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private AnimationPicker animationPickerHue;
        private AnimationPicker animationPickerSaturation;
        private AnimationPicker animationPickerLightness;
        private AnimationPicker animationPickerOpacity;
    }
}
