using System;
using System.Collections.Generic;
using System.Text;

namespace AutomataViaGraph.Graph
{
    internal interface IVertex<T>
    {
        T Value { get; set; }
        IEnumerable<IEdge<T>> Edges { get; set; }
    }
}
