using ProTester.Utilities;
using System;
using System.Windows.Forms;


namespace Pro_Tester_UI
{
    public partial class ApplicationTest : Form
    {
        public ApplicationTest()
        {

            InitializeComponent();

        }

        private void btn_execute_Click(object sender, EventArgs e)
        {
            if (txt_testCaseID.Text != "")
            {
                bool testResult = ProTester.Driver.Script.RunScript(txt_testCaseID.Text, chk_Priority.Checked);
                ProTester.Driver.Script.DriverEnd();
                MessageBox.Show(txt_testCaseID.Text + "--Test Status--" + testResult);
                this.Close();
            }
            else
            {
                MessageBox.Show("Enter TestCase ID");
            }
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            ProTester.Driver.Script.DriverEnd();
            this.Close();
        }
    }
}
