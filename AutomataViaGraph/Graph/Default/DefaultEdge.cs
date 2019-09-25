using System;
using System.Collections.Generic;
using System.Text;

namespace AutomataViaGraph.Graph.Default
{
    public class DefaultEdge<T> : IEdge<T>
    {
        public IVertex<T> From { get { return _from; } set { _from = value; } }
        public IVertex<T> To { get { return _to; } set { _to = value; } }
        private IVertex<T> _from, _to;
        public override bool Equals(object obj)
        {
            return obj is DefaultEdge<T> &&
                (((obj as DefaultEdge<T>)._from.Equals(_from) && (obj as DefaultEdge<T>)._to.Equals(_to)) ||
                 ((obj as DefaultEdge<T>)._to.Equals(_from) && (obj as DefaultEdge<T>)._from.Equals(_to)));
        }
        public override string ToString()
        {
            return _from.ToString() + "\n" + _to.ToString();
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
