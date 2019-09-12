namespace GdiSharp.Components.Base
{
    public interface IGdiContainer
    {
        float Height { get; set; }
        float Width { get; set; }

        void AddChild(GdiComponent component);
    }
}