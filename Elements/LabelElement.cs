﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium; 

namespace HW_2_IntreductionInSelenium.Elements
{
    public class LabelElement : BaseElement
    {
        public LabelElement(By locator, String elementName) : base(locator, elementName)
        {
        }
    }
}
