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

namespace LostArkAutoLogin
{
    public partial class LostArkAutoLogin : Form
    {
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
            cbSnsType.SelectedIndex = 0;
        }

        private void KillStoveClient()
        {
            var processList = Process.GetProcessesByName("STOVE");
            if (processList.Length > 0)
            {
                processList.First().Kill();
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

            var popup = new Form2(baseUrl, snsType.Equals("naver"));
            var result = popup.ShowDialog(this);

            if (result == DialogResult.OK)
            {

            }
        }
    }
}
