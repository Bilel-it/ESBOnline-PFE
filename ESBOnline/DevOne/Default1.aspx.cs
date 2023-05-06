using System;

namespace DevOne
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Success_Click(object sender, EventArgs e)
        {
            MessageBox1.ShowSuccess("Success, page processed.", 5000);
        }

        protected void Error_Click(object sender, EventArgs e)
        {
            MessageBox2.ShowError("Error, page can not be process because server offline.", 5000);
        }

        protected void Warning_Click(object sender, EventArgs e)
        {
            MessageBox1.ShowWarning("Warning, found error in data.", 5000);
        }

        protected void Information_Click(object sender, EventArgs e)
        {
            MessageBox2.ShowInfo("Information, you have set the date to next month.", 5000);
        }
    }
}
