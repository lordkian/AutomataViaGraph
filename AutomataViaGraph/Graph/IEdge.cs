using System;
using System.Collections.Generic;
using System.Text;

namespace AutomataViaGraph.Graph
{
    public interface IEdge<T>
    {
        IVertex<T> From { get; set; }
        IVertex<T> To { get; set; }
        string Name { get; set; }
    }
}
