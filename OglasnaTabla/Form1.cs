using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Text;
using System.Windows.Forms;

namespace OglasnaTabla
{
    //Treba da se obrati paznja za vanredne casove! Pomnozi trajanje Casova! i saberi sa odmorima! Nadji jednacinu za odmore!!!!
    public partial class Form1 : Form
    { 
        //Test1
        //DESKTOP VERZIJA
        int PocH;
        int PocM;

        public int PocH1;
        public int PocM1;

        public int PocH2;
        public int PocM2;

        public int trajanje1;
        public int trajanje2;

        public string VAZNO;

        int trajanje;

        DateTime vreme = DateTime.Now;

        int vremeH;

        int vremeM;

        bool redovan = true;

        //potprogram koji vraća redni broj trenutnog časa, parametri su pocetak nastave (sat i minut), trenutno vreme (sat i minut) i trajanje svakog časa
        public static int KolikoDoNastave (int PocetakSmeneH, int PocetakSmeneM, int VremeH, int VremeM)
        {
            int Smene = (PocetakSmeneH * 60 + PocetakSmeneM) - (VremeH * 60 + VremeM);
            return Smene;
        }
        public static int redniBrCasa(int pocNastaveH, int poceNastaveM, int vremeH, int vremeM, int trajanjeC, bool prov)
        {
            int minutaOdPocetka = vremeH * 60 + vremeM - pocNastaveH * 60 - poceNastaveM;//koliko je minuta proteklo do pocetka nastave
            if (prov==true)
            {
                if ((minutaOdPocetka >= 365) || (minutaOdPocetka < 0))
                {
                    return 0;
                }
                else if (minutaOdPocetka >= 320)
                {
                    return 7;// 7 cas je u toku
                }
                else if (minutaOdPocetka >= 270)
                {
                    return 6;
                }
                else if (minutaOdPocetka >= 220)
                {
                    return 5;
                }
                else if (minutaOdPocetka >= 165)
                {
                    return 4;
                }
                else if (minutaOdPocetka >= 115)
                {
                    return 3;
                }
                else if (minutaOdPocetka >= 50)
                {
                    return 2;
                }
                else if (minutaOdPocetka >= 0)
                {
                    return 1;
                }
                return 0;
            }
            else
            {
               // MessageBox.Show(" " + minutaOdPocetka + trajanjeC);
                if ((minutaOdPocetka >= ((trajanjeC * 6) + 45 + trajanjeC) || (minutaOdPocetka < 0)))
                {
                    return 0;
                }
                else if (minutaOdPocetka > ((trajanjeC * 6) + 45))
                {
                    return 7;// 7 cas je u toku
                }
                else if (minutaOdPocetka >= (trajanjeC * 5) + 40)
                {
                    return 6;
                }
                else if (minutaOdPocetka >= (trajanjeC * 4) + 35)
                {
                    return 5;
                }
                else if (minutaOdPocetka >= (trajanjeC * 3) + 30)
                {
                    return 4;
                }
                else if (minutaOdPocetka >= (trajanjeC * 2) + 10)
                {
                    return 3;
                }
                else if (minutaOdPocetka >= trajanjeC + 5)
                {
                    return 2;
                }
                else if (minutaOdPocetka >= 0)
                {
                    return 1;
                }
                return 0;
            }

            
        }

        //potprogram koji vraća koliko minuta je do sledećeg odmora, parametri su pocetak nastave (sat i minut), trenutno vreme (sat i minut) i trajanje svakog časa

