
namespace VoiceImporter {
    partial class VoicesManagerForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.AvailableVoicesCheckList = new System.Windows.Forms.CheckedListBox();
            this.InstallSelection = new System.Windows.Forms.Button();
            this.InstallAll = new System.Windows.Forms.Button();
            this.InstalledVoicesLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.InstalledVoicesList = new System.Windows.Forms.ListBox();
            this.SelectedVoiceDetails = new System.Windows.Forms.TextBox();
            this.SelectedVoiceDetailsLabel = new System.Windows.Forms.Label();
            this.RestoreRegistry = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AvailableVoicesCheckList
            // 
            this.AvailableVoicesCheckList.AccessibleDescription = "Here you can select the voices found on your system that can be installed in the " +
    "registry.";
            this.AvailableVoicesCheckList.AccessibleName = "Available voices";
            this.AvailableVoicesCheckList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AvailableVoicesCheckList.CheckOnClick = true;
            this.AvailableVoicesCheckList.FormattingEnabled = true;
            this.AvailableVoicesCheckList.Location = new System.Drawing.Point(8, 25);
            this.AvailableVoicesCheckList.Name = "AvailableVoicesCheckList";
            this.AvailableVoicesCheckList.Size = new System.Drawing.Size(326, 214);
            this.AvailableVoicesCheckList.TabIndex = 0;
            this.AvailableVoicesCheckList.SelectedIndexChanged += new System.EventHandler(this.AvailableVoicesCheckList_SelectedIndexChanged);
            // 
            // InstallSelection
            // 
            this.InstallSelection.AccessibleDescription = "Click here to install the voices selected in the available voices list.";
            this.InstallSelection.AccessibleName = "Install selected voices";
            this.InstallSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallSelection.Location = new System.Drawing.Point(455, 433);
            this.InstallSelection.Name = "InstallSelection";
            this.InstallSelection.Size = new System.Drawing.Size(100, 39);
            this.InstallSelection.TabIndex = 2;
            this.InstallSelection.Text = "Install selected voices";
            this.InstallSelection.UseVisualStyleBackColor = true;
            this.InstallSelection.Click += new System.EventHandler(this.InstallSelection_Click);
            // 
            // InstallAll
            // 
            this.InstallAll.AccessibleDescription = "Click here to install the voices found on your system.";
            this.InstallAll.AccessibleName = "Install all available voices";
            this.InstallAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallAll.Location = new System.Drawing.Point(561, 433);
            this.InstallAll.Name = "InstallAll";
            this.InstallAll.Size = new System.Drawing.Size(100, 39);
            this.InstallAll.TabIndex = 3;
            this.InstallAll.Text = "Install all available voices";
            this.InstallAll.UseVisualStyleBackColor = true;
            this.InstallAll.Click += new System.EventHandler(this.InstallAll_Click);
            // 
            // InstalledVoicesLabel
            // 
            this.InstalledVoicesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstalledVoicesLabel.AutoSize = true;
            this.InstalledVoicesLabel.Location = new System.Drawing.Point(346, 9);
            this.InstalledVoicesLabel.Name = "InstalledVoicesLabel";
            this.InstalledVoicesLabel.Size = new System.Drawing.Size(123, 13);
            this.InstalledVoicesLabel.TabIndex = 5;
            this.InstalledVoicesLabel.Text = "Voices currently installed";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Voices available";
            // 
            // InstalledVoicesList
            // 
            this.InstalledVoicesList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstalledVoicesList.FormattingEnabled = true;
            this.InstalledVoicesList.Location = new System.Drawing.Point(349, 25);
            this.InstalledVoicesList.Name = "InstalledVoicesList";
            this.InstalledVoicesList.Size = new System.Drawing.Size(312, 394);
            this.InstalledVoicesList.TabIndex = 7;
            this.InstalledVoicesList.SelectedIndexChanged += new System.EventHandler(this.InstalledVoicesList_SelectedIndexChanged);
            // 
            // SelectedVoiceDetails
            // 
            this.SelectedVoiceDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectedVoiceDetails.Location = new System.Drawing.Point(8, 268);
            this.SelectedVoiceDetails.Multiline = true;
            this.SelectedVoiceDetails.Name = "SelectedVoiceDetails";
            this.SelectedVoiceDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.SelectedVoiceDetails.Size = new System.Drawing.Size(326, 204);
            this.SelectedVoiceDetails.TabIndex = 8;
            // 
            // SelectedVoiceDetailsLabel
            // 
            this.SelectedVoiceDetailsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectedVoiceDetailsLabel.AutoSize = true;
            this.SelectedVoiceDetailsLabel.Location = new System.Drawing.Point(5, 252);
            this.SelectedVoiceDetailsLabel.Name = "SelectedVoiceDetailsLabel";
            this.SelectedVoiceDetailsLabel.Size = new System.Drawing.Size(111, 13);
            this.SelectedVoiceDetailsLabel.TabIndex = 9;
            this.SelectedVoiceDetailsLabel.Text = "Selected voice details";
            // 
            // RestoreRegistry
            // 
            this.RestoreRegistry.AccessibleDescription = "Restore previous version of the voice registry";
            this.RestoreRegistry.AccessibleName = "Restore a previous state";
            this.RestoreRegistry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RestoreRegistry.Location = new System.Drawing.Point(349, 433);
            this.RestoreRegistry.Name = "RestoreRegistry";
            this.RestoreRegistry.Size = new System.Drawing.Size(100, 39);
            this.RestoreRegistry.TabIndex = 10;
            this.RestoreRegistry.Text = "Restore registry";
            this.RestoreRegistry.UseVisualStyleBackColor = true;
            this.RestoreRegistry.Click += new System.EventHandler(this.RestoreRegistry_Click);
            // 
            // VoicesManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 478);
            this.Controls.Add(this.RestoreRegistry);
            this.Controls.Add(this.SelectedVoiceDetailsLabel);
            this.Controls.Add(this.SelectedVoiceDetails);
            this.Controls.Add(this.InstalledVoicesList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InstalledVoicesLabel);
            this.Controls.Add(this.InstallAll);
            this.Controls.Add(this.InstallSelection);
            this.Controls.Add(this.AvailableVoicesCheckList);
            this.Name = "VoicesManagerForm";
            this.Text = "SAPI voice registry manager";
            this.Load += new System.EventHandler(this.VoiceManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox AvailableVoicesCheckList;
        private System.Windows.Forms.Button InstallSelection;
        private System.Windows.Forms.Button InstallAll;
        private System.Windows.Forms.Label InstalledVoicesLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox InstalledVoicesList;
        private System.Windows.Forms.TextBox SelectedVoiceDetails;
        private System.Windows.Forms.Label SelectedVoiceDetailsLabel;
        private System.Windows.Forms.Button RestoreRegistry;
    }
}