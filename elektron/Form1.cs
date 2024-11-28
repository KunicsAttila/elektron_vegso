using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*A feladat hogy szimuláljuk ahogy az elektronok végigmennek a vezetéken. Az elektron az akkumulátor negatív feléről indul a pozitív felé. Az áramkörben van egy feszültésg szabályzó és egy fogyasztó. A feszültség szabályzóig konstans sebességgel haladnak az elektronok. A feszültség szabályzó az utána lévő részre beállítja az elektron sebességét.
Az akkumulátor 24 Voltos.
Az alapértelmezett feszültség érték 12 Volt amit egyesével lehet fel és le módosítani.
A maximális feszültség nem lehet nagyobb az akku feszültségénél. 
Miután egy elektron áthaladt a feszültség szabályzón, a sebessége változatlan marad.
A sebességet arányosan kell beállítani. Ha 12 Volton megy az elektron, akkor a 24 Voltos sebesség 50 százalékával kell haladnia.
A mozgás timer intervallumja fixen 16ms.
Van egy számláló ami visszajelzést nyújt arról hány elektron jutott vissza az akkuba.
Az elektronok fél másodpercenként jönnek létre*/


namespace elektron
{
    public partial class Form1 : Form
    {
        Timer elektronTimer = new Timer();
        int VoltSize = 12;
        int Xirany = 0;
        int Yirany = -1;
        int elektronSpeed = 0;
        int upVoltage = 24;
        int downVoltage = 1;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Feszultseg";
            Start();
        }
        void Start()
        {
            elektronTimer.Interval = 24;
            moveEvent();
            //FeszultsegEvent();
            elektronTimer.Start();
            //elektronTimer.Tick += elektronSpeed;

        }
        void moveEvent()
        {
            elektronTimer.Interval = 24;
            elektronTimer.Start();
            /*elektronTimer.Tick += (s, e) =>
            {
                buttonUp.Click += upVoltage;
                buttonDown.Click += downVoltage;
            };*/
        }
        /*void FeszultsegEvent()
        {
            upVolt();
            downVolt();
            eSpeed();
        }*/
        void eSpeed(object s, EventArgs e)
        {
            //  felfelé
            if (Xirany == 0 && Yirany == -1)
            {
                if (elektron.Top > alsoVezeto.Top + VoltSize)
                {
                    elektron.Top -= VoltSize;
                }
                else
                {
                    elektron.Top = alsoVezeto.Top - 2;
                    Xirany = -1;
                    Yirany = 0;
                }

            }
            //  lefelé 
            else if (Xirany == 0 && Yirany == 1)
            {
                if (elektron.Top < alsoVezeto.Bottom - elektron.Height - VoltSize)
                {
                    elektron.Top += VoltSize;
                }
                else
                {
                    elektron.Top = alsoVezeto.Bottom - elektron.Height + 2;
                    Xirany = 1;
                    Yirany = 0;
                }
            }

            //  balra
            else if (Xirany == -1 && Yirany == 0)
            {
                if (elektron.Left > felsoVezeto.Left + VoltSize)
                {
                    elektron.Left -= VoltSize;
                }
                else
                {
                    elektron.Left = felsoVezeto.Left - 2;
                    Xirany = 0;
                    Yirany = 1;
                    /*eSpeed += 1;
                    passedLabel.Text = $"Áthaladt elektron:: {eSpeed}";*/
                }
            }
            //  jobbra
            else if (Xirany == 1 && Yirany == 0)
            {
                if (elektron.Left < jobbVezeto.Right - elektron.Width - VoltSize)
                {
                    elektron.Left += VoltSize;
                    if (elektron.Left >= alsoVezeto.Right + 2)
                    {
                        elektron.Visible = false;
                    }
                }
                else
                {
                    elektron.Left = jobbVezeto.Right - elektron.Width + 2;
                    Xirany = 0;
                    Yirany = -1;
                    elektron.Visible = true;
                }
            }
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            if (VoltSize < 24)
            {
                VoltSize++;
                Feszmero.Text = VoltSize.ToString() + "V";
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            if (VoltSize > 1)
            {
                VoltSize--;
                Feszmero.Text = VoltSize.ToString() + "V";
            }
        }
    }
}
