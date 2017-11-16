using System;
using System.Windows.Forms;

namespace SuperShadowrunWindows
{
    public partial class Form1 : Form
    {

//        const long ORIGINAL_MUSIC_FILE_SIZE = 107277012;
        const long ORIGINAL_MUSIC_FILE_SIZE = 107277169;
        const long NEW_MUSIC_FILE_SIZE = 6648343;

        const String MESSAGE_BOX_TITLE = "Shadowrun Music Replacer";

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
            2004909452, //  Legwork-Gobbet
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
            4081444, // Legwork-Grendel
            2137219, // Legwork-ExitStageLeft
            23524,   // TESTSTINGER
            1945118, // Hub-Club88-ThroughWalls
            814336,  // Legwork-News
            2379468, // Combat-Boss
            1461548, // loudmusic
            2076444, // Legwork-Whistleblower
            1561717, // Combat-Is0bel-Int1
            2453971, // Combat-Generic-WrapUp
            2456839, // Combat-Generic-Int1
            1946454, // Hub-Club88-InStreet
            4769042, // Legwork-Kowloon
            174738,  // Combat-stinger-end
            1555961, // Combat-VictoriaHarbor-WrapUp
            2201641, // Combat-Grendel-Int1
            3824160, // Legwork-Museum
            1248268, // Sewer
            3632887, // Stealth-Matrix1
            3386416, // Legwork-Gobbet
            1558692, // Legwork-Hacking
            2204970, // Combat-Grendel-WrapUp
            1722735, // KnightKingsElevator
            2772601, // Legwork-VictoriaHarbor
            2203038, // Combat-Grendel-Int2
            1561330, // Combat-Is0bel-WrapUp
            1556423, // Combat-VictoriaHarbor-Int1
            98449,   // Combat-stinger-start
            1587496, // Combat-Gobbet-Int2
            1951388, // Club88-MainRoom
            1555953  // Combat-VictoriaHarbor-Int2
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
            37680465,  //    Combat-Gobbet-WrapUp
            39268230,  //    Legwork-Is0bel
            42037582,  //    Legwork-Erhu
            44372899,  //    Legwork-Grendel
            48454343,  //    Legwork-ExitStageLeft
            50591562,  //    TESTSTINGER
            50615086,  //    Hub-Club88-ThroughWalls
            52560204,  //    Legwork-News
            53374540,  //    Combat-Boss
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

        // The index into the new resources.assets.resS at which each track can be located. If using concat.py,
        // these values can be taken from indices.txt. Pad out the array to 47 elements, you can safely reuse the
        // same track multiple times. These do not necessarily need to be in ascending order.
        int[] NEW_POSITION_VALUES =
        {
            0,
            6943939,
            13870374,
            21041224,
            28190205,
            34785422,
            42134005,
            49636913,
            57229798,
            64338832,
            70267594,
            76169519,
            83302189,
            89192937,
            95780483,
            102093934,
            109158343,
            115258893,
            122801168,
            129112858,
            137339673,
            142449973,
            145542310,
            149849423,
            152641825,
            155852362,
            161850414,
            164993763,
            169494987,
            173443179,
            176145112,
            178103101,
            179613562,
            183456107,
            186622425,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0
        };

        int[] NEW_SIZE_VALUES =
        {
            6943939,
            6926435,
            7170850,
            7148981,
            6595217,
            7348583,
            7502908,
            7592885,
            7109034,
            5928762,
            5901925,
            7132670,
            5890748,
            6587546,
            6313451,
            7064409,
            6100550,
            7542275,
            6311690,
            8226815,
            5110300,
            3092337,
            4307113,
            2792402,
            3210537,
            5998052,
            3143349,
            4501224,
            3948192,
            2701933,
            1957989,
            1510461,
            3842545,
            3166318,
            1460540,
            6943939,
            6943939,
            6943939,
            6943939,
            6943939,
            6943939,
            6943939,
            6943939,
            6943939,
            6943939,
            6943939,
            6943939
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
            String currentMusicFilePath = path + CURRENT_MUSIC_FILE_PATH;
            String backupMusicFilePath = path + BACKUP_MUSIC_FILE_PATH;
            String assetsFilePath = path + ASSETS_FILE_PATH;

            bool canSkipBackup = false;

            System.IO.FileInfo backupInfo = new System.IO.FileInfo(backupMusicFilePath);
            if (backupInfo.Exists && backupInfo.Length == ORIGINAL_MUSIC_FILE_SIZE)
            {
                canSkipBackup = true;
            }

            System.IO.FileInfo currentInfo = new System.IO.FileInfo(currentMusicFilePath);
            if (!canSkipBackup)
            {
                if (currentInfo.Length != ORIGINAL_MUSIC_FILE_SIZE)
                {
                    MessageBox.Show("WARNING: The current music file size appears incorrect. Please correct by verifying the integrity of Shadowrun Hong Kong within Steam. Aborting.", MESSAGE_BOX_TITLE, MessageBoxButtons.OK);
                    return;
                }
                System.IO.File.Copy(currentMusicFilePath, backupMusicFilePath);
            }

            System.IO.File.Delete(currentMusicFilePath);
            CopyResource("SuperShadowrunWindows.Resources.03ShiftTheFields.ogg", currentMusicFilePath);

            writeArrays(assetsFilePath, NEW_SIZE_VALUES, NEW_POSITION_VALUES);

            updateButtons();
            MessageBox.Show("Conversion successful! The new music will now play for all campaigns, including the original.", MESSAGE_BOX_TITLE, MessageBoxButtons.OK);
        }

        private void CopyResource(string resourceName, string file)
        {
            using (System.IO.Stream resource = GetType().Assembly
                                              .GetManifestResourceStream(resourceName))
            {
                if (resource == null)
                {
                    throw new ArgumentException("No such resource", "resourceName");
                }
                using (System.IO.Stream output = System.IO.File.OpenWrite(file))
                {
                    resource.CopyTo(output);
                }
            }
        }

        private void writeArrays(String filePath, int[] sizes, int[] positions)
        {
            // TODO: Error handling? 
            System.IO.Stream stream = System.IO.File.Open(filePath, System.IO.FileMode.Open);
            for (int i = 0; i < SIZE_OFFSETS.Length; ++i)
            {
                int offset = SIZE_OFFSETS[i];
                int size = sizes[i];
                int position = positions[i];
                stream.Seek(offset, System.IO.SeekOrigin.Begin);
                byte[] sizeBytes = BitConverter.GetBytes(size);
                stream.Write(sizeBytes, 0, 4);
                byte[] positionBytes = BitConverter.GetBytes(position);
                stream.Write(positionBytes, 0, 4);
            }
            stream.Close();
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
