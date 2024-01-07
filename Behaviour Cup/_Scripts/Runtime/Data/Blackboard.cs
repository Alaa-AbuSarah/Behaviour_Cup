using System.Collections.Generic;
using UnityEngine;

namespace Behaviour_Cup
{
    public class Blackboard : MonoBehaviour
    {
        #region GameObject
        public List<DataEntitiy<GameObject>> _gameObjects = new List<DataEntitiy<GameObject>>();
        public GameObject Get_GameObject(string key)
        {
            foreach (DataEntitiy<GameObject> data in _gameObjects)
            {
                if (data.key == key) return data.value;
            }

            return null;
        }
        public void Set_GameObject(string key, GameObject value)
        {
            foreach (DataEntitiy<GameObject> data in _gameObjects)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            _gameObjects.Add(new DataEntitiy<GameObject>(key, value));
        }
        #endregion

        #region Component
        public List<DataEntitiy<Component>> _components = new List<DataEntitiy<Component>>();
        public T Get_Component<T>(string key) where T : Component
        {
            foreach (DataEntitiy<Component> data in _components)
            {
                if (data.key == key) return data.value as T;
            }

            return default(T);
        }

        public void Set_Component(string key, Component value)
        {
            foreach (DataEntitiy<Component> data in _components)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            _components.Add(new DataEntitiy<Component>(key, value));
        }

        #endregion

        #region string
        public List<DataEntitiy<string>> _strings = new List<DataEntitiy<string>>();
        public string Get_String(string key)
        {
            foreach (DataEntitiy<string> data in _strings)
            {
                if (data.key == key) return data.value;
            }

            return default(string);
        }
        public void Set_String(string key, string value)
        {
            foreach (DataEntitiy<string> data in _strings)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            _strings.Add(new DataEntitiy<string>(key, value));
        }

        #endregion

        #region int
        public List<DataEntitiy<int>> _ints = new List<DataEntitiy<int>>();
        public int Get_Int(string key)
        {
            foreach (DataEntitiy<int> data in _ints)
            {
                if (data.key == key) return data.value;
            }

            return default(int);
        }
        public void Set_Int(string key, int value)
        {
            foreach (DataEntitiy<int> data in _ints)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            _ints.Add(new DataEntitiy<int>(key, value));
        }

        #endregion

        #region float
        public List<DataEntitiy<float>> _floats = new List<DataEntitiy<float>>();
        public float Get_Float(string key)
        {
            foreach (DataEntitiy<float> data in _floats)
            {
                if (data.key == key) return data.value;
            }

            return default(float);
        }
        public void Set_Float(string key, float value)
        {
            foreach (DataEntitiy<float> data in _floats)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            _floats.Add(new DataEntitiy<float>(key, value));
        }

        #endregion

        #region Vector2
        public List<DataEntitiy<Vector2>> _vector2s = new List<DataEntitiy<Vector2>>();
        public Vector2 Get_Vector2(string key)
        {
            foreach (DataEntitiy<Vector2> data in _vector2s)
            {
                if (data.key == key) return data.value;
            }

            return default(Vector2);
        }
        public void Set_Vector2(string key, Vector2 value)
        {
            foreach (DataEntitiy<Vector2> data in _vector2s)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            _vector2s.Add(new DataEntitiy<Vector2>(key, value));
        }

        #endregion

        #region Vector3
        public List<DataEntitiy<Vector3>> _vector3s = new List<DataEntitiy<Vector3>>();
        public Vector3 Get_Vector3(string key)
        {
            foreach (DataEntitiy<Vector3> data in _vector3s)
            {
                if (data.key == key) return data.value;
            }

            return default(Vector3);
        }
        public void Set_Vector3(string key, Vector3 value)
        {
            foreach (DataEntitiy<Vector3> data in _vector3s)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            _vector3s.Add(new DataEntitiy<Vector3>(key, value));
        }

        #endregion

        #region Color
        public List<DataEntitiy<Color>> _colors = new List<DataEntitiy<Color>>();
        public Color Get_Color(string key)
        {
            foreach (DataEntitiy<Color> data in _colors)
            {
                if (data.key == key) return data.value;
            }

            return default(Color);
        }
        public void Set_Color(string key, Color value)
        {
            foreach (DataEntitiy<Color> data in _colors)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            _colors.Add(new DataEntitiy<Color>(key, value));
        }

        #endregion

        #region Gradient
        public List<DataEntitiy<Gradient>> _gradients = new List<DataEntitiy<Gradient>>();
        public Gradient Get_Gradient(string key)
        {
            foreach (DataEntitiy<Gradient> data in _gradients)
            {
                if (data.key == key) return data.value;
            }

            return null;
        }
        public void Set_Gradient(string key, Gradient value)
        {
            foreach (DataEntitiy<Gradient> data in _gradients)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            _gradients.Add(new DataEntitiy<Gradient>(key, value));
        }

        #endregion

