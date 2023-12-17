namespace Behaviour_Cup
{
    [System.Serializable]
    public class DataEntitiy<T>
    {
        public string key = "Key";
        public T value;

        public DataEntitiy(string Key, T Value)
        {
            key = Key;
            value = Value;
        }
    }
}