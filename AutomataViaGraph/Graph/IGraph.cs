using System;
using System.Collections.Generic;
using System.Text;

namespace AutomataViaGraph.Graph
{
    public interface IGraph<T>
    {
        IEnumerable<IEdge<T>> Edges { get; }
        IEnumerable<IVertex<T>> Vertices { get; }
        void Add(T data);
        void Add(T data, string name);
        void Remove(T data);
        void AddEdge(T vertex1, T vertex2, string name);
        void AddEdge(T vertex1, T vertex2);
        void RemoveEdge(T vertex1, T vertex2);
    }
}
