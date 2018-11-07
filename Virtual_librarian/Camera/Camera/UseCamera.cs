using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using FilesFunctions;

namespace Camera
{
    public class UseCamera
    {
        public Capture Camera { get; set; }

        public UseCamera()
        {

        } 

        public void TurnOn()
        {
            if (Camera != null)
            {
                Camera.Dispose();
            }

            try
            {
                Camera = new Capture(0);
                Camera.Start();
            }
            catch (Exception exc)
            {
                FileIO.SaveException(System.IO.Directory.GetCurrentDirectory() + @"\errors.txt", exc.Message, exc.Source);
            }
        }

        public void TurnOff()
        {
            if (Camera != null)
            { 
                Camera.Dispose();
                Camera = null;
            }
        }
        
    }
}
