﻿using OpenQA.Selenium;

namespace AddressBookTests
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected IWebDriver driver;
        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }
    } 
}