using System.Drawing;

namespace GdiSharp.Components
{
    public class GdiHozSplitContainer : GdiRectangle
    {
        public float LeftPanelWidth { get; set; }

        protected GdiRectangle LeftPanel { get; set; }

        protected GdiRectangle RightPanel { get; set; }

        public override void BeforeRendering(Graphics graphics)
        {
            base.BeforeRendering(graphics);
            if (LeftPanelWidth > 0)
            {
                CreateLeftPanel();
            }

            if (LeftPanelWidth < Size.Width)
            {
                CreateRightPanel();
            }
        }

        private void CreateLeftPanel()
        {
            LeftPanel = new GdiRectangle
            {
                Size = new SizeF(LeftPanelWidth, this.Size.Height)
            };
            this.AddChild(LeftPanel);
        }

        private void CreateRightPanel()
        {
            RightPanel = new GdiRectangle
            {
                Margin = new PointF(LeftPanelWidth, 0),
                Size = new SizeF(this.Size.Width - LeftPanelWidth, this.Size.Height)
            };
            this.AddChild(RightPanel);
        }
    }
}