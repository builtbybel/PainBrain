namespace Winrecall
{
    partial class SettingsForm
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
            this.components = new System.ComponentModel.Container();
            this.btnAiAndOcr = new System.Windows.Forms.Button();
            this.btnOcrOnly = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSetUserKey = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.textUserKey = new System.Windows.Forms.TextBox();
            this.btnIsEnvironmentReady = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.linkEnvironmentCheck = new System.Windows.Forms.LinkLabel();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAiAndOcr
            // 
            this.btnAiAndOcr.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAiAndOcr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(166)))), ((int)(((byte)(188)))));
            this.btnAiAndOcr.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAiAndOcr.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 11F);
            this.btnAiAndOcr.Location = new System.Drawing.Point(122, 324);
            this.btnAiAndOcr.Name = "btnAiAndOcr";
            this.btnAiAndOcr.Size = new System.Drawing.Size(165, 36);
            this.btnAiAndOcr.TabIndex = 0;
            this.btnAiAndOcr.TabStop = false;
            this.btnAiAndOcr.Text = "AI + OCR";
            this.tt.SetToolTip(this.btnAiAndOcr, "BLIP + Tesseract: Combines Hugging Face AI for image description with Tesseract O" +
        "CR for text extraction.");
            this.btnAiAndOcr.UseVisualStyleBackColor = false;
            this.btnAiAndOcr.Click += new System.EventHandler(this.btnAiAndOcr_Click);
            // 
            // btnOcrOnly
            // 
            this.btnOcrOnly.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOcrOnly.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOcrOnly.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 11F);
            this.btnOcrOnly.Location = new System.Drawing.Point(293, 324);
            this.btnOcrOnly.Name = "btnOcrOnly";
            this.btnOcrOnly.Size = new System.Drawing.Size(165, 36);
            this.btnOcrOnly.TabIndex = 1;
            this.btnOcrOnly.TabStop = false;
            this.btnOcrOnly.Text = "OCR Only";
            this.tt.SetToolTip(this.btnOcrOnly, "Tesseract OCR: Extracts text from images using classic optical character recognit" +
        "ion.");
            this.btnOcrOnly.UseVisualStyleBackColor = true;
            this.btnOcrOnly.Click += new System.EventHandler(this.btnOcrOnly_Click);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(239)))), ((int)(((byte)(248)))));
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.btnSetUserKey);
            this.panelTop.Controls.Add(this.lblDescription);
            this.panelTop.Controls.Add(this.textUserKey);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(574, 251);
            this.panelTop.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 8.25F);
            this.label2.Location = new System.Drawing.Point(10, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(561, 33);
            this.label2.TabIndex = 21;
            this.label2.Text = "Create an encryption key to log in and access your data. Note: The key is valid o" +
    "nly as long as the database exists. \r\nKeep it safe! 🔑";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSetUserKey
            // 
            this.btnSetUserKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetUserKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(121)))), ((int)(((byte)(145)))));
            this.btnSetUserKey.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSetUserKey.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 8.75F);
            this.btnSetUserKey.Location = new System.Drawing.Point(252, 152);
            this.btnSetUserKey.Name = "btnSetUserKey";
            this.btnSetUserKey.Size = new System.Drawing.Size(77, 29);
            this.btnSetUserKey.TabIndex = 20;
            this.btnSetUserKey.TabStop = false;
            this.btnSetUserKey.Text = "Sign in";
            this.btnSetUserKey.UseVisualStyleBackColor = false;
            this.btnSetUserKey.Click += new System.EventHandler(this.btnSetUserKey_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 16.75F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(6, 24);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(556, 50);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Set encryption key and Sign in";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textUserKey
            // 
            this.textUserKey.Font = new System.Drawing.Font("Segoe UI Variable Text", 10.75F);
            this.textUserKey.Location = new System.Drawing.Point(212, 121);
            this.textUserKey.Name = "textUserKey";
            this.textUserKey.Size = new System.Drawing.Size(161, 27);
            this.textUserKey.TabIndex = 18;
            this.textUserKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnIsEnvironmentReady
            // 
            this.btnIsEnvironmentReady.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIsEnvironmentReady.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(121)))), ((int)(((byte)(145)))));
            this.btnIsEnvironmentReady.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnIsEnvironmentReady.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 8.75F);
            this.btnIsEnvironmentReady.Location = new System.Drawing.Point(384, 475);
            this.btnIsEnvironmentReady.Name = "btnIsEnvironmentReady";
            this.btnIsEnvironmentReady.Size = new System.Drawing.Size(134, 25);
            this.btnIsEnvironmentReady.TabIndex = 14;
            this.btnIsEnvironmentReady.TabStop = false;
            this.btnIsEnvironmentReady.Text = "Setup Environment";
            this.btnIsEnvironmentReady.UseVisualStyleBackColor = false;
            this.btnIsEnvironmentReady.Click += new System.EventHandler(this.btnIsEnvironmentReady_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 9.25F);
            this.label3.Location = new System.Drawing.Point(-3, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(579, 21);
            this.label3.TabIndex = 17;
            this.label3.Text = "Choose Your Capture Mode\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tt
            // 
            this.tt.IsBalloon = true;
            // 
            // linkEnvironmentCheck
            // 
            this.linkEnvironmentCheck.AutoSize = true;
            this.linkEnvironmentCheck.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 8.25F);
            this.linkEnvironmentCheck.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkEnvironmentCheck.LinkColor = System.Drawing.Color.Black;
            this.linkEnvironmentCheck.Location = new System.Drawing.Point(35, 482);
            this.linkEnvironmentCheck.Name = "linkEnvironmentCheck";
            this.linkEnvironmentCheck.Size = new System.Drawing.Size(293, 15);
            this.linkEnvironmentCheck.TabIndex = 18;
            this.linkEnvironmentCheck.TabStop = true;
            this.linkEnvironmentCheck.Text = "If you\'re new here, check if your environment is ready to start";
            this.linkEnvironmentCheck.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEnvironmentCheck_LinkClicked);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(574, 506);
            this.Controls.Add(this.linkEnvironmentCheck);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.btnOcrOnly);
            this.Controls.Add(this.btnIsEnvironmentReady);
            this.Controls.Add(this.btnAiAndOcr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings 0.25.80";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAiAndOcr;
        private System.Windows.Forms.Button btnOcrOnly;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnIsEnvironmentReady;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textUserKey;
        private System.Windows.Forms.Button btnSetUserKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip tt;
        private System.Windows.Forms.LinkLabel linkEnvironmentCheck;
    }
}