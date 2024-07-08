namespace ShareNot.Tools.OCR
{
    partial class OCRForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCRForm));
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cbLanguages = new System.Windows.Forms.ComboBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lblScaleFactor = new System.Windows.Forms.Label();
            this.nudScaleFactor = new System.Windows.Forms.NumericUpDown();
            this.btnOpenOCRHelp = new System.Windows.Forms.Button();
            this.btnSelectRegion = new System.Windows.Forms.Button();
            this.cbSingleLine = new System.Windows.Forms.CheckBox();
            this.btnCopyAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudScaleFactor)).BeginInit();
            this.SuspendLayout();
            //
            // lblLanguage
            //
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.lblLanguage.Name = "lblLanguage";
            //
            // cbLanguages
            //
            this.cbLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbLanguages, "cbLanguages");
            this.cbLanguages.FormattingEnabled = true;
            this.cbLanguages.Name = "cbLanguages";
            this.cbLanguages.SelectedIndexChanged += new System.EventHandler(this.cbLanguages_SelectedIndexChanged);
            //
            // lblResult
            //
            resources.ApplyResources(this.lblResult, "lblResult");
            this.lblResult.Name = "lblResult";
            //
            // txtResult
            //
            resources.ApplyResources(this.txtResult, "txtResult");
            this.txtResult.Name = "txtResult";
            this.txtResult.TextChanged += new System.EventHandler(this.txtResult_TextChanged);
            //
            // lblScaleFactor
            //
            resources.ApplyResources(this.lblScaleFactor, "lblScaleFactor");
            this.lblScaleFactor.Name = "lblScaleFactor";
            //
            // nudScaleFactor
            //
            this.nudScaleFactor.DecimalPlaces = 1;
            resources.ApplyResources(this.nudScaleFactor, "nudScaleFactor");
            this.nudScaleFactor.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudScaleFactor.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudScaleFactor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudScaleFactor.Name = "nudScaleFactor";
            this.nudScaleFactor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudScaleFactor.ValueChanged += new System.EventHandler(this.nudScaleFactor_ValueChanged);
            //
            // btnOpenOCRHelp
            //
            resources.ApplyResources(this.btnOpenOCRHelp, "btnOpenOCRHelp");
            this.btnOpenOCRHelp.Image = global::ShareNot.Properties.Resources.question;
            this.btnOpenOCRHelp.Name = "btnOpenOCRHelp";
            this.btnOpenOCRHelp.UseVisualStyleBackColor = true;
            this.btnOpenOCRHelp.Click += new System.EventHandler(this.btnOpenOCRHelp_Click);
            //
            // btnSelectRegion
            //
            resources.ApplyResources(this.btnSelectRegion, "btnSelectRegion");
            this.btnSelectRegion.Name = "btnSelectRegion";
            this.btnSelectRegion.UseVisualStyleBackColor = true;
            this.btnSelectRegion.Click += new System.EventHandler(this.btnSelectRegion_Click);
            //
            // cbSingleLine
            //
            resources.ApplyResources(this.cbSingleLine, "cbSingleLine");
            this.cbSingleLine.Name = "cbSingleLine";
            this.cbSingleLine.UseVisualStyleBackColor = true;
            this.cbSingleLine.CheckedChanged += new System.EventHandler(this.cbSingleLine_CheckedChanged);
            //
            // btnCopyAll
            //
            resources.ApplyResources(this.btnCopyAll, "btnCopyAll");
            this.btnCopyAll.Name = "btnCopyAll";
            this.btnCopyAll.UseVisualStyleBackColor = true;
            this.btnCopyAll.Click += new System.EventHandler(this.btnCopyAll_Click);
            //
            // OCRForm
            //
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCopyAll);
            this.Controls.Add(this.cbSingleLine);
            this.Controls.Add(this.btnOpenOCRHelp);
            this.Controls.Add(this.btnSelectRegion);
            this.Controls.Add(this.nudScaleFactor);
            this.Controls.Add(this.lblScaleFactor);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.cbLanguages);
            this.Controls.Add(this.lblLanguage);
            this.Name = "OCRForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Shown += new System.EventHandler(this.OCRForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.nudScaleFactor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox cbLanguages;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label lblScaleFactor;
        private System.Windows.Forms.NumericUpDown nudScaleFactor;
        private System.Windows.Forms.Button btnOpenOCRHelp;
        private System.Windows.Forms.Button btnSelectRegion;
        private System.Windows.Forms.CheckBox cbSingleLine;
        private System.Windows.Forms.Button btnCopyAll;
    }
}