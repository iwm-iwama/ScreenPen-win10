using System;
//using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace iwm_ScreenPen
{
	public partial class Form1 : Form
	{
		/// private const string Ver = "iwm20220625";

		// Current
		private Bitmap Bitmap1 = null;
		private Graphics Graphics1 = null;

		private Bitmap BitmapUndo = null;
		private Bitmap BitmapCms2 = null;
		private Bitmap BitmapResize = null;

		private Pen Pen1 = null;
		private Color Pen1Color = Color.Empty;
		private int Pen1Size = 0;
		private readonly Color[] AryPen1Color = { Color.Red, Color.Blue, Color.Magenta, Color.Lime, Color.Yellow, Color.Cyan };
		private int AryPen1ColorIndex = 0;
		private readonly int[] AryPen1Size = { 3, 6, 9, 15, 24 };
		private int AryPen1SizeIndex = 2;

		private Cursor CursorPen = null;

		private int Drag1X = 0, Drag1Y = 0;
		private bool Drag1On = false;

		private int Drag2X = 0, Drag2Y = 0;
		private int Drag2Type = 0;
		private readonly int[] Drag2XYWH = { 0, 0, 0, 0 };

		private readonly float[] AryOpacity = { 1.0F, 0.75F, 0.5F, 0.25F };
		private int AryOpacityIndex = 0;

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
			Left = SystemInformation.WorkingArea.Left;
			Top = SystemInformation.WorkingArea.Top;
			Width = SystemInformation.WorkingArea.Width;
			Height = SystemInformation.WorkingArea.Height;

			// PictureBox1 初期化
			Bitmap1 = new Bitmap(Width, Height);
			Graphics1 = Graphics.FromImage(Bitmap1);
			Graphics1.FillRectangle(Brushes.Black, 0, 0, Width, Height);
			PictureBox1.BackgroundImage = Bitmap1;
			PictureBox1.Refresh();
			BitmapUndo = new Bitmap(Bitmap1);

			// Pen1 設定
			SubPen1ToolTip(AryPen1Color[AryPen1ColorIndex], AryPen1Size[AryPen1SizeIndex]);

			// マウスカーソル 設定
			System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
			CursorPen = new Cursor(asm.GetManifestResourceStream(asm.GetName().Name + ".cursor-pen.ico"));
			PictureBox1.Cursor = CursorPen;

			// ToolTip1 設定
			ToolTip1.AutomaticDelay = 100;
			ToolTip1.OwnerDraw = true;
			ToolTip1.Popup += new PopupEventHandler(ToolTip1_Popup);
			ToolTip1.Draw += new DrawToolTipEventHandler(ToolTip1_Draw);
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			// コンテキストメニュー 表示
			Cursor.Position = new Point((int)((Screen.PrimaryScreen.Bounds.Width * 0.5) - (Cms1.Width * 0.5)), (int)((Screen.PrimaryScreen.Bounds.Height * 0.25)));
			Cms1.Show(Cursor.Position);
		}

		private void PictureBox1_MouseEnter(object sender, EventArgs e)
		{
			_ = PictureBox1.Focus();
		}

		private void PictureBox1_DoubleClick(object sender, EventArgs e)
		{
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
			if ((MouseButtons & MouseButtons.Left) == MouseButtons.Left)
			{
				Drag1On = true;
				Drag1X = e.X;
				Drag1Y = e.Y;

				Pen1 = new Pen(Pen1Color, Pen1Size)
				{
					DashStyle = DashStyle.Solid,
					StartCap = LineCap.Round,
					EndCap = LineCap.Round
				};

				SubPen1ToolTip(Pen1Color, Pen1Size);
				ToolTip1.SetToolTip(PictureBox1, ToolTip1.GetToolTip(PictureBox1));
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
						Graphics1.DrawEllipse(Pen1, Drag2XYWH[0], Drag2XYWH[1], Drag2XYWH[2], Drag2XYWH[3]);
						break;

					case 11: // 矢印
					case 12: // 矢印（両端）
					case 21: // 直線
						Graphics1.DrawLine(Pen1, new Point(Drag2X, Drag2Y), new Point(cp.X, cp.Y));
						break;
				}

				PictureBox1.BackgroundImage = Bitmap1;
				PictureBox1.Refresh();

				return;
			}

			// １クリック による描画を回避
			if (Drag1On && (Drag1X != e.X || Drag1Y != e.Y))
			{
				Graphics1.DrawLine(Pen1, new Point(Drag1X, Drag1Y), new Point(e.X, e.Y));
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
				Graphics1.DrawRectangle(Pen1, iX, iY, iW, iH);
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
				Graphics1.DrawPath(Pen1, path);
			}
		}

		private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
		{
			Drag1On = false;
		}

		private void Form_MouseWheel(object sender, MouseEventArgs e)
		{
			// 上回転 +120
			if (e.Delta > 0)
			{
				if ((Control.ModifierKeys & Keys.Control) == Keys.Control && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
				{
					SubOpacitySelect(true);
				}
				else if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
				{
					SubPen1Resize(true);
				}
				else if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
				{
					SubPen1ColorSelect(true);
				}
				else
				{
					SubImageResize(true);
				}
			}
			// 下回転 -120
			else if (e.Delta < 0)
			{
				if ((Control.ModifierKeys & Keys.Control) == Keys.Control && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
				{
					SubOpacitySelect(false);
				}
				else if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
				{
					SubPen1Resize(false);
				}
				else if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
				{
					SubPen1ColorSelect(false);
				}
				else
				{
					SubImageResize(false);
				}
			}
		}

		private void SubOpacitySelect(bool bUp)
		{
			if (bUp && AryOpacityIndex == (AryOpacity.Length - 1) || !bUp && AryOpacityIndex == 0)
			{
			}
			else
			{
				if (bUp)
				{
					++AryOpacityIndex;
				}
				else
				{
					--AryOpacityIndex;
				}
			}
			Opacity = AryOpacity[AryOpacityIndex];
			ToolTip1.SetToolTip(PictureBox1, $"透過率 {100 - (int)(AryOpacity[AryOpacityIndex] * 100)}%");
		}

		private void SubPen1Resize(bool bUp)
		{
			if (bUp && AryPen1SizeIndex == (AryPen1Size.Length - 1) || !bUp && AryPen1SizeIndex == 0)
			{
			}
			else
			{
				if (bUp)
				{
					++AryPen1SizeIndex;
				}
				else
				{
					--AryPen1SizeIndex;
				}
			}
			SubPen1ToolTip(Pen1Color, AryPen1Size[AryPen1SizeIndex]);
		}

		private void SubPen1ColorSelect(bool bUp)
		{
			if (bUp && AryPen1ColorIndex == (AryPen1Color.Length - 1) || !bUp && AryPen1ColorIndex == 0)
			{
			}
			else
			{
				if (bUp)
				{
					++AryPen1ColorIndex;
				}
				else
				{
					--AryPen1ColorIndex;
				}
			}
			SubPen1ToolTip(AryPen1Color[AryPen1ColorIndex], Pen1Size);
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

			ToolTip1.SetToolTip(PictureBox1, $"拡大率 {AryImageResize[AryImageResizeIndex] * 100}%");
		}

		private void SubPen1ToolTip(Color pen1Color, int pen1Size)
		{
			Pen1Color = pen1Color;
			Pen1Size = pen1Size;

			// 初期設定
			Pen1 = new Pen(Pen1Color, Pen1Size)
			{
				DashStyle = DashStyle.Solid,
				StartCap = LineCap.Round,
				EndCap = LineCap.Round
			};

			ToolTip1.SetToolTip(PictureBox1, $"{Pen1Color.Name} {Pen1Size}px");
		}

		private void Cms1_Opened(object sender, EventArgs e)
		{
			// Cms1 移動
			Cms1.Left += 26;
			Cms1.Top -= 2;
		}

		private void Cms1_スクリーンショット_Click(object sender, EventArgs e)
		{
			Visible = false;
			Graphics1.CopyFromScreen(new Point(Left + 1, Top + 1), new Point(0, 0), Bitmap1.Size);
			PictureBox1.BackgroundImage = Bitmap1;
			PictureBox1.Refresh();
			BitmapUndo = new Bitmap(Bitmap1);
			Visible = true;

			// 100%画面
			AryImageResizeIndex = 0;

			GC.Collect();
		}

		private void Cms1_クリア_Click(object sender, EventArgs e)
		{
			Graphics1.DrawImage(BitmapUndo, 0, 0);
			PictureBox1.BackgroundImage = Bitmap1;
			PictureBox1.Refresh();

			// 100%画面
			AryImageResizeIndex = 0;

			GC.Collect();
		}

		private void Cms1_最小化_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
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

		private void Cms1_操作説明_Click(object sender, EventArgs e)
		{
			_ = MessageBox.Show(
				"・[左クリック]\n" +
				"　　ペン色・太さの情報を表示\n\n" +
				"・[左クリック] ＋ [ドラッグ]\n" +
				"　　フリーハンド描画\n\n" +
				"・[左ダブルクリック]\n" +
				"　　四角、円、矢印、線を描画\n" +
				"　　マウスカーソルで範囲指定、左クリックで描画\n\n" +
				"・[マウスホイール]\n" +
				"　　拡大率を変更\n\n" +
				"・[Ctrl] ＋ [マウスホイール]\n" +
				"　　ペン色を変更\n\n" +
				"・[Shift] ＋ [マウスホイール]\n" +
				"　　ペン太さを変更\n\n" +
				"・[Ctrl] ＋ [Shift] ＋ [マウスホイール]\n" +
				"　　透過率を変更\n\n",
				"操作説明 - iwm_ScreenPen"
			);
		}

		private void Cms1_閉じる_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void Cms2_Opened(object sender, EventArgs e)
		{
			Drag2Type = 0;
		}

		private void Cms2_MouseLeave(object sender, EventArgs e)
		{
			Cms2.Close();
		}

		private void Cms2_四角_Click(object sender, EventArgs e)
		{
			Drag2Type = 1;
			Pen1 = new Pen(Pen1Color, Pen1Size)
			{
				DashStyle = DashStyle.Solid
			};
		}

		private void Cms2_円_Click(object sender, EventArgs e)
		{
			Drag2Type = 2;
			Pen1 = new Pen(Pen1Color, Pen1Size)
			{
				DashStyle = DashStyle.Solid
			};
		}

		private void Cms2_矢印_Click(object sender, EventArgs e)
		{
			Drag2Type = 11;
			Pen1 = new Pen(Pen1Color, Pen1Size)
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
			Pen1 = new Pen(Pen1Color, Pen1Size)
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
			Pen1 = new Pen(Pen1Color, Pen1Size)
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
				new Pen(Pen1Color),
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
				e.Graphics.DrawString(e.ToolTipText, font, new SolidBrush(Pen1Color), new PointF(10, 1));
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
