using System;
using System.Collections.Generic;

using BennyBroseph.Contextual;

namespace BennyBroseph
{
    public sealed class Publisher : Singleton<Publisher>
    {
        public delegate void Subscription(string a_Message, object a_Param);

        private Dictionary<string, Subscription> m_Messages;

        public Publisher()
        {
            m_Messages = new Dictionary<string, Subscription>();
        }

        public void Subscribe(string a_Message, Subscription a_Subscription)
        {
            if (!m_Messages.ContainsKey(a_Message))
                m_Messages[a_Message] = a_Subscription;
            else
                m_Messages[a_Message] += a_Subscription;
        }
        public void UnSubscribe(string a_Message, Subscription a_Subscription)
        {
            if (m_Messages.ContainsKey(a_Message))
                m_Messages[a_Message] -= a_Subscription;
            else
                DebugError("The message '" + a_Message + "' does not exist. You cannot unsubscribe from it.");
        }

        public void Broadcast(string a_Message, object a_Param)
        {
            Subscription Callback;

            m_Messages.TryGetValue(a_Message, out Callback);

            if (Callback != null)
                Callback(a_Message, a_Param);
        }

        /// <summary>
        /// Attempts to access a debugging messenger. Will do nothing if it cannot be found
        /// </summary>
        /// <param name="a_Type">The string representing the type of message to display</param>
        /// <param name="a_Message">The message to display</param>
        private void DebugMessage(object a_Message)
        {
#if CONTEXT_DEBUG   // Only compiles if the build is using the 'ContextualDebug' by defining it in the build options
            Debug.Message(a_Message);
#elif (!UNITY_EDITOR && DEBUG) // Only compiles when in debug mode and not in unity
            Console.WriteLine(a_Message);
#endif
        }
        /// <summary>
        /// Attempts to access a debugging messenger at a warning level. Will do nothing if it cannot be found
        /// </summary>
        /// <param name="a_Type">The string representing the type of message to display</param>
        /// <param name="a_Message">The message to display</param>
        private void DebugWarning(object a_Message)
        {
#if CONTEXT_DEBUG   // Only compiles if the build is using the 'ContextualDebug' by defining it in the build options
            Debug.Warning(a_Message);
#elif (!UNITY_EDITOR && DEBUG) // Only compiles when in debug mode and not in unity
            Console.WriteLine(a_Message);
#endif
        }
        /// <summary>
        /// Attempts to access a debugging messenger at an error level. Will do nothing if it cannot be found
        /// </summary>
        /// <param name="a_Type">The string representing the type of message to display</param>
        /// <param name="a_Message">The message to display</param>
        private void DebugError(object a_Message)
        {
#if CONTEXT_DEBUG   // Only compiles if the build is using the 'ContextualDebug' by defining it in the build options
            Debug.Error(a_Message);
#elif (!UNITY_EDITOR && DEBUG) // Only compiles when in debug mode and not in unity
            Console.WriteLine(a_Message);
#endif
        }
    }
}
