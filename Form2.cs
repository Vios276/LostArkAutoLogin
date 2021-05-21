using System;
using System.Diagnostics;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

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
            Browser.ScriptErrorsSuppressed = true;
            Browser.DocumentCompleted += Browser_DocumentCompleted;
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
        }
        
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var processList = Process.GetProcessesByName("STOVE");
            if (processList.Length > 0)
            {
                Application.ExitThread();
                Environment.Exit(0);
            }
        }
        
        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (Browser.Url.ToString() == "https://lostark.game.onstove.com/Main")
            {
                var buttonList = Browser.Document.GetElementsByTagName("button");
                foreach (HtmlElement htmlElement in buttonList)
                {
                    if (htmlElement.InnerText.Equals("게임시작"))
                    {
                        htmlElement.InvokeMember("Click");
                    }
                }
            }
        }
    }
}