using System;
using System.Collections.Generic;
using System.Text;

namespace AutomataViaGraph.Graph
{
    public interface IVertex<T>
    {
        T Value { get; set; }
        IEnumerable<IEdge<T>> Edges { get; set; }
    }
}
