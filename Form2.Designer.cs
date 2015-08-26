namespace AutoPick
{
    partial class Form2
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
            this.numericUpDown_left = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_top = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_right = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_bottom = new System.Windows.Forms.NumericUpDown();
            this.button_exit = new System.Windows.Forms.Button();
            this.button_set_champion = new System.Windows.Forms.Button();
            this.button_set_chat = new System.Windows.Forms.Button();
            this.label_log = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_top)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_bottom)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown_left
            // 
            this.numericUpDown_left.Location = new System.Drawing.Point(11, 12);
            this.numericUpDown_left.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown_left.Name = "numericUpDown_left";
            this.numericUpDown_left.Size = new System.Drawing.Size(55, 20);
            this.numericUpDown_left.TabIndex = 0;
            this.numericUpDown_left.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // numericUpDown_top
            // 
            this.numericUpDown_top.Location = new System.Drawing.Point(72, 12);
            this.numericUpDown_top.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown_top.Name = "numericUpDown_top";
            this.numericUpDown_top.Size = new System.Drawing.Size(55, 20);
            this.numericUpDown_top.TabIndex = 1;
            this.numericUpDown_top.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // numericUpDown_right
            // 
            this.numericUpDown_right.Location = new System.Drawing.Point(11, 38);
            this.numericUpDown_right.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown_right.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown_right.Name = "numericUpDown_right";
            this.numericUpDown_right.Size = new System.Drawing.Size(55, 20);
            this.numericUpDown_right.TabIndex = 2;
            this.numericUpDown_right.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown_right.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // numericUpDown_bottom
            // 
            this.numericUpDown_bottom.Location = new System.Drawing.Point(72, 38);
            this.numericUpDown_bottom.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown_bottom.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown_bottom.Name = "numericUpDown_bottom";
            this.numericUpDown_bottom.Size = new System.Drawing.Size(55, 20);
            this.numericUpDown_bottom.TabIndex = 3;
            this.numericUpDown_bottom.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown_bottom.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(11, 200);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(116, 23);
            this.button_exit.TabIndex = 10;
            this.button_exit.Text = "Exit";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // button_set_champion
            // 
            this.button_set_champion.Location = new System.Drawing.Point(11, 64);
            this.button_set_champion.Name = "button_set_champion";
            this.button_set_champion.Size = new System.Drawing.Size(116, 23);
            this.button_set_champion.TabIndex = 15;
            this.button_set_champion.Text = "Set champion";
            this.button_set_champion.UseVisualStyleBackColor = true;
            this.button_set_champion.Click += new System.EventHandler(this.button_set_champion_Click);
            // 
            // button_set_chat
            // 
            this.button_set_chat.Location = new System.Drawing.Point(12, 93);
            this.button_set_chat.Name = "button_set_chat";
            this.button_set_chat.Size = new System.Drawing.Size(116, 23);
            this.button_set_chat.TabIndex = 16;
            this.button_set_chat.Text = "Set chat";
            this.button_set_chat.UseVisualStyleBackColor = true;
            this.button_set_chat.Click += new System.EventHandler(this.button_set_chat_Click);
            // 
            // label_log
            // 
            this.label_log.AutoSize = true;
            this.label_log.Location = new System.Drawing.Point(7, 257);
            this.label_log.Name = "label_log";
            this.label_log.Size = new System.Drawing.Size(46, 13);
            this.label_log.TabIndex = 17;
            this.label_log.Text = "Status...";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Set select";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 151);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "Set send";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(138, 279);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_log);
            this.Controls.Add(this.button_set_chat);
            this.Controls.Add(this.button_set_champion);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.numericUpDown_bottom);
            this.Controls.Add(this.numericUpDown_right);
            this.Controls.Add(this.numericUpDown_top);
            this.Controls.Add(this.numericUpDown_left);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Config";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.Form2_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_top)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_bottom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown_left;
        private System.Windows.Forms.NumericUpDown numericUpDown_top;
        private System.Windows.Forms.NumericUpDown numericUpDown_right;
        private System.Windows.Forms.NumericUpDown numericUpDown_bottom;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button_set_champion;
        private System.Windows.Forms.Button button_set_chat;
        private System.Windows.Forms.Label label_log;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}