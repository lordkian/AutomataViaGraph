using System;
using System.Collections.Generic;
using System.Text;

namespace AutomataViaGraph.Graph.Default
{
    public class DefaultVertex<T> : IVertex<T>
    {
        public T Value { get; set; }
        public IEnumerable<IEdge<T>> Edges { get; set; }
        public string Name { get; set; }
        public override bool Equals(object obj)
        {
            return obj is DefaultVertex<T> && (obj as DefaultVertex<T>).Value.Equals(Value);
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
