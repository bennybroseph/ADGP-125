//////////////////////
//     Singleton    //
//////////////////////


namespace BennyBroseph
{    
    namespace Contextual
    {
        [System.Serializable]
        public abstract class Singleton<T> where T : class, new()
        {
            static protected T s_Self;

            static public T self
            {
                get
                {
                    if (s_Self == null)
                        s_Self = new T();
                    return s_Self;
                }
            }

            protected Singleton()
            {

            }
        }

        [System.Serializable]
#if UNITY_EDITOR
        public class UnitySingleton<T> : UnityEngine.MonoBehaviour where T : UnityEngine.MonoBehaviour
        {
            static protected T s_Self;

            static public T self
            {
                get
                {
                    if (s_Self == null)
                        s_Self = FindObjectOfType<T>();
                    return s_Self;
                }
            }

            protected UnitySingleton()
            {

            }
        }
#endif
    }
}
