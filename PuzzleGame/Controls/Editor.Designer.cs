namespace PuzzleGame
{
    partial class Editor
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grid = new PuzzleGame.Grid2();
            this.backgroundEditor = new PuzzleGame.BackgroundEditor();
            this.rulesEditor = new PuzzleGame.RulesEditor();
            this.dotEditor = new PuzzleGame.DotEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPack = new System.Windows.Forms.Label();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.fileSelectorLevel = new PuzzleGame.FileSelector();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.grid, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.backgroundEditor, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.rulesEditor, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dotEditor, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(756, 508);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grid
            // 
            this.grid.BackgroundColor = System.Drawing.Color.Red;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(3, 3);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(523, 349);
            this.grid.TabIndex = 0;
            // 
            // backgroundEditor
            // 
            this.backgroundEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backgroundEditor.Grid = null;
            this.backgroundEditor.Location = new System.Drawing.Point(532, 3);
            this.backgroundEditor.Name = "backgroundEditor";
            this.backgroundEditor.Size = new System.Drawing.Size(221, 349);
            this.backgroundEditor.TabIndex = 1;
            // 
            // rulesEditor
            // 
            this.rulesEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rulesEditor.Grid = null;
            this.rulesEditor.Location = new System.Drawing.Point(3, 358);
            this.rulesEditor.Name = "rulesEditor";
            this.rulesEditor.Size = new System.Drawing.Size(523, 147);
            this.rulesEditor.TabIndex = 2;
            // 
            // dotEditor
            // 
            this.dotEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dotEditor.Grid = null;
            this.dotEditor.Location = new System.Drawing.Point(532, 358);
            this.dotEditor.Name = "dotEditor";
            this.dotEditor.Size = new System.Drawing.Size(221, 147);
            this.dotEditor.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Level";
            // 
            // labelPack
            // 
            this.labelPack.AutoSize = true;
            this.labelPack.Location = new System.Drawing.Point(13, 11);
            this.labelPack.Name = "labelPack";
            this.labelPack.Size = new System.Drawing.Size(32, 13);
            this.labelPack.TabIndex = 7;
            this.labelPack.Text = "Pack";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(83, 6);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 8;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // fileSelectorLevel
            // 
            this.fileSelectorLevel.File = null;
            this.fileSelectorLevel.Location = new System.Drawing.Point(203, 3);
            this.fileSelectorLevel.Name = "fileSelectorLevel";
            this.fileSelectorLevel.Path = null;
            this.fileSelectorLevel.Size = new System.Drawing.Size(207, 27);
            this.fileSelectorLevel.TabIndex = 9;
            this.fileSelectorLevel.FileSelected += new System.EventHandler(this.fileSelectorPack_FileSelected);
            this.fileSelectorLevel.FileToSave += new System.EventHandler(this.fileSelectorPack_FileToSave);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fileSelectorLevel);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.labelPack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Editor";
            this.Size = new System.Drawing.Size(756, 543);
            this.Load += new System.EventHandler(this.Editor_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Grid2 grid;
        private BackgroundEditor backgroundEditor;
        private RulesEditor rulesEditor;
        private DotEditor dotEditor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPack;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private FileSelector fileSelectorLevel;
    }
}