        public static int KolikoDoCasa(int pocNastaveH, int poceNastaveM, int vremeH, int vremeM, int trajanjeC, bool provera)
        {
           
            int minutaOdPocetka = vremeH * 60 + vremeM - pocNastaveH * 60 - poceNastaveM;//koliko je minuta proteklo do pocetka nastave
            //MessageBox.Show(minutaOdPocetka.ToString());
            if (provera == true)
            {
                if ((minutaOdPocetka >= 365) || (minutaOdPocetka < 0))
                {
                    return -1;
                }
                else if (minutaOdPocetka >= 320)
                {
                   
                    return (365 - 5 - minutaOdPocetka) + 5; //Odmor izmedju 6 i 7 -> 5 min
                }
                else if (minutaOdPocetka >= 270)
                {
                   
                    return (320 - 5 - minutaOdPocetka) + 5;  //   Odmor izmedju 5 i 6 -> 5 min

                }
                else if (minutaOdPocetka >= 220)
                {
                    
                    return (270 - 5 - minutaOdPocetka) + 5;  //  Odmor izmedju 4 i 5 -> 10 min
                }
                else if (minutaOdPocetka >= 165)
                {
                    
                    return (220 - 10 - minutaOdPocetka) + 10;  //Odmor izmedju 3 i 4 -> 5 min
                }
                else if (minutaOdPocetka >= 115)
                {
                   
                    return (165 - 5 - minutaOdPocetka) + 5;   // Odmor izmedju 2 i 3 -> 20 min
                }
                else if (minutaOdPocetka >= 50)
                {
                    return (115 - 20 - minutaOdPocetka) + 20;  //Odmor izmedju 1 i 2 -> 5 min.
                }
                else if (minutaOdPocetka >= 0)
                {
                    return (50 - 5 - minutaOdPocetka) + 5;
                }
                return 0; 
            }
            else
            {
                // TESTIRANJE OBAVEZNO!!!
                if (((minutaOdPocetka >= ((trajanjeC * 6) + 45) + trajanjeC)) || (minutaOdPocetka < 0))
                {
                    return -1;
                }
                else if (minutaOdPocetka > ((trajanjeC * 6) + 45) && minutaOdPocetka < (((trajanjeC * 6) + 45) + trajanjeC))
                {

                    return ((trajanjeC * 7 + 50) - minutaOdPocetka); //Odmor izmedju 6 i 7 -> 5 min
                }
                else if (minutaOdPocetka >= (trajanjeC * 5) + 40)
                {

                    return ((trajanjeC * 6 + 45) - minutaOdPocetka);  //   Odmor izmedju 5 i 6 -> 5 min

                }
                else if (minutaOdPocetka >= (trajanjeC * 4) + 35)
                {

                    return ((trajanjeC * 5 + 40) - minutaOdPocetka);  //  Odmor izmedju 4 i 5 -> 10 min
                }
                else if (minutaOdPocetka >= (trajanjeC * 3) + 30)
                {
                    return ((trajanjeC * 4 +35)- minutaOdPocetka);  //Odmor izmedju 3 i 4 -> 20 min
                }
                else if (minutaOdPocetka >= (trajanjeC * 2) + 10)
                {
                    return ((trajanjeC * 3 +30)- minutaOdPocetka);   // Odmor izmedju 2 i 3 -> 5 min
                }
                else if (minutaOdPocetka >= trajanjeC + 5)
                {
                    return ((trajanjeC * 2 + 10)-minutaOdPocetka);  //Odmor izmedju 1 i 2 -> 5 min.
                }
                else if (minutaOdPocetka >= 0)
                {
                    return (trajanjeC + 5) - minutaOdPocetka;
                }
            }
            return 0;
        }
        public static int kolikoDoOdmora(int pocNAstaveH, int pocNAstaveM, int vremeH, int vremeM, int trajanje, bool provera)
        {
            int minutaodpocetka = vremeH * 60 + vremeM - (pocNAstaveH * 60 + pocNAstaveM);
            if (provera == true)
            {
                // REDOVNI CASOVI
                if (minutaodpocetka > 365 || minutaodpocetka < 0)
                {
                    return 0;
                }
                if (minutaodpocetka >= 320 && minutaodpocetka < 365)
                {
                    return 365 - minutaodpocetka;//7.cas
                }
                if (minutaodpocetka >= 270)
                {
                    return 315 - minutaodpocetka;
                }
                if (minutaodpocetka >= 220)
                {
                    return 265 - minutaodpocetka;
                }
                if (minutaodpocetka >= 165)
                {
                    return 210 - minutaodpocetka;
                }
                if (minutaodpocetka >= 115)
                {
                    return 160 - minutaodpocetka;
                }
                if (minutaodpocetka >= 50)
                {
                    return 95 - minutaodpocetka;
                }
                if (minutaodpocetka >= 0)
                {
                    return 45 - minutaodpocetka;
                }
            }
            else
            {
                // IZMENJENI CASOVI
                if (minutaodpocetka > 365 || minutaodpocetka < 0)
                {
                    return 0;
                }
                if (minutaodpocetka > ((trajanje*6)+ 45) && minutaodpocetka < (((trajanje * 6) + 45)+trajanje))
                {
                    return ((trajanje * 7) + 45) - minutaodpocetka;//7.cas
                }
                if (minutaodpocetka >= (trajanje*5)+40)   // 5-6
                {
                    return ((trajanje * 6) + 40) - minutaodpocetka;
                }
                if (minutaodpocetka >= (trajanje*4)+35) // 4-5
                {
                    return ((trajanje * 5) + 35) - minutaodpocetka;
                }
                if (minutaodpocetka >= (trajanje*3)+ 30) //3 - 4
                {
                    return ((trajanje * 4) + 30) - minutaodpocetka;
                }
                if (minutaodpocetka >= (trajanje*2) + 10)
                {
                    return ((trajanje * 3) + 10) - minutaodpocetka; //Prelazak izmedju drugog i treceg casa
                }
                if (minutaodpocetka >= trajanje+5)
                {
                    return ((trajanje*2)+5) - minutaodpocetka;
                }
                if (minutaodpocetka >= 0)
                {
                    return trajanje - minutaodpocetka;
                }
            }
            // Izmenjeno
            
            return 0;
        }
        bool oglas = false;
        public Form1()
        {
            InitializeComponent();
            label1.BackColor = System.Drawing.Color.Transparent;
            label2.BackColor = System.Drawing.Color.Transparent;
            label3.BackColor = System.Drawing.Color.Transparent;
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Hide();
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {  
            vreme = DateTime.Now;
            vremeH = vreme.Hour;
            vremeM = vreme.Minute;
            int test = vremeH * 60 + vremeM - (PocH * 60 + PocM);
            if (oglas == true)
            {
                label4.Show();
                label4.Left = (this.Size.Width - label4.Size.Width) / 2;
                label4.Text = "OBAVE[TEWE: \n" + VAZNO;
            }
            else
            {
                label4.Hide();
            }
            
            if (redovan == true)
            {
                if (vremeH < 14)
                {
                    PocH = 7;
                    PocM = 45;
                    trajanje = 45;
                }
                if ((vremeH >= 14)&&(vremeH<21))
                {
                    PocH = 14;
                    PocM = 0;
                    trajanje = 45;
                }
                if (kolikoDoOdmora(PocH, PocM, vremeH, vremeM, trajanje, redovan) > 0)
                {
                    label2.Left = (this.Size.Width - label2.Size.Width) / 2;
                    label2.Text = "U toku je " + redniBrCasa(PocH, PocM, vremeH, vremeM, trajanje, redovan) + ". ^as, molimo Vas za ti[inu. ^as se zavr[ava za " + kolikoDoOdmora(PocH, PocM, vremeH, vremeM, trajanje, redovan) + ". minuta";
                }
                else
                {
                    label2.Left = (this.Size.Width - label2.Size.Width) / 2;
                    if ((KolikoDoCasa(PocH, PocM, vremeH, vremeM, trajanje, redovan)==-1)&&(vremeH>8))
                    {
                        label2.Text = (redniBrCasa(PocH, PocM, vremeH, vremeM, trajanje, redovan) + 1) + ". ^as po^iwe za " + (KolikoDoNastave(14, 0, vremeH, vremeM) + ". minuta! U@ivajte u odmoru!");
                    }
                    else if ((KolikoDoCasa(PocH, PocM, vremeH, vremeM, trajanje, redovan) == -1) && (vremeH <= 7)) //Obavezno testirati!!!
                    {
                        label2.Text = (redniBrCasa(PocH, PocM, vremeH, vremeM, trajanje, redovan) + 1) + ". ^as po^iwe za " + (KolikoDoNastave(7, 45, vremeH, vremeM) + ". minuta! U@ivajte u odmoru!");
                    }
                    else
                    {
                        label2.Text = (redniBrCasa(PocH, PocM, vremeH, vremeM, trajanje, redovan) + 1) + ". ^as po^iwe za " + (KolikoDoCasa(PocH, PocM, vremeH, vremeM, trajanje, redovan) + ". minuta! U@ivajte u odmoru!");
                    }
                }
            }
            else
            {
                
                if ((vremeH < PocH1)||((vremeH<PocH2)&&(vremeH>PocH1)) || ((vremeH == PocH1) && (vremeM >= PocM1))||((vremeH == PocH1) && (vremeM < PocM1)))
                { 
                    
                   
                    PocH = PocH1;
                    PocM = PocM1;
                    trajanje = trajanje1;   
                }
                else //if ((vremeH > PocH2) || ((vremeH == PocH2)&&(vremeM>=PocM2))||(test>365))
                {
                    PocH = PocH2;
                    PocM = PocM2;
                    trajanje = trajanje2; 
                }
                if (kolikoDoOdmora(PocH, PocM, vremeH, vremeM, trajanje, redovan) > 0)
                {
                    label2.Text = "U toku je " + (redniBrCasa(PocH, PocM, vremeH, vremeM, trajanje, redovan)) + ". ^as, molimo Vas za ti[inu. ^as se zavr[ava za " + kolikoDoOdmora(PocH, PocM, vremeH, vremeM, trajanje, redovan) + ". minuta";
                    label2.Left = (this.Size.Width - label2.Size.Width) / 2;
                }
                else if (kolikoDoOdmora(PocH, PocM, vremeH, vremeM, trajanje, redovan) < 0)
                {
                        label2.Left = (this.Size.Width - label2.Size.Width) / 2;
                        label2.Text = (redniBrCasa(PocH, PocM, vremeH, vremeM, trajanje, redovan) + 1) + ". ^as po^iwe za " + (KolikoDoCasa(PocH, PocM, vremeH, vremeM, trajanje, redovan) + ". minuta! U@ivajte u odmoru!");
                }
                if (KolikoDoCasa(PocH, PocM, vremeH, vremeM, trajanje, redovan) == -1)
                {
                    label2.Left = (this.Size.Width - label2.Size.Width) / 2;
                    label2.Text = (redniBrCasa(PocH, PocM, vremeH, vremeM, trajanje, redovan) + 1) + ". ^as po^iwe za " + (KolikoDoNastave(PocH, PocM, vremeH, vremeM) + ". minuta! U@ivajte u odmoru!");

                }
            }
            label3.Text = vreme.Date.ToLongDateString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Fpodesavanje podesi = new Fpodesavanje();
            podesi.textBox7.Text = VAZNO;
            podesi.checkBox1.Checked = oglas;
            if (podesi.ShowDialog() == DialogResult.OK)
            {
                redovan = podesi.redovan;
                if (redovan==false)
                {
                    
                    PocH1 = podesi.pocH1;
                    PocM1 = podesi.pocM1;
                    PocH2 = podesi.pocH2;
                    PocM2 = podesi.pocM2;
                    trajanje1 = podesi.trajanje1;
                    trajanje2 = podesi.trajanje2;
                }
                if (podesi.obavesti == true)
                {
                    oglas = true;
                    VAZNO = podesi.Obavestenje;
                }
                else
                {
                    oglas = false;
                }
            }
            //MessageBox.Show("Test> " + PocH1 + " " + PocM1 + " " + PocH2 + " "+ PocM2 + " " +trajanje1 +" "+ trajanje2 + redovan);

            //ZADACI ZA SLEDECU SEKCIJU:
        }//NACI ODGOVARAJUCU FORMULU ZA POCETAK DRUGE SMENE U VANREDNOJ NASTAVI! Jedno od mogucih resenja:
         //1.Napraviti potprogram koji ce se pozvati kada se zavrse casovi!!!!!! - Najbolja ideja!
         //2. Napraviti labelu gde se upisuju vazna obavestenja
         //3. I najvaznjije - PRODUZENI CASOVI!
         //Postoji neki BAG? Pokusati da nadjes resenje! BAG se aktivira tako sto unesemo da je pocetak nastave u 14:00 traje 17 minuta, sadasnje vreme je 14:17 - program nece reagovati dok se ne promeni vrednost u satu!


    }
}
