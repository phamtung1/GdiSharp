using GdiSharp.Components;
using GdiSharp.Components.Base;
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

            InitComponentComboBox();
            InitHorizontalAligntmentComboBox();
            InitVerticalAligntmentComboBox();

            numMarginX.ValueChanged += (x, y) => Render();
            numMarginY.ValueChanged += (x, y) => Render();

            Render();
        }
        private void InitComponentComboBox()
        {
            cboComponent.Items.Add(nameof(GdiText));
            cboComponent.Items.Add(nameof(GdiRectangle));

            cboComponent.SelectedIndex = 0;
            cboComponent.DropDownStyle = ComboBoxStyle.DropDownList;

            cboComponent.SelectedIndexChanged += (x, y) => Render();
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
                MarginX = 100,
                MarginY = 100,
                Width = 200,
                Height = 300,
                Color = Color.Gray
            };
            
            var component = CreateComponent(cboComponent.SelectedItem.ToString());
            component.HorizontalAlignment = (GdiSharp.Enum.HorizontalAlignment)cboHorizontalAlignment.SelectedItem;
            component.VerticalAlignment = (GdiSharp.Enum.VerticalAlignment)cboVerticalAlignment.SelectedItem;
            component.MarginX = (float)numMarginX.Value;
            component.MarginY = (float)numMarginY.Value;

            childRect.AddChild(component);
            container.AddChild(childRect);

            renderer.Render(container);
            if(pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }

            pictureBox1.Image = image;
        }

        private GdiComponent CreateComponent(string name)
        {
            switch (name)
            {
                case nameof(GdiText):
                    return new GdiText
                    {
                        Font = this.Font,
                        Content = "AAA dfdfgf",
                        Color = Color.Cyan,
                    };

                case nameof(GdiRectangle):
                    return new GdiRectangle
                    {
                        MarginX = 5,
                        MarginY = 5,
                        Width = 100,
                        Height = 50,
                        Color = Color.Yellow
                    };

                default:
                    throw new ArgumentException("Invalid name");
            }
        }
    }
}