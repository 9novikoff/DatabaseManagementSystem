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
    public partial class CreateDatabaseForm : Form
    {
        DatabaseEngine.DatabaseEngine _databaseEngine;
        public CreateDatabaseForm(DatabaseEngine.DatabaseEngine engine)
        {
            InitializeComponent();
            _databaseEngine = engine;
        }

        private void CreateDatabaseButton_Click(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Owner.Visible = true;
            this.Close();
        }
    }
}
