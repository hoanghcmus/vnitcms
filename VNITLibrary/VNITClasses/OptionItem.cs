using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNITLibrary
{
    public class ItemOption
    {
        public int OptionValue { get; set; }
        public string OptionName { get; set; }
        public ItemOption() { }

        public ItemOption(int optionValue, string optionName)
        {
            this.OptionValue = optionValue;
            this.OptionName = optionName;
        }
    }
}
