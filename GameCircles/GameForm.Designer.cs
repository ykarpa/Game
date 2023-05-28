namespace GameCircles
{
    partial class GameForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.scoreLabel = new System.Windows.Forms.Label();
            this.missedLabel = new System.Windows.Forms.Label();
            this.recordLabel = new System.Windows.Forms.Label();
            this.gamePanel = new System.Windows.Forms.Panel();
            this.ballTimer = new System.Windows.Forms.Timer(this.components);
            this.pausedButton = new System.Windows.Forms.Button();
            this.endButton = new System.Windows.Forms.Button();
            this.restartButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // scoreLabel
            // 
            resources.ApplyResources(this.scoreLabel, "scoreLabel");
            this.scoreLabel.Name = "scoreLabel";
            // 
            // missedLabel
            // 
            resources.ApplyResources(this.missedLabel, "missedLabel");
            this.missedLabel.Name = "missedLabel";
            // 
            // recordLabel
            // 
            resources.ApplyResources(this.recordLabel, "recordLabel");
            this.recordLabel.Name = "recordLabel";
            // 
            // gamePanel
            // 
            resources.ApplyResources(this.gamePanel, "gamePanel");
            this.gamePanel.Name = "gamePanel";
            // 
            // ballTimer
            // 
            this.ballTimer.Interval = 1000;
            this.ballTimer.Tick += new System.EventHandler(this.ballTimer_Tick);
            // 
            // pausedButton
            // 
            this.pausedButton.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pausedButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkSeaGreen;
            this.pausedButton.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.pausedButton, "pausedButton");
            this.pausedButton.Name = "pausedButton";
            this.pausedButton.UseVisualStyleBackColor = false;
            this.pausedButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // endButton
            // 
            this.endButton.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.endButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkSeaGreen;
            this.endButton.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.endButton, "endButton");
            this.endButton.Name = "endButton";
            this.endButton.UseVisualStyleBackColor = false;
            this.endButton.Click += new System.EventHandler(this.endButton_Click);
            // 
            // restartButton
            // 
            this.restartButton.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.restartButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkSeaGreen;
            this.restartButton.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.restartButton, "restartButton");
            this.restartButton.Name = "restartButton";
            this.restartButton.UseVisualStyleBackColor = false;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.AntiqueWhite;
            resources.ApplyResources(this.BackButton, "BackButton");
            this.BackButton.FlatAppearance.BorderSize = 0;
            this.BackButton.Name = "BackButton";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // GameForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.endButton);
            this.Controls.Add(this.pausedButton);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.recordLabel);
            this.Controls.Add(this.missedLabel);
            this.Controls.Add(this.scoreLabel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label scoreLabel;
        private Label missedLabel;
        private Label recordLabel;
        private Panel gamePanel;
        private System.Windows.Forms.Timer ballTimer;
        private Button pausedButton;
        private Button endButton;
        private Button restartButton;
        private Button BackButton;
    }
}