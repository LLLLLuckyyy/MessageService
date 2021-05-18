using ExtraClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses
{
    public class LookThroughPOST
    {
        public int CountOfMessages { get; set; }

        public IEnumerable<LookThroughGET> Messages { get; set; }
    }
}
