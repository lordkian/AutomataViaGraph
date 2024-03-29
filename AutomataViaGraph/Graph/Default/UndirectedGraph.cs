﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomataViaGraph.Graph.Default
{
    public class UndirectedGraph<T> : IGraph<T>
    {
        public IEnumerable<IEdge<T>> Edges
        {
            get
            {
                var edges = new List<IEdge<T>>();
                foreach (var item in Vertices)
                    edges.AddRange(item.Edges);
                return edges.Distinct().ToList();
            }
        }
        public IEnumerable<IVertex<T>> Vertices { get { return _vertices; } }
        private List<DefaultVertex<T>> _vertices = new List<DefaultVertex<T>>();
        public void Add(T data, string name)
        {
            foreach (var item in _vertices)
                if (item.Value.Equals(data))
                    throw new ArgumentException("A vertex with the same value has already been added.");
            _vertices.Add(new DefaultVertex<T>() { Value = data, Name = name });
        }
        public void AddEdge(T vertex1, T vertex2, string name)
        {
            if (vertex1.Equals(vertex2))
            {
                DefaultVertex<T> v = null;
                foreach (var item in _vertices)
                    if (item.Value.Equals(vertex1))
                        v = item;
                if (v == null)
                    throw new ArgumentException("A Vertex with this value does not exist.");
                foreach (var item in v.Edges)
                    if (item.From.Equals(v) && item.To.Equals(v))
                        throw new ArgumentException("An edge with the same value has already been added.");
                var edge = new DefaultEdge<T>() { From = v, To = v, Name = name };
                (v.Edges as List<IEdge<T>>).Add(edge);
            }
            else
            {
                DefaultVertex<T> v1 = null, v2 = null;
                foreach (var item in _vertices)
                {
                    if (item.Value.Equals(vertex1))
                        v1 = item;
                    if (item.Value.Equals(vertex2))
                        v2 = item;
                }
                if (v1 == null || v2 == null)
                    throw new ArgumentException("A Vertex with this value does not exist.");
                foreach (var item in v1.Edges)
                    if (item.From.Equals(v2) || item.To.Equals(v2))
                        throw new ArgumentException("An edge with the same value has already been added.");
                var edge = new DefaultEdge<T>() { From = v1, To = v2, Name = name };
                (v1.Edges as List<IEdge<T>>).Add(edge);
                (v2.Edges as List<IEdge<T>>).Add(edge);
            }
        }
        public void Remove(T data)
        {
            DefaultVertex<T> removeItem = null;
            foreach (var item in _vertices)
                if (item.Value.Equals(data))
                    removeItem = item;
            if (removeItem == null)
                throw new ArgumentException("An item with this value does not exist.");
            foreach (var item in removeItem.Edges.ToArray())
                RemoveEdge(item.From.Value, item.To.Value);
            _vertices.Remove(removeItem);
        }
        public void RemoveEdge(T vertex1, T vertex2)
        {
            if (vertex1.Equals(vertex2))
                throw new ArgumentException("tow vertices must be diffrent.");
            DefaultVertex<T> v1 = null, v2 = null;
            foreach (var item in _vertices)
                if (item.Value.Equals(vertex1))
                    v1 = item;
                else if (item.Value.Equals(vertex2))
                    v2 = item;
            if (v1 == null || v2 == null)
                throw new ArgumentException("A vertex with this value does not exist.");
            foreach (var item in v1.Edges)
                if (item.From.Equals(v2) || item.To.Equals(v2))
                {
                    (v1.Edges as List<IEdge<T>>).Remove(item);
                    (v2.Edges as List<IEdge<T>>).Remove(item);
                    return;
                }
            throw new ArgumentException("An edge with this values does not exist.");
        }
        public void Add(T data)
        {
            Add(data, "");
        }
        public void AddEdge(T vertex1, T vertex2)
        {
            AddEdge(vertex1, vertex2, "");
        }
    }
}
