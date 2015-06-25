using System;
using System.Collections;
using System.Collections.Generic;

namespace Gengine.Collections{
    public class ResourcePool<T> : IEnumerable<T> where T : class{
        private int _maxResources = 16;
        private T[] _pool;

        public ResourcePool(){
            _pool = new T[_maxResources];
        }

        public T this[int index]{
            get { return _pool[index]; }
            set { _pool[index] = value; }
        }

        public int Add(T resource){
            int id = 0;
            for (int i = 1; i < _maxResources; i++){
                if (_pool[i] == null){
                    id = i;
                    break;
                }
            }

            if (id == 0){
                id = _maxResources;
                Grow();
            }

            _pool[id] = resource;
            return id;
        }

        public T Get(int id){
            if (id < 0 || id >= _maxResources)
                throw new ArgumentException("Invalid id : " + id);

            return _pool[id];
        }

        public void Remove(int id){
            if (id < 0 || id >= _maxResources)
                throw new ArgumentException("Invalid id : " + id);
            if (_pool[id] == null)
                throw new ArgumentException("Resource not found : " + id);

            _pool[id] = null;
        }

        public void Remove(T resource){
            if (resource == null)
                throw new ArgumentException("resource empty");

            for (int i = 0; i < _maxResources; i++){
                if (_pool[i] == resource)
                    _pool[i] = null;
            }
        }

        private void Grow(){
            _maxResources = _maxResources*2;
            Array.Resize(ref _pool, _maxResources);
        }

        public IEnumerator<T> GetEnumerator(){
            foreach (var p in _pool){
                if (p != null){
                    yield return p;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator(){
            foreach (var p in _pool){
                if (p != null){
                    yield return p;
                }
            }
        }
    }
}
