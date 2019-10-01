using System;
using System.Collections.Generic;
using System.Text;

namespace AutomataViaGraph.Graph.Default
{
    public class DefaultEdge<T> : IEdge<T>
    {
        public IVertex<T> From { get; set; }
        public IVertex<T> To { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return obj is DefaultEdge<T> &&
                (((obj as DefaultEdge<T>).From.Equals(From) && (obj as DefaultEdge<T>).To.Equals(To)) ||
                 ((obj as DefaultEdge<T>).To.Equals(From) && (obj as DefaultEdge<T>).From.Equals(To)));
        }
        public override string ToString()
        {
            return From.ToString() + "\n" + To.ToString();
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
