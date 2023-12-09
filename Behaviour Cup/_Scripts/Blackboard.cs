using System;
using System.Collections.Generic;

namespace Behaviour_Cup
{
    [System.Serializable]
    public class Blackboard
    {
        protected Dictionary<string, DataEntitiy> data =
            new Dictionary<string, DataEntitiy>();


        public T Get<T>(string key) => GetDataEntitiy<T>(key).Value;
        public T Set<T>(string key, T value) => GetDataEntitiy<T>(key).Value = value;
        public void Reset<T>(string key) => GetDataEntitiy<T>(key).ResetValue();

        private DataEntitiy<T> GetDataEntitiy<T>(string key)
        {
            DataEntitiy<T> result;
            if (data.TryGetValue(key, out DataEntitiy resultRaw))
            {
                return resultRaw as DataEntitiy<T>;
            }
            result = GenericPool.Get<DataEntitiy<T>>();
            data[key] = result;
            return result;
        }
    }

    public abstract class DataEntitiy { }
    public class DataEntitiy<T> : DataEntitiy
    {
        private T _storedValue;

        public T Value
        {
            get => _storedValue;
            set => _storedValue = value;
        }

        public void ResetValue() => _storedValue = default;
    }

    public static class GenericPool
    {
        private static Dictionary<Type, object> _pool = new Dictionary<Type, object>();
        public static T Get<T>()
        {
            if (_pool.TryGetValue(typeof(T), out object value))
            {
                Stack<T> pooledObjects = value as Stack<T>;
                if (pooledObjects.Count > 0)
                {
                    return pooledObjects.Pop();
                }
            }
            return Activator.CreateInstance<T>();
        }
    }
}