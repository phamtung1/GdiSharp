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

        public void Render(GdiComponent component)
        {
            using (var graphics = Graphics.FromImage(_image))
            {
                RenderComponent(graphics, component);
            }
        }

        private void RenderComponent(Graphics graphics, GdiComponent component)
        {
            component.Render(graphics);
            if (component.Children != null && component.Children.Any())
            {
                foreach (var item in component.Children)
                {
                    RenderComponent(graphics, item);
                }
            }
        }
    }
}