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
    }
}
