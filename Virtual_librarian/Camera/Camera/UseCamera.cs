using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;

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
            Camera = new Capture(0);
            Camera.Start();
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
