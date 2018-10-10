using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Resim Dosyaları|" + "*.bmp;*.jpg;*.gif;*.wmf;*.tif;*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = null;
                pictureBox3.Image = null;
                pictureBox4.Image = null;
                pictureBox5.Image = null;
                pictureBox6.Image = null;
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap grey = Ortalama(image);

            pictureBox2.Image = grey;
        }

        private Bitmap Ortalama(Bitmap orta)
        {
            for(int i =0; i< orta.Width;i++)
            {
                for(int j =0; j< orta.Height;j++)
                {
                    int deger = (orta.GetPixel(i, j).R + orta.GetPixel(i, j).G + orta.GetPixel(i, j).B)/3;

                    Color renk;
                    renk = Color.FromArgb(deger,deger,deger);

                    orta.SetPixel(i, j, renk);

                }
            }
            return orta;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap grey = BT709(image);

            pictureBox3.Image = grey;
        }

        private Bitmap BT709(Bitmap bt)
        {
            Bitmap greyscale = new Bitmap(bt.Width, bt.Height);
            for (int x = 0; x < bt.Width; x++)
            {
                for (int y = 0; y < bt.Height; y++)
                {
                    Color pixelColor = bt.GetPixel(x, y);
                    int grey = (int)(pixelColor.R * 0.2125 + pixelColor.G * 0.7154 + pixelColor.B * 0.072);
                    greyscale.SetPixel(x, y, Color.FromArgb(pixelColor.A, grey, grey, grey));
                }
            }
            return greyscale;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap grey = Luma(image);

            pictureBox4.Image = grey;
        }

        private Bitmap Luma(Bitmap input)
        {
            Bitmap greyscale = new Bitmap(input.Width, input.Height);
            for (int x = 0; x < input.Width; x++)
            {
                for (int y = 0; y < input.Height; y++)
                {
                    Color pixelColor = input.GetPixel(x, y);
                    int grey = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    greyscale.SetPixel(x, y, Color.FromArgb(pixelColor.A, grey, grey, grey));
                }
            }
            return greyscale;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap gri = Aciklik(image);

            pictureBox5.Image = gri;
        }

        private Bitmap Aciklik(Bitmap bmp)
        {
            Bitmap greyscale = new Bitmap(bmp.Width, bmp.Height);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);

                    int grey = (int)(pixelColor.R | pixelColor.G | pixelColor.B);
                    greyscale.SetPixel(x, y, Color.FromArgb(pixelColor.A, grey, grey, grey));
                }
            }
            return greyscale;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap gri = Kanal(image);

            pictureBox6.Image = gri;
        }

        private Bitmap Kanal(Bitmap bmp)
        {
            Bitmap greyscale = new Bitmap(bmp.Width, bmp.Height);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);
                    int a = 0;
                    if (pixelColor.R > pixelColor.G & pixelColor.R > pixelColor.B)
                        a = pixelColor.R;
                    if (pixelColor.G > pixelColor.R & pixelColor.G > pixelColor.B)
                        a = pixelColor.G;
                    if (pixelColor.B > pixelColor.R & pixelColor.B > pixelColor.G)
                        a = pixelColor.B;
                    int b = 0;
                    if (pixelColor.R < pixelColor.G & pixelColor.R < pixelColor.B)
                        b = pixelColor.R;
                    if (pixelColor.G < pixelColor.R & pixelColor.G < pixelColor.B)
                        b = pixelColor.G;
                    if (pixelColor.B < pixelColor.R & pixelColor.B < pixelColor.G)
                        b = pixelColor.B;

                    int grey = (int)((a + b) / 2);

                    greyscale.SetPixel(x, y, Color.FromArgb(pixelColor.A, grey, grey, grey));
                }
            }
            return greyscale;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap bit = new Bitmap(pictureBox2.Image);
            string kayit1 = @"C:\Users\Baybars\Desktop\Ortalama Deger.png";
            bit.Save(kayit1);
            Bitmap biti = new Bitmap(pictureBox3.Image);
            string kayit2 = @"C:\Users\Baybars\Desktop\BT-709.png";
            biti.Save(kayit2);
            Bitmap bitin = new Bitmap(pictureBox4.Image);
            string kayit3 = @"C:\Users\Baybars\Desktop\Luma Yöntemi.png";
            bitin.Save(kayit3);
            Bitmap bitini = new Bitmap(pictureBox5.Image);
            string kayit4 = @"C:\Users\Baybars\Desktop\Açıklık Yöntemi.png";
            bitini.Save(kayit4);
            Bitmap bitinin = new Bitmap(pictureBox6.Image);
            string kayit5 = @"C:\Users\Baybars\Desktop\Kanal Çıkarımı.png";
            bitinin.Save(kayit5);
        }
    }
}
