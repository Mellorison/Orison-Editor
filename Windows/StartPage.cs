using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace OrisonEditor.Windows
{
    public partial class StartPage : UserControl
    {
        private const int MAX_TWEETS = 6;

        public StartPage()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            //Recent projects
            Orison.CheckRecentProjects();
            for (int i = 0; i < Properties.Settings.Default.RecentProjects.Count; i++)
            {
                LinkLabel link = new LinkLabel();
                link.Location = new Point(4, 24 + (i * 20));
                link.LinkColor = Color.Red;
                link.Font = new Font(FontFamily.GenericMonospace, 10);
                link.Size = new Size(172, 16);
                link.Text = Properties.Settings.Default.RecentProjectNames[i];
                link.Name = Properties.Settings.Default.RecentProjects[i];
                link.Click += delegate(object sender, EventArgs e) { Orison.LoadProject(link.Name); };
                recentPanel.Controls.Add(link);
            }

            //Twitter feed
            WebClient twitter = new WebClient();
            twitter.DownloadStringCompleted += new DownloadStringCompletedEventHandler(twitter_DownloadStringCompleted);
            twitter.DownloadStringAsync(new Uri(@"http://api.twitter.com/1/statuses/user_timeline.xml?screen_name=OrisonEditor"));

            //Browser
            webBrowser.Url = new Uri(Path.Combine(Orison.ProgramDirectory, "Content", "changelog.html"));
        }

        void twitter_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(e.Result);

                List<string> tweets = new List<string>();
                foreach (XmlElement el in xml.GetElementsByTagName("status"))
                {
                    if (el["text"].InnerText[0] != '@')
                    {
                        tweets.Add(el["text"].InnerText);
                        if (tweets.Count >= MAX_TWEETS)
                            break;
                    }
                }

                int addY = 10;
                foreach (var s in tweets)
                {
                    Label label = new Label();
                    label.Text = s;
                    label.Location = new Point(4, 24 + addY);
                    label.Font = new Font(FontFamily.GenericMonospace, 10);
                    label.TextAlign = ContentAlignment.TopLeft;
                    label.AutoSize = true;
                    label.MaximumSize = new Size(172, 600);
                    label.MinimumSize = new Size(172, 10);
                    twitterPanel.Controls.Add(label);

                    addY += label.Size.Height + 10;
                }
            }
            catch
            {
                Controls.Remove(twitterPanel);
            }
        }

        private void donateButton_Click(object sender, EventArgs e)
        {
            Orison.DonationLink();
        }

        private void websiteButton_Click(object sender, EventArgs e)
        {
            Orison.WebsiteLink();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
