namespace Winrecall
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStartCapture = new System.Windows.Forms.Button();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.btnStopCapture = new System.Windows.Forms.Button();
            this.btnClearSession = new System.Windows.Forms.Button();
            this.lblTimestamp = new System.Windows.Forms.Label();
            this.trackBarHistory = new System.Windows.Forms.TrackBar();
            this.comboBoxSizeMode = new System.Windows.Forms.ComboBox();
            this.lblResults = new System.Windows.Forms.Label();
            this.linkGitHub = new System.Windows.Forms.LinkLabel();
            this.textLog = new System.Windows.Forms.TextBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.linkSettings = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.linkOpenScreenshotsFolder = new System.Windows.Forms.LinkLabel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.flowLayoutPanelResults = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelRight = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHistory)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartCapture
            // 
            this.btnStartCapture.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStartCapture.AutoEllipsis = true;
            this.btnStartCapture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(187)))));
            this.btnStartCapture.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnStartCapture.ForeColor = System.Drawing.Color.White;
            this.btnStartCapture.Location = new System.Drawing.Point(467, 27);
            this.btnStartCapture.Name = "btnStartCapture";
            this.btnStartCapture.Size = new System.Drawing.Size(118, 32);
            this.btnStartCapture.TabIndex = 1;
            this.btnStartCapture.Text = "Capture";
            this.btnStartCapture.UseVisualStyleBackColor = false;
            this.btnStartCapture.Click += new System.EventHandler(this.btnStartCapture_Click);
            // 
            // textSearch
            // 
            this.textSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textSearch.Font = new System.Drawing.Font("Segoe UI Variable Text", 10.75F);
            this.textSearch.ForeColor = System.Drawing.Color.DimGray;
            this.textSearch.Location = new System.Drawing.Point(137, 30);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(284, 27);
            this.textSearch.TabIndex = 2;
            this.textSearch.Text = "Type here to search your history";
            this.textSearch.Click += new System.EventHandler(this.textSearch_Click);
            this.textSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxResult.Location = new System.Drawing.Point(46, 201);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(555, 411);
            this.pictureBoxResult.TabIndex = 4;
            this.pictureBoxResult.TabStop = false;
            this.tt.SetToolTip(this.pictureBoxResult, "Click to view in Windows Photo Viewer");
            this.pictureBoxResult.Click += new System.EventHandler(this.pictureBoxResult_Click);
            // 
            // btnStopCapture
            // 
            this.btnStopCapture.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStopCapture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.btnStopCapture.Enabled = false;
            this.btnStopCapture.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F);
            this.btnStopCapture.Location = new System.Drawing.Point(427, 27);
            this.btnStopCapture.Name = "btnStopCapture";
            this.btnStopCapture.Size = new System.Drawing.Size(34, 32);
            this.btnStopCapture.TabIndex = 5;
            this.btnStopCapture.Text = "...";
            this.btnStopCapture.UseVisualStyleBackColor = false;
            this.btnStopCapture.Click += new System.EventHandler(this.btnStopCapture_Click);
            // 
            // btnClearSession
            // 
            this.btnClearSession.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(187)))));
            this.btnClearSession.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClearSession.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 9F);
            this.btnClearSession.ForeColor = System.Drawing.Color.White;
            this.btnClearSession.Location = new System.Drawing.Point(19, 54);
            this.btnClearSession.Name = "btnClearSession";
            this.btnClearSession.Size = new System.Drawing.Size(128, 27);
            this.btnClearSession.TabIndex = 6;
            this.btnClearSession.Text = "Clear current session";
            this.tt.SetToolTip(this.btnClearSession, "A Panic Button that instantly wipes all captured snapshots");
            this.btnClearSession.UseVisualStyleBackColor = false;
            this.btnClearSession.Click += new System.EventHandler(this.btnClearSession_Click);
            // 
            // lblTimestamp
            // 
            this.lblTimestamp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimestamp.AutoEllipsis = true;
            this.lblTimestamp.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimestamp.Location = new System.Drawing.Point(6, 130);
            this.lblTimestamp.Name = "lblTimestamp";
            this.lblTimestamp.Size = new System.Drawing.Size(595, 26);
            this.lblTimestamp.TabIndex = 7;
            this.lblTimestamp.Text = "Timeline";
            this.lblTimestamp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBarHistory
            // 
            this.trackBarHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(239)))), ((int)(((byte)(248)))));
            this.trackBarHistory.Location = new System.Drawing.Point(46, 90);
            this.trackBarHistory.Name = "trackBarHistory";
            this.trackBarHistory.Size = new System.Drawing.Size(541, 45);
            this.trackBarHistory.TabIndex = 8;
            this.trackBarHistory.Scroll += new System.EventHandler(this.trackBarHistory_Scroll);
            // 
            // comboBoxSizeMode
            // 
            this.comboBoxSizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSizeMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxSizeMode.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSizeMode.FormattingEnabled = true;
            this.comboBoxSizeMode.Location = new System.Drawing.Point(138, 170);
            this.comboBoxSizeMode.Name = "comboBoxSizeMode";
            this.comboBoxSizeMode.Size = new System.Drawing.Size(121, 23);
            this.comboBoxSizeMode.TabIndex = 9;
            this.tt.SetToolTip(this.comboBoxSizeMode, "Change Images Sizemode");
            this.comboBoxSizeMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxSizeMode_SelectedIndexChanged);
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResults.Location = new System.Drawing.Point(14, 13);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(80, 28);
            this.lblResults.TabIndex = 10;
            this.lblResults.Text = "Results";
            // 
            // linkGitHub
            // 
            this.linkGitHub.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.linkGitHub.AutoEllipsis = true;
            this.linkGitHub.BackColor = System.Drawing.Color.Transparent;
            this.linkGitHub.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkGitHub.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkGitHub.LinkColor = System.Drawing.Color.PaleVioletRed;
            this.linkGitHub.Location = new System.Drawing.Point(360, 51);
            this.linkGitHub.Name = "linkGitHub";
            this.linkGitHub.Size = new System.Drawing.Size(139, 16);
            this.linkGitHub.TabIndex = 11;
            this.linkGitHub.TabStop = true;
            this.linkGitHub.Text = "A Belim app creation";
            this.tt.SetToolTip(this.linkGitHub, "We live on GitHub");
            this.linkGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGitHub_LinkClicked);
            // 
            // textLog
            // 
            this.textLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(249)))));
            this.textLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textLog.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 9.25F);
            this.textLog.Location = new System.Drawing.Point(15, 3);
            this.textLog.Multiline = true;
            this.textLog.Name = "textLog";
            this.textLog.ReadOnly = true;
            this.textLog.Size = new System.Drawing.Size(831, 39);
            this.textLog.TabIndex = 12;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(238)))), ((int)(((byte)(250)))));
            this.panelBottom.Controls.Add(this.textLog);
            this.panelBottom.Controls.Add(this.linkSettings);
            this.panelBottom.Controls.Add(this.linkGitHub);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 534);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(858, 76);
            this.panelBottom.TabIndex = 14;
            // 
            // linkSettings
            // 
            this.linkSettings.ActiveLinkColor = System.Drawing.Color.DeepPink;
            this.linkSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkSettings.AutoEllipsis = true;
            this.linkSettings.BackColor = System.Drawing.Color.Transparent;
            this.linkSettings.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 9.25F);
            this.linkSettings.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkSettings.LinkColor = System.Drawing.Color.Black;
            this.linkSettings.Location = new System.Drawing.Point(12, 52);
            this.linkSettings.Name = "linkSettings";
            this.linkSettings.Size = new System.Drawing.Size(120, 18);
            this.linkSettings.TabIndex = 17;
            this.linkSettings.TabStop = true;
            this.linkSettings.Text = "More Recall settings";
            this.tt.SetToolTip(this.linkSettings, "We live on GitHub");
            this.linkSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSettings_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(43, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Visual matches";
            // 
            // tt
            // 
            this.tt.IsBalloon = true;
            // 
            // linkOpenScreenshotsFolder
            // 
            this.linkOpenScreenshotsFolder.AutoEllipsis = true;
            this.linkOpenScreenshotsFolder.BackColor = System.Drawing.Color.Transparent;
            this.linkOpenScreenshotsFolder.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkOpenScreenshotsFolder.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkOpenScreenshotsFolder.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(107)))), ((int)(((byte)(160)))));
            this.linkOpenScreenshotsFolder.Location = new System.Drawing.Point(26, 84);
            this.linkOpenScreenshotsFolder.Name = "linkOpenScreenshotsFolder";
            this.linkOpenScreenshotsFolder.Size = new System.Drawing.Size(139, 16);
            this.linkOpenScreenshotsFolder.TabIndex = 16;
            this.linkOpenScreenshotsFolder.TabStop = true;
            this.linkOpenScreenshotsFolder.Text = "View results in Explorer";
            this.tt.SetToolTip(this.linkOpenScreenshotsFolder, "We live on GitHub");
            this.linkOpenScreenshotsFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOpenScreenshotsFolder_LinkClicked);
            // 
            // panelLeft
            // 
            this.panelLeft.AutoScroll = true;
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(249)))));
            this.panelLeft.Controls.Add(this.label3);
            this.panelLeft.Controls.Add(this.panelTop);
            this.panelLeft.Controls.Add(this.comboBoxSizeMode);
            this.panelLeft.Controls.Add(this.pictureBoxResult);
            this.panelLeft.Controls.Add(this.trackBarHistory);
            this.panelLeft.Controls.Add(this.lblTimestamp);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(615, 534);
            this.panelLeft.TabIndex = 16;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panelTop.Controls.Add(this.textSearch);
            this.panelTop.Controls.Add(this.btnStopCapture);
            this.panelTop.Controls.Add(this.btnStartCapture);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(615, 81);
            this.panelTop.TabIndex = 17;
            // 
            // flowLayoutPanelResults
            // 
            this.flowLayoutPanelResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelResults.AutoScroll = true;
            this.flowLayoutPanelResults.Location = new System.Drawing.Point(9, 110);
            this.flowLayoutPanelResults.Name = "flowLayoutPanelResults";
            this.flowLayoutPanelResults.Size = new System.Drawing.Size(214, 502);
            this.flowLayoutPanelResults.TabIndex = 17;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelLeft);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(249)))));
            this.splitContainer1.Panel2.Controls.Add(this.panelRight);
            this.splitContainer1.Size = new System.Drawing.Size(858, 534);
            this.splitContainer1.SplitterDistance = 615;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 18;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panelRight.Controls.Add(this.linkOpenScreenshotsFolder);
            this.panelRight.Controls.Add(this.flowLayoutPanelResults);
            this.panelRight.Controls.Add(this.lblResults);
            this.panelRight.Controls.Add(this.btnClearSession);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(0, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(233, 534);
            this.panelRight.TabIndex = 18;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(858, 610);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelBottom);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Winrecall (preview)";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHistory)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnStartCapture;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.PictureBox pictureBoxResult;
        private System.Windows.Forms.Button btnStopCapture;
        private System.Windows.Forms.Button btnClearSession;
        private System.Windows.Forms.Label lblTimestamp;
        private System.Windows.Forms.TrackBar trackBarHistory;
        private System.Windows.Forms.ComboBox comboBoxSizeMode;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.LinkLabel linkGitHub;
        private System.Windows.Forms.TextBox textLog;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip tt;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.LinkLabel linkOpenScreenshotsFolder;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelResults;
        private System.Windows.Forms.LinkLabel linkSettings;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelRight;
    }
}

