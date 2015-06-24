using System;
using System.Collections.Generic;

namespace Gengine.EntityComponentSystem {
    public class Entity {
        private const int Maxentities = 4096;
        private const int MaxComponentsForEntity = 100;
        private static bool[] _entities = new bool[Maxentities];
        private static int _maxComponentId = 0;
        private static Component[,] _componentToEid = new Component[Maxentities, MaxComponentsForEntity];
        
        public static int RegisterComponent(Component component){
            return ++_maxComponentId;
        }
        
        public static int Create(){
            int eid = 1;
            for (;eid < Maxentities && _entities[eid];++eid) {
            }

            if (eid < 1 || eid >= Maxentities)
                throw new Exception("Max entities reached");

            _entities[eid] = true;
            return eid;
        }

        public static int Create(params Component[] components){
            int eid = Create();
            foreach (Component component in components){
                _componentToEid[eid, component.Id] = component;
            }
            return eid;
        }

        public Component GetComponent<T>(int eid, T component) where T : Component {
            return GetComponent(eid, component.Id);
        }

        private Component GetComponent(int eid, int cid) {
            return _componentToEid[eid, cid];
        }

        public static IEnumerable<T> GetAllComponents<T>() where T : Component {
            for (int eid = 0; eid < Maxentities; eid++){
                if (_entities[eid]){
                    for(int i = 0; i < _componentToEid.GetUpperBound(1); i++){
                        var v = (T) _componentToEid[eid, i];
                        if (v != null){
                            yield return v;
                        }
                    }
                }
            }
        }
    }
}
