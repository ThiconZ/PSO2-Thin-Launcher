using System.Drawing;
using System.Windows.Forms;

namespace PSO2_Thin_Launcher
{
    class DarkRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
            Color c = Color.FromArgb(255, 25, 25, 25);
            using (SolidBrush Brush = new SolidBrush(c))
            {
                e.Graphics.FillRectangle(Brush, rc);
            }
            base.OnRenderSeparator(e);
        }
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            int MouseOver = 60;
            int MouseLeave = 25;
            Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
            // Do not highlight if item is disabled
            Color c = e.Item.Selected ? (e.Item.Enabled ? Color.FromArgb(255, MouseOver, MouseOver, MouseOver) : Color.FromArgb(255, MouseLeave, MouseLeave, MouseLeave)) : Color.FromArgb(255, MouseLeave, MouseLeave, MouseLeave);

            // Highlight even if item is disabled
            //Color c = e.Item.Selected ? Color.FromArgb(MouseOver, MouseOver, MouseOver) : Color.FromArgb(255, MouseLeave, MouseLeave, MouseLeave);
            using (SolidBrush Brush = new SolidBrush(c))
            {
                e.Graphics.FillRectangle(Brush, rc);
            }
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = Color.DodgerBlue;
            base.OnRenderArrow(e);
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            Rectangle rc = new Rectangle(Point.Empty, e.AffectedBounds.Size);
            Color c = Color.FromArgb(255, 40, 40, 40);
            using (Pen Brush = new Pen(c, 4))
            {
                // Left Side
                e.Graphics.DrawLine(Brush, e.AffectedBounds.Top, e.AffectedBounds.Top, e.AffectedBounds.Top, e.AffectedBounds.Bottom);
                // Right Side
                e.Graphics.DrawLine(Brush, e.AffectedBounds.Width, e.AffectedBounds.Top, e.AffectedBounds.Width, e.AffectedBounds.Bottom);
                // Top Side
                e.Graphics.DrawLine(Brush, e.AffectedBounds.Top, e.AffectedBounds.Top, e.AffectedBounds.Width, e.AffectedBounds.Top);
                // Bottom Side
                e.Graphics.DrawLine(Brush, e.AffectedBounds.Top, e.AffectedBounds.Bottom, e.AffectedBounds.Width, e.AffectedBounds.Bottom);
            }
        }
    }
}
