namespace Homework_Wars_External_Tool
{
    partial class HomeworkWarsTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeworkWarsTool));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PlayerBox = new System.Windows.Forms.CheckedListBox();
            this.EnemyBox = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ChangeBox = new System.Windows.Forms.RichTextBox();
            this.Button = new System.Windows.Forms.Button();
            this.Description = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("OCR A Extended", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(87, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Homework Wars";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(158, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "External Tool";
            // 
            // PlayerBox
            // 
            this.PlayerBox.CheckOnClick = true;
            this.PlayerBox.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerBox.FormattingEnabled = true;
            this.PlayerBox.Items.AddRange(new object[] {
            "Character Health",
            "Character Strength",
            "Character Defense",
            "Character Sprite"});
            this.PlayerBox.Location = new System.Drawing.Point(25, 133);
            this.PlayerBox.Name = "PlayerBox";
            this.PlayerBox.Size = new System.Drawing.Size(193, 60);
            this.PlayerBox.TabIndex = 2;
            this.PlayerBox.ThreeDCheckBoxes = true;
            // 
            // EnemyBox
            // 
            this.EnemyBox.CheckOnClick = true;
            this.EnemyBox.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnemyBox.FormattingEnabled = true;
            this.EnemyBox.Items.AddRange(new object[] {
            "Enemy Health",
            "Enemy Strength",
            "Enemy Defense",
            "Enemy Sprite"});
            this.EnemyBox.Location = new System.Drawing.Point(254, 133);
            this.EnemyBox.Name = "EnemyBox";
            this.EnemyBox.Size = new System.Drawing.Size(193, 60);
            this.EnemyBox.TabIndex = 3;
            this.EnemyBox.ThreeDCheckBoxes = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Character Values";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(281, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Enemy Values";
            // 
            // ChangeBox
            // 
            this.ChangeBox.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeBox.Location = new System.Drawing.Point(25, 220);
            this.ChangeBox.Name = "ChangeBox";
            this.ChangeBox.ReadOnly = true;
            this.ChangeBox.Size = new System.Drawing.Size(422, 109);
            this.ChangeBox.TabIndex = 6;
            this.ChangeBox.Text = "";
            // 
            // Button
            // 
            this.Button.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button.Location = new System.Drawing.Point(178, 335);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(108, 40);
            this.Button.TabIndex = 7;
            this.Button.Text = "Change";
            this.Button.UseVisualStyleBackColor = true;
            this.Button.Click += new System.EventHandler(this.Button_Click);
            // 
            // Description
            // 
            this.Description.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description.Location = new System.Drawing.Point(12, 381);
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Size = new System.Drawing.Size(460, 68);
            this.Description.TabIndex = 8;
            this.Description.Text = resources.GetString("Description.Text");
            // 
            // HomeworkWarsTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.Button);
            this.Controls.Add(this.ChangeBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EnemyBox);
            this.Controls.Add(this.PlayerBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "HomeworkWarsTool";
            this.Text = "Homework Wars Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox PlayerBox;
        private System.Windows.Forms.CheckedListBox EnemyBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox ChangeBox;
        private System.Windows.Forms.Button Button;
        private System.Windows.Forms.RichTextBox Description;
    }
}

