namespace Euclid
{
    partial class ConfigWnd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigWnd));
            this.gbColorsAndThicknesses = new System.Windows.Forms.GroupBox();
            this.btnPointsColor = new System.Windows.Forms.Button();
            this.nupPointsWidth = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnArcColor = new System.Windows.Forms.Button();
            this.nupArcWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLineColor = new System.Windows.Forms.Button();
            this.nupLineWidth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.gbFonts = new System.Windows.Forms.GroupBox();
            this.btnPLFont = new System.Windows.Forms.Button();
            this.btnCCFont = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbAnimation = new System.Windows.Forms.GroupBox();
            this.cbAnimated = new System.Windows.Forms.CheckBox();
            this.nupDelay = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbColorsAndThicknesses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupPointsWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupArcWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupLineWidth)).BeginInit();
            this.gbFonts.SuspendLayout();
            this.gbAnimation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // gbColorsAndThicknesses
            // 
            this.gbColorsAndThicknesses.Controls.Add(this.btnPointsColor);
            this.gbColorsAndThicknesses.Controls.Add(this.nupPointsWidth);
            this.gbColorsAndThicknesses.Controls.Add(this.label3);
            this.gbColorsAndThicknesses.Controls.Add(this.btnArcColor);
            this.gbColorsAndThicknesses.Controls.Add(this.nupArcWidth);
            this.gbColorsAndThicknesses.Controls.Add(this.label2);
            this.gbColorsAndThicknesses.Controls.Add(this.btnLineColor);
            this.gbColorsAndThicknesses.Controls.Add(this.nupLineWidth);
            this.gbColorsAndThicknesses.Controls.Add(this.label1);
            this.gbColorsAndThicknesses.Location = new System.Drawing.Point(176, 73);
            this.gbColorsAndThicknesses.Name = "gbColorsAndThicknesses";
            this.gbColorsAndThicknesses.Size = new System.Drawing.Size(158, 112);
            this.gbColorsAndThicknesses.TabIndex = 0;
            this.gbColorsAndThicknesses.TabStop = false;
            this.gbColorsAndThicknesses.Text = "Colors and thicknesses";
            // 
            // btnPointsColor
            // 
            this.btnPointsColor.BackColor = System.Drawing.Color.Black;
            this.btnPointsColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPointsColor.Location = new System.Drawing.Point(46, 74);
            this.btnPointsColor.Name = "btnPointsColor";
            this.btnPointsColor.Size = new System.Drawing.Size(55, 21);
            this.btnPointsColor.TabIndex = 8;
            this.btnPointsColor.UseVisualStyleBackColor = false;
            this.btnPointsColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // nupPointsWidth
            // 
            this.nupPointsWidth.Location = new System.Drawing.Point(107, 74);
            this.nupPointsWidth.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nupPointsWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupPointsWidth.Name = "nupPointsWidth";
            this.nupPointsWidth.Size = new System.Drawing.Size(41, 20);
            this.nupPointsWidth.TabIndex = 7;
            this.nupPointsWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Points";
            // 
            // btnArcColor
            // 
            this.btnArcColor.BackColor = System.Drawing.Color.Black;
            this.btnArcColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArcColor.Location = new System.Drawing.Point(46, 46);
            this.btnArcColor.Name = "btnArcColor";
            this.btnArcColor.Size = new System.Drawing.Size(55, 21);
            this.btnArcColor.TabIndex = 5;
            this.btnArcColor.UseVisualStyleBackColor = false;
            this.btnArcColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // nupArcWidth
            // 
            this.nupArcWidth.Location = new System.Drawing.Point(107, 46);
            this.nupArcWidth.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nupArcWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupArcWidth.Name = "nupArcWidth";
            this.nupArcWidth.Size = new System.Drawing.Size(41, 20);
            this.nupArcWidth.TabIndex = 4;
            this.nupArcWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Arcs";
            // 
            // btnLineColor
            // 
            this.btnLineColor.BackColor = System.Drawing.Color.Black;
            this.btnLineColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLineColor.Location = new System.Drawing.Point(46, 19);
            this.btnLineColor.Name = "btnLineColor";
            this.btnLineColor.Size = new System.Drawing.Size(55, 21);
            this.btnLineColor.TabIndex = 2;
            this.btnLineColor.UseVisualStyleBackColor = false;
            this.btnLineColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // nupLineWidth
            // 
            this.nupLineWidth.Location = new System.Drawing.Point(107, 19);
            this.nupLineWidth.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nupLineWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupLineWidth.Name = "nupLineWidth";
            this.nupLineWidth.Size = new System.Drawing.Size(41, 20);
            this.nupLineWidth.TabIndex = 1;
            this.nupLineWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lines";
            // 
            // fontDialog
            // 
            this.fontDialog.AllowScriptChange = false;
            this.fontDialog.FontMustExist = true;
            this.fontDialog.ShowColor = true;
            // 
            // gbFonts
            // 
            this.gbFonts.Controls.Add(this.btnPLFont);
            this.gbFonts.Controls.Add(this.btnCCFont);
            this.gbFonts.Location = new System.Drawing.Point(12, 73);
            this.gbFonts.Name = "gbFonts";
            this.gbFonts.Size = new System.Drawing.Size(158, 112);
            this.gbFonts.TabIndex = 1;
            this.gbFonts.TabStop = false;
            this.gbFonts.Text = "Fonts";
            // 
            // btnPLFont
            // 
            this.btnPLFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPLFont.Location = new System.Drawing.Point(11, 64);
            this.btnPLFont.Name = "btnPLFont";
            this.btnPLFont.Size = new System.Drawing.Size(137, 41);
            this.btnPLFont.TabIndex = 1;
            this.btnPLFont.Text = "Point labels";
            this.btnPLFont.UseVisualStyleBackColor = true;
            this.btnPLFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // btnCCFont
            // 
            this.btnCCFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCCFont.Location = new System.Drawing.Point(11, 19);
            this.btnCCFont.Name = "btnCCFont";
            this.btnCCFont.Size = new System.Drawing.Size(137, 41);
            this.btnCCFont.TabIndex = 0;
            this.btnCCFont.Text = "Comments";
            this.btnCCFont.UseVisualStyleBackColor = true;
            this.btnCCFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOK.Location = new System.Drawing.Point(244, 11);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 25);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gbAnimation
            // 
            this.gbAnimation.Controls.Add(this.cbAnimated);
            this.gbAnimation.Controls.Add(this.nupDelay);
            this.gbAnimation.Controls.Add(this.label4);
            this.gbAnimation.Location = new System.Drawing.Point(12, 4);
            this.gbAnimation.Name = "gbAnimation";
            this.gbAnimation.Size = new System.Drawing.Size(226, 62);
            this.gbAnimation.TabIndex = 3;
            this.gbAnimation.TabStop = false;
            this.gbAnimation.Text = "Animation";
            // 
            // cbAnimated
            // 
            this.cbAnimated.AutoSize = true;
            this.cbAnimated.Checked = true;
            this.cbAnimated.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAnimated.Location = new System.Drawing.Point(11, 39);
            this.cbAnimated.Name = "cbAnimated";
            this.cbAnimated.Size = new System.Drawing.Size(166, 17);
            this.cbAnimated.TabIndex = 2;
            this.cbAnimated.Text = "Animated drawing of curves...";
            this.cbAnimated.UseVisualStyleBackColor = true;
            // 
            // nupDelay
            // 
            this.nupDelay.Location = new System.Drawing.Point(132, 16);
            this.nupDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nupDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupDelay.Name = "nupDelay";
            this.nupDelay.Size = new System.Drawing.Size(88, 20);
            this.nupDelay.TabIndex = 1;
            this.nupDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Animation delay (msec):";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCancel.Location = new System.Drawing.Point(244, 43);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ConfigWnd
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(343, 189);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbAnimation);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbFonts);
            this.Controls.Add(this.gbColorsAndThicknesses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigWnd";
            this.Opacity = 0.93;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration ...";
            this.Load += new System.EventHandler(this.ConfigWnd_Load);
            this.gbColorsAndThicknesses.ResumeLayout(false);
            this.gbColorsAndThicknesses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupPointsWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupArcWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupLineWidth)).EndInit();
            this.gbFonts.ResumeLayout(false);
            this.gbAnimation.ResumeLayout(false);
            this.gbAnimation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupDelay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbColorsAndThicknesses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nupLineWidth;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button btnLineColor;
        private System.Windows.Forms.Button btnArcColor;
        private System.Windows.Forms.NumericUpDown nupArcWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPointsColor;
        private System.Windows.Forms.NumericUpDown nupPointsWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.GroupBox gbFonts;
        private System.Windows.Forms.Button btnCCFont;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox gbAnimation;
        private System.Windows.Forms.Button btnPLFont;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nupDelay;
        private System.Windows.Forms.CheckBox cbAnimated;
    }
}