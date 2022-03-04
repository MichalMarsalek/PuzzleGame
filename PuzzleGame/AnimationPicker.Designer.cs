namespace PuzzleGame
{
    partial class AnimationPicker
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
            this.labelName = new System.Windows.Forms.Label();
            this.labelOver = new System.Windows.Forms.Label();
            this.checkBoxSynced = new System.Windows.Forms.CheckBox();
            this.comboBoxAnimation = new System.Windows.Forms.ComboBox();
            this.labelAnimation = new System.Windows.Forms.Label();
            this.labelWait = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelGroup = new System.Windows.Forms.Label();
            this.numericUpDownGroup = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWithUnitWait = new PuzzleGame.NumericUpDownWithUnit();
            this.numericUpDownWithUnitOver = new PuzzleGame.NumericUpDownWithUnit();
            this.numericUpDownWithUnitVariation = new PuzzleGame.NumericUpDownWithUnit();
            this.numericUpDownWithUnitBase = new PuzzleGame.NumericUpDownWithUnit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWithUnitWait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWithUnitOver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWithUnitVariation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWithUnitBase)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(4, 4);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(34, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Value";
            // 
            // labelOver
            // 
            this.labelOver.AutoSize = true;
            this.labelOver.Location = new System.Drawing.Point(4, 27);
            this.labelOver.Name = "labelOver";
            this.labelOver.Size = new System.Drawing.Size(30, 13);
            this.labelOver.TabIndex = 2;
            this.labelOver.Text = "Over";
            // 
            // checkBoxSynced
            // 
            this.checkBoxSynced.AutoSize = true;
            this.checkBoxSynced.Location = new System.Drawing.Point(288, 28);
            this.checkBoxSynced.Name = "checkBoxSynced";
            this.checkBoxSynced.Size = new System.Drawing.Size(60, 17);
            this.checkBoxSynced.TabIndex = 4;
            this.checkBoxSynced.Text = "synced";
            this.checkBoxSynced.UseVisualStyleBackColor = true;
            // 
            // comboBoxAnimation
            // 
            this.comboBoxAnimation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAnimation.FormattingEnabled = true;
            this.comboBoxAnimation.Items.AddRange(new object[] {
            "Constant",
            "Linear",
            "Sine",
            "Half sine"});
            this.comboBoxAnimation.Location = new System.Drawing.Point(267, 1);
            this.comboBoxAnimation.Name = "comboBoxAnimation";
            this.comboBoxAnimation.Size = new System.Drawing.Size(81, 21);
            this.comboBoxAnimation.TabIndex = 5;
            this.comboBoxAnimation.SelectedIndexChanged += new System.EventHandler(this.comboBoxAnimation_SelectedIndexChanged);
            // 
            // labelAnimation
            // 
            this.labelAnimation.AutoSize = true;
            this.labelAnimation.Location = new System.Drawing.Point(208, 4);
            this.labelAnimation.Name = "labelAnimation";
            this.labelAnimation.Size = new System.Drawing.Size(53, 13);
            this.labelAnimation.TabIndex = 0;
            this.labelAnimation.Text = "Animation";
            // 
            // labelWait
            // 
            this.labelWait.AutoSize = true;
            this.labelWait.Location = new System.Drawing.Point(106, 27);
            this.labelWait.Name = "labelWait";
            this.labelWait.Size = new System.Drawing.Size(29, 13);
            this.labelWait.TabIndex = 2;
            this.labelWait.Text = "Wait";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(128, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "±";
            // 
            // labelGroup
            // 
            this.labelGroup.AutoSize = true;
            this.labelGroup.Location = new System.Drawing.Point(202, 27);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(36, 13);
            this.labelGroup.TabIndex = 11;
            this.labelGroup.Text = "Group";
            // 
            // numericUpDownGroup
            // 
            this.numericUpDownGroup.Location = new System.Drawing.Point(244, 24);
            this.numericUpDownGroup.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDownGroup.Name = "numericUpDownGroup";
            this.numericUpDownGroup.Size = new System.Drawing.Size(38, 20);
            this.numericUpDownGroup.TabIndex = 12;
            // 
            // numericUpDownWithUnitWait
            // 
            this.numericUpDownWithUnitWait.Location = new System.Drawing.Point(141, 24);
            this.numericUpDownWithUnitWait.Name = "numericUpDownWithUnitWait";
            this.numericUpDownWithUnitWait.Size = new System.Drawing.Size(55, 20);
            this.numericUpDownWithUnitWait.TabIndex = 10;
            this.numericUpDownWithUnitWait.Unit = "s";
            // 
            // numericUpDownWithUnitOver
            // 
            this.numericUpDownWithUnitOver.Location = new System.Drawing.Point(45, 25);
            this.numericUpDownWithUnitOver.Name = "numericUpDownWithUnitOver";
            this.numericUpDownWithUnitOver.Size = new System.Drawing.Size(55, 20);
            this.numericUpDownWithUnitOver.TabIndex = 9;
            this.numericUpDownWithUnitOver.Unit = "s";
            // 
            // numericUpDownWithUnitVariation
            // 
            this.numericUpDownWithUnitVariation.Location = new System.Drawing.Point(141, 3);
            this.numericUpDownWithUnitVariation.Name = "numericUpDownWithUnitVariation";
            this.numericUpDownWithUnitVariation.Size = new System.Drawing.Size(55, 20);
            this.numericUpDownWithUnitVariation.TabIndex = 8;
            this.numericUpDownWithUnitVariation.Unit = "%";
            this.numericUpDownWithUnitVariation.ValueChanged += new System.EventHandler(this.numericUpDownWithUnitVariation_ValueChanged);
            // 
            // numericUpDownWithUnitBase
            // 
            this.numericUpDownWithUnitBase.Location = new System.Drawing.Point(75, 4);
            this.numericUpDownWithUnitBase.Name = "numericUpDownWithUnitBase";
            this.numericUpDownWithUnitBase.Size = new System.Drawing.Size(55, 20);
            this.numericUpDownWithUnitBase.TabIndex = 7;
            this.numericUpDownWithUnitBase.Unit = "%";
            this.numericUpDownWithUnitBase.ValueChanged += new System.EventHandler(this.numericUpDownWithUnitBase_ValueChanged);
            // 
            // AnimationPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.numericUpDownGroup);
            this.Controls.Add(this.labelGroup);
            this.Controls.Add(this.numericUpDownWithUnitWait);
            this.Controls.Add(this.numericUpDownWithUnitOver);
            this.Controls.Add(this.numericUpDownWithUnitVariation);
            this.Controls.Add(this.numericUpDownWithUnitBase);
            this.Controls.Add(this.comboBoxAnimation);
            this.Controls.Add(this.checkBoxSynced);
            this.Controls.Add(this.labelWait);
            this.Controls.Add(this.labelOver);
            this.Controls.Add(this.labelAnimation);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Name = "AnimationPicker";
            this.Size = new System.Drawing.Size(354, 48);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWithUnitWait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWithUnitOver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWithUnitVariation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWithUnitBase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelOver;
        private System.Windows.Forms.CheckBox checkBoxSynced;
        private System.Windows.Forms.ComboBox comboBoxAnimation;
        private System.Windows.Forms.Label labelAnimation;
        private System.Windows.Forms.Label labelWait;
        private System.Windows.Forms.Label label2;
        private NumericUpDownWithUnit numericUpDownWithUnitBase;
        private NumericUpDownWithUnit numericUpDownWithUnitVariation;
        private NumericUpDownWithUnit numericUpDownWithUnitOver;
        private NumericUpDownWithUnit numericUpDownWithUnitWait;
        private System.Windows.Forms.Label labelGroup;
        private System.Windows.Forms.NumericUpDown numericUpDownGroup;
    }
}
