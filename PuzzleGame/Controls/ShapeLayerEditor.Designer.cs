namespace PuzzleGame
{
    partial class ShapeLayerEditor
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
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.animationPickerHue = new PuzzleGame.AnimationPicker();
            this.animationPickerSaturation = new PuzzleGame.AnimationPicker();
            this.animationPickerLightness = new PuzzleGame.AnimationPicker();
            this.animationPickerOpacity = new PuzzleGame.AnimationPicker();
            this.animationPickerDistX = new PuzzleGame.AnimationPicker();
            this.animationPickerDistY = new PuzzleGame.AnimationPicker();
            this.animationPickerScaleX = new PuzzleGame.AnimationPicker();
            this.animationPickerScaleY = new PuzzleGame.AnimationPicker();
            this.animationPickerTransX = new PuzzleGame.AnimationPicker();
            this.animationPickerTransY = new PuzzleGame.AnimationPicker();
            this.animationPickerRotation = new PuzzleGame.AnimationPicker();
            this.groupBox.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.AutoSize = true;
            this.groupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox.Controls.Add(this.comboBoxType);
            this.groupBox.Controls.Add(this.flowLayoutPanel1);
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(425, 183);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            // 
            // comboBoxType
            // 
            this.comboBoxType.BackColor = System.Drawing.SystemColors.Control;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Square",
            "Triangle",
            "Hexagon",
            "Circle"});
            this.comboBoxType.Location = new System.Drawing.Point(0, 0);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxType.TabIndex = 1;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.animationPickerHue);
            this.flowLayoutPanel1.Controls.Add(this.animationPickerSaturation);
            this.flowLayoutPanel1.Controls.Add(this.animationPickerLightness);
            this.flowLayoutPanel1.Controls.Add(this.animationPickerOpacity);
            this.flowLayoutPanel1.Controls.Add(this.animationPickerDistX);
            this.flowLayoutPanel1.Controls.Add(this.animationPickerDistY);
            this.flowLayoutPanel1.Controls.Add(this.animationPickerScaleX);
            this.flowLayoutPanel1.Controls.Add(this.animationPickerScaleY);
            this.flowLayoutPanel1.Controls.Add(this.animationPickerTransX);
            this.flowLayoutPanel1.Controls.Add(this.animationPickerTransY);
            this.flowLayoutPanel1.Controls.Add(this.animationPickerRotation);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(7, 20);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(420, 100000);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(412, 144);
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
            this.animationPickerHue.ValueChanged += new System.EventHandler(this.ColorValueChanged);
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
            this.animationPickerSaturation.ValueChanged += new System.EventHandler(this.ColorValueChanged);
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
            this.animationPickerLightness.ValueChanged += new System.EventHandler(this.ColorValueChanged);
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
            this.animationPickerOpacity.ValueChanged += new System.EventHandler(this.ColorValueChanged);
            // 
            // animationPickerDistX
            // 
            this.animationPickerDistX.BackColor = System.Drawing.SystemColors.Control;
            this.animationPickerDistX.Base = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.animationPickerDistX.CopyTo = null;
            this.animationPickerDistX.Location = new System.Drawing.Point(3, 48);
            this.animationPickerDistX.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.animationPickerDistX.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.animationPickerDistX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.animationPickerDistX.Name = "animationPickerDistX";
            this.animationPickerDistX.Size = new System.Drawing.Size(200, 24);
            this.animationPickerDistX.TabIndex = 4;
            this.animationPickerDistX.Unit = "";
            this.animationPickerDistX.ValueName = "Dist X";
            this.animationPickerDistX.ValueChanged += new System.EventHandler(this.animationPickerDistX_ValueChanged);
            // 
            // animationPickerDistY
            // 
            this.animationPickerDistY.BackColor = System.Drawing.SystemColors.Control;
            this.animationPickerDistY.Base = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.animationPickerDistY.CopyTo = null;
            this.flowLayoutPanel1.SetFlowBreak(this.animationPickerDistY, true);
            this.animationPickerDistY.Location = new System.Drawing.Point(209, 48);
            this.animationPickerDistY.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.animationPickerDistY.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.animationPickerDistY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.animationPickerDistY.Name = "animationPickerDistY";
            this.animationPickerDistY.Size = new System.Drawing.Size(200, 24);
            this.animationPickerDistY.TabIndex = 5;
            this.animationPickerDistY.Unit = "";
            this.animationPickerDistY.ValueName = "DistY";
            this.animationPickerDistY.ValueChanged += new System.EventHandler(this.animationPickerDistY_ValueChanged);
            // 
            // animationPickerScaleX
            // 
            this.animationPickerScaleX.BackColor = System.Drawing.SystemColors.Control;
            this.animationPickerScaleX.Base = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.animationPickerScaleX.CopyTo = null;
            this.animationPickerScaleX.Location = new System.Drawing.Point(3, 72);
            this.animationPickerScaleX.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.animationPickerScaleX.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.animationPickerScaleX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.animationPickerScaleX.Name = "animationPickerScaleX";
            this.animationPickerScaleX.Size = new System.Drawing.Size(200, 24);
            this.animationPickerScaleX.TabIndex = 6;
            this.animationPickerScaleX.Unit = "";
            this.animationPickerScaleX.ValueName = "Scale X";
            this.animationPickerScaleX.ValueChanged += new System.EventHandler(this.animationPickerScaleX_ValueChanged);
            // 
            // animationPickerScaleY
            // 
            this.animationPickerScaleY.BackColor = System.Drawing.SystemColors.Control;
            this.animationPickerScaleY.Base = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.animationPickerScaleY.CopyTo = null;
            this.flowLayoutPanel1.SetFlowBreak(this.animationPickerScaleY, true);
            this.animationPickerScaleY.Location = new System.Drawing.Point(209, 72);
            this.animationPickerScaleY.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.animationPickerScaleY.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.animationPickerScaleY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.animationPickerScaleY.Name = "animationPickerScaleY";
            this.animationPickerScaleY.Size = new System.Drawing.Size(200, 24);
            this.animationPickerScaleY.TabIndex = 7;
            this.animationPickerScaleY.Unit = "";
            this.animationPickerScaleY.ValueName = "Scale Y";
            this.animationPickerScaleY.ValueChanged += new System.EventHandler(this.animationPickerScaleY_ValueChanged);
            // 
            // animationPickerTransX
            // 
            this.animationPickerTransX.BackColor = System.Drawing.SystemColors.Control;
            this.animationPickerTransX.Base = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.animationPickerTransX.CopyTo = null;
            this.animationPickerTransX.Location = new System.Drawing.Point(3, 96);
            this.animationPickerTransX.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.animationPickerTransX.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.animationPickerTransX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.animationPickerTransX.Name = "animationPickerTransX";
            this.animationPickerTransX.Size = new System.Drawing.Size(200, 24);
            this.animationPickerTransX.TabIndex = 8;
            this.animationPickerTransX.Unit = "";
            this.animationPickerTransX.ValueName = "Trans X";
            this.animationPickerTransX.ValueChanged += new System.EventHandler(this.animationPickerTransX_ValueChanged);
            // 
            // animationPickerTransY
            // 
            this.animationPickerTransY.BackColor = System.Drawing.SystemColors.Control;
            this.animationPickerTransY.Base = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.animationPickerTransY.CopyTo = null;
            this.flowLayoutPanel1.SetFlowBreak(this.animationPickerTransY, true);
            this.animationPickerTransY.Location = new System.Drawing.Point(209, 96);
            this.animationPickerTransY.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.animationPickerTransY.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.animationPickerTransY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.animationPickerTransY.Name = "animationPickerTransY";
            this.animationPickerTransY.Size = new System.Drawing.Size(200, 24);
            this.animationPickerTransY.TabIndex = 9;
            this.animationPickerTransY.Unit = "";
            this.animationPickerTransY.ValueName = "Trans Y";
            this.animationPickerTransY.ValueChanged += new System.EventHandler(this.animationPickerTransY_ValueChanged);
            // 
            // animationPickerRotation
            // 
            this.animationPickerRotation.BackColor = System.Drawing.SystemColors.Control;
            this.animationPickerRotation.Base = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.animationPickerRotation.CopyTo = null;
            this.animationPickerRotation.Location = new System.Drawing.Point(3, 120);
            this.animationPickerRotation.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.animationPickerRotation.Maximum = new decimal(new int[] {
            3599,
            0,
            0,
            65536});
            this.animationPickerRotation.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.animationPickerRotation.Name = "animationPickerRotation";
            this.animationPickerRotation.Size = new System.Drawing.Size(200, 24);
            this.animationPickerRotation.TabIndex = 10;
            this.animationPickerRotation.Unit = "°";
            this.animationPickerRotation.ValueName = "Rotation";
            this.animationPickerRotation.ValueChanged += new System.EventHandler(this.animationPickerRotation_ValueChanged);
            // 
            // ShapeLayerEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.groupBox);
            this.Name = "ShapeLayerEditor";
            this.Size = new System.Drawing.Size(428, 186);
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
        private System.Windows.Forms.ComboBox comboBoxType;
        private AnimationPicker animationPickerDistX;
        private AnimationPicker animationPickerDistY;
        private AnimationPicker animationPickerScaleX;
        private AnimationPicker animationPickerScaleY;
        private AnimationPicker animationPickerTransX;
        private AnimationPicker animationPickerTransY;
        private AnimationPicker animationPickerRotation;
    }
}
