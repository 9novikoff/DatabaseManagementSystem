namespace DatabaseManagementStudio
{
    partial class NotificationForm
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
            CloseButton = new Button();
            NotificationLabel = new Label();
            SuspendLayout();
            // 
            // CloseButton
            // 
            CloseButton.BackColor = Color.LightGray;
            CloseButton.Location = new Point(45, 113);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(200, 50);
            CloseButton.TabIndex = 0;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = false;
            CloseButton.Click += CloseButton_Click;
            // 
            // NotificationLabel
            // 
            NotificationLabel.AutoSize = true;
            NotificationLabel.Location = new Point(45, 9);
            NotificationLabel.Name = "NotificationLabel";
            NotificationLabel.Size = new Size(29, 20);
            NotificationLabel.TabIndex = 1;
            NotificationLabel.Text = "OK";
            // 
            // NotificationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(290, 175);
            Controls.Add(NotificationLabel);
            Controls.Add(CloseButton);
            Name = "NotificationForm";
            Text = "NotificationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CloseButton;
        private Label NotificationLabel;
    }
}