using System.Drawing;

namespace GdiSharp.Components.Base
{
    public interface IGdiComponent
    {
        void Render(Graphics graphics);
    }
}