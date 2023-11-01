namespace DatabaseManagementStudio
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button3 = new Button();
            button2 = new Button();
            NewDatabaseButton = new Button();
            SuspendLayout();
            // 
            // button3
            // 
            button3.BackColor = Color.LightGray;
            button3.ForeColor = Color.Black;
            button3.Location = new Point(12, 124);
            button3.Name = "button3";
            button3.Size = new Size(200, 50);
            button3.TabIndex = 8;
            button3.Text = "Load database";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.LightGray;
            button2.ForeColor = Color.Black;
            button2.Location = new Point(12, 68);
            button2.Name = "button2";
            button2.Size = new Size(200, 50);
            button2.TabIndex = 7;
            button2.Text = "Review available databases";
            button2.UseVisualStyleBackColor = false;
            // 
            // NewDatabaseButton
            // 
            NewDatabaseButton.BackColor = Color.LightGray;
            NewDatabaseButton.ForeColor = Color.Black;
            NewDatabaseButton.Location = new Point(12, 12);
            NewDatabaseButton.Name = "NewDatabaseButton";
            NewDatabaseButton.Size = new Size(200, 50);
            NewDatabaseButton.TabIndex = 6;
            NewDatabaseButton.Text = "New database";
            NewDatabaseButton.UseVisualStyleBackColor = false;
            NewDatabaseButton.Click += NewDatabaseButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(1262, 673);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(NewDatabaseButton);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            Text = "DatabaseManagementStudio";
            ResumeLayout(false);
        }

        #endregion
        private TextBox textBox1;
        private Button button3;
        private Button button2;
        private Button NewDatabaseButton;
    }
}