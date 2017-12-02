using System;
using System.Windows.Forms;

namespace SuperShadowrunWindows
{
    public partial class Form1 : Form
    {

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
            1393879,
            3014944,
            4520349,
            6075686,
            13224667,
            16859277,
            23705366,
            27333628,
            30392989,
            31785729,
            36227626,
            37558729,
            39215240,
            42753645,
            48193852,
            50059652,
            52826294,
            58756297,
            60484053,
            61866854,
            64926321,
            67814125,
            69554962,
            70868771,
            74036566,
            77274731,
            78780769,
            80649419,
            82085067,
            83502179,
            85835133,
            89345991,
            90902926,
            92457982,
            96090766,
            99115787,
            100674517,
            102037008,
            104243280,
            107256232,
            111057445,
            113768371,
            115841178,
            117621935,
            118888656,
            126481541
        };

        int[] NEW_SIZE_VALUES =
        {
            1393879,
            1621065,
            1505405,
            1555337,
            7148981,
            3634610,
            6846089,
            3628262,
            3059361,
            1392740,
            4441897,
            1331103,
            1656511,
            3538405,
            5440207,
            1865800,
            2766642,
            5930003,
            1727756,
            1382801,
            3059467,
            2887804,
            1740837,
            1313809,
            3167795,
            3238165,
            1506038,
            1868650,
            1435648,
            1417112,
            2332954,
            3510858,
            1556935,
            1555056,
            3632784,
            3025021,
            1558730,
            1362491,
            2206272,
            3012952,
            3801213,
            2710926,
            2072807,
            1780757,
            1266721,
            7592885,
            7064409
        };

        // Mapping info
        /*
        Hub-TeaHouse              -> ../music/vlc_converted/track0.ogg
        Hub-Exterior              -> ../music/vlc_converted/track1.ogg
        Combat-Generic-Int2       -> ../music/vlc_converted/track3.ogg
        Legwork-SLinterior        -> ../music/vlc_converted/track5.ogg
        TitleTheme-UI             -> invocationarray_acff/04siren.ogg
        Combat-Matrix2            -> ../music/combat_matrix2.ogg
        Combat-Kowloon-Int2       -> invocationarray_op/06catalyst.ogg
        Combat-Gobbet-Int1        -> ../music/vlc_converted/track6.ogg
        Combat-Kowloon-WrapUp     -> ../music/vlc_converted/track7.ogg
        Hub-SafeHouse             -> ../music/vlc_converted/track9.ogg
        Combat-Is0bel-Int2        -> ../music/vlc_converted/track12.ogg
        Legwork-Generic           -> ../music/vlc_converted/track14.ogg
        Combat-Kowloon-Int1       -> ../music/vlc_converted/track16.ogg
        Combat-Gobbet-WrapUp      -> ../music/vlc_converted/track17.ogg
        Legwork-Is0bel            -> ../music/vlc_converted/track18.ogg
        Legwork-Erhu              -> ../music/vlc_converted/track22.ogg
        Legwork-Grendel           -> ../music/vlc_converted/track24.ogg
        Legwork-ExitStageLeft     -> ../music/vlc_converted/track26.ogg
        TESTSTINGER               -> ../music/vlc_converted/track27.ogg
        Hub-Club88-ThroughWalls   -> ../music/vlc_converted/track30.ogg
        Legwork-News              -> ../music/vlc_converted/track32.ogg
        Combat-Boss               -> ../music/vlc_converted/track33.ogg
        loudmusic                 -> ../music/vlc_converted/track34.ogg
        Legwork-Whistleblower     -> ../music/vlc_converted/track35.ogg
        Combat-Is0bel-Int1        -> ../music/vlc_converted/track36.ogg
        Combat-Generic-WrapUp     -> ../music/vlc_converted/track37.ogg
        Combat-Generic-Int1       -> ../music/vlc_converted/track38.ogg
        Hub-Club88-InStreet       -> ../music/vlc_converted/track39.ogg
        Legwork-Kowloon           -> ../music/vlc_converted/track41.ogg
        Combat-stinger-end        -> ../music/vlc_converted/track43.ogg
        Combat-VictoriaHarbor-WrapUp -> ../music/vlc_converted/track49.ogg
        Combat-Grendel-Int1       -> ../music/vlc_converted/track46.ogg
        Legwork-Museum            -> ../music/vlc_converted/track47.ogg
        Sewer                     -> ../music/vlc_converted/track48.ogg
        Stealth-Matrix1           -> ../music/stealth_matrix1.ogg
        Legwork-Gobbet            -> ../music/vlc_converted/track50.ogg
        Legwork-Hacking           -> ../music/legwork_hacking.ogg
        Combat-Grendel-WrapUp     -> ../music/vlc_converted/track53.ogg
        KnightKingsElevator       -> ../music/vlc_converted/track51.ogg
        Legwork-VictoriaHarbor    -> ../music/vlc_converted/track54.ogg
        Combat-Grendel-Int2       -> ../music/vlc_converted/track55.ogg
        Combat-Is0bel-WrapUp      -> ../music/vlc_converted/track57.ogg
        Combat-VictoriaHarbor-Int1 -> ../music/vlc_converted/track58.ogg
        Combat-stinger-start      -> ../music/vlc_converted/track59.ogg
        Combat-Gobbet-Int2        -> ../music/vlc_converted/track60.ogg
        Club88-MainRoom           -> invocationarray_acff/08withme.ogg
        Combat-VictoriaHarbor-Int2 -> invocationarray_op/16catalyst.ogg
    */

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
            CopyResource("SuperShadowrunWindows.Resources.resources.assets.resS", currentMusicFilePath);

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
            // Should probably check errors here.
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
            restoreButton.Enabled = backupInfo.Exists && currentInfo.Length != backupInfo.Length;
        }

        private void restoreButton_Click(object sender, EventArgs e)
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

            try {
                System.IO.File.Delete(currentMusicFilePath);
            } catch (System.IO.IOException ioe) {
                MessageBox.Show("ERROR: Could not replace music file. Please exit Shadowrun Hong Kong if it is running and try again. If this problem persists, try rebooting your computer.", MESSAGE_BOX_TITLE, MessageBoxButtons.OK);
                return;
            }

            System.IO.File.Copy(backupMusicFilePath, currentMusicFilePath);
            writeArrays(assetsFilePath, ORIGINAL_SIZE_VALUES, ORIGINAL_POSITION_VALUES);

            updateButtons();
            MessageBox.Show("Restore successful! The original Hong Kong music will now play for all campaigns.", MESSAGE_BOX_TITLE, MessageBoxButtons.OK);

        }

    }
}
