﻿namespace PuzzleGame
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
            this.editor1 = new PuzzleGame.Editor();
            this.SuspendLayout();
            // 
            // editor1
            // 
            this.editor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor1.Location = new System.Drawing.Point(0, 0);
            this.editor1.Name = "editor1";
            this.editor1.Path = "C:\\Users\\Michal\\Documents\\Puzzle game packs\\Pack 1";
            this.editor1.Size = new System.Drawing.Size(1188, 620);
            this.editor1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 620);
            this.Controls.Add(this.editor1);
            this.Name = "Form1";
            this.Text = "Puzzle game";
            this.ResumeLayout(false);

        }

        #endregion

        private Editor editor1;
    }
}

