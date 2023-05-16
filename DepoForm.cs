using System;
using System.Windows.Forms;

namespace MediaBazzar
{
    public partial class DepoForm : Form
    {
        public DepoForm()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            Hide();
            form.Show();
        }
    }
}
