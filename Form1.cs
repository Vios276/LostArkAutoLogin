using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Timer = System.Timers.Timer;

namespace LostArkAutoLogin
{
    public partial class LostArkAutoLogin : Form
    {
        WebBrowser wb = new WebBrowser();

        private Timer timer = new Timer(1000);

        public LostArkAutoLogin()
        {
            InitializeComponent();

            SetWebbrowserVersion();
        }

        private void SetWebbrowserVersion()
        {
            if (Environment.Is64BitOperatingSystem) // 운영체제 종류 확인 (64비트)
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", Application.ProductName + ".exe", 11001);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", Application.ProductName + ".vshost.exe", 11001);
            }
            else
            {  //For 32 bit machine
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", Application.ProductName + ".exe", 11001);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", Application.ProductName + ".vshost.exe", 11001);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            KillStoveClient();
            wb.ScriptErrorsSuppressed = true;
            cbSnsType.SelectedIndex = 0;
            timer.AutoReset = true;
            wb.DocumentCompleted += Wb_DocumentCompleted;
            wb.Navigating += Wb_Navigating;
            timer.Elapsed += Timer_Elapsed;
        }

        private void Wb_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            Console.Write(wb.Document.Cookie);
        }

        private void KillStoveClient()
        {
            var processList = Process.GetProcessesByName("STOVE");
            if (processList.Length > 0)
            {
                processList.First().Kill();
            }
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

        private void Wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (wb.Url.ToString() != "https://lostark.game.onstove.com/Main")
                return;

            var buttonList = wb.Document.GetElementsByTagName("button");
            foreach (HtmlElement htmlElement in buttonList)
            {
                if (htmlElement.InnerText.Equals("게임시작"))
                {
                    htmlElement.InvokeMember("Click");
                }
            }
        }

        private void btnAutoLogin_Click(object sender, EventArgs e)
        {
            string snsType = string.Empty;

            switch ((string)cbSnsType.SelectedItem)
            {
                case "구글":
                    snsType = "google";
                    break;
                case "페이스북":
                    snsType = "facebook";
                    break;
                case "네이버":
                    snsType = "naver";
                    break;
                case "트위터":
                    snsType = "twitter";
                    break;
            }

            var encodeRedirectUrl = "https://lostark.game.onstove.com/Main";
            var reqParams = "redirect_url=" + encodeRedirectUrl;
            reqParams += "&inflow_path=LOST_ARK&game_no=45&show_play_button=N&callback_url=https://member.onstove.com/oauth/" + snsType + "/signin&forever=false";
            var baseUrl = "https://member.onstove.com/oauth/" + snsType + "/code?" + reqParams;

            if (((Button)sender).Name.Equals("btnAutoLogin"))
            {
                var popup = new Form2(baseUrl, snsType.Equals("naver"));
                popup.Show(this);
            }
            else
            {
                wb.Navigate(baseUrl);
                timer.Start();
            }
        }
    }
}
