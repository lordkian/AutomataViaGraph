using System;
using System.Collections.Generic;
using System.Text;

namespace AutomataViaGraph.Graph.Default
{
    public class UndirectedGraph<T> : IGraph<T>
    {
        public IEnumerable<IEdge<T>> Edges { get { return _edges; } }
        public IEnumerable<IVertex<T>> Vertices { get { return _vertices; } }
        private List<IEdge<T>> _edges = new List<IEdge<T>>();
        private List<IVertex<T>> _vertices = new List<IVertex<T>>();
        public void Add(T data)
        {
            foreach (var item in _vertices)
                if (item.Value.Equals(data))
                    throw new ArgumentException("An item with the same value has already been added.");
            _vertices.Add(new DefaultVertex<T>() { Value = data });
        }

        public void AddEdge(T vertex1, T vertex2)
        {
            throw new NotImplementedException();
        }

        public void Remove(T data)
        {
            IVertex<T> removeItem = null;
            foreach (var item in _vertices)
                if (item.Value.Equals(data))
                    removeItem = item;
            if (removeItem == null)
                throw new ArgumentException("An item with this value does not exist.");
            _vertices.Remove(removeItem);
        }

        public void RemoveEdge(T vertex1, T vertex2)
        {
            throw new NotImplementedException();
        }
    }
}
