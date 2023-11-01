namespace DatabaseManagementStudio
{
    public partial class MainForm : Form
    {
        private readonly DatabaseEngine.DatabaseEngine _databaseEngine;
        public MainForm()
        {
            InitializeComponent();
            _databaseEngine = new DatabaseEngine.DatabaseEngine();
        }


        private void NewDatabaseButton_Click(object sender, EventArgs e)
        {
            var notificationForm = new NotificationForm();
            var createDatabaseForm = new CreateDatabaseForm(_databaseEngine, notificationForm);
            createDatabaseForm.Show();
            createDatabaseForm.Owner = this;
            this.Visible = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ReviewButton_Click(object sender, EventArgs e)
        {
            var notificationForm = new NotificationForm();
            var reviewForm = new DatabasesListForm(_databaseEngine, notificationForm);
            reviewForm.Show();
            reviewForm.Owner = this;
            this.Visible = false;
        }
    }
}