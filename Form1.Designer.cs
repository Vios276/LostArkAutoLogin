
namespace LostArkAutoLogin
{
    partial class LostArkAutoLogin
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbSnsType = new System.Windows.Forms.ComboBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnAutoLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbSnsType
            // 
            this.cbSnsType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSnsType.FormattingEnabled = true;
            this.cbSnsType.Items.AddRange(new object[] {
            "구글",
            "페이스북",
            "네이버",
            "트위터"});
            this.cbSnsType.Location = new System.Drawing.Point(122, 126);
            this.cbSnsType.Name = "cbSnsType";
            this.cbSnsType.Size = new System.Drawing.Size(121, 20);
            this.cbSnsType.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(249, 124);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "로그인";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnAutoLogin_Click);
            // 
            // btnAutoLogin
            // 
            this.btnAutoLogin.Location = new System.Drawing.Point(330, 124);
            this.btnAutoLogin.Name = "btnAutoLogin";
            this.btnAutoLogin.Size = new System.Drawing.Size(75, 23);
            this.btnAutoLogin.TabIndex = 6;
            this.btnAutoLogin.Text = "설정";
            this.btnAutoLogin.UseVisualStyleBackColor = true;
            this.btnAutoLogin.Click += new System.EventHandler(this.btnAutoLogin_Click);
            // 
            // LostArkAutoLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 298);
            this.Controls.Add(this.btnAutoLogin);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.cbSnsType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LostArkAutoLogin";
            this.Text = "LostArk AutoLogin";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSnsType;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnAutoLogin;
    }
}

