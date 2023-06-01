namespace GameCircles
{
    partial class RatingForm
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
            this.ratingPanel = new System.Windows.Forms.Panel();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.topNLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ratingPanel
            // 
            this.ratingPanel.AutoScroll = true;
            this.ratingPanel.Location = new System.Drawing.Point(10, 140);
            this.ratingPanel.Name = "ratingPanel";
            this.ratingPanel.Size = new System.Drawing.Size(610, 443);
            this.ratingPanel.TabIndex = 0;
            // 
            // comboBox
            // 
            this.comboBox.BackColor = System.Drawing.Color.LightBlue;
            this.comboBox.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "Топ 5 гравців",
            "Топ 10 гравців",
            "Топ 20 гравців",
            "Топ 50 гравців",
            "Топ 100 гравців",
            "Топ 1000 гравців"});
            this.comboBox.Location = new System.Drawing.Point(27, 24);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(206, 28);
            this.comboBox.TabIndex = 1;
            this.comboBox.Text = "Виберіть топ N гравців";
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            this.comboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboBox_KeyPress);
            // 
            // topNLabel
            // 
            this.topNLabel.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.topNLabel.Location = new System.Drawing.Point(0, 80);
            this.topNLabel.Name = "topNLabel";
            this.topNLabel.Size = new System.Drawing.Size(630, 30);
            this.topNLabel.TabIndex = 2;
            this.topNLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RatingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(632, 603);
            this.Controls.Add(this.topNLabel);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.ratingPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RatingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Рейтинг гравців";
            this.Load += new System.EventHandler(this.RatingForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel ratingPanel;
        private ComboBox comboBox;
        private Label topNLabel;
    }
}