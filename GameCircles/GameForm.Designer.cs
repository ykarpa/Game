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
            this.game_Panel = new System.Windows.Forms.Panel();
            this.ballTimer = new System.Windows.Forms.Timer(this.components);
            this.stopButton = new System.Windows.Forms.Button();
            this.continueButton = new System.Windows.Forms.Button();
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
            // game_Panel
            // 
            resources.ApplyResources(this.game_Panel, "game_Panel");
            this.game_Panel.Name = "game_Panel";
            // 
            // ballTimer
            // 
            this.ballTimer.Interval = 1000;
            this.ballTimer.Tick += new System.EventHandler(this.ballTimer_Tick);
            // 
            // StopButton
            // 
            this.stopButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.stopButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.stopButton.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.stopButton, "stopButton");
            this.stopButton.Name = "stopButton";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // continueButton
            // 
            this.continueButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.continueButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.continueButton.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.continueButton, "continueButton");
            this.continueButton.Name = "continueButton";
            this.continueButton.UseVisualStyleBackColor = false;
            this.continueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // GameForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.game_Panel);
            this.Controls.Add(this.recordLabel);
            this.Controls.Add(this.missedLabel);
            this.Controls.Add(this.scoreLabel);
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
        private Panel game_Panel;
        private System.Windows.Forms.Timer ballTimer;
        private Button stopButton;
        private Button continueButton;
    }
}