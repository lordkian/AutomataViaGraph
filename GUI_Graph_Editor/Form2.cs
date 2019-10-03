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
            }
            groupBox1.Refresh();
        }

        private void GroupBox1_Paint(object sender, PaintEventArgs e)
        {
            if (Graph == null)
                return;
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            foreach (var item in Graph.Edges)
                e.Graphics.DrawLine(pen, item.From.Value.Top, item.From.Value.Left, item.To.Value.Top, item.To.Value.Left);
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
            RefreshGroupBox();
        }

        private void LabelMouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startX = e.X;
            startY = e.Y;
        }

        private void LabelMouseMove(object sender, MouseEventArgs e)
        {
            var lbl = sender as Label;
            if ((dragging == true))
            {
                lbl.Location = new Point(lbl.Location.X + (e.X - startX), lbl.Location.Y + (e.Y - startY));
                Refresh();
            }
        }

        private void LabelMouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
