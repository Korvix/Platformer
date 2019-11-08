using UnityEngine;

namespace Platformer.GameSystem
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));

                    if (instance == null)
                    {
                        GameObject obj = new GameObject();
                        instance = obj.AddComponent<T>();
                        obj.name = instance.GetType().ToString();
                    }
                }
                return instance;
            }
        }
    }
}