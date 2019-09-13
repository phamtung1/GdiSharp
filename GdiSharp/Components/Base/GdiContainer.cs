using System.Collections.Generic;

namespace GdiSharp.Components.Base
{
    public abstract class GdiContainer : GdiComponent, IGdiContainer
    {
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
    }
}