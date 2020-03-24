using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iks_oks
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen p = new Pen(Color.Blue, 5);


        string prvi_igrac, drugi_igrac;
        //matrica u koju spremam sto je u kojem polju 0->prazno, 1-> krizic, 2-> kruzic 
        int[,] iks_oks = new int[3, 3] {{0,0,0},{0,0,0},{0,0,0}};
        //igrac_na_redu -> 1 je prvi_igrac, 2 je drugi_igrac
        //rez_prvi/rez_drugi su rezultati koje prikazujem u labelama
        int igrac_na_redu = 1, rez_prvi = 0, rez_drugi = 0;

        class Circle
        {
            int r;
            public Circle()
            {
                r = 50;
            }
            public void draw(Graphics g, Pen p, int x, int y)
            {
                g.DrawEllipse(p, x, y, r, r);
            }
        }

        class Iks
        {
            PointF x1;
            PointF x2;
            PointF y1;
            PointF y2;

            public Iks()
            {
                x1 = new PointF(15, 15);
                y1 = new PointF(65, 65);
                x2 = new PointF(65, 15);
                y2 = new PointF(15, 65);

            }
            public void draw(Graphics g, Pen p)
            {
                g.DrawLine(p, x1,y1);
                g.DrawLine(p, x2, y2);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            switchToLogInterface();
        }

        

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            g = pictureBox1.CreateGraphics();

            if (iks_oks[0,0] == 0 && igrac_na_redu == 1)
            {
                p.Color = Color.Red;
                Iks x = new Iks();
                x.draw(g, p);
                igrac_na_redu = 2;
                iks_oks[0, 0] = 1;
                lbl_naRedu.Text = drugi_igrac;
            }
            if (iks_oks[0, 0] == 0 && igrac_na_redu == 2)
            {
                p.Color = Color.Blue;
                Circle c = new Circle();
                c.draw(g, p, 15, 15);
                igrac_na_redu = 1;
                iks_oks[0, 0] = 2;
                lbl_naRedu.Text = prvi_igrac;
            }

            //provjeri_pobjedu(1) provjerava ako je krizic pobjedio, (2)->kruzic
            if (provjeri_pobjedu(1))
            {;
                zabiljezi_pobjedu(1);
            }
            else if (provjeri_pobjedu(2))
            {
                zabiljezi_pobjedu(2);
            }
            else if(provjeri_pobjedu(1) == false && provjeri_pobjedu(2) == false && provjeri_koliko_je_polja_popunjeno() == 9)
            {
                zabiljezi_nerjeseno();
            }
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            g = pictureBox2.CreateGraphics();

            if (iks_oks[0, 1] == 0 && igrac_na_redu == 1)
            {
                p.Color = Color.Red;
                Iks x = new Iks();
                x.draw(g, p);
                igrac_na_redu = 2;
                iks_oks[0, 1] = 1;
                lbl_naRedu.Text = drugi_igrac;
            }
            if (iks_oks[0, 1] == 0 && igrac_na_redu == 2)
            {
                p.Color = Color.Blue;
                Circle c = new Circle();
                c.draw(g, p, 15, 15);
                igrac_na_redu = 1;
                iks_oks[0, 1] = 2;
                lbl_naRedu.Text = prvi_igrac;
            }

            if (provjeri_pobjedu(1))
            {
                zabiljezi_pobjedu(1);
            }
            else if (provjeri_pobjedu(2))
            {
                zabiljezi_pobjedu(2);
            }
            else if (provjeri_pobjedu(1) == false && provjeri_pobjedu(2) == false && provjeri_koliko_je_polja_popunjeno() == 9)
            {
                zabiljezi_nerjeseno();
            }
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            g = pictureBox3.CreateGraphics();

            if (iks_oks[0, 2] == 0 && igrac_na_redu == 1)
            {
                p.Color = Color.Red;
                Iks x = new Iks();
                x.draw(g, p);
                igrac_na_redu = 2;
                iks_oks[0, 2] = 1;
                lbl_naRedu.Text = drugi_igrac;
            }
            if (iks_oks[0, 2] == 0 && igrac_na_redu == 2)
            {
                p.Color = Color.Blue;
                Circle c = new Circle();
                c.draw(g, p, 15, 15);
                igrac_na_redu = 1;
                iks_oks[0, 2] = 2;
                lbl_naRedu.Text = prvi_igrac;
            }

            if (provjeri_pobjedu(1))
            {
                zabiljezi_pobjedu(1);
            }
            else if (provjeri_pobjedu(2))
            {
                zabiljezi_pobjedu(2);
            }
            else if (provjeri_pobjedu(1) == false && provjeri_pobjedu(2) == false && provjeri_koliko_je_polja_popunjeno() == 9)
            {
                zabiljezi_nerjeseno();
            }
        }

        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            g = pictureBox4.CreateGraphics();

            if (iks_oks[1, 0] == 0 && igrac_na_redu == 1)
            {
                p.Color = Color.Red;
                Iks x = new Iks();
                x.draw(g, p);
                igrac_na_redu = 2;
                iks_oks[1, 0] = 1;
                lbl_naRedu.Text = drugi_igrac;
            }
            if (iks_oks[1, 0] == 0 && igrac_na_redu == 2)
            {
                p.Color = Color.Blue;
                Circle c = new Circle();
                c.draw(g, p, 15, 15);
                igrac_na_redu = 1;
                iks_oks[1, 0] = 2;
                lbl_naRedu.Text = prvi_igrac;
            }

            if (provjeri_pobjedu(1))
            {
                zabiljezi_pobjedu(1);
            }
            else if (provjeri_pobjedu(2))
            {
                zabiljezi_pobjedu(2);
            }
            else if (provjeri_pobjedu(1) == false && provjeri_pobjedu(2) == false && provjeri_koliko_je_polja_popunjeno() == 9)
            {
                zabiljezi_nerjeseno();
            }
        }

        private void pictureBox5_MouseUp(object sender, MouseEventArgs e)
        {
            g = pictureBox5.CreateGraphics();

            if (iks_oks[1, 1] == 0 && igrac_na_redu == 1)
            {
                p.Color = Color.Red;
                Iks x = new Iks();
                x.draw(g, p);
                igrac_na_redu = 2;
                iks_oks[1, 1] = 1;
                lbl_naRedu.Text = drugi_igrac;
            }
            if (iks_oks[1, 1] == 0 && igrac_na_redu == 2)
            {
                p.Color = Color.Blue;
                Circle c = new Circle();
                c.draw(g, p, 15, 15);
                igrac_na_redu = 1;
                iks_oks[1, 1] = 2;
                lbl_naRedu.Text = prvi_igrac;
            }

            if (provjeri_pobjedu(1))
            {
                zabiljezi_pobjedu(1);
            }
            else if (provjeri_pobjedu(2))
            {
                zabiljezi_pobjedu(2);
            }
            else if (provjeri_pobjedu(1) == false && provjeri_pobjedu(2) == false && provjeri_koliko_je_polja_popunjeno() == 9)
            {
                zabiljezi_nerjeseno();
            }
        }

        private void pictureBox6_MouseUp(object sender, MouseEventArgs e)
        {
            g = pictureBox6.CreateGraphics();

            if (iks_oks[1, 2] == 0 && igrac_na_redu == 1)
            {
                p.Color = Color.Red;
                Iks x = new Iks();
                x.draw(g, p);
                igrac_na_redu = 2;
                iks_oks[1, 2] = 1;
                lbl_naRedu.Text = drugi_igrac;
            }
            if (iks_oks[1, 2] == 0 && igrac_na_redu == 2)
            {
                p.Color = Color.Blue;
                Circle c = new Circle();
                c.draw(g, p, 15, 15);
                igrac_na_redu = 1;
                iks_oks[1, 2] = 2;
                lbl_naRedu.Text = prvi_igrac;
            }

            if (provjeri_pobjedu(1))
            {
                zabiljezi_pobjedu(1);
            }
            else if (provjeri_pobjedu(2))
            {
                zabiljezi_pobjedu(2);
            }
            else if (provjeri_pobjedu(1) == false && provjeri_pobjedu(2) == false && provjeri_koliko_je_polja_popunjeno() == 9)
            {
                zabiljezi_nerjeseno();
            }
        }

        private void pictureBox7_MouseUp(object sender, MouseEventArgs e)
        {
            g = pictureBox7.CreateGraphics();

            if (iks_oks[2, 0] == 0 && igrac_na_redu == 1)
            {
                p.Color = Color.Red;
                Iks x = new Iks();
                x.draw(g, p);
                igrac_na_redu = 2;
                iks_oks[2, 0] = 1;
                lbl_naRedu.Text = drugi_igrac;
            }
            if (iks_oks[2, 0] == 0 && igrac_na_redu == 2)
            {
                p.Color = Color.Blue;
                Circle c = new Circle();
                c.draw(g, p, 15, 15);
                igrac_na_redu = 1;
                iks_oks[2, 0] = 2;
                lbl_naRedu.Text = prvi_igrac;
            }

            if (provjeri_pobjedu(1))
            {
                zabiljezi_pobjedu(1);
            }
            else if (provjeri_pobjedu(2))
            {
                zabiljezi_pobjedu(2);
            }
            else if (provjeri_pobjedu(1) == false && provjeri_pobjedu(2) == false && provjeri_koliko_je_polja_popunjeno() == 9)
            {
                zabiljezi_nerjeseno();
            }
        }

        private void pictureBox8_MouseUp(object sender, MouseEventArgs e)
        {
            g = pictureBox8.CreateGraphics();

            if (iks_oks[2, 1] == 0 && igrac_na_redu == 1)
            {
                p.Color = Color.Red;
                Iks x = new Iks();
                x.draw(g, p);
                igrac_na_redu = 2;
                iks_oks[2, 1] = 1;
                lbl_naRedu.Text = drugi_igrac;
            }
            if (iks_oks[2, 1] == 0 && igrac_na_redu == 2)
            {
                p.Color = Color.Blue;
                Circle c = new Circle();
                c.draw(g, p, 15, 15);
                igrac_na_redu = 1;
                iks_oks[2, 1] = 2;
                lbl_naRedu.Text = prvi_igrac;
            }

            if (provjeri_pobjedu(1))
            {
                zabiljezi_pobjedu(1);
            }
            else if (provjeri_pobjedu(2))
            {
                zabiljezi_pobjedu(2);
            }
            else if (provjeri_pobjedu(1) == false && provjeri_pobjedu(2) == false && provjeri_koliko_je_polja_popunjeno() == 9)
            {
                zabiljezi_nerjeseno();
            }
        }

        private void pictureBox9_MouseUp(object sender, MouseEventArgs e)
        {
            g = pictureBox9.CreateGraphics();

            if (iks_oks[2, 2] == 0 && igrac_na_redu == 1)
            {
                p.Color = Color.Red;
                Iks x = new Iks();
                x.draw(g, p);
                igrac_na_redu = 2;
                iks_oks[2, 2] = 1;
                lbl_naRedu.Text = drugi_igrac;
            }
            if (iks_oks[2, 2] == 0 && igrac_na_redu == 2)
            {
                p.Color = Color.Blue;
                Circle c = new Circle();
                c.draw(g, p, 15, 15);
                igrac_na_redu = 1;
                iks_oks[2, 2] = 2;
                lbl_naRedu.Text = prvi_igrac;
            }

            if (provjeri_pobjedu(1))
            {
                zabiljezi_pobjedu(1);
            }
            else if (provjeri_pobjedu(2))
            {
                zabiljezi_pobjedu(2);
            }
            else if (provjeri_pobjedu(1) == false && provjeri_pobjedu(2) == false && provjeri_koliko_je_polja_popunjeno() == 9)
            {
                zabiljezi_nerjeseno();
            }
        }


        //Sve se resetira i ponovo se unose imena
        private void btnNovaIgra_Click(object sender, EventArgs e)
        {
            switchToLogInterface();
            resetiraj_matricu();
            igrac_na_redu = 1;
            rez_prvi = 0;
            rez_drugi = 0;
            resetiraj_matricu();
            izbrisi_polja();
        }

        //Ako se ne unesu imena, bit ce X i O
        private void btnIgraj_Click(object sender, EventArgs e)
        {
            prvi_igrac = txtB_prvi.Text;
            drugi_igrac = txtB_drugi.Text;
            if(prvi_igrac == "")
            {
                prvi_igrac = "X";
            }
            if (drugi_igrac == "")
            {
                drugi_igrac = "O";
            }
            lblPrvi_igrac.Text = prvi_igrac;
            lblDrugi_igrac.Text = drugi_igrac;
            lbl_Rez1.Text = rez_prvi.ToString();
            lbl_Rez2.Text = rez_prvi.ToString();
            switchToGameInterface();
            txtB_prvi.Clear();
            txtB_drugi.Clear();
            lbl_naRedu.Text = prvi_igrac;
        }






        //Funkcije
        void resetiraj_matricu(){
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    iks_oks[i, j] = 0;
                }
            }
        }

        int provjeri_koliko_je_polja_popunjeno()
        {
            int popunjeno = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(iks_oks[i,j] != 0)
                    {
                        popunjeno++;
                    }
                }
            }
            return popunjeno;
        }

        bool provjeri_pobjedu(int lik)
        {
            //x==1, O==2
            if(iks_oks[0,0] == lik && iks_oks[0, 1] == lik && iks_oks[0, 2] == lik)
            {
                return true; 
            }
            if (iks_oks[1, 0] == lik && iks_oks[1, 1] == lik && iks_oks[1, 2] == lik)
            {
                return true;
            }
            if (iks_oks[2, 0] == lik && iks_oks[2, 1] == lik && iks_oks[2, 2] == lik)
            {
                return true;
            }
            if (iks_oks[0, 0] == lik && iks_oks[1, 0] == lik && iks_oks[2, 0] == lik)
            {
                return true;
            }
            if (iks_oks[0, 1] == lik && iks_oks[1, 1] == lik && iks_oks[2, 1] == lik)
            {
                return true;
            }
            if (iks_oks[0, 2] == lik && iks_oks[1, 2] == lik && iks_oks[2, 2] == lik)
            {
                return true;
            }
            if (iks_oks[0, 0] == lik && iks_oks[1, 1] == lik && iks_oks[2, 2] == lik)
            {
                return true;
            }
            if (iks_oks[0, 2] == lik && iks_oks[1, 1] == lik && iks_oks[2, 0] == lik)
            {
                return true;
            }
            return false;
        }

        /*Igrac koji je izgubio igra prvi u sljedecoj rundi*/
        void zabiljezi_pobjedu(int igrac)
        {
            if(igrac == 1)
            {
                igrac_na_redu = 2;
                rez_prvi++;
                MessageBox.Show("Pobjedio je " + prvi_igrac + " (Križić)!");
                lbl_Rez1.Text = (rez_prvi).ToString();
            }
            if(igrac == 2)
            {
                igrac_na_redu = 1;
                rez_drugi++;
                MessageBox.Show("Pobjedio je " + drugi_igrac + " (Kružić)!");
                lbl_Rez2.Text = (rez_drugi).ToString();
            }
            izbrisi_polja();
            resetiraj_matricu();
        }
        

        /*Ako je nerijeseno, igrac koji je zadnji igrao prvi je na redu u sljedecoj rundi (posljednji koji je izgubio)*/
        void zabiljezi_nerjeseno()
        {
            MessageBox.Show("Neriješeno...");
            izbrisi_polja();
            resetiraj_matricu();

            if(igrac_na_redu == 1)
            {
                igrac_na_redu = 2;
            }
            else
            {
                igrac_na_redu = 1;
            }
            
        }

        void izbrisi_polja()
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;
            pictureBox7.Image = null;
            pictureBox8.Image = null;
            pictureBox9.Image = null;
        }

        void switchToLogInterface()
        {
            pictureBox1.Hide();
            pictureBox1.Enabled = false;
            pictureBox2.Hide();
            pictureBox2.Enabled = false;
            pictureBox3.Hide();
            pictureBox3.Enabled = false;
            pictureBox4.Hide();
            pictureBox4.Enabled = false;
            pictureBox5.Hide();
            pictureBox5.Enabled = false;
            pictureBox6.Hide();
            pictureBox6.Enabled = false;
            pictureBox7.Hide();
            pictureBox7.Enabled = false;
            pictureBox8.Hide();
            pictureBox8.Enabled = false;
            pictureBox9.Hide();
            pictureBox9.Enabled = false;
            btnNovaIgra.Hide();
            btnNovaIgra.Enabled = false;
            lblPrvi_igrac.Hide();
            lblDrugi_igrac.Hide();
            lbl_naRedu.Hide();
            lbl_Rez1.Hide();
            lbl_Rez2.Hide();
            label2.Hide();
            btnIgraj.Show();
            btnIgraj.Enabled = true;
            lbl_prvi.Show();
            lbl_drugi.Show();
            txtB_prvi.Show();
            txtB_prvi.Enabled = true;
            txtB_drugi.Show();
            txtB_drugi.Enabled = true;
        }

        void switchToGameInterface()
        {
            pictureBox1.Show();
            pictureBox1.Enabled = true;
            pictureBox2.Show();
            pictureBox2.Enabled = true;
            pictureBox3.Show();
            pictureBox3.Enabled = true;
            pictureBox4.Show();
            pictureBox4.Enabled = true;
            pictureBox5.Show();
            pictureBox5.Enabled = true;
            pictureBox6.Show();
            pictureBox6.Enabled = true;
            pictureBox7.Show();
            pictureBox7.Enabled = true;
            pictureBox8.Show();
            pictureBox8.Enabled = true;
            pictureBox9.Show();
            pictureBox9.Enabled = true;
            btnNovaIgra.Show();
            btnNovaIgra.Enabled = true;
            lblPrvi_igrac.Show();
            lblDrugi_igrac.Show();
            lbl_naRedu.Show();
            lbl_Rez1.Show();
            lbl_Rez2.Show();
            label2.Show();
            btnIgraj.Hide();
            btnIgraj.Enabled = false;
            lbl_prvi.Hide();
            lbl_drugi.Hide();
            txtB_prvi.Hide();
            txtB_prvi.Enabled = false;
            txtB_drugi.Hide();
            txtB_drugi.Enabled = false;
        }
    }
}
