﻿using Spikes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spikes.Common
{
    public class DefaultSpike : ISpike
    {
        public string GetName()
        {
            return "Default spike";
        }

        public void Run()
        {
            // empty
        }
    }
}
