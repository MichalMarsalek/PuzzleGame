namespace PuzzleGame
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxFiles = new System.Windows.Forms.ComboBox();
            this.richTextBoxGridSetup = new System.Windows.Forms.RichTextBox();
            this.richTextBoxRules = new System.Windows.Forms.RichTextBox();
            this.richTextBoxDebug = new System.Windows.Forms.RichTextBox();
            this.buttonFormat = new System.Windows.Forms.Button();
            this.grid = new PuzzleGame.Grid2();
            this.backgroundLayerEditor = new PuzzleGame.BackgroundEditor();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(970, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Setup";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(970, 323);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rules";
            // 
            // comboBoxFiles
            // 
            this.comboBoxFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxFiles.FormattingEnabled = true;
            this.comboBoxFiles.Location = new System.Drawing.Point(1055, 5);
            this.comboBoxFiles.Name = "comboBoxFiles";
            this.comboBoxFiles.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFiles.TabIndex = 3;
            this.comboBoxFiles.SelectedIndexChanged += new System.EventHandler(this.comboBoxFiles_SelectedIndexChanged);
            // 
            // richTextBoxGridSetup
            // 
            this.richTextBoxGridSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxGridSetup.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBoxGridSetup.Location = new System.Drawing.Point(600, 42);
            this.richTextBoxGridSetup.Name = "richTextBoxGridSetup";
            this.richTextBoxGridSetup.Size = new System.Drawing.Size(576, 264);
            this.richTextBoxGridSetup.TabIndex = 4;
            this.richTextBoxGridSetup.Text = "";
            // 
            // richTextBoxRules
            // 
            this.richTextBoxRules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxRules.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBoxRules.Location = new System.Drawing.Point(600, 340);
            this.richTextBoxRules.Name = "richTextBoxRules";
            this.richTextBoxRules.Size = new System.Drawing.Size(576, 182);
            this.richTextBoxRules.TabIndex = 5;
            this.richTextBoxRules.Text = "";
            this.richTextBoxRules.TextChanged += new System.EventHandler(this.richTextBoxRules_TextChanged);
            // 
            // richTextBoxDebug
            // 
            this.richTextBoxDebug.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxDebug.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBoxDebug.Location = new System.Drawing.Point(600, 540);
            this.richTextBoxDebug.Name = "richTextBoxDebug";
            this.richTextBoxDebug.Size = new System.Drawing.Size(576, 68);
            this.richTextBoxDebug.TabIndex = 5;
            this.richTextBoxDebug.Text = "";
            // 
            // buttonFormat
            // 
            this.buttonFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFormat.Location = new System.Drawing.Point(601, 313);
            this.buttonFormat.Name = "buttonFormat";
            this.buttonFormat.Size = new System.Drawing.Size(75, 23);
            this.buttonFormat.TabIndex = 6;
            this.buttonFormat.Text = "Format";
            this.buttonFormat.UseVisualStyleBackColor = true;
            this.buttonFormat.Click += new System.EventHandler(this.buttonFormat_Click);
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.BackColor = System.Drawing.Color.White;
            this.grid.BackgroundColor = System.Drawing.Color.Red;
            this.grid.Location = new System.Drawing.Point(1, -1);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(593, 621);
            this.grid.TabIndex = 0;
            this.grid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grid_MouseMove_1);
            this.grid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grid_MouseUp);
            // 
            // backgroundLayerEditor
            // 
            this.backgroundLayerEditor.Location = new System.Drawing.Point(631, 126);
            this.backgroundLayerEditor.Name = "backgroundLayerEditor";
            this.backgroundLayerEditor.Size = new System.Drawing.Size(513, 301);
            this.backgroundLayerEditor.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 620);
            this.Controls.Add(this.backgroundLayerEditor);
            this.Controls.Add(this.buttonFormat);
            this.Controls.Add(this.richTextBoxDebug);
            this.Controls.Add(this.richTextBoxRules);
            this.Controls.Add(this.richTextBoxGridSetup);
            this.Controls.Add(this.comboBoxFiles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grid);
            this.Name = "Form1";
            this.Text = "Puzzle game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Grid2 grid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxFiles;
        private System.Windows.Forms.RichTextBox richTextBoxGridSetup;
        private System.Windows.Forms.RichTextBox richTextBoxRules;
        private System.Windows.Forms.RichTextBox richTextBoxDebug;
        private System.Windows.Forms.Button buttonFormat;
        private BackgroundEditor backgroundLayerEditor;
    }
}

