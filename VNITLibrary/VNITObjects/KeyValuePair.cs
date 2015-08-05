using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNITLibrary
{
    public class KeyValuePair
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public KeyValuePair()
        {
            Key = String.Empty;
            Value = String.Empty;
        }
    }
}