        #region bool
        public List<DataEntitiy<bool>> _bools = new List<DataEntitiy<bool>>();
        public bool Get_Bool(string key)
        {
            foreach (DataEntitiy<bool> data in _bools)
            {
                if (data.key == key) return data.value;
            }

            return default(bool);
        }
        public void Set_Bool(string key, bool value)
        {
            foreach (DataEntitiy<bool> data in _bools)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            _bools.Add(new DataEntitiy<bool>(key, value));
        }

        #endregion

        #region Sprite
        public List<DataEntitiy<Sprite>> _sprites = new List<DataEntitiy<Sprite>>();
        public Sprite Get_Sprite(string key)
        {
            foreach (DataEntitiy<Sprite> data in _sprites)
            {
                if (data.key == key) return data.value;
            }

            return null;
        }
        public void Set_Sprite(string key, Sprite value)
        {
            foreach (DataEntitiy<Sprite> data in _sprites)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            _sprites.Add(new DataEntitiy<Sprite>(key, value));
        }

        #endregion

        #region AnimationCurve
        public List<DataEntitiy<AnimationCurve>> _curves = new List<DataEntitiy<AnimationCurve>>();
        public AnimationCurve Get_Curve(string key)
        {
            foreach (DataEntitiy<AnimationCurve> data in _curves)
            {
                if (data.key == key) return data.value;
            }

            return null;
        }
        public void Set_Curve(string key, AnimationCurve value)
        {
            foreach (DataEntitiy<AnimationCurve> data in _curves)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            _curves.Add(new DataEntitiy<AnimationCurve>(key, value));
        }

        #endregion

        #region UnityEngine.GameObject[]

        public List<DataEntitiy<UnityEngine.GameObject[]>> _list_GameObjects = new List<DataEntitiy<UnityEngine.GameObject[]>>();

        public UnityEngine.GameObject[] Get_list_GameObjects(string key)
        {
            foreach (DataEntitiy<UnityEngine.GameObject[]> data in _list_GameObjects)
                if (data.key == key) return data.value;

            return default(UnityEngine.GameObject[]);
        }

        public void Set_list_GameObjects(string key, UnityEngine.GameObject[] value)
        {
            foreach (DataEntitiy<UnityEngine.GameObject[]> data in _list_GameObjects)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            _list_GameObjects.Add(new DataEntitiy<UnityEngine.GameObject[]>(key, value));
        }

        #endregion

        #region UnityEngine.Transform

        public List<DataEntitiy<UnityEngine.Transform>> _transforms = new List<DataEntitiy<UnityEngine.Transform>>();

        public UnityEngine.Transform Get_transforms(string key)
        {
            foreach (DataEntitiy<UnityEngine.Transform> data in _transforms)
                if (data.key == key) return data.value;

            return default(UnityEngine.Transform);
        }

        public void Set_transforms(string key, UnityEngine.Transform value)
        {
            foreach (DataEntitiy<UnityEngine.Transform> data in _transforms)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            _transforms.Add(new DataEntitiy<UnityEngine.Transform>(key, value));
        }

        #endregion

        #region UnityEngine.Transform[]

        public List<DataEntitiy<UnityEngine.Transform[]>> _list_transforms = new List<DataEntitiy<UnityEngine.Transform[]>>();

        public UnityEngine.Transform[] Get_list_transforms(string key)
        {
            foreach (DataEntitiy<UnityEngine.Transform[]> data in _list_transforms)
                if (data.key == key) return data.value;

            return default(UnityEngine.Transform[]);
        }

        public void Set_list_transforms(string key, UnityEngine.Transform[] value)
        {
            foreach (DataEntitiy<UnityEngine.Transform[]> data in _list_transforms)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            _list_transforms.Add(new DataEntitiy<UnityEngine.Transform[]>(key, value));
        }

        #endregion

        #region UnityEngine.Component[]

        public List<DataEntitiy<UnityEngine.Component[]>> _list_components = new List<DataEntitiy<UnityEngine.Component[]>>();

        public UnityEngine.Component[] Get_list_components(string key)
        {
            foreach (DataEntitiy<UnityEngine.Component[]> data in _list_components)
                if (data.key == key) return data.value;

            return default(UnityEngine.Component[]);
        }

        public void Set_list_components(string key, UnityEngine.Component[] value)
        {
            foreach (DataEntitiy<UnityEngine.Component[]> data in _list_components)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            _list_components.Add(new DataEntitiy<UnityEngine.Component[]>(key, value));
        }

        #endregion

        #region UnityEngine.Material

        public List<DataEntitiy<UnityEngine.Material>> _material = new List<DataEntitiy<UnityEngine.Material>>();

        public UnityEngine.Material Get_material(string key)
        {
            foreach (DataEntitiy<UnityEngine.Material> data in _material)
                if (data.key == key) return data.value;

            return default(UnityEngine.Material);
        }

        public void Set_material(string key, UnityEngine.Material value)
        {
            foreach (DataEntitiy<UnityEngine.Material> data in _material)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            _material.Add(new DataEntitiy<UnityEngine.Material>(key, value));
        }

