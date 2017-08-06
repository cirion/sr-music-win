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

        int[] SIZE_OFFSETS = {
            2004907468, //  Hub-TeaHouse
            2004907524, //  Hub-Exterior
            2004907584, //  Combat-Generic-Int2
            2004907640, //  Legwork-SLinterior
            2004907692, //  TitleTheme-UI
            2004907748, //  Combat-Matrix2
            2004907808, //  Combat-Kowloon-Int2
            2004907864, //  Combat-Gobbet-Int1
            2004907924, //  Combat-Kowloon-WrapUp
            2004907980, //  Hub-SafeHouse
            2004908040, //  Combat-Is0bel-Int2
            2004908092, //  Legwork-Generic
            2004908152, //  Combat-Kowloon-Int1
            2004908212, //  Combat-Gobbet-WrapUp
            2004908268, //  Legwork-Is0bel
            2004908324, //  Legwork-Erhu
            2004908380, //  Legwork-Grendel
            2004908444, //  Legwork-ExitStageLeft
            2004908488, //  TESTSTINGER
            2004908548, //  Hub-Club88-ThroughWalls
            2004908604, //  Legwork-News
            2004908656, //  Combat-Boss
            2004908704, //  loudmusic
            2004908764, //  Legwork-Whistleblower
            2004908824, //  Combat-Is0bel-Int1
            2004908884, //  Combat-Generic-WrapUp
            2004908944, //  Combat-Generic-Int1
            2004909000, //  Hub-Club88-InStreet
            2004909052, //  Legwork-Kowloon
            2004909112, //  Combat-stinger-end
            2004909180, //  Combat-VictoriaHarbor-WrapUp
            2004909240, //  Combat-Grendel-Int1
            2004909292, //  Legwork-Museum
            2004909340, //  Sewer
            2004909396, //  Stealth-Matrix1
            2004909542, //  Legwork-Gobbet
            2004909508, //  Legwork-Hacking
            2004909572, //  Combat-Grendel-WrapUp
            2004909632, //  KnightKingsElevator
            2004909692, //  Legwork-VictoriaHarbor
            2004909752, //  Combat-Grendel-Int2
            2004909812, //  Combat-Is0bel-WrapUp
            2004909880, //  Combat-VictoriaHarbor-Int1
            2004909940, //  Combat-stinger-start
            2004910000, //  Combat-Gobbet-Int2
            2004910056, //  Club88-MainRoom
            2004910120  //  Combat-VictoriaHarbor-Int2
        };

        int[] ORIGINAL_SIZE_VALUES =
        {
            3124134, // Hub-TeaHouse
            5637312, // Hub-Exterior
            2455567, // Combat-Generic-Int2
            2188996, // Legwork-SLinterior
            3114613, // TitleTheme-UI
            3634330, // Combat-Matrix2
            2041347, // Combat-Kowloon-Int2
            1584808, // Combat-Gobbet-Int1
            2041312, // Combat-Kowloon-WrapUp
            4940168, // Hub-SafeHouse
            1561468, // Combat-Is0bel-Int2
            3314907, // Legwork-Generic
            2041503, // Combat-Kowloon-Int1
            1587765, // Combat-Gobbet-WrapUp
            2769352, // Legwork-Is0bel
            2335317, // Legwork-Erhu
            4081956, // Legwork-Grendel
            2137219, // Legwork-ExitStageLeft
            23524,   //   TESTSTINGER
            1945118, // Hub-Club88-ThroughWalls
            814336, //  Legwork-News
            2379468, // Combat-Boss
            1461548, // loudmusic
            2076444, // Legwork-Whistleblower
            1561717, // Combat-Is0bel-Int1
            2453971, // Combat-Generic-WrapUp
            2456839, // Combat-Generic-Int1
            1946454, // Hub-Club88-InStreet
            4769042, // Legwork-Kowloon
            174738,  //  Combat-stinger-end
            1555961, // Combat-VictoriaHarbor-WrapUp
            2201641, // Combat-Grendel-Int1
            3824160, // Legwork-Museum
            1248268, // Sewer
            3632887, // Stealth-Matrix1
            3386416, // Legwork-Gobbet
            97418,   //   Legwork-Hacking
            2204970, // Combat-Grendel-WrapUp
            1722703, // KnightKingsElevator
            2772601, // Legwork-VictoriaHarbor
            2203038, // Combat-Grendel-Int2
            1561330, // Combat-Is0bel-WrapUp
            1556423, // Combat-VictoriaHarbor-Int1
            98449,   //   Combat-stinger-start
            1587496, // Combat-Gobbet-Int2
            1951388, // Club88-MainRoom
            1555953  //Combat-VictoriaHarbor-Int2
        };

        int[] ORIGINAL_POSITION_VALUES =
        {
            0,         //    Hub-TeaHouse
            3124134,   //    Hub-Exterior
            8761446,   //    Combat-Generic-Int2
            11217013,  //    Legwork-SLinterior
            13406009,  //    TitleTheme-UI
            16520622,  //    Combat-Matrix2
            20154952,  //    Combat-Kowloon-Int2
            22196299,  //    Combat-Gobbet-Int1
            23781107,  //    Combat-Kowloon-WrapUp
            25822419,  //    Hub-SafeHouse
            30762587,  //    Combat-Is0bel-Int2
            32324055,  //    Legwork-Generic
            35638962,  //    Combat-Kowloon-Int1
            37642065,  //    Combat-Gobbet-WrapUp
            39268230,  //    Legwork-Is0bel
            42037582,  //    Legwork-Erhu
            44372899,  //    Legwork-Grendel
            48454343,  //    Legwork-ExitStageLeft
            50591562,  //    TESTSTINGER
            50615086,  //    Hub-Club88-ThroughWalls
            52560204,  //    Legwork-News
            54423116,  //    Combat-Boss
            55754008,  //    loudmusic
            57215556,  //    Legwork-Whistleblower
            59292000,  //    Combat-Is0bel-Int1
            60853717,  //    Combat-Generic-WrapUp
            63307688,  //    Combat-Generic-Int1
            65764527,  //    Hub-Club88-InStreet
            67710981,  //    Legwork-Kowloon
            72480023,  //    Combat-stinger-end
            72654761,  //    Combat-VictoriaHarbor-WrapUp
            74210722,  //    Combat-Grendel-Int1
            76412363,  //    Legwork-Museum
            80236523,  //    Sewer
            81484791,  //    Stealth-Matrix1
            85117678,  //    Legwork-Gobbet
            88504094,  //    Legwork-Hacking
            90062786,  //    Combat-Grendel-WrapUp
            92267756,  //    KnightKingsElevator
            93990491,  //    Legwork-VictoriaHarbor
            96763092,  //    Combat-Grendel-Int2
            98966130,  //    Combat-Is0bel-WrapUp
            100527460, //    Combat-VictoriaHarbor-Int1
            102083883, //    Combat-stinger-start
            102182332, //    Combat-Gobbet-Int2
            103769828, //    Club88-MainRoom
            105721216  //    Combat-VictoriaHarbor-Int2
        };

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
