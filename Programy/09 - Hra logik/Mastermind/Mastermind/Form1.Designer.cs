namespace Logik
{
    partial class Form1
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
            this.color_label_1 = new System.Windows.Forms.Label();
            this.guess_label_1 = new System.Windows.Forms.Label();
            this.color_label_4 = new System.Windows.Forms.Label();
            this.color_label_2 = new System.Windows.Forms.Label();
            this.color_label_5 = new System.Windows.Forms.Label();
            this.color_label_6 = new System.Windows.Forms.Label();
            this.color_label_3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.heading_label = new System.Windows.Forms.Label();
            this.guess_label_2 = new System.Windows.Forms.Label();
            this.guess_label_3 = new System.Windows.Forms.Label();
            this.guess_label_4 = new System.Windows.Forms.Label();
            this.guess_label_5 = new System.Windows.Forms.Label();
            this.move_history = new System.Windows.Forms.DataGridView();
            this.start_game_button = new System.Windows.Forms.Button();
            this.black_user_input = new System.Windows.Forms.NumericUpDown();
            this.white_user_input = new System.Windows.Forms.NumericUpDown();
            this.manual_evaluation_button = new System.Windows.Forms.Button();
            this.automatic_evaluate_button = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.move_history)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.black_user_input)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.white_user_input)).BeginInit();
            this.SuspendLayout();
            // 
            // color_label_1
            // 
            this.color_label_1.BackColor = System.Drawing.Color.Red;
            this.color_label_1.Location = new System.Drawing.Point(9, 8);
            this.color_label_1.Name = "color_label_1";
            this.color_label_1.Size = new System.Drawing.Size(47, 51);
            this.color_label_1.TabIndex = 0;
            this.color_label_1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.get_color);
            // 
            // guess_label_1
            // 
            this.guess_label_1.AllowDrop = true;
            this.guess_label_1.BackColor = System.Drawing.Color.Silver;
            this.guess_label_1.Location = new System.Drawing.Point(16, 55);
            this.guess_label_1.Name = "guess_label_1";
            this.guess_label_1.Size = new System.Drawing.Size(27, 29);
            this.guess_label_1.TabIndex = 1;
            this.guess_label_1.DragDrop += new System.Windows.Forms.DragEventHandler(this.color_drag_drop);
            this.guess_label_1.DragEnter += new System.Windows.Forms.DragEventHandler(this.color_drag_enter);
            // 
            // color_label_4
            // 
            this.color_label_4.BackColor = System.Drawing.Color.Blue;
            this.color_label_4.Location = new System.Drawing.Point(9, 64);
            this.color_label_4.Name = "color_label_4";
            this.color_label_4.Size = new System.Drawing.Size(47, 51);
            this.color_label_4.TabIndex = 2;
            this.color_label_4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.get_color);
            // 
            // color_label_2
            // 
            this.color_label_2.BackColor = System.Drawing.Color.Green;
            this.color_label_2.Location = new System.Drawing.Point(62, 8);
            this.color_label_2.Name = "color_label_2";
            this.color_label_2.Size = new System.Drawing.Size(47, 51);
            this.color_label_2.TabIndex = 3;
            this.color_label_2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.get_color);
            // 
            // color_label_5
            // 
            this.color_label_5.BackColor = System.Drawing.Color.Gray;
            this.color_label_5.Location = new System.Drawing.Point(62, 64);
            this.color_label_5.Name = "color_label_5";
            this.color_label_5.Size = new System.Drawing.Size(47, 51);
            this.color_label_5.TabIndex = 4;
            this.color_label_5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.get_color);
            // 
            // color_label_6
            // 
            this.color_label_6.BackColor = System.Drawing.Color.Orange;
            this.color_label_6.Location = new System.Drawing.Point(115, 64);
            this.color_label_6.Name = "color_label_6";
            this.color_label_6.Size = new System.Drawing.Size(47, 51);
            this.color_label_6.TabIndex = 5;
            this.color_label_6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.get_color);
            // 
            // color_label_3
            // 
            this.color_label_3.BackColor = System.Drawing.Color.White;
            this.color_label_3.Location = new System.Drawing.Point(115, 8);
            this.color_label_3.Name = "color_label_3";
            this.color_label_3.Size = new System.Drawing.Size(47, 51);
            this.color_label_3.TabIndex = 6;
            this.color_label_3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.get_color);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.color_label_3);
            this.panel1.Controls.Add(this.color_label_1);
            this.panel1.Controls.Add(this.color_label_6);
            this.panel1.Controls.Add(this.color_label_4);
            this.panel1.Controls.Add(this.color_label_5);
            this.panel1.Controls.Add(this.color_label_2);
            this.panel1.Location = new System.Drawing.Point(189, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 126);
            this.panel1.TabIndex = 7;
            // 
            // heading_label
            // 
            this.heading_label.AutoSize = true;
            this.heading_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.heading_label.Location = new System.Drawing.Point(13, 11);
            this.heading_label.Name = "heading_label";
            this.heading_label.Size = new System.Drawing.Size(168, 33);
            this.heading_label.TabIndex = 8;
            this.heading_label.Text = "Mastermind";
            // 
            // guess_label_2
            // 
            this.guess_label_2.AllowDrop = true;
            this.guess_label_2.BackColor = System.Drawing.Color.Silver;
            this.guess_label_2.Location = new System.Drawing.Point(49, 55);
            this.guess_label_2.Name = "guess_label_2";
            this.guess_label_2.Size = new System.Drawing.Size(27, 29);
            this.guess_label_2.TabIndex = 9;
            this.guess_label_2.DragDrop += new System.Windows.Forms.DragEventHandler(this.color_drag_drop);
            this.guess_label_2.DragEnter += new System.Windows.Forms.DragEventHandler(this.color_drag_enter);
            // 
            // guess_label_3
            // 
            this.guess_label_3.AllowDrop = true;
            this.guess_label_3.BackColor = System.Drawing.Color.Silver;
            this.guess_label_3.Location = new System.Drawing.Point(82, 55);
            this.guess_label_3.Name = "guess_label_3";
            this.guess_label_3.Size = new System.Drawing.Size(27, 29);
            this.guess_label_3.TabIndex = 10;
            this.guess_label_3.DragDrop += new System.Windows.Forms.DragEventHandler(this.color_drag_drop);
            this.guess_label_3.DragEnter += new System.Windows.Forms.DragEventHandler(this.color_drag_enter);
            // 
            // guess_label_4
            // 
            this.guess_label_4.AllowDrop = true;
            this.guess_label_4.BackColor = System.Drawing.Color.Silver;
            this.guess_label_4.Location = new System.Drawing.Point(115, 55);
            this.guess_label_4.Name = "guess_label_4";
            this.guess_label_4.Size = new System.Drawing.Size(27, 29);
            this.guess_label_4.TabIndex = 11;
            this.guess_label_4.DragDrop += new System.Windows.Forms.DragEventHandler(this.color_drag_drop);
            this.guess_label_4.DragEnter += new System.Windows.Forms.DragEventHandler(this.color_drag_enter);
            // 
            // guess_label_5
            // 
            this.guess_label_5.AllowDrop = true;
            this.guess_label_5.BackColor = System.Drawing.Color.Silver;
            this.guess_label_5.Location = new System.Drawing.Point(148, 55);
            this.guess_label_5.Name = "guess_label_5";
            this.guess_label_5.Size = new System.Drawing.Size(27, 29);
            this.guess_label_5.TabIndex = 12;
            this.guess_label_5.DragDrop += new System.Windows.Forms.DragEventHandler(this.color_drag_drop);
            this.guess_label_5.DragEnter += new System.Windows.Forms.DragEventHandler(this.color_drag_enter);
            // 
            // move_history
            // 
            this.move_history.AllowUserToAddRows = false;
            this.move_history.AllowUserToDeleteRows = false;
            this.move_history.AllowUserToResizeColumns = false;
            this.move_history.AllowUserToResizeRows = false;
            this.move_history.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.move_history.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.move_history.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.move_history.ColumnHeadersHeight = 5;
            this.move_history.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.move_history.ColumnHeadersVisible = false;
            this.move_history.EnableHeadersVisualStyles = false;
            this.move_history.Location = new System.Drawing.Point(17, 96);
            this.move_history.MultiSelect = false;
            this.move_history.Name = "move_history";
            this.move_history.ReadOnly = true;
            this.move_history.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.move_history.RowHeadersVisible = false;
            this.move_history.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.move_history.Size = new System.Drawing.Size(156, 95);
            this.move_history.TabIndex = 13;
            // 
            // start_game_button
            // 
            this.start_game_button.Location = new System.Drawing.Point(189, 144);
            this.start_game_button.Name = "start_game_button";
            this.start_game_button.Size = new System.Drawing.Size(56, 47);
            this.start_game_button.TabIndex = 14;
            this.start_game_button.Text = "Start game";
            this.start_game_button.UseVisualStyleBackColor = true;
            this.start_game_button.Click += new System.EventHandler(this.start_game_button_Click);
            // 
            // black_user_input
            // 
            this.black_user_input.Enabled = false;
            this.black_user_input.Location = new System.Drawing.Point(254, 144);
            this.black_user_input.Name = "black_user_input";
            this.black_user_input.Size = new System.Drawing.Size(33, 20);
            this.black_user_input.TabIndex = 15;
            this.black_user_input.ValueChanged += new System.EventHandler(this.black_user_input_ValueChanged);
            // 
            // white_user_input
            // 
            this.white_user_input.Enabled = false;
            this.white_user_input.Location = new System.Drawing.Point(254, 171);
            this.white_user_input.Name = "white_user_input";
            this.white_user_input.Size = new System.Drawing.Size(33, 20);
            this.white_user_input.TabIndex = 16;
            // 
            // manual_evaluation_button
            // 
            this.manual_evaluation_button.Enabled = false;
            this.manual_evaluation_button.Location = new System.Drawing.Point(293, 144);
            this.manual_evaluation_button.Name = "manual_evaluation_button";
            this.manual_evaluation_button.Size = new System.Drawing.Size(70, 20);
            this.manual_evaluation_button.TabIndex = 17;
            this.manual_evaluation_button.Text = "Manual";
            this.manual_evaluation_button.UseVisualStyleBackColor = true;
            this.manual_evaluation_button.Click += new System.EventHandler(this.manual_evaluation_button_Click);
            // 
            // automatic_evaluate_button
            // 
            this.automatic_evaluate_button.Enabled = false;
            this.automatic_evaluate_button.Location = new System.Drawing.Point(293, 171);
            this.automatic_evaluate_button.Name = "automatic_evaluate_button";
            this.automatic_evaluate_button.Size = new System.Drawing.Size(70, 20);
            this.automatic_evaluate_button.TabIndex = 18;
            this.automatic_evaluate_button.Text = "Automatic";
            this.automatic_evaluate_button.UseVisualStyleBackColor = true;
            this.automatic_evaluate_button.Click += new System.EventHandler(this.automatic_evaluate_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 204);
            this.Controls.Add(this.automatic_evaluate_button);
            this.Controls.Add(this.manual_evaluation_button);
            this.Controls.Add(this.white_user_input);
            this.Controls.Add(this.black_user_input);
            this.Controls.Add(this.start_game_button);
            this.Controls.Add(this.move_history);
            this.Controls.Add(this.guess_label_5);
            this.Controls.Add(this.guess_label_4);
            this.Controls.Add(this.guess_label_3);
            this.Controls.Add(this.guess_label_2);
            this.Controls.Add(this.heading_label);
            this.Controls.Add(this.guess_label_1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Matermind";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.color_drag_drop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.color_drag_enter);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.move_history)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.black_user_input)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.white_user_input)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label color_label_1;
        private System.Windows.Forms.Label guess_label_1;
        private System.Windows.Forms.Label color_label_4;
        private System.Windows.Forms.Label color_label_2;
        private System.Windows.Forms.Label color_label_5;
        private System.Windows.Forms.Label color_label_6;
        private System.Windows.Forms.Label color_label_3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label heading_label;
        private System.Windows.Forms.Label guess_label_2;
        private System.Windows.Forms.Label guess_label_3;
        private System.Windows.Forms.Label guess_label_4;
        private System.Windows.Forms.Label guess_label_5;
        private System.Windows.Forms.DataGridView move_history;
        private System.Windows.Forms.Button start_game_button;
        private System.Windows.Forms.NumericUpDown black_user_input;
        private System.Windows.Forms.NumericUpDown white_user_input;
        private System.Windows.Forms.Button manual_evaluation_button;
        private System.Windows.Forms.Button automatic_evaluate_button;
    }
}

