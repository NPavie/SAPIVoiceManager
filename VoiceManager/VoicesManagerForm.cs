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

        public List<Voice> voicesInstalled;

        public List<Voice> voicesAvailable;

        

        public VoicesManagerForm(List<Voice> voicesInstalled, List<Voice> voicesAvailable) {
            this.voicesInstalled = voicesInstalled;
            this.voicesAvailable = voicesAvailable;
            InitializeComponent();
        }

        private void InstallSelection_Click(object sender, EventArgs e) {

        }

        private void InstallAll_Click(object sender, EventArgs e) {

        }

        private void VoiceManager_Load(object sender, EventArgs e) {

        }
    }
}
