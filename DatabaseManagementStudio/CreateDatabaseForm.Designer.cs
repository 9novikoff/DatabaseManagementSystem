namespace DatabaseManagementStudio
{
    partial class CreateDatabaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DatabaseNameLabel = new Label();
            DatabaseNameTextBox = new TextBox();
            CreateDatabaseButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // DatabaseNameLabel
            // 
            DatabaseNameLabel.AutoSize = true;
            DatabaseNameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            DatabaseNameLabel.Location = new Point(12, 9);
            DatabaseNameLabel.Name = "DatabaseNameLabel";
            DatabaseNameLabel.Size = new Size(113, 20);
            DatabaseNameLabel.TabIndex = 15;
            DatabaseNameLabel.Text = "Database name";
            // 
            // DatabaseNameTextBox
            // 
            DatabaseNameTextBox.Location = new Point(12, 32);
            DatabaseNameTextBox.Name = "DatabaseNameTextBox";
            DatabaseNameTextBox.Size = new Size(520, 27);
            DatabaseNameTextBox.TabIndex = 16;
            // 
            // CreateDatabaseButton
            // 
            CreateDatabaseButton.BackColor = Color.LightGray;
            CreateDatabaseButton.Location = new Point(12, 611);
            CreateDatabaseButton.Name = "CreateDatabaseButton";
            CreateDatabaseButton.Size = new Size(200, 50);
            CreateDatabaseButton.TabIndex = 17;
            CreateDatabaseButton.Text = "Create";
            CreateDatabaseButton.UseVisualStyleBackColor = false;
            CreateDatabaseButton.Click += CreateDatabaseButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.BackColor = Color.LightGray;
            CancelButton.Location = new Point(218, 611);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(200, 50);
            CancelButton.TabIndex = 18;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = false;
            CancelButton.Click += CancelButton_Click;
            // 
            // CreateDatabaseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(1262, 673);
            Controls.Add(CancelButton);
            Controls.Add(CreateDatabaseButton);
            Controls.Add(DatabaseNameTextBox);
            Controls.Add(DatabaseNameLabel);
            Name = "CreateDatabaseForm";
            Text = "CreateDatabaseForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button backButton;
        private Label DatabaseNameLabel;
        private TextBox DatabaseNameTextBox;
        private Button CreateDatabaseButton;
        private Button CancelButton;
    }
}