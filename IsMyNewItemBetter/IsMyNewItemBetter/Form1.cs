using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace IsMyNewItemBetter
{
    public partial class Form1 : Form
    {
        #region Variables
        // OLD
        public static double MSo = 0;
        public static double Mo = 0;
        public static double Co = 0;
        public static double Vo = 0;
        public static double Ho = 0;
        public static double resulto;
        // NEW
        public static double MSn = 0;
        public static double Mn = 0;
        public static double Cn = 0;
        public static double Vn = 0;
        public static double Hn = 0;
        public static double resultn;
        // STAT WEIGHT
        public static double MSsw = 0;
        public static double Msw = 0;
        public static double Csw = 0;
        public static double Vsw = 0;
        public static double Hsw = 0;
        public static string pfad = @"Config.csv";
        public string pfad2 = @"Config_2.csv";
        public static char seperator = ';';
        // LISTS
        public List<string> ClassList = new List<string>();
        public List<string> SpecList = new List<string>();
        public List<string> MainStatSWList = new List<string>();
        public List<string> MasterySWList = new List<string>();
        public List<string> CritSWList = new List<string>();
        public List<string> HasteSWList = new List<string>();
        public List<string> VersalitySWList = new List<string>();
        // Hilfsvariablen für Zeilen in csv datei
        public static int assa = 0;
        int outlaw = 1;
        int sub = 2;
        int arcan = 3;
        int mfrost = 4;
        int fire = 5;
        int priestholy = 6;
        int shadow = 7;
        int disc = 8;
        int havoc = 9;
        int veng = 10;
        int mms = 11;
        int surv = 12;
        int bm = 13;
        int brew = 14;
        int mist = 15;
        int wind = 16;
        int unholy = 17;
        int dkfrost = 18;
        int blood = 19;
        int arms = 20;
        int fury = 21;
        int wprot = 22;
        int palaholy = 23;
        int pprot = 24;
        int ret = 25;
        int affi = 26;
        int demo = 27;
        int destro = 28;
        int ele = 29;
        int sresto = 30;
        int enh = 31;
        int dresto = 32;
        int balance = 33;
        int feral = 34;
        int guard = 35;

        #endregion
        #region Class Arrays
        // KLASSEN ARRAY
        string[] klassen = { "", "Rogue", "Mage", "Priest", "Demon Hunter", "Hunter", "Monk", "Death Knight", "Warrior", "Paladin", "Warlock", "Schaman", "Druid" };
        string[] rogue = { "", "Assassination", "Outlaw", "Subtlety" };
        string[] mage = { "", "Arcan", "Frost", "Fire" };
        string[] priest = { "", "Holy", "Shadow", "Discipline" };
        string[] demonHunter = { "", "Havoc", "Vengeance" };
        string[] hunter = { "", "Marksmanship", "Survival", "Beast Mastery" };
        string[] monk = { "", "Brewmaster", "Mistweaver", "Windwalker" };
        string[] deathKnight = { "", "Unholy", "Frost", "Blood" };
        string[] warrior = { "", "Arms", "Fury", "Protection" };
        string[] paladin = { "", "Holy", "Protection", "Retribution" };
        string[] warlock = { "", "Affliction", "Demonology", "Destruction" };
        string[] schaman = { "", "Elemental", "Restoration", "Enhancement" };
        string[] druid = { "", "Restoration", "Balance", "Feral", "Guardian" };
        #endregion
        public Form1()
        {
            InitializeComponent();
            // KLASSEN COMBO BOX
            KlassenCB.DataSource = klassen;
            // WERTE AUF 0 SETZEN OLD           
            MainStatOld.Text = 0.ToString();
            MasteryOld.Text = 0.ToString();
            CritOld.Text = 0.ToString();
            VersalityOld.Text = 0.ToString();
            HasteOld.Text = 0.ToString();
            ResultOld.Text = 0.ToString();
            // WERTE AUF 0 SETZEN NEW
            MainStatNew.Text = 0.ToString();
            MasteryNew.Text = 0.ToString();
            CritNew.Text = 0.ToString();
            VersalityNew.Text = 0.ToString();
            HasteNew.Text = 0.ToString();
            ResultNew.Text = 0.ToString();
            // WERTE AUF 0 SETZEN STAT WEIGHT
            StatWeightZero();
        }
        // FÜLLE SPEC COMBOBOX BETREFFEND DER KLASSE
        private void KlassenCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (KlassenCB.SelectedIndex)
            {
                case 1: SpecCB.DataSource = rogue; break;
                case 2: SpecCB.DataSource = mage; break;
                case 3: SpecCB.DataSource = priest; break;
                case 4: SpecCB.DataSource = demonHunter; break;
                case 5: SpecCB.DataSource = hunter; break;
                case 6: SpecCB.DataSource = monk; break;
                case 7: SpecCB.DataSource = deathKnight; break;
                case 8: SpecCB.DataSource = warrior; break;
                case 9: SpecCB.DataSource = paladin; break;
                case 10: SpecCB.DataSource = warlock; break;
                case 11: SpecCB.DataSource = schaman; break;
                case 12: SpecCB.DataSource = druid; break;
                default: SpecCB.DataSource = rogue; break;
            }
        }
        // FÜLLE ENTSPRECHENDEN STAT WEIGHTS IN DIE TEXTBOXEN
        private void SpecCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (KlassenCB.SelectedItem.ToString())
            {
                case "Rogue": RogueStatWeight(); break;
                case "Mage": MageStatWeight(); break;
                case "Priest": PriestStatWeight(); break;
                case "Demon Hunter": DemonHunterStatWeight(); break;
                case "Hunter": HunterStatWeight(); break;
                case "Warrior": WarriorStatWeight(); break;
                case "Paladin": PaladinStatWeight(); break;
                case "Warlock": WarlockStatWeight(); break;
                case "Schaman": SchamanStatWeight(); break;
                case "Druid": DruidStatWeight(); break;
                default:
                    break;
            }
            //RogueStatWeight();
            //MageStatWeight();
            //PriestStatWeight();
            //DemonHunterStatWeight();
            //HunterStatWeight();
            //MonkStatWeight();
            //DeathKnightStatWeight();
            //WarriorStatWeight();
            //PaladinStatWeight();
            //WarlockStatWeight();
            //SchamanStatWeight();
            //DruidStatWeight();

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // TEXTBOXEN EINLESEN OLD
                double.TryParse(MainStatOld.Text, out MSo);
                double.TryParse(MasteryOld.Text, out Mo);
                double.TryParse(CritOld.Text, out Co);
                double.TryParse(VersalityOld.Text, out Vo);
                double.TryParse(HasteOld.Text, out Ho);
                resulto = (MSo * MSsw) + (Mo * Msw) + (Co * Csw) + (Vo * Vsw) + (Ho * Hsw);
                Math.Round(resulto, 1);
                ResultOld.Text = resulto.ToString();
                // TEXTBOXEN EINLESEN NEW
                double.TryParse(MainStatNew.Text, out MSn);
                double.TryParse(MasteryNew.Text, out Mn);
                double.TryParse(CritNew.Text, out Cn);
                double.TryParse(VersalityNew.Text, out Vn);
                double.TryParse(HasteNew.Text, out Hn);
                resultn = (MSn * MSsw) + (Mn * Msw) + (Cn * Csw) + (Vn * Vsw) + (Hn * Hsw);
                Math.Round(resultn, 1);
                ResultNew.Text = resultn.ToString();
                if (resultn > resulto)
                {
                    Ausgabe.Text = "Your new item is better!";
                }
                else if (resulto > resultn)
                {
                    Ausgabe.Text = "Your old item is better!";
                }
                else
                {
                    Ausgabe.Text = "Result is the same, take the one with the higher item level!";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void link_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.icy-veins.com/wow/class-guides");
        }
        private void Update_Click(object sender, EventArgs e)
        {
            /// todo
            /// bei buttonclick soll mittels StreamReader die entsprechende Zeile gefunden werden
            /// und dann mittels StreamWriter überschrieben werden.
            /// da ich eine datei nicht zugleich lesen und schreiben kann lege ich eine neue datei an.
            /// danach soll die ursprungsdatei mit der neuen überschrieben werden und die
            /// neue datei wieder gelöscht werden.
            using (StreamReader sr = new StreamReader(pfad))
            {
                string line = KlassenCB.SelectedItem.ToString() + seperator + SpecCB.SelectedItem.ToString() + seperator;
                while ((line = sr.ReadLine()) != null)
                {
                    string newFile = pfad.Replace(".csv", "_2.csv");
                    FileStream fs = File.Create(pfad2);
                    fs.Close();
                    string text = File.ReadAllText(pfad, Encoding.Default);
                    text = text.Replace(pfad2, pfad);
                    File.WriteAllText(pfad2 + Name, text, UnicodeEncoding.Default);
                    using (StreamWriter sw = new StreamWriter(pfad2, true))
                    {
                        sw.WriteLine(KlassenCB.SelectedItem.ToString() + seperator + SpecCB.SelectedItem.ToString() + seperator +
                            MainStatSW.Text + seperator + MasterySW.Text + seperator + CritSW.Text + seperator +
                            HasteSW.Text + seperator + VersalitySW.Text + seperator);
                    }
                }
            }
        }

        public void CreateList()
        {
            using (StreamReader sr = new StreamReader(pfad))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var values = line.Split(seperator);
                    ClassList.Add(values[0]);
                    SpecList.Add(values[1]);
                    MainStatSWList.Add(values[2]);
                    MasterySWList.Add(values[3]);
                    CritSWList.Add(values[4]);
                    HasteSWList.Add(values[5]);
                    VersalitySWList.Add(values[6]);
                }
            }
        }
        public void RogueStatWeight()
        {
            StatWeightZero();
            CreateList();
            switch (SpecCB.SelectedItem.ToString())
            {
                case "Assassination": SRFillTextBox(assa); break;
                case "Outlaw": SRFillTextBox(outlaw); break;
                case "Subtlety": SRFillTextBox(sub); break;
                default: break;
            }

            //if (KlassenCB.SelectedIndex == 1)
            //{
            //    switch (SpecCB.SelectedIndex)
            //    {
            //        // ASSASSINATION
            //        case 1:
            //            MainStatSW.Text = 1.ToString();
            //            MasterySW.Text = 0.84.ToString();
            //            CritSW.Text = 0.68.ToString();
            //            VersalitySW.Text = 0.67.ToString();
            //            HasteSW.Text = 0.46.ToString();
            //            double.TryParse(MainStatSW.Text, out MSsw);
            //            double.TryParse(MasterySW.Text, out Msw);
            //            double.TryParse(CritSW.Text, out Csw);
            //            double.TryParse(VersalitySW.Text, out Vsw);
            //            double.TryParse(HasteSW.Text, out Hsw);
            //            break;
            //        // OUTLAW
            //        case 2:
            //            MainStatSW.Text = 1.ToString();
            //            MasterySW.Text = 0.54.ToString();
            //            CritSW.Text = 0.58.ToString();
            //            VersalitySW.Text = 0.69.ToString();
            //            HasteSW.Text = 0.49.ToString();
            //            double.TryParse(MainStatSW.Text, out MSsw);
            //            double.TryParse(MasterySW.Text, out Msw);
            //            double.TryParse(CritSW.Text, out Csw);
            //            double.TryParse(VersalitySW.Text, out Vsw);
            //            double.TryParse(HasteSW.Text, out Hsw);
            //            break;
            //        // SUBTLETY
            //        case 3:
            //            MainStatSW.Text = 1.ToString();
            //            MasterySW.Text = 0.65.ToString();
            //            CritSW.Text = 0.61.ToString();
            //            VersalitySW.Text = 0.70.ToString();
            //            HasteSW.Text = 0.38.ToString();
            //            double.TryParse(MainStatSW.Text, out MSsw);
            //            double.TryParse(MasterySW.Text, out Msw);
            //            double.TryParse(CritSW.Text, out Csw);
            //            double.TryParse(VersalitySW.Text, out Vsw);
            //            double.TryParse(HasteSW.Text, out Hsw);
            //            break;
            //        default:; break;
            //    }
            //}

        }
        public void MageStatWeight()
        {
            StatWeightZero();
            CreateList();
            switch (SpecCB.SelectedItem.ToString())
            {
                case "Arcan": SRFillTextBox(arcan); break;
                case "Frost": SRFillTextBox(mfrost); break;
                case "Fire": SRFillTextBox(fire); break;
                default: break;
            }
        }
        public void PriestStatWeight()
        {
            CreateList();
            switch (SpecCB.SelectedItem.ToString())
            {
                case "Holy": SRFillTextBox(priestholy); break;
                case "Shadow": SRFillTextBox(shadow); break;
                case "Discipline": SRFillTextBox(disc); break;
                default: break;
            }
        }
        public void DemonHunterStatWeight()
        {
            CreateList();
            switch (SpecCB.SelectedItem.ToString())
            {
                case "Havoc": SRFillTextBox(havoc); break;
                case "Vengeance": SRFillTextBox(veng); break;
                default: break;
            }
        }
        public void HunterStatWeight()
        {
            CreateList();
            switch (SpecCB.SelectedItem.ToString())
            {
                case "Marksmanship": SRFillTextBox(mms); break;
                case "Survival": SRFillTextBox(surv); break;
                case "Beast Mastery": SRFillTextBox(bm); break;
                default: break;
            }
        }
        public void MonkStatWeight()
        {
            CreateList();
            switch (SpecCB.SelectedItem.ToString())
            {
                case "Brewmaster": SRFillTextBox(brew); break;
                case "Mistweaver": SRFillTextBox(mist); break;
                case "Windwalker": SRFillTextBox(wind); break;
                default: break;
            }
        }
        public void DeathKnightStatWeight()
        {
            CreateList();
            switch (SpecCB.SelectedItem.ToString())
            {
                case "Unholy": SRFillTextBox(unholy); break;
                case "Frost": SRFillTextBox(dkfrost); break;
                case "Blood": SRFillTextBox(blood); break;
                default: break;
            }
        }
        public void WarriorStatWeight()
        {
            CreateList();
            switch (SpecCB.SelectedItem.ToString())
            {
                case "Arms": SRFillTextBox(arms); break;
                case "Fury": SRFillTextBox(fury); break;
                case "Protection": SRFillTextBox(wprot); break;
                default: break;
            }
        }
        public void PaladinStatWeight()
        {
            CreateList();
            switch (SpecCB.SelectedItem.ToString())
            {
                case "Holy": SRFillTextBox(palaholy); break;
                case "Protection": SRFillTextBox(pprot); break;
                case "Retribution": SRFillTextBox(ret); break;
                default: break;
            }
        }
        public void WarlockStatWeight()
        {
            CreateList();
            switch (SpecCB.SelectedItem.ToString())
            {
                case "Affliction": SRFillTextBox(affi); break;
                case "Demonology": SRFillTextBox(demo); break;
                case "Destruction": SRFillTextBox(destro); break;
                default: break;
            }
        }
        public void SchamanStatWeight()
        {
            CreateList();
            switch (SpecCB.SelectedItem.ToString())
            {
                case "Elemental": SRFillTextBox(ele); break;
                case "Restoration": SRFillTextBox(sresto); break;
                case "Enhancement": SRFillTextBox(enh); break;
                default: break;
            }
        }
        public void DruidStatWeight()
        {
            CreateList();
            switch (SpecCB.SelectedItem.ToString())
            {
                case "Restoration": SRFillTextBox(dresto); break;
                case "Balance": SRFillTextBox(balance); break;
                case "Feral": SRFillTextBox(feral); break;
                case "Guardian": SRFillTextBox(guard); break;
                default: break;
            }
        }
        public void SRFillTextBox(int skillung)
        {
            using (StreamReader sr = new StreamReader(pfad))
            {
                string line2 = KlassenCB.SelectedItem.ToString() + seperator + SpecCB.SelectedItem.ToString() + seperator;
                if (this.KlassenCB.SelectedItem == KlassenCB.SelectedItem && this.SpecCB.SelectedItem == SpecCB.SelectedItem)
                {
                    MainStatSW.Text = MainStatSWList[skillung];
                    MasterySW.Text = MasterySWList[skillung];
                    CritSW.Text = CritSWList[skillung];
                    HasteSW.Text = HasteSWList[skillung];
                    VersalitySW.Text = VersalitySWList[skillung];
                    double.TryParse(MainStatSW.Text, out MSsw);
                    double.TryParse(MasterySW.Text, out Msw);
                    double.TryParse(CritSW.Text, out Csw);
                    double.TryParse(VersalitySW.Text, out Vsw);
                    double.TryParse(HasteSW.Text, out Hsw);
                }
            }
        }
        public void StatWeightZero()
        {
            MainStatSW.Text = 0.ToString();
            MasterySW.Text = 0.ToString();
            CritSW.Text = 0.ToString();
            VersalitySW.Text = 0.ToString();
            HasteSW.Text = 0.ToString();
        }
    }
}