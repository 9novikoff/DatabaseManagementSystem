namespace DatabaseManagementStudio
{
    partial class DatabasesListForm
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
            DatabasesList = new ListBox();
            CloseButton = new Button();
            SuspendLayout();
            // 
            // DatabasesList
            // 
            DatabasesList.BackColor = Color.LightGray;
            DatabasesList.FormattingEnabled = true;
            DatabasesList.ItemHeight = 20;
            DatabasesList.Location = new Point(12, 12);
            DatabasesList.Name = "DatabasesList";
            DatabasesList.Size = new Size(1238, 584);
            DatabasesList.TabIndex = 0;
            DatabasesList.DoubleClick += DatabasesList_DoubleClick;
            // 
            // CloseButton
            // 
            CloseButton.BackColor = Color.LightGray;
            CloseButton.Location = new Point(12, 611);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(200, 50);
            CloseButton.TabIndex = 1;
            CloseButton.Text = "Cancel";
            CloseButton.UseVisualStyleBackColor = false;
            CloseButton.Click += CloseButton_Click;
            // 
            // DatabasesListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(1262, 673);
            Controls.Add(CloseButton);
            Controls.Add(DatabasesList);
            Name = "DatabasesListForm";
            Text = "DatabasesListForm";
            ResumeLayout(false);
        }

        #endregion

        private ListBox DatabasesList;
        private Button CloseButton;
    }
}