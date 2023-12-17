using System.Collections.Generic;
using UnityEngine;

namespace Behaviour_Cup
{
    public class Blackboard : MonoBehaviour
    {
        #region Component
        public List<DataEntitiy<Component>> components = new List<DataEntitiy<Component>>();
        public T GetComponent<T>(string key) where T : Component
        {
            foreach (DataEntitiy<Component> data in components)
            {
                if (data.key == key) return data.value as T;
            }

            return default(T);
        }

        public void SetComponent(string key, Component value)
        {
            foreach (DataEntitiy<Component> data in components)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            components.Add(new DataEntitiy<Component>(key, value));
        }

        #endregion

        #region string
        public List<DataEntitiy<string>> strings = new List<DataEntitiy<string>>();
        public string GetString(string key)
        {
            foreach (DataEntitiy<string> data in strings)
            {
                if (data.key == key) return data.value;
            }

            return default(string);
        }
        public void SetString(string key, string value)
        {
            foreach (DataEntitiy<string> data in strings)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            strings.Add(new DataEntitiy<string>(key, value));
        }

        #endregion

        #region int
        public List<DataEntitiy<int>> ints = new List<DataEntitiy<int>>();
        public int GetInt(string key)
        {
            foreach (DataEntitiy<int> data in ints)
            {
                if (data.key == key) return data.value;
            }

            return default(int);
        }
        public void SetInt(string key, int value)
        {
            foreach (DataEntitiy<int> data in ints)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            ints.Add(new DataEntitiy<int>(key, value));
        }

        #endregion

        #region float
        public List<DataEntitiy<float>> floats = new List<DataEntitiy<float>>();
        public float GetFloat(string key)
        {
            foreach (DataEntitiy<float> data in floats)
            {
                if (data.key == key) return data.value;
            }

            return default(float);
        }
        public void SetFloat(string key, float value)
        {
            foreach (DataEntitiy<float> data in floats)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            floats.Add(new DataEntitiy<float>(key, value));
        }

        #endregion

        #region Vector2
        public List<DataEntitiy<Vector2>> vector2s = new List<DataEntitiy<Vector2>>();
        public Vector2 GetVector2(string key)
        {
            foreach (DataEntitiy<Vector2> data in vector2s)
            {
                if (data.key == key) return data.value;
            }

            return default(Vector2);
        }
        public void SetVector2(string key, Vector2 value)
        {
            foreach (DataEntitiy<Vector2> data in vector2s)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            vector2s.Add(new DataEntitiy<Vector2>(key, value));
        }

        #endregion

        #region Vector3
        public List<DataEntitiy<Vector3>> vector3s = new List<DataEntitiy<Vector3>>();
        public Vector3 GetVector3(string key)
        {
            foreach (DataEntitiy<Vector3> data in vector3s)
            {
                if (data.key == key) return data.value;
            }

            return default(Vector3);
        }
        public void SetVector3(string key, Vector3 value)
        {
            foreach (DataEntitiy<Vector3> data in vector3s)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            vector3s.Add(new DataEntitiy<Vector3>(key, value));
        }

        #endregion

        #region Color
        public List<DataEntitiy<Color>> colors = new List<DataEntitiy<Color>>();
        public Color GetColor(string key)
        {
            foreach (DataEntitiy<Color> data in colors)
            {
                if (data.key == key) return data.value;
            }

            return default(Color);
        }
        public void SetColor(string key, Color value)
        {
            foreach (DataEntitiy<Color> data in colors)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            colors.Add(new DataEntitiy<Color>(key, value));
        }

        #endregion

        #region Gradient
        public List<DataEntitiy<Gradient>> gradients = new List<DataEntitiy<Gradient>>();
        public Gradient GetGradient(string key)
        {
            foreach (DataEntitiy<Gradient> data in gradients)
            {
                if (data.key == key) return data.value;
            }

            return null;
        }
        public void SetGradient(string key, Gradient value)
        {
            foreach (DataEntitiy<Gradient> data in gradients)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            gradients.Add(new DataEntitiy<Gradient>(key, value));
        }

        #endregion

        #region bool
        public List<DataEntitiy<bool>> bools = new List<DataEntitiy<bool>>();
        public bool GetBool(string key)
        {
            foreach (DataEntitiy<bool> data in bools)
            {
                if (data.key == key) return data.value;
            }

            return default(bool);
        }
        public void SetBool(string key, bool value)
        {
            foreach (DataEntitiy<bool> data in bools)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            bools.Add(new DataEntitiy<bool>(key, value));
        }

        #endregion

        #region Sprite
        public List<DataEntitiy<Sprite>> sprites = new List<DataEntitiy<Sprite>>();
        public Sprite GetSprite(string key)
        {
            foreach (DataEntitiy<Sprite> data in sprites)
            {
                if (data.key == key) return data.value;
            }

            return null;
        }
        public void SetSprite(string key, Sprite value)
        {
            foreach (DataEntitiy<Sprite> data in sprites)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            sprites.Add(new DataEntitiy<Sprite>(key, value));
        }

        #endregion

        public bool Have(string key)
        {
            bool v = false;

            components.ForEach(d => { if (d.key == key) v = true; });
            if (!v) strings.ForEach(d => { if (d.key == key) v = true; });
            if (!v) ints.ForEach(d => { if (d.key == key) v = true; });
            if (!v) floats.ForEach(d => { if (d.key == key) v = true; });
            if (!v) vector2s.ForEach(d => { if (d.key == key) v = true; });
            if (!v) vector3s.ForEach(d => { if (d.key == key) v = true; });
            if (!v) colors.ForEach(d => { if (d.key == key) v = true; });
            if (!v) gradients.ForEach(d => { if (d.key == key) v = true; });
            if (!v) bools.ForEach(d => { if (d.key == key) v = true; });
            if (!v) sprites.ForEach(d => { if (d.key == key) v = true; });

            return v;
        }
    }
}