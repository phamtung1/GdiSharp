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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitHorizontalAligntmentComboBox();
            InitVerticalAligntmentComboBox();
        }

        private void InitHorizontalAligntmentComboBox()
        {
            var alignments = Enum.GetValues(typeof(GdiSharp.Enum.HorizontalAlignment));
            foreach (var item in alignments)
            {
                cboHorizontalAlignment.Items.Add(item);
            }

            cboHorizontalAlignment.SelectedIndex = 0;
            cboHorizontalAlignment.DropDownStyle = ComboBoxStyle.DropDownList;

            cboHorizontalAlignment.SelectedIndexChanged += (x,y) => Render();
        }

        private void InitVerticalAligntmentComboBox()
        {
            var alignments = Enum.GetValues(typeof(GdiSharp.Enum.VerticalAlignment));
            foreach (var item in alignments)
            {
                cboVerticalAlignment.Items.Add(item);
            }

            cboVerticalAlignment.SelectedIndex = 0;
            cboVerticalAlignment.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVerticalAlignment.SelectedIndexChanged += (x, y) => Render();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Render();
        }

        private void Render()
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
                HorizontalAlignment = (GdiSharp.Enum.HorizontalAlignment)cboHorizontalAlignment.SelectedItem,
                VerticalAlignment = (GdiSharp.Enum.VerticalAlignment)cboVerticalAlignment.SelectedItem,
            };
            childRect.AddChild(text);
            container.AddChild(childRect);

            renderer.Render(container);
            pictureBox1.Image = image;
        }
    }
}