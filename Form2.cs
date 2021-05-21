﻿using System;
using System.Windows.Forms;

namespace LostArkAutoLogin
{
    public partial class Form2 : Form
    {
        private Timer timer = new Timer(1000);
        private Timer mainTimer = new Timer(3000);

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string url, bool isNaver)
        {
            InitializeComponent();

            if (isNaver)
            {
                Width = 504;
                Height = 642;
            }
            else
            {
                Width = 650;
                Height = 560;
            }

            Browser.Navigate(url);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Browser.DocumentCompleted += Browser_DocumentCompleted;
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
        }
        
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (e.Url.ToString() == "https://lostark.game.onstove.com/Main")
                Close();
        }

        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (Browser.Url.ToString() == "https://lostark.game.onstove.com/Main")
                Close();
        }
    }
}