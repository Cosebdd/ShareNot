﻿namespace ShareNot.Forms
{
    partial class FirstTimeConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstTimeConfigForm));
            this.cbRunStartup = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // cbRunStartup
            //
            resources.ApplyResources(this.cbRunStartup, "cbRunStartup");
            this.cbRunStartup.Name = "cbRunStartup";
            this.cbRunStartup.UseVisualStyleBackColor = false;
            this.cbRunStartup.CheckedChanged += new System.EventHandler(this.cbRunStartup_CheckedChanged);
            //
            // btnOK
            //
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnOK_MouseClick);
            //
            // lblNote
            //
            resources.ApplyResources(this.lblNote, "lblNote");
            this.lblNote.Name = "lblNote";
            //
            // lblTitle
            //
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Name = "lblTitle";
            //
            // FirstTimeConfigForm
            //
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbRunStartup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FirstTimeConfigForm";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbRunStartup;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Label lblTitle;
    }
}