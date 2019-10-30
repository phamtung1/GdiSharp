using GdiSharp.Components.Base;
using System.Drawing;
using System.Linq;

namespace GdiSharp.Renderer
{
    public class GdiRenderer
    {
        private readonly Image _image;

        public GdiRenderer(Image image)
        {
            _image = image;
        }

        public void Render(GdiContainer component)
        {
            using (var graphics = GetGraphics())
            {
                RenderComponent(graphics, component);
            }
        }

        public Graphics GetGraphics()
        {
            var graphics = Graphics.FromImage(_image);
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            return graphics;
        }

        private void RenderComponent(Graphics graphics, GdiComponent component)
        {
            component.BeforeRendering(graphics);
            component.Render(graphics);
            var container = component as GdiContainer;
            if (container != null && container.Children != null && container.Children.Any())
            {
                foreach (var item in container.Children)
                {
                    RenderComponent(graphics, item);
                }
            }
        }
    }
}