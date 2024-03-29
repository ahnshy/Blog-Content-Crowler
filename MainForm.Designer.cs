
using HtmlAgilityPack;
using System.Net;
using System.Text.RegularExpressions;

namespace Blog_Content_Crowler
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Blog-Content-Crowker";

            WebClient wc = new WebClient();
            //wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)"); // MSIE
            wc.Headers.Add("user-agent", "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 123.0.0.0 Safari / 537.36");

            wc.Encoding = System.Text.Encoding.UTF8;
            //string html = wc.DownloadString(@"https://blog.naver.com/ahnshy/223380673641");
            string html = wc.DownloadString(@"https://blog.naver.com/PostView.naver?blogId=ahnshy&logNo=223221850917&redirect=Dlog&widgetTypeCall=true&noTrackingCode=true&directAccess=false");

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            //var htmlNode = doc.DocumentNode.SelectNodes("//div[@id='postListBody']");
            var htmlNode = doc.DocumentNode.SelectNodes("//div[@class='se-main-container']");

            var html2 = doc.DocumentNode.SelectSingleNode("//div[@class='se-main-container']").OuterHtml;


            var text = doc.DocumentNode.SelectSingleNode("//div[@class='se-main-container']").InnerText;

            int a = 0;


            //var numNodes = htmlNode.("li");
            //foreach (var item in numNodes)
            {
                text = Regex.Replace(text, @"&lt;", "<");
                text = Regex.Replace(text, @"&gt;", ">");
            }
        }

        #endregion
    }
}

