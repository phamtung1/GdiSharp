using System.Collections.Generic;

using System.Drawing;

namespace GdiSharp.Components.Base
{
    public abstract class GdiContainer : GdiComponent, IGdiContainer
    {
        public float Width { get; set; }

        public float Height { get; set; }

        internal IList<GdiComponent> Children { get; set; }

        public void AddChild(GdiComponent component)
        {
            if (Children == null)
            {
                Children = new List<GdiComponent>();
            }

            component.Parent = this;
            Children.Add(component);
        }

        protected override SizeF GetComponentSize(Graphics graphics)
        {
            return new SizeF(this.Width, this.Height);
        }
    }
}