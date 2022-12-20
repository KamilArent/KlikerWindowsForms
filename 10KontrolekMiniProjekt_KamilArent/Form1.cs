namespace _10KontrolekMiniProjekt_KamilArent
{
    public partial class Form1 : Form
    {
        //inicjalizacja zmiennych, œcie¿ka muzyki i wiadomoœæ pocz¹tkowa//
        int kasa, barvalue, cenapracm, cenasklepm, cenafabm;
        double kasadouble, mpwartosc, mswartosc, mfwartosc;
        int pracownicy, sklepiki, fabryki;
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\muzyka.wav");
        public Form1()
        {
            InitializeComponent();
            kasa = 0;
            pracownicy = 0;
            sklepiki = 0;
            fabryki = 0;
            barvalue = 0;
            cenapracm = 50;
            mpwartosc = 1;
            cenasklepm = 500;
            mswartosc = 1;
            cenafabm = 5000;
            mfwartosc = 1;
            string message = "Aplikacja któr¹ otworzy³eœ to kliker.\nJej celem jest zdobycie 250 000 waluty poprzez klikanie oraz kupowanie Ÿróde³ dochodów.\nPowodzenia!";
            string title = "Witaj!";
            MessageBox.Show(message, title);
        }
        //inicialzacja zmiennych koniec, œcie¿ka muzyki i wiadomoœæ pocz¹tkowa//
        //Uaktualnianie napisów//
        private void UpdateLabels()
        {
            labelmonety.Text = "Iloœæ posiadanych monet: " + kasa.ToString();
            label1.Text = "Posiadane monety: " + "\n" + kasa.ToString();
            label8.Text = "Iloœæ zatrudnionych pracowników: " + pracownicy.ToString() + "/10";
            label9.Text = "Aktualny mno¿nik: " + mpwartosc.ToString() + "/10";
            labelCenaPracownikMnoznik.Text = "Cena: " + cenapracm.ToString();
            label12.Text = "Iloœæ posiadanych sklepów: " + sklepiki.ToString() + "/10"; 
            label13.Text = "Aktualny mno¿nik: " + mswartosc.ToString() + "/10";
            labelCenaSklepMnoznik.Text = "Cena: " + cenasklepm.ToString();
            label18.Text = "Iloœæ posiadanych fabryk: " + fabryki.ToString() + "/10";
            label19.Text = "Aktualny mno¿nik: " + mfwartosc.ToString() + "/10";
            labelCenaFabrykaMnoznik.Text = "Cena: " + cenafabm.ToString();          
        }

        private void czy100bar()
        {
            if (kasa <= 250000)
            {
                kasadouble = kasa;
                barvalue = Convert.ToInt32((kasadouble / 250000) * 100);
                progressBar.Value = barvalue;

            }
            else progressBar.Value = 100;

        }
        
        //Uaktualnianie napisów koniec//
        //1 strona (kliker)//
        private void klikaj_Click_1(object sender, EventArgs e)
        {
            if (kasa < 1000 && !klikajzamnie.Checked) kasa++;
            else if (kasa >= 1000 && kasa < 10000 && !klikajzamnie.Checked) kasa += 10;
            else if (kasa >= 10000 && !klikajzamnie.Checked) kasa += 100;
            UpdateLabels();
        }
        private void bia³yToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabPage1.BackColor = Color.White;
            tabPage2.BackColor = Color.White;
            menuStrip1.BackColor = Color.White;
        }

        private void onToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player.Play();
        }

        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void resetGryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Czy na pewno chcesz zresetowaæ grê?\n Usunie to ca³y twój postêp!";
            string title = "UWAGA!";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                kasa = 0;
                pracownicy = 0;
                sklepiki = 0;
                fabryki = 0;
                progressBar.Value = 0;
                cenapracm = 50;
                mpwartosc = 1;
                cenasklepm = 500;
                mswartosc = 1;
                cenafabm = 5000;
                mfwartosc = 1;
                labelPracownikCena.Font = new Font(labelPracownikCena.Font, FontStyle.Regular);
                labelCenaPracownikMnoznik.Font = new Font(labelCenaPracownikMnoznik.Font, FontStyle.Regular);
                labelCenaSklep.Font = new Font(labelCenaSklep.Font, FontStyle.Regular);
                labelCenaSklepMnoznik.Font = new Font(labelCenaSklepMnoznik.Font, FontStyle.Regular);
                labelCenaFab.Font = new Font(labelCenaFab.Font, FontStyle.Regular);
                labelCenaFabrykaMnoznik.Font = new Font(labelCenaFabrykaMnoznik.Font, FontStyle.Regular);
            }
            else
            {
                kasa += 0;
            }
        }

        private void wyjscieZGryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void szaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabPage1.BackColor = Color.LightGray;
            tabPage2.BackColor = Color.LightGray;
            menuStrip1.BackColor = Color.LightGray;
        }

        private void jasnoNiebieskiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabPage1.BackColor = Color.LightSkyBlue;
            tabPage2.BackColor = Color.LightSkyBlue;
            menuStrip1.BackColor = Color.LightSkyBlue;
        }   

        //1 strona koniec//
        //Timery//   
        private void Glowny_Tick(object sender, EventArgs e)
        {
            kasa += Convert.ToInt32(pracownicy * mpwartosc);
            kasa += Convert.ToInt32(sklepiki * 5 * mswartosc);
            kasa += Convert.ToInt32(fabryki * 50 * mfwartosc);
            if (pracownicy == 10) labelPracownikCena.Font = new Font(labelPracownikCena.Font, FontStyle.Strikeout);
            if (mpwartosc == 10) labelCenaPracownikMnoznik.Font = new Font(labelCenaPracownikMnoznik.Font, FontStyle.Strikeout);
            if (sklepiki == 10) labelCenaSklep.Font = new Font(labelCenaSklep.Font, FontStyle.Strikeout);
            if (mswartosc == 10) labelCenaSklepMnoznik.Font = new Font(labelCenaSklepMnoznik.Font, FontStyle.Strikeout);
            if (fabryki == 10) labelCenaFab.Font = new Font(labelCenaFab.Font, FontStyle.Strikeout);
            if (mfwartosc == 10) labelCenaFabrykaMnoznik.Font = new Font(labelCenaFabrykaMnoznik.Font, FontStyle.Strikeout);
            UpdateLabels();
        }
        
        private void autoKlik_Tick(object sender, EventArgs e)
        {
            if (klikajzamnie.Checked)
            {
                kasa++;
                UpdateLabels();
            }
        }

        private void czy100_Tick_1(object sender, EventArgs e)
        {
            czy100bar();
            if (progressBar.Value == 100)
            {
                czy100.Enabled = false;
                string message = "Gratulacje!\nUkoñczy³eœ grê!\nCzy chcia³byœ graæ dalej?";
                string title = "Gratulacje!";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    kasa += 0;
                }
                else
                {
                    this.Close();
                }
            }
        }

        //timery koniec//
        //2 strona (sklep)//
        private void kupPracownik_Click(object sender, EventArgs e)
        {
            if (kasa >= 10 && pracownicy < 10)
            {
                kasa -= 10;
                pracownicy += 1;
                UpdateLabels();
            }
        }

        private void pracownikMnoznik_Click(object sender, EventArgs e)
        {
            if (kasa >= cenapracm && pracownicy > 0 && mpwartosc == 1)
            {
                mpwartosc += 0.5;
                cenapracm += 50;
                kasa -= 50;
                UpdateLabels();
            }
            else if (kasa >= cenapracm && pracownicy > 0 && mpwartosc < 9)
            {
                kasa -= cenapracm;
                mpwartosc += 1.5;
                cenapracm += 50;
                UpdateLabels();
            }
            else if (kasa >= cenapracm && pracownicy > 0 && mpwartosc == 9)
            {
                kasa -= cenapracm;
                mpwartosc += 1;
                cenapracm += 50;
                UpdateLabels();
            }
        }

        private void kupSklep_Click(object sender, EventArgs e)
        {
            if (kasa >= 100 && sklepiki < 10)
            {
                kasa -= 100;
                sklepiki += 1;
                UpdateLabels();
            }
        }

        private void sklepMnoznik_Click(object sender, EventArgs e)
        {
            if (kasa >= cenasklepm && sklepiki > 0 && mswartosc == 1)
            {
                mswartosc += 0.5;
                cenasklepm += 500;
                kasa -= 500;
                UpdateLabels();
            }
            else if (kasa >= cenasklepm && sklepiki > 0 && mswartosc < 9)
            {
                kasa -= cenasklepm;
                mswartosc += 1.5;
                cenasklepm += 500;
                UpdateLabels();
            }
            else if (kasa >= cenasklepm && sklepiki > 0 && mswartosc == 9)
            {
                kasa -= cenasklepm;
                mswartosc += 1;
                cenasklepm += 500;
                UpdateLabels();
            }
        }

        private void kupFabryka_Click(object sender, EventArgs e)
        {
            if (kasa >= 1000 && fabryki < 10)
            {
                kasa -= 1000;
                fabryki += 1;
                UpdateLabels();
            }
        }

        private void fabrykaMnoznik_Click(object sender, EventArgs e)
        {
            if (kasa >= cenafabm && fabryki > 0 && mfwartosc == 1)
            {
                mfwartosc += 0.5;
                cenafabm += 5000;
                kasa -= 500;
                UpdateLabels();
            }
            else if (kasa >= cenafabm && fabryki > 0 && mfwartosc < 9)
            {
                kasa -= cenafabm;
                mfwartosc += 1.5;
                cenafabm += 5000;
                UpdateLabels();
            }
            else if (kasa >= cenafabm && fabryki > 0 && mfwartosc == 9)
            {
                kasa -= cenafabm;
                mfwartosc += 1;
                cenafabm += 5000;
                UpdateLabels();
            }
        }


        //2 strona (sklep) koniec//
    }
}