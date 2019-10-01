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
                groupBox1.Controls.Add(item.Value);
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
    }
}
