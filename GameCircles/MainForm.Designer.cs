namespace GameCircles
{
    partial class MainForm
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
            this.StartButton = new System.Windows.Forms.Button();
            this.HowToPlayButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.PlayerRatingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.LightBlue;
            this.StartButton.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StartButton.Location = new System.Drawing.Point(525, 240);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(200, 64);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Розпочати";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // HowToPlayButton
            // 
            this.HowToPlayButton.BackColor = System.Drawing.Color.LightBlue;
            this.HowToPlayButton.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HowToPlayButton.Location = new System.Drawing.Point(525, 452);
            this.HowToPlayButton.Name = "HowToPlayButton";
            this.HowToPlayButton.Size = new System.Drawing.Size(200, 64);
            this.HowToPlayButton.TabIndex = 1;
            this.HowToPlayButton.Text = "Як грати";
            this.HowToPlayButton.UseVisualStyleBackColor = false;
            this.HowToPlayButton.Click += new System.EventHandler(this.HowToPlayButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Salmon;
            this.ExitButton.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ExitButton.Location = new System.Drawing.Point(525, 553);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(200, 64);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Вийти";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // PlayerRatingButton
            // 
            this.PlayerRatingButton.BackColor = System.Drawing.Color.LightBlue;
            this.PlayerRatingButton.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PlayerRatingButton.Location = new System.Drawing.Point(525, 349);
            this.PlayerRatingButton.Name = "PlayerRatingButton";
            this.PlayerRatingButton.Size = new System.Drawing.Size(200, 64);
            this.PlayerRatingButton.TabIndex = 3;
            this.PlayerRatingButton.Text = "Рейтинг гравців";
            this.PlayerRatingButton.UseVisualStyleBackColor = false;
            this.PlayerRatingButton.Click += new System.EventHandler(this.PlayerRatingButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(1232, 803);
            this.Controls.Add(this.PlayerRatingButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.HowToPlayButton);
            this.Controls.Add(this.StartButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Головне меню";
            this.ResumeLayout(false);

        }

        #endregion

        private Button StartButton;
        private Button HowToPlayButton;
        private Button ExitButton;
        private Button PlayerRatingButton;
    }
}