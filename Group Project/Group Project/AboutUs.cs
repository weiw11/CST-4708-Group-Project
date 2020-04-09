using System;
using System.Windows.Forms;

namespace Group_Project
{
    public partial class AboutUs : Form
    {
        private readonly String aboutUsInfo = "QuillComics is an online comics book retail store. We offer a variety of comic books published by well-known publishers such as Marvel Comics and DC Comics. Our comic books are always up to date and in brand new condition.";
        private readonly String missionInfo = "To provide our customers with a large variety of quality, affordable, and up-to-date comic books. We greatly value our customers, that is why we offer our mechandises at a lower price than most comic book retailers.";

        public AboutUs()
        {
            InitializeComponent();
            lbAboutUsInfo.Text = aboutUsInfo;
            lbMissionInfo.Text = missionInfo;
        }

        private void BTNgoBack_Click(object sender, EventArgs e)
        {
            Global.ShowLogin();
            this.Close();
        }
    }
}