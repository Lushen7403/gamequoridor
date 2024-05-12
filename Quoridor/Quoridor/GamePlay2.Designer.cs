namespace Quoridor
{
	partial class GamePlay2
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
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.rbVerWall = new System.Windows.Forms.RadioButton();
			this.rbHorWall = new System.Windows.Forms.RadioButton();
			this.btnMenu = new System.Windows.Forms.Button();
			this.btnTuto = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.panel3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelBoard
			// 
			this.panelBoard.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelBoard.Location = new System.Drawing.Point(0, 0);
			this.panelBoard.Name = "panelBoard";
			this.panelBoard.Size = new System.Drawing.Size(632, 642);
			this.panelBoard.TabIndex = 0;
			this.panelBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBoard_Paint);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnExit);
			this.panel3.Controls.Add(this.btnTuto);
			this.panel3.Controls.Add(this.btnMenu);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(0, 756);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(632, 77);
			this.panel3.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.rbVerWall);
			this.panel1.Controls.Add(this.rbHorWall);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 642);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(632, 114);
			this.panel1.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.label2.Location = new System.Drawing.Point(398, 78);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 22);
			this.label2.TabIndex = 3;
			this.label2.Text = "10";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.label1.Location = new System.Drawing.Point(398, 52);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(30, 22);
			this.label1.TabIndex = 2;
			this.label1.Text = "10";
			// 
			// rbVerWall
			// 
			this.rbVerWall.AutoSize = true;
			this.rbVerWall.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.rbVerWall.Location = new System.Drawing.Point(95, 74);
			this.rbVerWall.Name = "rbVerWall";
			this.rbVerWall.Size = new System.Drawing.Size(130, 26);
			this.rbVerWall.TabIndex = 1;
			this.rbVerWall.TabStop = true;
			this.rbVerWall.Text = "Tường dọc";
			this.rbVerWall.UseVisualStyleBackColor = true;
			// 
			// rbHorWall
			// 
			this.rbHorWall.AutoSize = true;
			this.rbHorWall.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.rbHorWall.Location = new System.Drawing.Point(95, 42);
			this.rbHorWall.Name = "rbHorWall";
			this.rbHorWall.Size = new System.Drawing.Size(153, 26);
			this.rbHorWall.TabIndex = 0;
			this.rbHorWall.TabStop = true;
			this.rbHorWall.Text = "Tường ngang";
			this.rbHorWall.UseVisualStyleBackColor = true;
			// 
			// btnMenu
			// 
			this.btnMenu.Location = new System.Drawing.Point(83, 16);
			this.btnMenu.Name = "btnMenu";
			this.btnMenu.Size = new System.Drawing.Size(103, 36);
			this.btnMenu.TabIndex = 0;
			this.btnMenu.Text = "Menu";
			this.btnMenu.UseVisualStyleBackColor = true;
			this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
			// 
			// btnTuto
			// 
			this.btnTuto.Location = new System.Drawing.Point(244, 16);
			this.btnTuto.Name = "btnTuto";
			this.btnTuto.Size = new System.Drawing.Size(112, 36);
			this.btnTuto.TabIndex = 1;
			this.btnTuto.Text = "Tutorial";
			this.btnTuto.UseVisualStyleBackColor = true;
			this.btnTuto.Click += new System.EventHandler(this.btnTuto_Click);
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(420, 16);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(125, 36);
			this.btnExit.TabIndex = 2;
			this.btnExit.Text = "Exit";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// GamePlay2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(632, 833);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panelBoard);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(654, 889);
			this.MinimumSize = new System.Drawing.Size(654, 889);
			this.Name = "GamePlay2";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "GamePlay2";
			this.panel3.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelBoard;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RadioButton rbVerWall;
		private System.Windows.Forms.RadioButton rbHorWall;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnTuto;
		private System.Windows.Forms.Button btnMenu;
	}
}