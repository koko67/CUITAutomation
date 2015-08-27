using Microsoft.VisualStudio.TestTools.UITesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Framework.Browser
{
    public sealed class BrowserManager
    {
        public  BrowserWindow Browser;

        private BrowserManager()
        {
            //Example
            //browser.ExecuteScript("return document.getElementById('btnID').click()");
        }

        public void Init()
        {
            Browser = BrowserWindow.Launch("http://localhost:41787");
            Browser.Maximized = true;
        }

        private static BrowserManager _instance;

        public static BrowserManager Instance
        {
            get 
            {
                if(_instance == null)
                {
                    _instance = new BrowserManager();
                }
                return _instance; 
            }
        }
        
    }
}
