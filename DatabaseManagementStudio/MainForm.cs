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
            CreateDatabaseForm createDatabaseForm = new CreateDatabaseForm(_databaseEngine);
            createDatabaseForm.Show();
            createDatabaseForm.Owner = this;
            this.Visible = false;
        }
    }
}