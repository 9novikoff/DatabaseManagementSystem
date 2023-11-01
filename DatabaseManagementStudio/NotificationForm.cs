using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseManagementStudio
{
    public partial class NotificationForm : Form
    {
        public NotificationForm()
        {
            InitializeComponent();
        }

        public void Notify(string message)
        {
            SetNotification(message);
            this.Visible = true;
        }

        private void SetNotification(string message)
        {
            NotificationLabel.Text = message;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
