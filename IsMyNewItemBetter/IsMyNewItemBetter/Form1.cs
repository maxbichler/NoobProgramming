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
        public static double Ao = 0;
        public static double Mo = 0;
        public static double Co = 0;
        public static double Vo = 0;
        public static double Ho = 0;
        public static double resulto;

        // NEW
        public static double An = 0;
        public static double Mn = 0;
        public static double Cn = 0;
        public static double Vn = 0;
        public static double Hn = 0;
        public static double resultn;

        // KLASSEN ARRAY
        string[] klassen = { "Rogue", "Mage", "Priest", "Demon Hunter", "Hunter", "Monk", "Death Knight", "Warrior", "Gayadin", "Warlock", "Schaman" };
        string[] rogue = { "Assassination", "Outlaw", "Subtlety" };
        string[] priest = { "Holy", "Shadow", "Discipline" };

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
                Ao = double.Parse(MainStatOld.Text);
                Mo = double.Parse(MasteryOld.Text);
                Co = double.Parse(CritOld.Text);
                Vo = double.Parse(VersalityOld.Text);
                Ho = double.Parse(HasteOld.Text);
                resulto = Ao + (Mo * 0.84) + (Co * 0.68) + (Vo * 0.67) + (Ho * 0.46);
                Math.Round(resulto, 1);
                ResultOld.Text = resulto.ToString();

                // TEXTBOXEN EINLESEN NEW
                An = double.Parse(MainStatNew.Text);
                Mn = double.Parse(MasteryNew.Text);
                Cn = double.Parse(CritNew.Text);
                Vn = double.Parse(VersalityNew.Text);
                Hn = double.Parse(HasteNew.Text);
                resultn = An + (Mn * 0.84) + (Cn * 0.68) + (Vn * 0.67) + (Hn * 0.46);
                Math.Round(resultn, 1);
                ResultNew.Text = resultn.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
