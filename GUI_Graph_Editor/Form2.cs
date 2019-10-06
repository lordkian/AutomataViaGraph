using AutomataViaGraph.Graph;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Graph_Editor
{
    public partial class Form2 : Form
    {
        public IGraph<Label> Graph { get; set; }
        private List<Label> SelectedLabels = new List<Label>();
        private bool dragging;
        private int startX;
        private int startY;
        public Form2(IGraph<Label> graph)
        {
            Graph = graph;
            InitializeComponent();
            RefreshGroupBox();
        }
        private void RefreshGroupBox()
        {
            groupBox1.Controls.Clear();
            foreach (var item in Graph.Vertices)
            {
                groupBox1.Controls.Add(item.Value);
                item.Value.MouseDown += LabelMouseDown;
                item.Value.MouseMove += LabelMouseMove;
                item.Value.MouseUp += LabelMouseUp;
                item.Value.DoubleClick += LabelDoubleClick;
            }
            groupBox1.Refresh();
        }

        private void GroupBox1_Paint(object sender, PaintEventArgs e)
        {
            if (Graph == null)
                return;
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            Font font = new Font("Arial", 14);
            foreach (var item in Graph.Edges)
            {
                var x1 = item.From.Value.Left + item.From.Value.Width / 2;
                var x2 = item.To.Value.Left + item.To.Value.Width / 2;
                var y1 = item.From.Value.Top + item.From.Value.Height / 2;
                var y2 = item.To.Value.Top + item.To.Value.Height / 2;
                e.Graphics.DrawLine(pen, x1, y1, x2, y2);
                e.Graphics.DrawString(item.Name, font, Brushes.Blue, (x1 + x2) / 2, (y1 + y2) / 2);
            }
            pen.Dispose();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1)
                return;
            var random = new Random();
            var lbl = new Label()
            {
                Text = textBox1.Text,
                AutoSize = true
            };
            lbl.Top = random.Next(0, groupBox1.Height - lbl.Height);
            lbl.Left = random.Next(0, groupBox1.Width - lbl.Width);
            Graph.Add(lbl, textBox1.Text);
            groupBox1.Controls.Add(lbl);
            lbl.MouseDown += LabelMouseDown;
            lbl.MouseMove += LabelMouseMove;
            lbl.MouseUp += LabelMouseUp;
            lbl.DoubleClick += LabelDoubleClick;
        }

        private void LabelDoubleClick(object sender, EventArgs e)
        {
            var lbl = sender as Label;
            if (SelectedLabels.Contains(lbl))
            {
                lbl.BackColor = Color.Transparent;
                SelectedLabels.Remove(lbl);
            }
            else
            {
                lbl.BackColor = Color.Red;
                SelectedLabels.Add(lbl);
                if (SelectedLabels.Count > 2)
                    LabelDoubleClick(SelectedLabels[0], e);
            }
        }

        private void LabelMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                startX = e.X;
                startY = e.Y;
            }
        }

        private void LabelMouseMove(object sender, MouseEventArgs e)
        {
            var lbl = sender as Label;
            if (lbl != null && dragging && e.Button == MouseButtons.Left)
            {
                lbl.Location = new Point(lbl.Location.X + (e.X - startX), lbl.Location.Y + (e.Y - startY));
                Refresh();
            }
        }

        private void LabelMouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var i = groupBox1.Controls;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1 || SelectedLabels.Count != 2)
                return;
            Graph.AddEdge(SelectedLabels[0], SelectedLabels[1], textBox1.Text);
            groupBox1.Refresh();
        }
    }
}