        #endregion

        #region UnityEngine.Quaternion

        public List<DataEntitiy<UnityEngine.Quaternion>> _quaternions = new List<DataEntitiy<UnityEngine.Quaternion>>();

        public UnityEngine.Quaternion Get_quaternions(string key)
        {
            foreach (DataEntitiy<UnityEngine.Quaternion> data in _quaternions)
                if (data.key == key) return data.value;

            return default(UnityEngine.Quaternion);
        }

        public void Set_quaternions(string key, UnityEngine.Quaternion value)
        {
            foreach (DataEntitiy<UnityEngine.Quaternion> data in _quaternions)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            _quaternions.Add(new DataEntitiy<UnityEngine.Quaternion>(key, value));
        }

        #endregion

        #region UnityEngine.Vector2Int

        public List<DataEntitiy<UnityEngine.Vector2Int>> _vector2sInt = new List<DataEntitiy<UnityEngine.Vector2Int>>();

        public UnityEngine.Vector2Int Get_vector2sInt(string key)
        {
            foreach (DataEntitiy<UnityEngine.Vector2Int> data in _vector2sInt)
                if (data.key == key) return data.value;

            return default(UnityEngine.Vector2Int);
        }

        public void Set_vector2sInt(string key, UnityEngine.Vector2Int value)
        {
            foreach (DataEntitiy<UnityEngine.Vector2Int> data in _vector2sInt)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            _vector2sInt.Add(new DataEntitiy<UnityEngine.Vector2Int>(key, value));
        }

        #endregion

        #region UnityEngine.Vector3Int

        public List<DataEntitiy<UnityEngine.Vector3Int>> _vector3sInt = new List<DataEntitiy<UnityEngine.Vector3Int>>();

        public UnityEngine.Vector3Int Get_vector3sInt(string key)
        {
            foreach (DataEntitiy<UnityEngine.Vector3Int> data in _vector3sInt)
                if (data.key == key) return data.value;

            return default(UnityEngine.Vector3Int);
        }

        public void Set_vector3sInt(string key, UnityEngine.Vector3Int value)
        {
            foreach (DataEntitiy<UnityEngine.Vector3Int> data in _vector3sInt)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            _vector3sInt.Add(new DataEntitiy<UnityEngine.Vector3Int>(key, value));
        }

        #endregion

        #region UnityEngine.Vector4

        public List<DataEntitiy<UnityEngine.Vector4>> _vector4s = new List<DataEntitiy<UnityEngine.Vector4>>();

        public UnityEngine.Vector4 Get_vector4s(string key)
        {
            foreach (DataEntitiy<UnityEngine.Vector4> data in _vector4s)
                if (data.key == key) return data.value;

            return default(UnityEngine.Vector4);
        }

        public void Set_vector4s(string key, UnityEngine.Vector4 value)
        {
            foreach (DataEntitiy<UnityEngine.Vector4> data in _vector4s)
            {
                if (data.key == key)
                {
                    data.value = value;
                    return;
                }
            }

            _vector4s.Add(new DataEntitiy<UnityEngine.Vector4>(key, value));
        }

        #endregion

//API Line

        public bool Have(string key)
        {
            bool v = false;

            if (!v) _gameObjects.ForEach(d => { if (d.key == key) v = true; });
            if (!v) _components.ForEach(d => { if (d.key == key) v = true; });
            if (!v) _strings.ForEach(d => { if (d.key == key) v = true; });
            if (!v) _ints.ForEach(d => { if (d.key == key) v = true; });
            if (!v) _floats.ForEach(d => { if (d.key == key) v = true; });
            if (!v) _vector2s.ForEach(d => { if (d.key == key) v = true; });
            if (!v) _vector3s.ForEach(d => { if (d.key == key) v = true; });
            if (!v) _colors.ForEach(d => { if (d.key == key) v = true; });
            if (!v) _gradients.ForEach(d => { if (d.key == key) v = true; });
            if (!v) _bools.ForEach(d => { if (d.key == key) v = true; });
            if (!v) _sprites.ForEach(d => { if (d.key == key) v = true; });
            if (!v) _curves.ForEach(d => { if (d.key == key) v = true; });
            if (!v) _list_GameObjects.ForEach(d => { if (d.key == key) v = true; });
            if (!v) _transforms.ForEach(d => { if (d.key == key) v = true; });
            if (!v) _list_transforms.ForEach(d => { if (d.key == key) v = true; });
            if (!v) _list_components.ForEach(d => { if (d.key == key) v = true; });
            if (!v) _material.ForEach(d => { if (d.key == key) v = true; });
            if (!v) _quaternions.ForEach(d => { if (d.key == key) v = true; });
            if (!v) _vector2sInt.ForEach(d => { if (d.key == key) v = true; });
            if (!v) _vector3sInt.ForEach(d => { if (d.key == key) v = true; });
            if (!v) _vector4s.ForEach(d => { if (d.key == key) v = true; });
//Have Line

            return v;
        }
    }
}

