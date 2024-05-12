namespace Quoridor
{
	partial class GamePlay
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
			this.panelBoard = new System.Windows.Forms.Panel();
			this.rbVerWall = new System.Windows.Forms.RadioButton();
			this.rbHorWall = new System.Windows.Forms.RadioButton();
			this.panel4 = new System.Windows.Forms.Panel();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel4.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelBoard
			// 
			this.panelBoard.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelBoard.Location = new System.Drawing.Point(0, 0);
			this.panelBoard.Name = "panelBoard";
			this.panelBoard.Size = new System.Drawing.Size(632, 642);
			this.panelBoard.TabIndex = 1;
			this.panelBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBoard_Paint_1);
			// 
			// rbVerWall
			// 
			this.rbVerWall.AutoSize = true;
			this.rbVerWall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.rbVerWall.Location = new System.Drawing.Point(144, 82);
			this.rbVerWall.Name = "rbVerWall";
			this.rbVerWall.Size = new System.Drawing.Size(118, 24);
			this.rbVerWall.TabIndex = 1;
			this.rbVerWall.TabStop = true;
			this.rbVerWall.Text = "Tường dọc";
			this.rbVerWall.UseVisualStyleBackColor = true;
			// 
			// rbHorWall
			// 
			this.rbHorWall.AutoSize = true;
			this.rbHorWall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.rbHorWall.Location = new System.Drawing.Point(144, 54);
			this.rbHorWall.Name = "rbHorWall";
			this.rbHorWall.Size = new System.Drawing.Size(139, 24);
			this.rbHorWall.TabIndex = 0;
			this.rbHorWall.TabStop = true;
			this.rbHorWall.Text = "Tường ngang";
			this.rbHorWall.UseVisualStyleBackColor = true;
			this.rbHorWall.CheckedChanged += new System.EventHandler(this.rbHorWall_CheckedChanged);
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.button3);
			this.panel4.Controls.Add(this.button2);
			this.panel4.Controls.Add(this.button1);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel4.Location = new System.Drawing.Point(0, 758);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(632, 75);
			this.panel4.TabIndex = 6;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(440, 20);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(116, 43);
			this.button3.TabIndex = 2;
			this.button3.Text = "Exit";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(248, 20);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(118, 43);
			this.button2.TabIndex = 1;
			this.button2.Text = "Tutorial";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(67, 20);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(110, 43);
			this.button1.TabIndex = 0;
			this.button1.Text = "Menu";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.rbHorWall);
			this.panel1.Controls.Add(this.rbVerWall);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 642);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(632, 116);
			this.panel1.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.label2.Location = new System.Drawing.Point(390, 82);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 22);
			this.label2.TabIndex = 3;
			this.label2.Text = "10";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.label1.Location = new System.Drawing.Point(390, 54);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 22);
			this.label1.TabIndex = 2;
			this.label1.Text = "10";
			// 
			// GamePlay
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(632, 833);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panelBoard);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(654, 889);
			this.MinimumSize = new System.Drawing.Size(654, 889);
			this.Name = "GamePlay";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "GamePlay";
			this.Load += new System.EventHandler(this.GamePlay_Load);
			this.panel4.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelBoard;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RadioButton rbHorWall;
		private System.Windows.Forms.RadioButton rbVerWall;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}