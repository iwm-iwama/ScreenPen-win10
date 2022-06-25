namespace iwm_ScreenPen
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.Cms1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.Cms1_スクリーンショット = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms1_クリア = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms1_最小化 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.Cms1_画像を保存 = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms1_操作説明 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.Cms1_閉じる = new System.Windows.Forms.ToolStripMenuItem();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.Cms2 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.Cms2_四角 = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms2_円 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.Cms2_矢印 = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms2_矢印両端 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.Cms2_直線 = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.Cms1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.Cms2.SuspendLayout();
			this.SuspendLayout();
			// 
			// Cms1
			// 
			this.Cms1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Cms1.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Cms1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Cms1_スクリーンショット,
            this.Cms1_クリア,
            this.Cms1_最小化,
            this.toolStripSeparator3,
            this.Cms1_画像を保存,
            this.Cms1_操作説明,
            this.toolStripSeparator2,
            this.Cms1_閉じる});
			this.Cms1.Name = "contextMenuStrip1";
			this.Cms1.Size = new System.Drawing.Size(181, 170);
			this.Cms1.Opened += new System.EventHandler(this.Cms1_Opened);
			// 
			// Cms1_スクリーンショット
			// 
			this.Cms1_スクリーンショット.BackColor = System.Drawing.Color.RoyalBlue;
			this.Cms1_スクリーンショット.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Cms1_スクリーンショット.ForeColor = System.Drawing.Color.White;
			this.Cms1_スクリーンショット.Image = ((System.Drawing.Image)(resources.GetObject("Cms1_スクリーンショット.Image")));
			this.Cms1_スクリーンショット.Name = "Cms1_スクリーンショット";
			this.Cms1_スクリーンショット.Size = new System.Drawing.Size(180, 22);
			this.Cms1_スクリーンショット.Text = "スクリーンショット";
			this.Cms1_スクリーンショット.Click += new System.EventHandler(this.Cms1_スクリーンショット_Click);
			// 
			// Cms1_クリア
			// 
			this.Cms1_クリア.Image = ((System.Drawing.Image)(resources.GetObject("Cms1_クリア.Image")));
			this.Cms1_クリア.Name = "Cms1_クリア";
			this.Cms1_クリア.Size = new System.Drawing.Size(180, 22);
			this.Cms1_クリア.Text = "クリア";
			this.Cms1_クリア.Click += new System.EventHandler(this.Cms1_クリア_Click);
			// 
			// Cms1_最小化
			// 
			this.Cms1_最小化.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Cms1_最小化.Image = ((System.Drawing.Image)(resources.GetObject("Cms1_最小化.Image")));
			this.Cms1_最小化.Name = "Cms1_最小化";
			this.Cms1_最小化.Size = new System.Drawing.Size(180, 22);
			this.Cms1_最小化.Text = "最小化";
			this.Cms1_最小化.Click += new System.EventHandler(this.Cms1_最小化_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
			// 
			// Cms1_画像を保存
			// 
			this.Cms1_画像を保存.Image = ((System.Drawing.Image)(resources.GetObject("Cms1_画像を保存.Image")));
			this.Cms1_画像を保存.Name = "Cms1_画像を保存";
			this.Cms1_画像を保存.Size = new System.Drawing.Size(180, 22);
			this.Cms1_画像を保存.Text = "画像を保存";
			this.Cms1_画像を保存.Click += new System.EventHandler(this.Cms1_画像を保存_Click);
			// 
			// Cms1_操作説明
			// 
			this.Cms1_操作説明.Image = ((System.Drawing.Image)(resources.GetObject("Cms1_操作説明.Image")));
			this.Cms1_操作説明.Name = "Cms1_操作説明";
			this.Cms1_操作説明.Size = new System.Drawing.Size(180, 22);
			this.Cms1_操作説明.Text = "操作説明";
			this.Cms1_操作説明.Click += new System.EventHandler(this.Cms1_操作説明_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
			// 
			// Cms1_閉じる
			// 
			this.Cms1_閉じる.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Cms1_閉じる.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Cms1_閉じる.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Cms1_閉じる.Image = ((System.Drawing.Image)(resources.GetObject("Cms1_閉じる.Image")));
			this.Cms1_閉じる.ImageTransparentColor = System.Drawing.Color.Transparent;
			this.Cms1_閉じる.Name = "Cms1_閉じる";
			this.Cms1_閉じる.Size = new System.Drawing.Size(180, 22);
			this.Cms1_閉じる.Text = "閉じる";
			this.Cms1_閉じる.Click += new System.EventHandler(this.Cms1_閉じる_Click);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.PictureBox1.BackColor = System.Drawing.Color.Black;
			this.PictureBox1.ContextMenuStrip = this.Cms1;
			this.PictureBox1.Location = new System.Drawing.Point(0, 0);
			this.PictureBox1.Margin = new System.Windows.Forms.Padding(0);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(298, 298);
			this.PictureBox1.TabIndex = 1;
			this.PictureBox1.TabStop = false;
			this.PictureBox1.DoubleClick += new System.EventHandler(this.PictureBox1_DoubleClick);
			this.PictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
			this.PictureBox1.MouseEnter += new System.EventHandler(this.PictureBox1_MouseEnter);
			this.PictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseMove);
			this.PictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseUp);
			// 
			// Cms2
			// 
			this.Cms2.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Cms2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Cms2_四角,
            this.Cms2_円,
            this.toolStripMenuItem1,
            this.Cms2_矢印,
            this.Cms2_矢印両端,
            this.toolStripMenuItem2,
            this.Cms2_直線});
			this.Cms2.Name = "Cms2";
			this.Cms2.Size = new System.Drawing.Size(147, 126);
			this.Cms2.Opened += new System.EventHandler(this.Cms2_Opened);
			this.Cms2.MouseLeave += new System.EventHandler(this.Cms2_MouseLeave);
			// 
			// Cms2_四角
			// 
			this.Cms2_四角.Image = ((System.Drawing.Image)(resources.GetObject("Cms2_四角.Image")));
			this.Cms2_四角.Name = "Cms2_四角";
			this.Cms2_四角.Size = new System.Drawing.Size(146, 22);
			this.Cms2_四角.Text = "四角";
			this.Cms2_四角.Click += new System.EventHandler(this.Cms2_四角_Click);
			// 
			// Cms2_円
			// 
			this.Cms2_円.Image = ((System.Drawing.Image)(resources.GetObject("Cms2_円.Image")));
			this.Cms2_円.Name = "Cms2_円";
			this.Cms2_円.Size = new System.Drawing.Size(146, 22);
			this.Cms2_円.Text = "円";
			this.Cms2_円.Click += new System.EventHandler(this.Cms2_円_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(143, 6);
			// 
			// Cms2_矢印
			// 
			this.Cms2_矢印.Image = ((System.Drawing.Image)(resources.GetObject("Cms2_矢印.Image")));
			this.Cms2_矢印.Name = "Cms2_矢印";
			this.Cms2_矢印.Size = new System.Drawing.Size(146, 22);
			this.Cms2_矢印.Text = "矢印";
			this.Cms2_矢印.Click += new System.EventHandler(this.Cms2_矢印_Click);
			// 
			// Cms2_矢印両端
			// 
			this.Cms2_矢印両端.Image = ((System.Drawing.Image)(resources.GetObject("Cms2_矢印両端.Image")));
			this.Cms2_矢印両端.Name = "Cms2_矢印両端";
			this.Cms2_矢印両端.Size = new System.Drawing.Size(146, 22);
			this.Cms2_矢印両端.Text = "矢印（両端）";
			this.Cms2_矢印両端.Click += new System.EventHandler(this.Cms2_矢印両端_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(143, 6);
			// 
			// Cms2_直線
			// 
			this.Cms2_直線.Image = ((System.Drawing.Image)(resources.GetObject("Cms2_直線.Image")));
			this.Cms2_直線.Name = "Cms2_直線";
			this.Cms2_直線.Size = new System.Drawing.Size(146, 22);
			this.Cms2_直線.Text = "直線";
			this.Cms2_直線.Click += new System.EventHandler(this.Cms2_直線_Click);
			// 
			// ToolTip1
			// 
			this.ToolTip1.AutomaticDelay = 150;
			this.ToolTip1.OwnerDraw = true;
			this.ToolTip1.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.ToolTip1_Draw);
			this.ToolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.ToolTip1_Popup);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(298, 298);
			this.ControlBox = false;
			this.Controls.Add(this.PictureBox1);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.TopMost = true;
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.Cms1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.Cms2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ContextMenuStrip Cms1;
		private System.Windows.Forms.ToolStripMenuItem Cms1_閉じる;
		private System.Windows.Forms.PictureBox PictureBox1;
		private System.Windows.Forms.ToolStripMenuItem Cms1_スクリーンショット;
		private System.Windows.Forms.ContextMenuStrip Cms2;
		private System.Windows.Forms.ToolStripMenuItem Cms2_矢印;
		private System.Windows.Forms.ToolStripMenuItem Cms2_四角;
		private System.Windows.Forms.ToolStripMenuItem Cms2_矢印両端;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem Cms1_操作説明;
		private System.Windows.Forms.ToolStripMenuItem Cms2_円;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem Cms2_直線;
		private System.Windows.Forms.ToolStripMenuItem Cms1_画像を保存;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem Cms1_クリア;
		private System.Windows.Forms.ToolTip ToolTip1;
		private System.Windows.Forms.ToolStripMenuItem Cms1_最小化;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
	}
}
