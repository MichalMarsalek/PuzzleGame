namespace PuzzleGame
{
    partial class BackgroundEditor
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
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.baseLayerEditor = new PuzzleGame.BaseLayerEditor();
            this.buttonDeleteLayer = new System.Windows.Forms.Button();
            this.buttonNewLayer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FileSelector = new PuzzleGame.FileSelector();
            this.flowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Controls.Add(this.baseLayerEditor);
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 33);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(516, 237);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // baseLayerEditor
            // 
            this.baseLayerEditor.AutoSize = true;
            this.baseLayerEditor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.baseLayerEditor.Location = new System.Drawing.Point(3, 3);
            this.baseLayerEditor.Name = "baseLayerEditor";
            this.baseLayerEditor.Size = new System.Drawing.Size(428, 90);
            this.baseLayerEditor.TabIndex = 0;
            // 
            // buttonDeleteLayer
            // 
            this.buttonDeleteLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDeleteLayer.Location = new System.Drawing.Point(84, 275);
            this.buttonDeleteLayer.Name = "buttonDeleteLayer";
            this.buttonDeleteLayer.Size = new System.Drawing.Size(93, 23);
            this.buttonDeleteLayer.TabIndex = 2;
            this.buttonDeleteLayer.Text = "Delete last layer";
            this.buttonDeleteLayer.UseVisualStyleBackColor = true;
            this.buttonDeleteLayer.Click += new System.EventHandler(this.buttonDeleteLayer_Click);
            // 
            // buttonNewLayer
            // 
            this.buttonNewLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonNewLayer.Location = new System.Drawing.Point(3, 275);
            this.buttonNewLayer.Name = "buttonNewLayer";
            this.buttonNewLayer.Size = new System.Drawing.Size(75, 23);
            this.buttonNewLayer.TabIndex = 1;
            this.buttonNewLayer.Text = "New layer";
            this.buttonNewLayer.UseVisualStyleBackColor = true;
            this.buttonNewLayer.Click += new System.EventHandler(this.buttonNewLayer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Background";
            // 
            // fileSelector
            // 
            this.FileSelector.Location = new System.Drawing.Point(74, 3);
            this.FileSelector.Name = "fileSelector";
            this.FileSelector.Path = null;
            this.FileSelector.Size = new System.Drawing.Size(207, 27);
            this.FileSelector.TabIndex = 10;
            // 
            // BackgroundEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FileSelector);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDeleteLayer);
            this.Controls.Add(this.buttonNewLayer);
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "BackgroundEditor";
            this.Size = new System.Drawing.Size(516, 301);
            this.flowLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button buttonDeleteLayer;
        private System.Windows.Forms.Button buttonNewLayer;
        private BaseLayerEditor baseLayerEditor;
        private System.Windows.Forms.Label label1;
        public FileSelector FileSelector;
    }
}
