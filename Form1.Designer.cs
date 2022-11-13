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
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.Cms1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.Cms1_クリア = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.Cms1_マーカー色 = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms1_マーカー色_レッド = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms1_マーカー色_ブルー = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms1_マーカー色_マゼンタ = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms1_マーカー色_ライム = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms1_マーカー色_イエロー = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms1_マーカー色_オレンジ = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms1_マーカー色_シアン = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms1_マーカーサイズ = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms1_マーカーサイズ_3px = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms1_マーカーサイズ_6px = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms1_マーカーサイズ_9px = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms1_マーカーサイズ_15px = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms1_マーカーサイズ_24px = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms1_画面透過 = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms1_画面透過_0per = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms1_画面透過_25per = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms1_画面透過_50per = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms1_画面透過_75per = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.Cms1_スクリーンショット = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms1_最小化 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.Cms1_画像を保存 = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms1_操作説明 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.Cms1_閉じる = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.Cms2 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.Cms2_四角 = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms2_円 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.Cms2_矢印 = new System.Windows.Forms.ToolStripMenuItem();
			this.Cms2_矢印両端 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.Cms2_直線 = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.Cms1.SuspendLayout();
			this.Cms2.SuspendLayout();
			this.SuspendLayout();
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
			// Cms1
			// 
			this.Cms1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Cms1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Cms1_クリア,
            this.toolStripSeparator1,
            this.Cms1_マーカー色,
            this.Cms1_マーカーサイズ,
            this.Cms1_画面透過,
            this.toolStripSeparator2,
            this.Cms1_スクリーンショット,
            this.Cms1_最小化,
            this.toolStripSeparator3,
            this.Cms1_画像を保存,
            this.Cms1_操作説明,
            this.toolStripSeparator4,
            this.Cms1_閉じる});
			this.Cms1.Name = "contextMenuStrip1";
			this.Cms1.Size = new System.Drawing.Size(153, 226);
			this.Cms1.Opened += new System.EventHandler(this.Cms1_Opened);
			// 
			// Cms1_クリア
			// 
			this.Cms1_クリア.Image = ((System.Drawing.Image)(resources.GetObject("Cms1_クリア.Image")));
			this.Cms1_クリア.Name = "Cms1_クリア";
			this.Cms1_クリア.Size = new System.Drawing.Size(152, 22);
			this.Cms1_クリア.Text = "クリア";
			this.Cms1_クリア.Click += new System.EventHandler(this.Cms1_クリア_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
			// 
			// Cms1_マーカー色
			// 
			this.Cms1_マーカー色.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Cms1_マーカー色_レッド,
            this.Cms1_マーカー色_ブルー,
            this.Cms1_マーカー色_マゼンタ,
            this.Cms1_マーカー色_ライム,
            this.Cms1_マーカー色_イエロー,
            this.Cms1_マーカー色_オレンジ,
            this.Cms1_マーカー色_シアン});
			this.Cms1_マーカー色.Image = ((System.Drawing.Image)(resources.GetObject("Cms1_マーカー色.Image")));
			this.Cms1_マーカー色.Name = "Cms1_マーカー色";
			this.Cms1_マーカー色.Size = new System.Drawing.Size(152, 22);
			this.Cms1_マーカー色.Text = "マーカー色";
			// 
			// Cms1_マーカー色_レッド
			// 
			this.Cms1_マーカー色_レッド.Image = ((System.Drawing.Image)(resources.GetObject("Cms1_マーカー色_レッド.Image")));
			this.Cms1_マーカー色_レッド.Name = "Cms1_マーカー色_レッド";
			this.Cms1_マーカー色_レッド.Size = new System.Drawing.Size(111, 22);
			this.Cms1_マーカー色_レッド.Text = "レッド";
			this.Cms1_マーカー色_レッド.Click += new System.EventHandler(this.Cms1_マーカー色_レッド_Click);
			// 
			// Cms1_マーカー色_ブルー
			// 
			this.Cms1_マーカー色_ブルー.Image = ((System.Drawing.Image)(resources.GetObject("Cms1_マーカー色_ブルー.Image")));
			this.Cms1_マーカー色_ブルー.Name = "Cms1_マーカー色_ブルー";
			this.Cms1_マーカー色_ブルー.Size = new System.Drawing.Size(111, 22);
			this.Cms1_マーカー色_ブルー.Text = "ブルー";
			this.Cms1_マーカー色_ブルー.Click += new System.EventHandler(this.Cms1_マーカー色_ブルー_Click);
			// 
			// Cms1_マーカー色_マゼンタ
			// 
			this.Cms1_マーカー色_マゼンタ.Image = ((System.Drawing.Image)(resources.GetObject("Cms1_マーカー色_マゼンタ.Image")));
			this.Cms1_マーカー色_マゼンタ.Name = "Cms1_マーカー色_マゼンタ";
			this.Cms1_マーカー色_マゼンタ.Size = new System.Drawing.Size(111, 22);
			this.Cms1_マーカー色_マゼンタ.Text = "マゼンタ";
			this.Cms1_マーカー色_マゼンタ.Click += new System.EventHandler(this.Cms1_マーカー色_マゼンタ_Click);
			// 
			// Cms1_マーカー色_ライム
			// 
			this.Cms1_マーカー色_ライム.Image = ((System.Drawing.Image)(resources.GetObject("Cms1_マーカー色_ライム.Image")));
			this.Cms1_マーカー色_ライム.Name = "Cms1_マーカー色_ライム";
			this.Cms1_マーカー色_ライム.Size = new System.Drawing.Size(111, 22);
			this.Cms1_マーカー色_ライム.Text = "ライム";
			this.Cms1_マーカー色_ライム.Click += new System.EventHandler(this.Cms1_マーカー色_ライム_Click);
			// 
			// Cms1_マーカー色_イエロー
			// 
			this.Cms1_マーカー色_イエロー.Image = ((System.Drawing.Image)(resources.GetObject("Cms1_マーカー色_イエロー.Image")));
			this.Cms1_マーカー色_イエロー.Name = "Cms1_マーカー色_イエロー";
			this.Cms1_マーカー色_イエロー.Size = new System.Drawing.Size(111, 22);
			this.Cms1_マーカー色_イエロー.Text = "イエロー";
			this.Cms1_マーカー色_イエロー.Click += new System.EventHandler(this.Cms1_マーカー色_イエロー_Click);
			// 
			// Cms1_マーカー色_オレンジ
			// 
			this.Cms1_マーカー色_オレンジ.Image = ((System.Drawing.Image)(resources.GetObject("Cms1_マーカー色_オレンジ.Image")));
			this.Cms1_マーカー色_オレンジ.Name = "Cms1_マーカー色_オレンジ";
			this.Cms1_マーカー色_オレンジ.Size = new System.Drawing.Size(111, 22);
			this.Cms1_マーカー色_オレンジ.Text = "オレンジ";
			this.Cms1_マーカー色_オレンジ.Click += new System.EventHandler(this.Cms1_マーカー色_オレンジ_Click);
			// 
			// Cms1_マーカー色_シアン
			// 
			this.Cms1_マーカー色_シアン.Image = ((System.Drawing.Image)(resources.GetObject("Cms1_マーカー色_シアン.Image")));
			this.Cms1_マーカー色_シアン.Name = "Cms1_マーカー色_シアン";
			this.Cms1_マーカー色_シアン.Size = new System.Drawing.Size(111, 22);
			this.Cms1_マーカー色_シアン.Text = "シアン";
			this.Cms1_マーカー色_シアン.Click += new System.EventHandler(this.Cms1_マーカー色_シアン_Click);
			// 
			// Cms1_マーカーサイズ
			// 
			this.Cms1_マーカーサイズ.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Cms1_マーカーサイズ_3px,
            this.Cms1_マーカーサイズ_6px,
            this.Cms1_マーカーサイズ_9px,
            this.Cms1_マーカーサイズ_15px,
            this.Cms1_マーカーサイズ_24px});
			this.Cms1_マーカーサイズ.Image = ((System.Drawing.Image)(resources.GetObject("Cms1_マーカーサイズ.Image")));
			this.Cms1_マーカーサイズ.Name = "Cms1_マーカーサイズ";
			this.Cms1_マーカーサイズ.Size = new System.Drawing.Size(152, 22);
			this.Cms1_マーカーサイズ.Text = "マーカーサイズ";
			// 
			// Cms1_マーカーサイズ_3px
			// 
			this.Cms1_マーカーサイズ_3px.Name = "Cms1_マーカーサイズ_3px";
			this.Cms1_マーカーサイズ_3px.Size = new System.Drawing.Size(99, 22);
			this.Cms1_マーカーサイズ_3px.Text = "3px";
			this.Cms1_マーカーサイズ_3px.Click += new System.EventHandler(this.Cms1_マーカーサイズ_3px_Click);
			// 
			// Cms1_マーカーサイズ_6px
			// 
			this.Cms1_マーカーサイズ_6px.Name = "Cms1_マーカーサイズ_6px";
			this.Cms1_マーカーサイズ_6px.Size = new System.Drawing.Size(99, 22);
			this.Cms1_マーカーサイズ_6px.Text = "6px";
			this.Cms1_マーカーサイズ_6px.Click += new System.EventHandler(this.Cms1_マーカーサイズ_6px_Click);
			// 
			// Cms1_マーカーサイズ_9px
			// 
			this.Cms1_マーカーサイズ_9px.Name = "Cms1_マーカーサイズ_9px";
			this.Cms1_マーカーサイズ_9px.Size = new System.Drawing.Size(99, 22);
			this.Cms1_マーカーサイズ_9px.Text = "9px";
			this.Cms1_マーカーサイズ_9px.Click += new System.EventHandler(this.Cms1_マーカーサイズ_9px_Click);
			// 
			// Cms1_マーカーサイズ_15px
			// 
			this.Cms1_マーカーサイズ_15px.Name = "Cms1_マーカーサイズ_15px";
			this.Cms1_マーカーサイズ_15px.Size = new System.Drawing.Size(99, 22);
			this.Cms1_マーカーサイズ_15px.Text = "15px";
			this.Cms1_マーカーサイズ_15px.Click += new System.EventHandler(this.Cms1_マーカーサイズ_15px_Click);
			// 
			// Cms1_マーカーサイズ_24px
			// 
			this.Cms1_マーカーサイズ_24px.Name = "Cms1_マーカーサイズ_24px";
			this.Cms1_マーカーサイズ_24px.Size = new System.Drawing.Size(99, 22);
			this.Cms1_マーカーサイズ_24px.Text = "24px";
			this.Cms1_マーカーサイズ_24px.Click += new System.EventHandler(this.Cms1_マーカーサイズ_24px_Click);
			// 
			// Cms1_画面透過
			// 
			this.Cms1_画面透過.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Cms1_画面透過_0per,
            this.Cms1_画面透過_25per,
            this.Cms1_画面透過_50per,
            this.Cms1_画面透過_75per});
			this.Cms1_画面透過.Image = ((System.Drawing.Image)(resources.GetObject("Cms1_画面透過.Image")));
			this.Cms1_画面透過.Name = "Cms1_画面透過";
			this.Cms1_画面透過.Size = new System.Drawing.Size(152, 22);
			this.Cms1_画面透過.Text = "画面透過";
			// 
			// Cms1_画面透過_0per
			// 
			this.Cms1_画面透過_0per.Name = "Cms1_画面透過_0per";
			this.Cms1_画面透過_0per.Size = new System.Drawing.Size(96, 22);
			this.Cms1_画面透過_0per.Text = "0%";
			this.Cms1_画面透過_0per.Click += new System.EventHandler(this.Cms1_画面透過_0per_Click);
			// 
			// Cms1_画面透過_25per
			// 
			this.Cms1_画面透過_25per.Name = "Cms1_画面透過_25per";
			this.Cms1_画面透過_25per.Size = new System.Drawing.Size(96, 22);
			this.Cms1_画面透過_25per.Text = "25%";
			this.Cms1_画面透過_25per.Click += new System.EventHandler(this.Cms1_画面透過_25per_Click);
			// 
			// Cms1_画面透過_50per
			// 
			this.Cms1_画面透過_50per.Name = "Cms1_画面透過_50per";
			this.Cms1_画面透過_50per.Size = new System.Drawing.Size(96, 22);
			this.Cms1_画面透過_50per.Text = "50%";
			this.Cms1_画面透過_50per.Click += new System.EventHandler(this.Cms1_画面透過_50per_Click);
			// 
			// Cms1_画面透過_75per
			// 
			this.Cms1_画面透過_75per.Name = "Cms1_画面透過_75per";
			this.Cms1_画面透過_75per.Size = new System.Drawing.Size(96, 22);
			this.Cms1_画面透過_75per.Text = "75%";
			this.Cms1_画面透過_75per.Click += new System.EventHandler(this.Cms1_画面透過_75per_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
			// 
			// Cms1_スクリーンショット
			// 
			this.Cms1_スクリーンショット.BackColor = System.Drawing.Color.RoyalBlue;
			this.Cms1_スクリーンショット.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Cms1_スクリーンショット.ForeColor = System.Drawing.Color.White;
			this.Cms1_スクリーンショット.Image = ((System.Drawing.Image)(resources.GetObject("Cms1_スクリーンショット.Image")));
			this.Cms1_スクリーンショット.Name = "Cms1_スクリーンショット";
			this.Cms1_スクリーンショット.Size = new System.Drawing.Size(152, 22);
			this.Cms1_スクリーンショット.Text = "スクリーンショット";
			this.Cms1_スクリーンショット.Click += new System.EventHandler(this.Cms1_スクリーンショット_Click);
			// 
			// Cms1_最小化
			// 
			this.Cms1_最小化.Image = ((System.Drawing.Image)(resources.GetObject("Cms1_最小化.Image")));
			this.Cms1_最小化.Name = "Cms1_最小化";
			this.Cms1_最小化.Size = new System.Drawing.Size(152, 22);
			this.Cms1_最小化.Text = "最小化";
			this.Cms1_最小化.Click += new System.EventHandler(this.Cms1_最小化_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
			// 
			// Cms1_画像を保存
			// 
			this.Cms1_画像を保存.Image = ((System.Drawing.Image)(resources.GetObject("Cms1_画像を保存.Image")));
			this.Cms1_画像を保存.Name = "Cms1_画像を保存";
			this.Cms1_画像を保存.Size = new System.Drawing.Size(152, 22);
			this.Cms1_画像を保存.Text = "画像を保存";
			this.Cms1_画像を保存.Click += new System.EventHandler(this.Cms1_画像を保存_Click);
			// 
			// Cms1_操作説明
			// 
			this.Cms1_操作説明.Image = ((System.Drawing.Image)(resources.GetObject("Cms1_操作説明.Image")));
			this.Cms1_操作説明.Name = "Cms1_操作説明";
			this.Cms1_操作説明.Size = new System.Drawing.Size(152, 22);
			this.Cms1_操作説明.Text = "操作説明";
			this.Cms1_操作説明.Click += new System.EventHandler(this.Cms1_操作説明_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
			// 
			// Cms1_閉じる
			// 
			this.Cms1_閉じる.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Cms1_閉じる.Image = ((System.Drawing.Image)(resources.GetObject("Cms1_閉じる.Image")));
			this.Cms1_閉じる.ImageTransparentColor = System.Drawing.Color.Transparent;
			this.Cms1_閉じる.Name = "Cms1_閉じる";
			this.Cms1_閉じる.Size = new System.Drawing.Size(152, 22);
			this.Cms1_閉じる.Text = "閉じる";
			this.Cms1_閉じる.Click += new System.EventHandler(this.Cms1_閉じる_Click);
			// 
			// ToolTip1
			// 
			this.ToolTip1.AutomaticDelay = 150;
			this.ToolTip1.OwnerDraw = true;
			this.ToolTip1.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.ToolTip1_Draw);
			this.ToolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.ToolTip1_Popup);
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
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.DimGray;
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
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.Cms1.ResumeLayout(false);
			this.Cms2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.PictureBox PictureBox1;
		private System.Windows.Forms.ToolTip ToolTip1;
		private System.Windows.Forms.ContextMenuStrip Cms1;
		private System.Windows.Forms.ToolStripMenuItem Cms1_クリア;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem Cms1_マーカー色;
		private System.Windows.Forms.ToolStripMenuItem Cms1_マーカー色_レッド;
		private System.Windows.Forms.ToolStripMenuItem Cms1_マーカー色_ブルー;
		private System.Windows.Forms.ToolStripMenuItem Cms1_マーカー色_マゼンタ;
		private System.Windows.Forms.ToolStripMenuItem Cms1_マーカー色_ライム;
		private System.Windows.Forms.ToolStripMenuItem Cms1_マーカー色_イエロー;
		private System.Windows.Forms.ToolStripMenuItem Cms1_マーカー色_オレンジ;
		private System.Windows.Forms.ToolStripMenuItem Cms1_マーカー色_シアン;
		private System.Windows.Forms.ToolStripMenuItem Cms1_マーカーサイズ;
		private System.Windows.Forms.ToolStripMenuItem Cms1_マーカーサイズ_3px;
		private System.Windows.Forms.ToolStripMenuItem Cms1_マーカーサイズ_6px;
		private System.Windows.Forms.ToolStripMenuItem Cms1_マーカーサイズ_9px;
		private System.Windows.Forms.ToolStripMenuItem Cms1_マーカーサイズ_15px;
		private System.Windows.Forms.ToolStripMenuItem Cms1_マーカーサイズ_24px;
		private System.Windows.Forms.ToolStripMenuItem Cms1_画面透過;
		private System.Windows.Forms.ToolStripMenuItem Cms1_画面透過_0per;
		private System.Windows.Forms.ToolStripMenuItem Cms1_画面透過_25per;
		private System.Windows.Forms.ToolStripMenuItem Cms1_画面透過_50per;
		private System.Windows.Forms.ToolStripMenuItem Cms1_画面透過_75per;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem Cms1_スクリーンショット;
		private System.Windows.Forms.ToolStripMenuItem Cms1_最小化;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem Cms1_画像を保存;
		private System.Windows.Forms.ToolStripMenuItem Cms1_操作説明;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem Cms1_閉じる;
		private System.Windows.Forms.ContextMenuStrip Cms2;
		private System.Windows.Forms.ToolStripMenuItem Cms2_四角;
		private System.Windows.Forms.ToolStripMenuItem Cms2_円;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem Cms2_矢印;
		private System.Windows.Forms.ToolStripMenuItem Cms2_矢印両端;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem Cms2_直線;
	}
}
