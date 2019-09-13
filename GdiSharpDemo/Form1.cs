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
            cboComponent.Items.Add(nameof(GdiHozLine));
            cboComponent.Items.Add(nameof(GdiVerLine));
            cboComponent.Items.Add(nameof(GdiGrid));

            cboComponent.SelectedIndex = 0;
            cboComponent.DropDownStyle = ComboBoxStyle.DropDownList;

            cboComponent.SelectedIndexChanged += (x, y) => Render();
        }

        private void InitHorizontalAligntmentComboBox()
        {
            var alignments = Enum.GetValues(typeof(GdiSharp.Enum.GdiHorizontalAlign));
            foreach (var item in alignments)
            {
                cboHorizontalAlignment.Items.Add(item);
            }

            cboHorizontalAlignment.SelectedIndex = 0;
            cboHorizontalAlignment.DropDownStyle = ComboBoxStyle.DropDownList;

            cboHorizontalAlignment.SelectedIndexChanged += (x, y) => Render();
        }

        private void InitVerticalAligntmentComboBox()
        {
            var alignments = Enum.GetValues(typeof(GdiSharp.Enum.GdiVerticalAlign));
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
            var rootContainer = new GdiRectangle
            {
                Width = image.Width,
                Height = image.Height,
                Color = Color.White
            };
            var childRect = new GdiRectangle
            {
                X = 50,
                Y = 50,
                Width = 600,
                Height = 400,
                Color = Color.Gray
            };

            var component = CreateComponent(cboComponent.SelectedItem.ToString());
            component.X = (float)numMarginX.Value;
            component.Y = (float)numMarginY.Value;

            component.HorizontalAlignment = (GdiSharp.Enum.GdiHorizontalAlign)cboHorizontalAlignment.SelectedItem;
            component.VerticalAlignment = (GdiSharp.Enum.GdiVerticalAlign)cboVerticalAlignment.SelectedItem;

            childRect.AddChild(component);
            rootContainer.AddChild(childRect);

            renderer.Render(rootContainer);
            if (pictureBox1.Image != null)
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
                        X = 5,
                        Y = 5,
                        Width = 100,
                        Height = 50,
                        Color = Color.Yellow
                    };

                case nameof(GdiHozLine):
                    return new GdiHozLine
                    {
                        X = 5,
                        Y = 5,
                        Length = 200,
                        Color = Color.Cyan
                    };

                case nameof(GdiVerLine):
                    return new GdiVerLine
                    {
                        X = 5,
                        Y = 5,
                        Color = Color.Cyan,
                        Length = 200
                    };

                case nameof(GdiGrid):
                    return new GdiGrid
                    {
                        CellHeight = 10,
                        CellWidth = 20,
                        Width = 150,
                        Height = 100,
                        LineColor = Color.Cyan,
                        GridBorderVisible = true
                    };

                default:
                    throw new ArgumentException("Invalid name");
            }
        }
    }
}