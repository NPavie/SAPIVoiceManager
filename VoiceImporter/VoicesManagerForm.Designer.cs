
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
            this.availableVoices = new System.Windows.Forms.CheckedListBox();
            this.InstallSelection = new System.Windows.Forms.Button();
            this.InstallAll = new System.Windows.Forms.Button();
            this.InstalledVoicesLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.InstalledVoices = new System.Windows.Forms.ListBox();
            this.SelectedVoiceDetails = new System.Windows.Forms.TextBox();
            this.SelectedVoiceDetailsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // availableVoices
            // 
            this.availableVoices.AccessibleDescription = "Here you can select the voices found on your system that can be installed in the " +
    "registry.";
            this.availableVoices.AccessibleName = "Available voices";
            this.availableVoices.FormattingEnabled = true;
            this.availableVoices.Location = new System.Drawing.Point(12, 25);
            this.availableVoices.Name = "availableVoices";
            this.availableVoices.Size = new System.Drawing.Size(234, 139);
            this.availableVoices.TabIndex = 0;
            // 
            // InstallSelection
            // 
            this.InstallSelection.AccessibleDescription = "Click here to install the voices selected in the available voices list.";
            this.InstallSelection.AccessibleName = "Install selected voices";
            this.InstallSelection.Location = new System.Drawing.Point(262, 308);
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
            this.InstallAll.Location = new System.Drawing.Point(396, 308);
            this.InstallAll.Name = "InstallAll";
            this.InstallAll.Size = new System.Drawing.Size(100, 39);
            this.InstallAll.TabIndex = 3;
            this.InstallAll.Text = "Install all available voices";
            this.InstallAll.UseVisualStyleBackColor = true;
            this.InstallAll.Click += new System.EventHandler(this.InstallAll_Click);
            // 
            // InstalledVoicesLabel
            // 
            this.InstalledVoicesLabel.AutoSize = true;
            this.InstalledVoicesLabel.Location = new System.Drawing.Point(259, 9);
            this.InstalledVoicesLabel.Name = "InstalledVoicesLabel";
            this.InstalledVoicesLabel.Size = new System.Drawing.Size(123, 13);
            this.InstalledVoicesLabel.TabIndex = 5;
            this.InstalledVoicesLabel.Text = "Voices currently installed";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Voices available";
            // 
            // InstalledVoices
            // 
            this.InstalledVoices.FormattingEnabled = true;
            this.InstalledVoices.Location = new System.Drawing.Point(262, 25);
            this.InstalledVoices.Name = "InstalledVoices";
            this.InstalledVoices.Size = new System.Drawing.Size(234, 277);
            this.InstalledVoices.TabIndex = 7;
            // 
            // SelectedVoiceDetails
            // 
            this.SelectedVoiceDetails.Location = new System.Drawing.Point(12, 183);
            this.SelectedVoiceDetails.Multiline = true;
            this.SelectedVoiceDetails.Name = "SelectedVoiceDetails";
            this.SelectedVoiceDetails.Size = new System.Drawing.Size(234, 123);
            this.SelectedVoiceDetails.TabIndex = 8;
            // 
            // SelectedVoiceDetailsLabel
            // 
            this.SelectedVoiceDetailsLabel.AutoSize = true;
            this.SelectedVoiceDetailsLabel.Location = new System.Drawing.Point(9, 167);
            this.SelectedVoiceDetailsLabel.Name = "SelectedVoiceDetailsLabel";
            this.SelectedVoiceDetailsLabel.Size = new System.Drawing.Size(111, 13);
            this.SelectedVoiceDetailsLabel.TabIndex = 9;
            this.SelectedVoiceDetailsLabel.Text = "Selected voice details";
            // 
            // VoiceManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 353);
            this.Controls.Add(this.SelectedVoiceDetailsLabel);
            this.Controls.Add(this.SelectedVoiceDetails);
            this.Controls.Add(this.InstalledVoices);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InstalledVoicesLabel);
            this.Controls.Add(this.InstallAll);
            this.Controls.Add(this.InstallSelection);
            this.Controls.Add(this.availableVoices);
            this.Name = "VoiceManager";
            this.Text = "VoiceManager";
            this.Load += new System.EventHandler(this.VoiceManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox availableVoices;
        private System.Windows.Forms.Button InstallSelection;
        private System.Windows.Forms.Button InstallAll;
        private System.Windows.Forms.Label InstalledVoicesLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox InstalledVoices;
        private System.Windows.Forms.TextBox SelectedVoiceDetails;
        private System.Windows.Forms.Label SelectedVoiceDetailsLabel;
    }
}