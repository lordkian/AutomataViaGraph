using System;
using System.Collections.Generic;
using System.Text;

namespace AutomataViaGraph.Graph.Default
{
    public class DefaultVertex<T> : IVertex<T>
    {
        public T Value { get { return _value; } set { _value = value } }
        private T _value;
        public IEnumerable<IEdge<T>> Edges { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
