using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;

namespace Virtual_librarian
{
    public partial class UCFaceScan : UserControl
    {
        public VideoCapture capture;

        private int numberOfSeconds = 3; //Per kiek sekundziu padarysim visas nuotraukas
        private static int numberOfImages = 5; //Kiek is viso reikes padaryti nuotrauku
        double intervalForCapture; //Kas kiek milisekundziu reiks daryti nuotrauka
        public List<Bitmap> images; //Cia bus visos padarytos nuotraukos, kurias veliau siusim i FaceAPI

        public Timer tmrForVideo;
        public Timer tmrForCapure;

        public UCFaceScan()
        {
            InitializeComponent();

            capture = new VideoCapture();

            images = new List<Bitmap>();
            tmrForVideo = new Timer();
            tmrForCapure = new Timer();
            intervalForCapture = Math.Truncate(((double)numberOfSeconds / (double)numberOfImages) * 1000);

            tmrForVideo.Interval = 40; //40 milisekundes - 25 frames per second
            tmrForCapure.Interval = System.Convert.ToInt32(intervalForCapture); //Dabar 0,6 sekundes

            tmrForVideo.Enabled = true;
            tmrForCapure.Enabled = true;

            tmrForVideo.Tick += TmrForVideo_Tick;
            tmrForCapure.Tick += TmrForCapure_Tick;

            pbarScanning.Maximum = numberOfImages;
        }

        private void TmrForCapure_Tick(object sender, EventArgs e)
        {
            if(images.Count == numberOfImages)
            {
                //tmrForVideo.Enabled = false; //Dabar video nesustos
                tmrForCapure.Enabled = false;

                showImages(); //Parodo padarytas nuotraukas - sito veliau nebereikes - testavimo tikslais
            }
            else
            {
                images.Add(showOneFrame());
                pbarScanning.Value += pbarScanning.Step;
            }
        }

        private void showImages() //Parodo padarytas nuotraukas - sito veliau nebereikes - testavimo tikslais
        {
            int kuriRodo = 0;

            Form formaParodymui = new Form();

            PictureBox nuotrauka = new PictureBox();
            nuotrauka.Height = formaParodymui.Height;
            nuotrauka.Width = formaParodymui.Width;
            nuotrauka.SizeMode = PictureBoxSizeMode.StretchImage;
            nuotrauka.Image = images[kuriRodo];

            Button toliau = new Button();
            toliau.Text = "Kita foto";
            toliau.Click += delegate
            {
                kuriRodo++;
                if (kuriRodo == 5)
                {
                    kuriRodo = 0;
                }
                nuotrauka.Image = images[kuriRodo];
            };

            formaParodymui.Controls.Add(nuotrauka);
            formaParodymui.Controls.Add(toliau);
            nuotrauka.SendToBack();

            formaParodymui.ShowDialog();
        }

        private void TmrForVideo_Tick(object sender, EventArgs e)
        {
            showOneFrame();
        }

        private Bitmap showOneFrame()
        {
            Bitmap image = capture.QueryFrame().Bitmap;
            picWebCam.Image = image;

            return image;
        }
    }
}
