using System;
using System.Collections.Generic;
using System.Text;

namespace AutomataViaGraph.Graph
{
    public interface IGraph<T>
    {
        IEnumerable<IEdge<T>> Edges { get; }
        IEnumerable<IVertex<T>> Vertices { get; }
    }
}
