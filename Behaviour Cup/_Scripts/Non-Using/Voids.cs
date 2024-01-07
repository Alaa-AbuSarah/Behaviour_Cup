/*        public T Get<T>(string key) where T : class
        {
            T v = null;

            GameObjects.ForEach(d => { if (d.key == key & typeof(T) == typeof(GameObject)) v = d.value as T; });
            if (v == null) components.ForEach(d => { if (d.key == key & typeof(T) == typeof(Component)) v = d.value as T; });
            if (v == null) strings.ForEach(d => { if (d.key == key & typeof(T) == typeof(string)) v = d.value as T; });
            if (v == null) ints.ForEach(d => { if (d.key == key & typeof(T) == typeof(int)) v = d.value as T; });
            if (v == null) floats.ForEach(d => { if (d.key == key & typeof(T) == typeof(float)) v = d.value as T; });
            if (v == null) vector2s.ForEach(d => { if (d.key == key & typeof(T) == typeof(Vector2)) v = d.value as T; });
            if (v == null) vector3s.ForEach(d => { if (d.key == key & typeof(T) == typeof(Vector3)) v = d.value as T; });
            if (v == null) colors.ForEach(d => { if (d.key == key & typeof(T) == typeof(Color)) v = d.value as T; });
            if (v == null) gradients.ForEach(d => { if (d.key == key & typeof(T) == typeof(Gradient)) v = d.value as T; });
            if (v == null) bools.ForEach(d => { if (d.key == key & typeof(T) == typeof(bool)) v = d.value as T; });
            if (v == null) sprites.ForEach(d => { if (d.key == key & typeof(T) == typeof(Sprite)) v = d.value as T; });

            return v;
        }*/