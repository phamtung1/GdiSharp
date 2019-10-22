using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GdiSharp.Components;
using GdiSharp.Components.Base;
using GdiSharp.Components.DataGrid;
using GdiSharp.Models;
using GdiSharp.Renderer;

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

            numMarginLeft.ValueChanged += (x, y) => Render();
            numMarginTop.ValueChanged += (x, y) => Render();

            Render();
        }

        private void InitComponentComboBox()
        {
            cboComponent.Items.Add(nameof(GdiText));
            cboComponent.Items.Add(nameof(GdiRectangle));
            cboComponent.Items.Add(nameof(GdiHozLine));
            cboComponent.Items.Add(nameof(GdiVerLine));
            cboComponent.Items.Add(nameof(GdiGrid));
            cboComponent.Items.Add(nameof(GdiDataGrid));

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
                Size = image.Size,
                Color = Color.White
            };
            var childRect = new GdiRectangle
            {
                Margin = new PointF(50, 50),
                Size = new SizeF(600, 350),
                Color = Color.Gray
            };

            var component = CreateComponent(cboComponent.SelectedItem.ToString());
            component.Margin = new PointF((float)numMarginLeft.Value, (float)numMarginTop.Value);
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
                        Font = SlimFont.FromFatFont(this.Font),
                        Content = "First Line\nSecond Line",
                        Color = Color.Cyan,
                        TextAlign = StringAlignment.Near
                    };

                case nameof(GdiRectangle):
                    return new GdiRectangle
                    {
                        Margin = new PointF(5, 5),
                        Size = new SizeF(100, 50),
                        Color = Color.Yellow
                    };

                case nameof(GdiHozLine):
                    return new GdiHozLine
                    {
                        Margin = new PointF(5, 5),
                        Length = 200,
                        Color = Color.Cyan
                    };

                case nameof(GdiVerLine):
                    return new GdiVerLine
                    {
                        Margin = new PointF(5, 5),
                        Color = Color.Cyan,
                        Length = 200
                    };

                case nameof(GdiGrid):
                    return new GdiGrid
                    {
                        CellSize = new SizeF(20, 10),
                        Size = new SizeF(150, 100),
                        LineColor = Color.Cyan,
                        GridBorderVisible = true
                    };

                case nameof(GdiDataGrid):
                    return new GdiDataGrid
                    {
                        Size = new SizeF(400, 300),
                        LineColor = Color.Cyan,
                        Rows = 10,
                        Columns = 10,
                        MergedCells = new List<DataGridMergedCell>
                        {
                            new DataGridMergedCell(1, 1, 3, 3)
                        },
                        Texts = new string[][]
                        {
                            new []{ "1", "1", "1" },
                            new []{ "1", "1", "", "", "1" },
                        }
                    };

                default:
                    throw new ArgumentException("Invalid name");
            }
        }
    }
}