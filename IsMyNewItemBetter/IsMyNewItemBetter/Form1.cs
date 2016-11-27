using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsMyNewItemBetter
{
    public partial class Form1 : Form
    {
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

        // KLASSEN ARRAY
        string[] klassen = { "Rogue", "Mage", "Priest", "Demon Hunter", "Hunter", "Monk", "Death Knight", "Warrior", "Paladin", "Warlock", "Schaman", "Druid" };
        string[] rogue = { "Assassination", "Outlaw", "Subtlety" };
        string[] priest = { "Holy", "Shadow", "Discipline" };
        string[] demonHunter = { "Havoc", "Vengeance" };
        string[] warlock = { "Affliction", "Demonology", "Destruction" };
        string[] paladin = { "Holy", "Protection", "Retribution" };
        string[] warrior = { "Arms", "Fury", "Protection" };
        string[] hunter = { "Marksmanship", "Survival", "Beast Mastery"};
        string[] monk = { "Brewmaster", "Mistweaver", "Windwalker" };
        string[] deathKnight = { "Unholy", "Frost", "Blood" };
        string[] mage = { "Arcan", "Frost", "Fire" };
        string[] schaman = { "Elemental", "Restoration", "Enhancement" };
        string[] druid = { "Restoration", "Balance", "Feral", "Guardian" };

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

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // TEXTBOXEN EINLESEN OLD
                double.TryParse(MainStatOld.Text,out MSo);
                double.TryParse(MasteryOld.Text, out Mo);
                double.TryParse(CritOld.Text, out Co);
                double.TryParse(VersalityOld.Text, out Vo);
                double.TryParse(HasteOld.Text, out Ho);
                resulto = MSo + (Mo * 0.84) + (Co * 0.68) + (Vo * 0.67) + (Ho * 0.46);
                Math.Round(resulto, 1);
                ResultOld.Text = resulto.ToString();

                // TEXTBOXEN EINLESEN NEW
                double.TryParse(MainStatNew.Text, out MSn);
                double.TryParse(MasteryNew.Text, out Mn);
                double.TryParse(CritNew.Text, out Cn);
                double.TryParse(VersalityNew.Text, out Vn);
                double.TryParse(HasteNew.Text, out Hn);
                resultn = MSn + (Mn * 0.84) + (Cn * 0.68) + (Vn * 0.67) + (Hn * 0.46);
                Math.Round(resultn, 1);
                ResultNew.Text = resultn.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // FÜLLE SPEC COMBOBOX BETREFFEND DER KLASSE
        private void KlassenCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (KlassenCB.SelectedIndex)
            {
                case 0: SpecCB.DataSource = rogue; break;
                case 1: SpecCB.DataSource = mage; break;
                case 2: SpecCB.DataSource = priest; break;
                case 3: SpecCB.DataSource = demonHunter; break;
                case 4: SpecCB.DataSource = hunter; break;
                case 5: SpecCB.DataSource = monk; break;
                case 6: SpecCB.DataSource = deathKnight; break;
                case 7: SpecCB.DataSource = warrior; break;
                case 8: SpecCB.DataSource = paladin; break;
                case 9: SpecCB.DataSource = warlock; break;
                case 10: SpecCB.DataSource = schaman; break;
                case 11: SpecCB.DataSource = druid; break;
                default: SpecCB.DataSource = rogue; break;
            }
        }

        // FÜLLE ENTSPRECHENDEN STAT WEIGHTS IN DIE TEXTBOXEN
        private void SpecCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (SpecCB.SelectedIndex)
            {
                case 0: MainStatSW.Text = 1.ToString(); break;
                
                default:
                    break;
            }
        }
    }
}
