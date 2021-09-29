using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VoicesManagementLibrary;

namespace VoiceImporter {
    public partial class VoicesManagerForm : Form {

        public List<Voice> InstalledVoices;

        public List<Voice> AvailableVoices;
        

        public VoicesManagerForm(List<Voice> InstalledVoices, List<Voice> AvailableVoices) {
            this.InstalledVoices = InstalledVoices;
            this.AvailableVoices = AvailableVoices;

            InitializeComponent();

        }

        
        private void VoiceManager_Load(object sender, EventArgs e) {
            InstalledVoicesList.Items.Clear();
            this.AvailableVoicesCheckList.Items.Clear();
            foreach (Voice installed in this.InstalledVoices) {
                InstalledVoicesList.Items.Add(installed.Name);
            }

            foreach (Voice available in this.AvailableVoices) {
                if (!this.InstalledVoices.Contains(available)) {
                    this.AvailableVoicesCheckList.Items.Add(available.Name);
                }
            }
        }

        private void InstallSelection_Click(object sender, EventArgs e) {
            List<Voice> toInstall = new List<Voice>();
            if (this.AvailableVoicesCheckList.CheckedItems.Count > 0) {
                foreach (object item in this.AvailableVoicesCheckList.CheckedItems) {
                    string voiceName = (string)item;
                    Voice found = AvailableVoices.Find(v => v.Name == voiceName);
                    if (found != null) {
                        toInstall.Add(found);
                    }
                }
                InstalledVoices = VoicesRegistryManagement.SaveToRegistry(toInstall, VoicesRegistryManagement.VoiceTokensRoot.SAPI);

                // remove installed voices from Available
                foreach (Voice installed in toInstall) {
                    AvailableVoices.Remove(installed);
                }
                // reload the manager form
                this.VoiceManager_Load(this, null);


            } else {
                MessageBox.Show("Please select one or more voices to install " +
                    "in the available voices list before clicking on this button.");
            }


        }

        private void InstallAll_Click(object sender, EventArgs e) {
            List<Voice> toInstall = new List<Voice>();

            foreach (Voice available in this.AvailableVoices) {
                if (!this.InstalledVoices.Contains(available)) {
                    toInstall.Add(available);
                }
            }
            InstalledVoices = VoicesRegistryManagement.SaveToRegistry(toInstall, VoicesRegistryManagement.VoiceTokensRoot.SAPI);

            // remove installed voices from Available
            foreach (Voice installed in toInstall) {
                AvailableVoices.Remove(installed);
            }
            // reload the manager form
            this.VoiceManager_Load(this, null);
            // Update lists

        }

        private void AvailableVoicesCheckList_SelectedIndexChanged(object sender, EventArgs e) {
            // update voice details panel
            string voiceName = (string)AvailableVoicesCheckList.SelectedItem;
            Voice found = AvailableVoices.Find(v => v.Name == voiceName);
            if (found != null) {
                SelectedVoiceDetails_Update(found);
            }

        }

        private void InstalledVoicesList_SelectedIndexChanged(object sender, EventArgs e) {
            // update voice details panel
            string voiceName = (string)InstalledVoicesList.SelectedItem;
            Voice found = InstalledVoices.Find(v => v.Name == voiceName);
            if (found != null) {
                SelectedVoiceDetails_Update(found);
            }
        }

        private void SelectedVoiceDetails_Update(Voice toDisplay = null) {
            this.SelectedVoiceDetails.Text = toDisplay?.ToString();
            this.SelectedVoiceDetails.Refresh();
        }

        private void RestoreRegistry_Click(object sender, EventArgs e) {
            // Open a file selection to open the backup folder
            // when user has selected a json file, parse it and update the SAPI voice accordingly
        }
    }
}
