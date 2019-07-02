using GdiSharp.Components;
using GdiSharp.Renderer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GdiSharpDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InitConentAligntmentComboBox()
        {

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            var image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            var renderer = new GdiRenderer(image);
            var container = new GdiRectangle
            {
                Width = image.Width,
                Height = image.Height,
                Color = Color.White
            };
            var childRect = new GdiRectangle
            {
                X = 100,
                Y = 100,
                Width = 200,
                Height = 300,
                Color = Color.Green
            };
            var text = new GdiText
            {
                Font = this.Font,
                Content = "AAA dfdfgf",
                Color = Color.White,
                ContentAlignment = ContentAlignment.MiddleCenter
            };
            childRect.AddChild(text);
            container.AddChild(childRect);

            renderer.Render(container);
            pictureBox1.Image = image;
        }
    }
}