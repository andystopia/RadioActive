#nullable enable
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace RadioActive {
    internal class BiMultiMap<K, V>
    {
        private readonly Dictionary<K, List<V>> _forwards = new();
        
        
        public List<V> this[K key] => _forwards[key];


        private readonly Dictionary<V, K> _backwards = new();

        public void Add(K key, V value)
        {
            if (_forwards.ContainsKey(key))
            {
                _forwards[key].Add(value);
            }
            else
            {
                _forwards.Add(key, new List<V> {value});
            }
            
            _backwards.Add(value, key);
        }

        public K GetKeyFor(V value)
        {
            return _backwards[value];
        }

        public void RemoveValue(V value)
        {
            var key = GetKeyFor(value);

            _forwards[key].RemoveAll(v => Equals(v, value));
        }


        public IList<V>? TryGet(K key)
        {
            return _forwards.ContainsKey(key) ? _forwards[key] : null;
        }
    }
    
    [CreateAssetMenu(fileName = "Messenger", menuName = "RadioActive/Messenger", order = 1)]
    public class Messenger : ScriptableObject
    {
        private readonly BiMultiMap<Type, Action<object>> _listeners = new();
        
        
        public void Subscribe<T>(Action<T> listener)
        {
            _listeners.Add(typeof(T), v => listener((T) v));
        }
        
        public void Publish<T>([DisallowNull] T ev)
        {
            if (ev == null) throw new ArgumentNullException(nameof(ev));
            
            var listeners = _listeners.TryGet(typeof(T));

            if (listeners == null)
            {
                return;
            }

            Debug.Log(listeners.Count);
            foreach (var listener in listeners)
            {
                listener.Invoke(ev);
            }
        }
    }
}