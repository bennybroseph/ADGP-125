//////////////////////
//     Singleton    //
//////////////////////


namespace BennyBroseph
{    
    namespace Contextual
    {
        [System.Serializable]
#if UNITY_EDITOR
        public class Singleton<T> : MonoBehavior
#else
        public abstract class Singleton<T> where T : class, new()
#endif
        {
            static protected T s_Self;

            static public T self
            {
                get
                {
                    if (s_Self == null)
#if UNITY_EDITOR
                        s_Self = FindObjectOfType<T>();
#else
                        s_Self = new T();
#endif
                    return s_Self;
                }
            }

            protected Singleton()
            {

            }
        }
    }
}
