﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera
{
    public class RecognisedPersonEventArgs : EventArgs
    {
        public string recognisedID { get; private set; }

        public RecognisedPersonEventArgs(string recognisedID)
        {
            this.recognisedID = recognisedID;
        }
    }
}
