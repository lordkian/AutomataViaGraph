using System;
using System.Collections.Generic;
using System.Text;

namespace AutomataViaGraph.Graph
{
    internal interface IEdge<T>
    {
        IVertex<T> From { get; set; }
        IVertex<T> To { get; set; }
    }
}
