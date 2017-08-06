using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperShadowrunWindows
{
    public partial class Form1 : Form
    {

//        const long ORIGINAL_MUSIC_FILE_SIZE = 107277012;
        const long ORIGINAL_MUSIC_FILE_SIZE = 107277169;
        const long NEW_MUSIC_FILE_SIZE = 6648343;

        const String CURRENT_MUSIC_FILE_PATH = "SRHK_Data\\resources.assets.resS";
        const String BACKUP_MUSIC_FILE_PATH = "SRHK_Data\\resources.assets.resS.original";
        const String ASSETS_FILE_PATH = "SRHK_Data\\resources.assets";

        String path;

        public Form1()
        {
            InitializeComponent();
            replaceButton.Enabled = false;
            restoreButton.Enabled = false;
        }

        // Browse...
        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String fullPath = openFileDialog1.FileName;
                int endOfPath = fullPath.LastIndexOf("SRHK.exe");
                path = openFileDialog1.FileName.Substring(0, endOfPath);
                updateButtons();
            }
        }

        private void replaceButton_Click(object sender, EventArgs e)
        {

        }

        private void updateButtons()
        {
            string currentMusicFilePath = path + CURRENT_MUSIC_FILE_PATH;
            string backupMusicFilePath = path + BACKUP_MUSIC_FILE_PATH;
            System.IO.FileInfo currentInfo = new System.IO.FileInfo(currentMusicFilePath);
            System.IO.FileInfo backupInfo = new System.IO.FileInfo(backupMusicFilePath);
            replaceButton.Enabled = currentInfo.Exists && currentInfo.Length == ORIGINAL_MUSIC_FILE_SIZE;
            restoreButton.Enabled = backupInfo.Exists && currentInfo.Length == NEW_MUSIC_FILE_SIZE;
        }
    }
}
