namespace PuzzleGame
{
    partial class RulesEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonFormat = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.richTextBoxRules = new System.Windows.Forms.RichTextBox();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.FileSelector = new PuzzleGame.FileSelector();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Rules";
            // 
            // buttonFormat
            // 
            this.buttonFormat.Location = new System.Drawing.Point(271, 3);
            this.buttonFormat.Name = "buttonFormat";
            this.buttonFormat.Size = new System.Drawing.Size(75, 23);
            this.buttonFormat.TabIndex = 8;
            this.buttonFormat.Text = "Format";
            this.buttonFormat.UseVisualStyleBackColor = true;
            this.buttonFormat.Click += new System.EventHandler(this.buttonFormat_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(7, 31);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.richTextBoxRules);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.textBoxOutput);
            this.splitContainer.Size = new System.Drawing.Size(605, 355);
            this.splitContainer.SplitterDistance = 290;
            this.splitContainer.TabIndex = 9;
            // 
            // richTextBoxRules
            // 
            this.richTextBoxRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxRules.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxRules.Name = "richTextBoxRules";
            this.richTextBoxRules.Size = new System.Drawing.Size(605, 290);
            this.richTextBoxRules.TabIndex = 0;
            this.richTextBoxRules.Text = "";
            this.richTextBoxRules.TextChanged += new System.EventHandler(this.richTextBoxRules_TextChanged);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxOutput.Location = new System.Drawing.Point(0, 0);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ReadOnly = true;
            this.textBoxOutput.Size = new System.Drawing.Size(605, 61);
            this.textBoxOutput.TabIndex = 0;
            // 
            // FileSelector
            // 
            this.FileSelector.File = null;
            this.FileSelector.Location = new System.Drawing.Point(58, 2);
            this.FileSelector.Name = "FileSelector";
            this.FileSelector.Path = null;
            this.FileSelector.Size = new System.Drawing.Size(207, 27);
            this.FileSelector.TabIndex = 10;
            this.FileSelector.FileSelected += new System.EventHandler(this.fileSelector_FileSelected);
            this.FileSelector.FileToSave += new System.EventHandler(this.fileSelector_FileToSave);
            // 
            // RulesEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FileSelector);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.buttonFormat);
            this.Controls.Add(this.label1);
            this.Name = "RulesEditor";
            this.Size = new System.Drawing.Size(615, 389);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonFormat;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.RichTextBox richTextBoxRules;
        private System.Windows.Forms.TextBox textBoxOutput;
        public FileSelector FileSelector;
    }
}
