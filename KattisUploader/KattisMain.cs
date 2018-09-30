using KattisUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
/*
* [user]
username: mark-wardell
token: aa14d4dd381062429ac55d28c90b65b7715dfe30726ad37847557216cf6261df

[kattis]
loginurl: https://open.kattis.com/login
submissionurl: https://open.kattis.com/submit
C,
C#,
C++,
C++,
C++,
C#,
C++,
Go,
C++,
Haskell,
Java,
JavaScript,
Objective-C,
Pascal,
PHP,
Prolog,
Python,
Ruby
*/
namespace KattisUploader
{
    public partial class KattisMain : Form
    {
        private List<string> languages = new List<string>()
        {
            "C",
            "C#",
            "C++",
            "C++",
            "C++",
            "C#",
            "C++",
            "Go",
            "C++",
            "Haskell",
            "Java",
            "JavaScript",
            "Objective-C",
            "Pascal",
            "PHP",
            "Prolog",
            "Python",
            "Ruby"
       };
        KattisRSS kRSS ;
        public KattisMain()
        {
            InitializeComponent();
        }

        private void KattisMain_Load(object sender, EventArgs e)
        {

            lbLanguages.DataSource = languages;
            lbLanguages.SelectedIndex = languages.IndexOf("C#");

            XElement kattisElement = XElement.Load(@"..\..\KattisRSS.xml");
            kRSS = new KattisRSS(kattisElement);
            cbKattisIDS.DataSource = kRSS.Keys.ToList();
            cbKattisIDS.DisplayMember = "ID";
            
            
   

        }
    }
}
