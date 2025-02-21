using System.Drawing;
using System.Windows.Forms;
using System;

public class WrapComboBox : ComboBox
{
    public WrapComboBox()
    {
        this.DrawMode = DrawMode.OwnerDrawVariable;
        this.ItemHeight = 25;
    }

    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        if (e.Index < 0) return;

        string text = Items[e.Index].ToString();
        e.DrawBackground();

        // Calculate required height for wrapped text
        SizeF textSize = e.Graphics.MeasureString(text, e.Font, this.DropDownWidth);

        // Draw the text
        using (SolidBrush brush = new SolidBrush(e.ForeColor))
        {
            e.Graphics.DrawString(text, e.Font, brush,
                new RectangleF(e.Bounds.X, e.Bounds.Y, this.DropDownWidth, textSize.Height));
        }

        e.DrawFocusRectangle();
    }

    protected override void OnMeasureItem(MeasureItemEventArgs e)
    {
        if (e.Index < 0) return;

        string text = Items[e.Index].ToString();

        // Measure the height needed for the text
        SizeF textSize = e.Graphics.MeasureString(text, this.Font, this.DropDownWidth);
        e.ItemHeight = (int)Math.Ceiling(textSize.Height);
    }
}