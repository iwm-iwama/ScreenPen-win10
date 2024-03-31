using System;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace iwm_ScreenPen
{
	public partial class Form1 : Form
	{
		private const string COPYRIGHT = "(C)2022-2024 iwm-iwama";
		private const string VERSION = "iwm_ScreenPen_20240328";

		// Global
		private static readonly Color GblPic1MaxBtnColor = Color.DarkBlue;
		private static readonly Color GblPic1MinBtnColor = Color.Crimson;

		private static readonly Color[] GblAryMarkerColor = {
			Color.Red,     // [0]
			Color.Blue,    // [1]
			Color.Magenta, // [2]
			Color.Lime,    // [3]
			Color.Yellow,  // [4]
			Color.Orange,  // [5]
			Color.Cyan     // [6]
		};

		private readonly List<ToolStripMenuItem> GblListCms1MarkerColor = new List<ToolStripMenuItem>();

		private static readonly int[] GblAryMarkerSize = {
			3,  // [0]
			6,  // [1]
			9,  // [2]
			15, // [3]
			24  // [4]
		};

		private readonly List<ToolStripMenuItem> GblListCms1MarkerSize = new List<ToolStripMenuItem>();

		private readonly List<ToolStripMenuItem> GblListCms1Opacity = new List<ToolStripMenuItem>();

		// Current
		private Bitmap Bitmap1 = null;
		private Graphics Graphics1 = null;

		private readonly List<Bitmap> ListBitmap = new List<Bitmap>();
		private int ListBitmapCurIndex = 0;

		private Bitmap BitmapCms2 = null;
		private Bitmap BitmapResize = null;

		private Pen Marker1 = null;
		private Color Marker1Color = GblAryMarkerColor[0];
		private int Marker1Size = GblAryMarkerSize[2];

		private Cursor CursorPen = null;

		private int Drag1X = 0, Drag1Y = 0;
		private bool Drag1On = false;

		private int Drag2X = 0, Drag2Y = 0;
		private int Drag2Type = 0;
		private readonly int[] Drag2XYWH = { 0, 0, 0, 0 };

		public Form1()
		{
			InitializeComponent();

			// MouseWhell イベント追加
			MouseWheel += new MouseEventHandler(Form_MouseWheel);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// Form1 設定
			TopMost = true;
			SubBtnFormSizeChange();

			// PictureBox1 初期化
			Bitmap1 = new Bitmap(Width, Height);
			Graphics1 = Graphics.FromImage(Bitmap1);
			Graphics1.FillRectangle(Brushes.Black, 0, 0, Width, Height);
			PictureBox1.BackgroundImage = Bitmap1;
			PictureBox1.Refresh();

			// ボタン色
			BtnFormSizeChange1.BackColor = BtnFormSizeChange2.BackColor = BtnFormSizeChange3.BackColor = BtnFormSizeChange4.BackColor = GblPic1MaxBtnColor;

			// 履歴を初期化
			ListBitmap.Add(new Bitmap(Bitmap1));
			ListBitmapCurIndex = 0;

			// Marker1 設定
			SubMarker1ToolTip(Marker1Color, Marker1Size);

			// マウスカーソル 設定
			System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
			CursorPen = new Cursor(asm.GetManifestResourceStream(asm.GetName().Name + ".cursor-pen.ico"));
			PictureBox1.Cursor = CursorPen;

			// ToolTip1 設定
			ToolTip1.AutoPopDelay = ToolTip1.AutomaticDelay = 2000;
			ToolTip1.OwnerDraw = true;
			ToolTip1.Popup += new PopupEventHandler(ToolTip1_Popup);
			ToolTip1.Draw += new DrawToolTipEventHandler(ToolTip1_Draw);

			// Cms1 マーカー色
			GblListCms1MarkerColor.Add(Cms1_マーカー色0);
			GblListCms1MarkerColor.Add(Cms1_マーカー色1);
			GblListCms1MarkerColor.Add(Cms1_マーカー色2);
			GblListCms1MarkerColor.Add(Cms1_マーカー色3);
			GblListCms1MarkerColor.Add(Cms1_マーカー色4);
			GblListCms1MarkerColor.Add(Cms1_マーカー色5);
			GblListCms1MarkerColor.Add(Cms1_マーカー色6);

			for (int _i1 = 0; _i1 < GblListCms1MarkerColor.Count; _i1++)
			{
				GblListCms1MarkerColor[_i1].Text = GblAryMarkerColor[_i1].Name;
			}

			// Cms1 マーカーサイズ
			GblListCms1MarkerSize.Add(Cms1_マーカーサイズ0);
			GblListCms1MarkerSize.Add(Cms1_マーカーサイズ1);
			GblListCms1MarkerSize.Add(Cms1_マーカーサイズ2);
			GblListCms1MarkerSize.Add(Cms1_マーカーサイズ3);
			GblListCms1MarkerSize.Add(Cms1_マーカーサイズ4);

			for (int _i1 = 0; _i1 < GblListCms1MarkerSize.Count; _i1++)
			{
				GblListCms1MarkerSize[_i1].Text = GblAryMarkerSize[_i1] + "px";
			}

			// Cms1 画面透過
			GblListCms1Opacity.Add(Cms1_画面透過_0per);
			GblListCms1Opacity.Add(Cms1_画面透過_25per);
			GblListCms1Opacity.Add(Cms1_画面透過_50per);
			GblListCms1Opacity.Add(Cms1_画面透過_75per);

			// 操作説明
			LblHelp.Visible = false;

			int i1 = 0;
			string s1 = "";
			for (; i1 < GblAryMarkerColor.Length - 1; i1++)
			{
				s1 += GblAryMarkerColor[i1].Name + ", ";
			}
			s1 += GblAryMarkerColor[i1].Name;

			int i2 = 0;
			string s2 = "";
			for (; i2 < GblAryMarkerSize.Length - 1; i2++)
			{
				s2 += GblAryMarkerSize[i2] + "px, ";
			}
			s2 += GblAryMarkerSize[i2] + "px";

			LblHelp.Text =
				$"{VERSION}  {COPYRIGHT}\n\n" +
				"【操作説明】\n\n" +
				"  [右クリック]\n" +
				"    コンテキストメニュー\n\n" +
				"  [Space]\n" +
				"    スクリーンショット\n\n" +
				"  [左クリック]＋[ドラッグ]\n" +
				"    フリーハンド描画\n\n" +
				"  [左ダブルクリック]\n" +
				"    四角／円／矢印／線を描画\n" +
				"    描画種を選択、マウスカーソルで範囲指定、左クリックで決定\n\n" +
				"  [マウスホイール]\n" +
				"    拡大率を変更\n\n" +
				"  [四隅のボタン]\n" +
				"    最小化／元に戻す\n\n" +
				"  [F1]\n" +
				"    操作説明を表示／非表示\n\n" +
				"  [F5／F6]\n" +
				"    マーカー色変更\n" +
				"      " + s1 + "\n\n" +
				"  [F7／F8]\n" +
				"    マーカーサイズ変更\n" +
				"      " + s2 + "\n\n" +
				"  [F9／F10]\n" +
				"    透過率を下げる／上げる\n\n" +
				"  [F11／F12]\n" +
				"    前／次の履歴画面へ移動\n";
			LblHelp.Left = (Width - LblHelp.Width) / 2;
			LblHelp.Top = (Height - LblHelp.Height) / 2;
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			// コンテキストメニュー表示
			Cursor.Position = new Point((int)((Screen.PrimaryScreen.Bounds.Width * 0.5) - (Cms1.Width * 0.5)), (int)((Screen.PrimaryScreen.Bounds.Height * 0.25)));
			Cms1.Show(Cursor.Position);
		}

		private void PictureBox1_MouseEnter(object sender, EventArgs e)
		{
			_ = PictureBox1.Focus();
		}

		private bool Gbl_PictureBox1_DoubleClick_On = false;

		private void PictureBox1_DoubleClick(object sender, EventArgs e)
		{
			Gbl_PictureBox1_DoubleClick_On = true;

			if (Drag2Type == 0)
			{
				Point cp = PointToClient(Cursor.Position);
				Drag2X = cp.X;
				Drag2Y = cp.Y;

				// 描画タイプ選択
				Cms2.Show(Cursor.Position);

				// 画面バックアップ
				BitmapCms2 = new Bitmap(Bitmap1);
			}
		}

		private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			Drag1On = false;

			if (Drag2Type > 0)
			{
				Drag2Type = 0;
				return;
			}

			// 左クリック でフリーハンド描画
			if (e.Button == MouseButtons.Left)
			{
				Drag1On = true;
				Drag1X = e.X;
				Drag1Y = e.Y;

				Marker1 = new Pen(Marker1Color, Marker1Size)
				{
					DashStyle = DashStyle.Solid,
					StartCap = LineCap.Round,
					EndCap = LineCap.Round
				};

				SubMarker1ToolTip(Marker1Color, Marker1Size);
				ToolTip1.AutoPopDelay = 1000;
				ToolTip1.SetToolTip(PictureBox1, ToolTip1.GetToolTip(PictureBox1));
				ToolTip1.AutoPopDelay = 0;
			}
		}

		private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			if (Drag2Type > 0)
			{
				Point cp = PointToClient(Cursor.Position);

				if (Drag2X <= cp.X)
				{
					Drag2XYWH[0] = Drag2X;
					Drag2XYWH[2] = cp.X - Drag2X;
				}
				else
				{
					Drag2XYWH[0] = cp.X;
					Drag2XYWH[2] = Drag2X - cp.X;
				}

				if (Drag2Y <= cp.Y)
				{
					Drag2XYWH[1] = Drag2Y;
					Drag2XYWH[3] = cp.Y - Drag2Y;
				}
				else
				{
					Drag2XYWH[1] = cp.Y;
					Drag2XYWH[3] = Drag2Y - cp.Y;
				}

				// バックアップ画面に戻す
				Graphics1.DrawImage(BitmapCms2, 0, 0);

				switch (Drag2Type)
				{
					case 1: // 四角
						SubDrawRectangle(Drag2XYWH[0], Drag2XYWH[1], Drag2XYWH[2], Drag2XYWH[3], 16);
						break;

					case 2: // 円
						Graphics1.DrawEllipse(Marker1, Drag2XYWH[0], Drag2XYWH[1], Drag2XYWH[2], Drag2XYWH[3]);
						break;

					case 11: // 矢印
					case 12: // 矢印（両端）
					case 21: // 直線
						Graphics1.DrawLine(Marker1, new Point(Drag2X, Drag2Y), new Point(cp.X, cp.Y));
						break;
				}

				PictureBox1.BackgroundImage = Bitmap1;
				PictureBox1.Refresh();

				return;
			}

			// １クリック による描画を回避
			if (Drag1On && (Drag1X != e.X || Drag1Y != e.Y))
			{
				// 描画時は情報非表示
				ToolTip1.Hide(PictureBox1);

				Graphics1.DrawLine(Marker1, new Point(Drag1X, Drag1Y), new Point(e.X, e.Y));
				PictureBox1.Refresh();

				Drag1X = e.X;
				Drag1Y = e.Y;
			}
		}

		private void SubDrawRectangle(int iX, int iY, int iW, int iH, int iR)
		{
			int iR4 = iR * 4;
			if (iR4 > iW || iR4 > iH)
			{
				Graphics1.DrawRectangle(Marker1, iX, iY, iW, iH);
			}
			else
			{
				/// (int)((Math.Sqrt(2) - 1.0) / 3 * iR4)
				int i1 = (int)(0.41421356 * 0.33333333 * iR4);

				GraphicsPath path = new GraphicsPath();
				path.StartFigure();
				path.AddBezier(iX, iY + iR, iX, iY + iR - i1, iX + iR - i1, iY, iX + iR, iY);
				path.AddBezier(iX + iW - iR, iY, iX + iW - iR + i1, iY, iX + iW, iY + iR - i1, iX + iW, iY + iR);
				path.AddBezier(iX + iW, iY + iH - iR, iX + iW, iY + iH - iR + i1, iX + iW - iR + i1, iY + iH, iX + iW - iR, iY + iH);
				path.AddBezier(iX + iR, iY + iH, iX + iR - i1, iY + iH, iX, iY + iH - iR + i1, iX, iY + iH - iR);
				path.CloseFigure();
				Graphics1.DrawPath(Marker1, path);
			}
		}

		private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
		{
			if (Gbl_PictureBox1_DoubleClick_On)
			{
				// ダブルクリックの１度目はシングルクリックとして(後述)画面保存するため、その画像を削除しておく。
				ListBitmap.RemoveAt(ListBitmap.Count - 1);
				// インデックス末尾
				ListBitmapCurIndex = ListBitmap.Count - 1;
				return;
			}

			switch (e.Button)
			{
				case MouseButtons.Left:
					Drag1On = false;
					ListBitmap.Add(new Bitmap(Bitmap1));
					ListBitmapCurIndex = ListBitmap.Count - 1;
					break;
			}
		}

		private void Form_MouseWheel(object sender, MouseEventArgs e)
		{
			// 上回転 +120
			if (e.Delta > 0)
			{
				SubImageResize(true);
			}
			// 下回転 -120
			else if (e.Delta < 0)
			{
				SubImageResize(false);
			}
		}

		private readonly int[] AryImageResize = { 1, 2, 4, 8 };
		private int AryImageResizeIndex = 0;
		private int ImageResizePosX = 0, ImageResizePosY = 0;

		private void SubImageResize(bool bUp)
		{
			if (bUp && AryImageResizeIndex == (AryImageResize.Length - 1) || !bUp && AryImageResizeIndex == 0)
			{
			}
			else
			{
				int i1, i2, iX, iY;

				// 100%画面をバックアップ
				if (AryImageResize[AryImageResizeIndex] == 1)
				{
					BitmapResize = new Bitmap(Bitmap1);
				}

				if (bUp)
				{
					++AryImageResizeIndex;

					Point cp = PointToClient(Cursor.Position);
					iX = -cp.X;
					iY = -cp.Y;
					ImageResizePosX = cp.X;
					ImageResizePosY = cp.Y;
				}
				else
				{
					// 100%画面に戻す
					AryImageResizeIndex = 0;

					iX = -ImageResizePosX;
					iY = -ImageResizePosY;
				}

				i1 = AryImageResize[AryImageResizeIndex];
				i2 = i1 - 1;

				// 100%画面を元に拡大
				Graphics1.DrawImage(BitmapResize, 0, 0);
				Graphics1.DrawImage(Bitmap1, iX * i2, iY * i2, Width * i1, Height * i1);
				Graphics1.InterpolationMode = bUp ? InterpolationMode.HighQualityBicubic : InterpolationMode.Default;
				PictureBox1.BackgroundImage = Bitmap1;
				PictureBox1.Refresh();
			}

			ToolTip1.AutoPopDelay = 2000;
			ToolTip1.SetToolTip(PictureBox1, $"拡大率 {AryImageResize[AryImageResizeIndex] * 100}%");
			ToolTip1.AutoPopDelay = 0;
		}

		private void SubMarker1ToolTip(Color pen1Color, int pen1Size)
		{
			Marker1Color = pen1Color;
			Marker1Size = pen1Size;

			// 初期設定
			Marker1 = new Pen(Marker1Color, Marker1Size)
			{
				DashStyle = DashStyle.Solid,
				StartCap = LineCap.Round,
				EndCap = LineCap.Round
			};

			ToolTip1.AutoPopDelay = 2000;
			ToolTip1.SetToolTip(PictureBox1, $"{Marker1Color.Name} {Marker1Size}px");
			ToolTip1.AutoPopDelay = 0;
		}

		private void PictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			switch (e.KeyCode)
			{
				// スクリーンショット
				case Keys.Space:
					Cms1_スクリーンショット_Click(sender, null);
					break;

				// 操作説明
				case Keys.F1:
					Cms1_操作説明_Click(sender, e);
					break;

				// マーカー
				case Keys.F5:
				case Keys.F6:
				case Keys.F7:
				case Keys.F8:
					// マーカー色 -1
					if (e.KeyCode == Keys.F5)
					{
						for (int _i1 = GblAryMarkerColor.Length - 1; _i1 > 0; _i1--)
						{
							if (GblAryMarkerColor[_i1] == Marker1Color)
							{
								Marker1Color = GblAryMarkerColor[--_i1];
								break;
							}
						}
					}
					// マーカー色 +1
					else if (e.KeyCode == Keys.F6)
					{

						for (int _i1 = 0; _i1 < GblAryMarkerColor.Length - 1; _i1++)
						{
							if (GblAryMarkerColor[_i1] == Marker1Color)
							{
								Marker1Color = GblAryMarkerColor[++_i1];
								break;
							}
						}
					}
					// マーカーサイズ -1
					else if (e.KeyCode == Keys.F7)
					{
						for (int _i1 = GblAryMarkerSize.Length - 1; _i1 > 0; _i1--)
						{
							if (GblAryMarkerSize[_i1] == Marker1Size)
							{
								Marker1Size = GblAryMarkerSize[--_i1];
								break;
							}
						}
					}
					// マーカーサイズ +1
					else if (e.KeyCode == Keys.F8)
					{
						for (int _i1 = 0; _i1 < GblAryMarkerSize.Length - 1; _i1++)
						{
							if (GblAryMarkerSize[_i1] == Marker1Size)
							{
								Marker1Size = GblAryMarkerSize[++_i1];
								break;
							}
						}
					}
					SubMarker1ToolTip(Marker1Color, Marker1Size);
					ToolTip1.AutoPopDelay = 750;
					ToolTip1.SetToolTip(PictureBox1, ToolTip1.GetToolTip(PictureBox1));
					ToolTip1.AutoPopDelay = 0;
					break;

				// 透過率 -25%
				case Keys.F9:
					Opacity += 0.25F;
					if (Opacity > 1.0F)
					{
						Opacity = 1.0F;
					}
					break;

				// 透過率 +25%
				case Keys.F10:
					Opacity -= 0.25F;
					if (Opacity < 0.25F)
					{
						Opacity = 0.25F;
					}
					break;

				// Undo
				case Keys.F11:
					--ListBitmapCurIndex;
					if (ListBitmapCurIndex < 0)
					{
						ListBitmapCurIndex = 0;
						return;
					}
					break;

				// Redo
				case Keys.F12:
					++ListBitmapCurIndex;
					if (ListBitmapCurIndex >= ListBitmap.Count)
					{
						ListBitmapCurIndex = ListBitmap.Count - 1;
						return;
					}
					break;
			}

			Graphics1.DrawImage(ListBitmap[ListBitmapCurIndex], 0, 0);
			PictureBox1.BackgroundImage = Bitmap1;
			PictureBox1.Refresh();
		}

		private void Cms1_Opened(object sender, EventArgs e)
		{
			// Cms1 移動
			Cms1.Left -= 4;
			Cms1.Top += 32;

			string s1 = "";

			foreach (ToolStripMenuItem _v1 in GblListCms1MarkerColor)
			{
				_v1.Checked = false;
			}

			for (int _i1 = 0; _i1 < GblAryMarkerColor.Length; _i1++)
			{
				if (GblAryMarkerColor[_i1] == Marker1Color)
				{
					GblListCms1MarkerColor[_i1].Checked = true;
					s1 = GblListCms1MarkerColor[_i1].Text;
					break;
				}
			}
			Cms1_マーカー色.Text = $"マーカー色（{s1}）";

			foreach (ToolStripMenuItem _v1 in GblListCms1MarkerSize)
			{
				_v1.Checked = false;
			}

			for (int _i1 = 0; _i1 < GblAryMarkerSize.Length; _i1++)
			{
				if (GblAryMarkerSize[_i1] == Marker1Size)
				{
					GblListCms1MarkerSize[_i1].Checked = true;
					s1 = GblListCms1MarkerSize[_i1].Text;
					break;
				}
			}
			Cms1_マーカーサイズ.Text = $"マーカーサイズ（{s1}）";

			foreach (ToolStripMenuItem _v1 in GblListCms1Opacity)
			{
				_v1.Checked = false;
			}

			GblListCms1Opacity[(int)((1.0F - Opacity) * 4.0F)].Checked = true;

			Cms1_画面透過.Text = $"画面透過（{(int)((1.0F - Opacity) * 100F)}%）";
		}

		private void Cms1_操作説明_Click(object sender, EventArgs e)
		{
			if (LblHelp.Visible)
			{
				LblHelp.Visible = false;
				PictureBox1.Focus();
			}
			else
			{
				LblHelp.Visible = true;
				LblHelp.Focus();
			}
		}

		private void Cms1_マーカー色0_Click(object sender, EventArgs e)
		{
			Marker1Color = GblAryMarkerColor[0];
		}

		private void Cms1_マーカー色1_Click(object sender, EventArgs e)
		{
			Marker1Color = GblAryMarkerColor[1];
		}

		private void Cms1_マーカー色2_Click(object sender, EventArgs e)
		{
			Marker1Color = GblAryMarkerColor[2];
		}

		private void Cms1_マーカー色3_Click(object sender, EventArgs e)
		{
			Marker1Color = GblAryMarkerColor[3];
		}

		private void Cms1_マーカー色4_Click(object sender, EventArgs e)
		{
			Marker1Color = GblAryMarkerColor[4];
		}

		private void Cms1_マーカー色5_Click(object sender, EventArgs e)
		{
			Marker1Color = GblAryMarkerColor[5];
		}

		private void Cms1_マーカー色6_Click(object sender, EventArgs e)
		{
			Marker1Color = GblAryMarkerColor[6];
		}

		private void Cms1_マーカーサイズ0_Click(object sender, EventArgs e)
		{
			Marker1Size = GblAryMarkerSize[0];
		}

		private void Cms1_マーカーサイズ1_Click(object sender, EventArgs e)
		{
			Marker1Size = GblAryMarkerSize[1];
		}

		private void Cms1_マーカーサイズ2_Click(object sender, EventArgs e)
		{
			Marker1Size = GblAryMarkerSize[2];
		}

		private void Cms1_マーカーサイズ3_Click(object sender, EventArgs e)
		{
			Marker1Size = GblAryMarkerSize[3];
		}

		private void Cms1_マーカーサイズ4_Click(object sender, EventArgs e)
		{
			Marker1Size = GblAryMarkerSize[4];
		}

		private void Cms1_画面透過_0per_Click(object sender, EventArgs e)
		{
			Opacity = 1.0F;
		}

		private void Cms1_画面透過_25per_Click(object sender, EventArgs e)
		{
			Opacity = 0.75F;
		}

		private void Cms1_画面透過_50per_Click(object sender, EventArgs e)
		{
			Opacity = 0.5F;
		}

		private void Cms1_画面透過_75per_Click(object sender, EventArgs e)
		{
			Opacity = 0.25F;
		}

		private void Cms1_スクリーンショット_Click(object sender, EventArgs e)
		{
			// スクリーンショット
			Visible = false;
			Graphics1.CopyFromScreen(new Point(Left + 1, Top + 1), new Point(0, 0), Bitmap1.Size);
			Visible = true;

			// 履歴に追加
			ListBitmap.Add(new Bitmap(Bitmap1));
			ListBitmapCurIndex = ListBitmap.Count - 1;

			// 100%画面
			AryImageResizeIndex = 0;
		}

		private void Cms1_クリア_Click(object sender, EventArgs e)
		{
			try
			{
				Graphics1.FillRectangle(Brushes.Black, 0, 0, Width, Height);
				PictureBox1.BackgroundImage = Bitmap1;
				PictureBox1.Refresh();

				// 履歴をクリア
				ListBitmap.Clear();
				ListBitmap.Add(new Bitmap(Bitmap1));
				ListBitmapCurIndex = 0;

				GC.Collect();
			}
			catch
			{
			}

			// 100%画面
			AryImageResizeIndex = 0;
		}

		private void Cms1_画像を保存_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog
			{
				FileName = DateTime.Now.ToString("yyyyMMdd_HHmmss"),
				Filter = "PNG - Portable Network Graphics (*.png)|*.png",
				FilterIndex = 1,
				InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
			};

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				Bitmap1.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
			}
		}

		private void Cms1_終了_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void Cms2_Opened(object sender, EventArgs e)
		{
			Drag2Type = 0;
		}

		private void Cms2_Closed(object sender, ToolStripDropDownClosedEventArgs e)
		{
			Gbl_PictureBox1_DoubleClick_On = false;
		}

		private void Cms2_MouseLeave(object sender, EventArgs e)
		{
			Drag1On = false;
			Cms2.Close();
		}

		private void Cms2_四角_Click(object sender, EventArgs e)
		{
			Drag2Type = 1;
			Marker1 = new Pen(Marker1Color, Marker1Size)
			{
				DashStyle = DashStyle.Solid
			};
		}

		private void Cms2_円_Click(object sender, EventArgs e)
		{
			Drag2Type = 2;
			Marker1 = new Pen(Marker1Color, Marker1Size)
			{
				DashStyle = DashStyle.Solid
			};
		}

		private void Cms2_矢印_Click(object sender, EventArgs e)
		{
			Drag2Type = 11;
			Marker1 = new Pen(Marker1Color, Marker1Size)
			{
				DashStyle = DashStyle.Solid,
				StartCap = LineCap.Round,
				EndCap = LineCap.ArrowAnchor,
				CustomEndCap = new AdjustableArrowCap(6, 4, false)
			};
		}

		private void Cms2_矢印両端_Click(object sender, EventArgs e)
		{
			Drag2Type = 12;
			Marker1 = new Pen(Marker1Color, Marker1Size)
			{
				DashStyle = DashStyle.Solid,
				StartCap = LineCap.ArrowAnchor,
				EndCap = LineCap.ArrowAnchor,
				CustomStartCap = new AdjustableArrowCap(6, 4, false),
				CustomEndCap = new AdjustableArrowCap(6, 4, false)
			};
		}

		private void Cms2_直線_Click(object sender, EventArgs e)
		{
			Drag2Type = 21;
			Marker1 = new Pen(Marker1Color, Marker1Size)
			{
				DashStyle = DashStyle.Solid,
				StartCap = LineCap.Round,
				EndCap = LineCap.Round
			};
		}

		private readonly string ToolTip1FotType = "Meiryo UI";
		private readonly float ToolTip1FontSize = 18.0F;

		private void ToolTip1_Popup(object sender, PopupEventArgs e)
		{
			// ツールチップサイズを計測
			e.ToolTipSize = TextRenderer.MeasureText(ToolTip1.GetToolTip(PictureBox1), new Font(ToolTip1FotType, ToolTip1FontSize + 2.0F));
		}

		private void ToolTip1_Draw(object sender, DrawToolTipEventArgs e)
		{
			// BackColor
			e.Graphics.FillRectangle(Brushes.Black, e.Bounds);

			// Border
			e.Graphics.DrawLines(
				new Pen(Marker1Color),
				new Point[]
				{
					new Point (0, 0),
					new Point (e.Bounds.Width - 1, 0),
					new Point (e.Bounds.Width - 1,  e.Bounds.Height - 1),
					new Point (0, e.Bounds.Height - 1),
					new Point (0, 0),
				}
			);

			// ForeColor
			using (Font font = new Font(ToolTip1FotType, ToolTip1FontSize))
			{
				e.Graphics.DrawString(e.ToolTipText, font, new SolidBrush(Marker1Color), new PointF(10, 1));
			}
		}

		private void LblHelp_Click(object sender, EventArgs e)
		{
			Cms1_操作説明_Click(sender, e);
		}

		private void LblHelp_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F1:
					Cms1_操作説明_Click(sender, e);
					break;
			}
		}

		private void BtnFormSizeChange1_Click(object sender, EventArgs e)
		{
			SubBtnFormSizeChange("1");
		}

		private void BtnFormSizeChange2_Click(object sender, EventArgs e)
		{
			SubBtnFormSizeChange("2");
		}

		private void BtnFormSizeChange3_Click(object sender, EventArgs e)
		{
			SubBtnFormSizeChange("3");
		}

		private void BtnFormSizeChange4_Click(object sender, EventArgs e)
		{
			SubBtnFormSizeChange("4");
		}

		private int GblLeft = 0;
		private int GblTop = 0;

		private void SubBtnFormSizeChange(string id = "")
		{
			Control ctrl = Controls[$"BtnFormSizeChange{id}"];
			bool bSizeMin = Width < SystemInformation.WorkingArea.Width || Height < SystemInformation.WorkingArea.Height;

			if (ctrl is null || bSizeMin)
			{
				Width = Screen.PrimaryScreen.Bounds.Width;
				Height = Screen.PrimaryScreen.Bounds.Height;
				Left = GblLeft = Screen.PrimaryScreen.Bounds.Left;
				Top = GblTop = Screen.PrimaryScreen.Bounds.Top;

				BtnFormSizeChange1.BackColor = BtnFormSizeChange2.BackColor = BtnFormSizeChange3.BackColor = BtnFormSizeChange4.BackColor = GblPic1MaxBtnColor;
				BtnFormSizeChange1.Visible = BtnFormSizeChange2.Visible = BtnFormSizeChange3.Visible = BtnFormSizeChange4.Visible = true;
			}
			else
			{
				BtnFormSizeChange1.Visible = BtnFormSizeChange2.Visible = BtnFormSizeChange3.Visible = BtnFormSizeChange4.Visible = false;

				GblLeft = SystemInformation.WorkingArea.Left;
				GblTop = SystemInformation.WorkingArea.Top;

				// ウィンドウ外のときはプロパティ値を取得できない？ので幅／高は最後に設定
				switch (id)
				{
					case ("1"):
						Left = GblLeft;
						Top = GblTop;
						break;
					case ("2"):
						Left = GblLeft + ctrl.Location.X - (Screen.PrimaryScreen.Bounds.Width - SystemInformation.WorkingArea.Width);
						Top = GblTop;
						break;
					case ("3"):
						Left = GblLeft;
						Top = GblTop + ctrl.Location.Y - (Screen.PrimaryScreen.Bounds.Height - SystemInformation.WorkingArea.Height);
						break;
					case ("4"):
						Left = GblLeft + ctrl.Location.X - (Screen.PrimaryScreen.Bounds.Width - SystemInformation.WorkingArea.Width);
						Top = GblTop + ctrl.Location.Y - (Screen.PrimaryScreen.Bounds.Height - SystemInformation.WorkingArea.Height);
						break;
				}

				Width = ctrl.Width + 2;
				Height = ctrl.Height + 2;
				ctrl.BackColor = GblPic1MinBtnColor;
				ctrl.Visible = true;
			}
		}

		private static class Program
		{
			/// <summary>
			/// アプリケーションのメイン エントリ ポイントです。
			/// </summary>
			[STAThread]
			private static void Main()
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new Form1());
			}
		}
	}
}
