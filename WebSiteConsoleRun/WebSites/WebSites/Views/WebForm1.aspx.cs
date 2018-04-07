using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace WebSites.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.WorkingDirectory = @"C:\Users\Developer\Desktop\ProtoType\WebSiteConsoleRun\RunConsoleTest\RunConsoleTest\bin\Debug";
            processStartInfo.FileName = "RunConsoleTest.exe";
            processStartInfo.Arguments = " RC000001;RC000002";

            Process.Start(processStartInfo);
        }

    }
}