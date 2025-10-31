using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;

namespace DOSBoxLaunchX.Controls;

/// <summary>
/// A label that is transparent (no background is painted, just text).
/// </summary>
internal class TransparentLabel : Control {
	#region Private vars

	private ContentAlignment? _textAlign = ContentAlignment.TopLeft;

	#endregion

	#region Private helper methods

	private void drawText(PaintEventArgs ea) {
		using Brush brush = new SolidBrush(ForeColor);
		SizeF size = ea.Graphics.MeasureString(Text, Font);

		float top = 0;
		switch (_textAlign) {
			case ContentAlignment.MiddleLeft:
			case ContentAlignment.MiddleCenter:
			case ContentAlignment.MiddleRight:
				top = (Height - size.Height) / 2;
				break;
			case ContentAlignment.BottomLeft:
			case ContentAlignment.BottomCenter:
			case ContentAlignment.BottomRight:
				top = Height - size.Height;
				break;
		}

		float left = -1;
		switch (_textAlign) {
			case ContentAlignment.TopLeft:
			case ContentAlignment.MiddleLeft:
			case ContentAlignment.BottomLeft:
				if (RightToLeft == RightToLeft.Yes) {
					left = Width - size.Width;
				}
				else {
					left = -1;
				}
				break;
			case ContentAlignment.TopCenter:
			case ContentAlignment.MiddleCenter:
			case ContentAlignment.BottomCenter:
				left = (Width - size.Width) / 2;
				break;
			case ContentAlignment.TopRight:
			case ContentAlignment.MiddleRight:
			case ContentAlignment.BottomRight:
				if (RightToLeft == RightToLeft.Yes) {
					left = -1;
				}
				else {
					left = Width - size.Width;
				}
				break;
		}
		ea.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
		ea.Graphics.DrawString(Text, Font, brush, left, top);
	}

	#endregion

	public TransparentLabel() {
		TabStop = false;
	}

	protected override CreateParams CreateParams {
		get {
			CreateParams cp = base.CreateParams;
			cp.ExStyle |= 0x20; // WS_EX_TRANSPARENT
			return cp;
		}
	}

	protected override void OnPaintBackground(PaintEventArgs ea) {
		// do nothing
	}

	protected override void OnPaint(PaintEventArgs ea) {
		drawText(ea);
	}

	/// <summary>
	/// Gets or sets the text associated with this control.
	/// </summary>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[AllowNull]
	public override string Text {
		get {
			return base.Text;
		}
		set {
			base.Text = value;
			RecreateHandle();
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether control's elements are aligned to support locales using right-to-left fonts.
	/// </summary>
	public override RightToLeft RightToLeft {
		get {
			return base.RightToLeft;
		}
		set {
			base.RightToLeft = value;
			RecreateHandle();
		}
	}

	/// <summary>
	/// Gets or sets the font of the text displayed by the control.
	/// </summary>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[AllowNull]
	public override Font Font {
		get {
			return base.Font;
		}
		set {
			base.Font = value;
			RecreateHandle();
		}
	}

	/// <summary>
	/// Gets or sets the text alignment.
	/// </summary>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public ContentAlignment? TextAlign {
		get {
			return _textAlign;
		}
		set {
			_textAlign = value;
			RecreateHandle();
		}
	}
}
