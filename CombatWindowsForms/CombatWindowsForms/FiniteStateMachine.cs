﻿using System;                           // Required for the type 'Enum'
using System.Collections.Generic;       // Required to use 'List<T>' and 'Dictionary<T, T>'
using BennyBroseph.Contextual;

namespace BennyBroseph
{
    // Usage:
    // enum MyStates { Init, Idle };
    // FiniteStateMachine<MyStates> MyFSM = new FiniteStateMachine<MyStates>(OPTIONAL: MyStates.Idle);
    /// <summary>
    /// My Finite State Machine
    /// </summary>
    /// <typeparam name="T">A 'System.Type' in which 'T.IsEnum()' is true</typeparam>
    [Serializable]
    public sealed class FiniteStateMachine<T>
    {
        public delegate bool ValidateTransition();  // Delegate that will be used to determine if a state change is valid by the user

        private T m_CurrentState;   // The current state the machine is in
        private List<T> m_States;   // Cached list of all states in the enumeration

        private Dictionary<string, ValidateTransition> m_Transitions;   // Dynamic dictionary of all transitions as dictated by the user

        // Read-Only property for the current state 'm_CurrentState'
        // Look at me. I'm the captain now.
        public T currentState { get { return m_CurrentState; } }

        /// <summary>
        /// Default constructor which will initialize the list and dictionary
        /// </summary>
        public FiniteStateMachine()
        {
            m_States = new List<T>();
            m_Transitions = new Dictionary<string, ValidateTransition>();

            StoreStates();
        }
        /// <summary>
        /// Parameterized constructor which allows a state other than 'm_States[0]' to initialize 'm_CurrentState'
        /// </summary>
        /// <param name="a_InitialState">Used as the current state 'm_CurrentState' on creation</param>
        public FiniteStateMachine(T a_InitialState) : base()
        {
            m_CurrentState = a_InitialState;
        }

        /// <summary>
        /// Attempts to add a new transition to the current list of transitions
        /// </summary>
        /// <param name="a_From">The state to come from</param>
        /// <param name="a_To">The state to go to</param>
        /// <param name="a_IsValidTransition">An optional delegate with no parameters that returns true when the state change is valid and false when it is not</param>
        /// <returns>Returns true if the transition was able to be added and false otherwise</returns>
        public bool AddTransition(T a_From, T a_To, ValidateTransition a_IsValidTransition = null)
        {
            // if 'a_From' and 'a_To' are the same state
            if (a_From.Equals(a_To))
            {
                DebugWarning("'" + a_From + "'" + " is the same state as " + "'" + a_To + "'");
                return false;
            }

            // if 'a_From' or 'a_To' is not in the list of states
            if (!m_States.Contains(a_From) || !m_States.Contains(a_To))
            {
                T invalidKey;   // Will decipher which state is invalid
                if (!m_States.Contains(a_From))
                    invalidKey = a_From;
                else
                    invalidKey = a_To;

                DebugWarning("'" + invalidKey + "' does not exist in '" + typeof(T) + "'");
                return false;
            }

            // Properly serializes 'a_From' and 'a_To' into the expected key format
            string key = a_From.ToString() + "->" + a_To.ToString();
            // if the key 'key' does not currently exist in 'm_Transitions'
            if (!m_Transitions.ContainsKey(key))
            {
                // if the user did not pass in a delegate to check the transition
                if (a_IsValidTransition == null)
                    m_Transitions[key] = delegate () { return true; };  // Set a default one that always allows the transition
                else
                    m_Transitions[key] = a_IsValidTransition;           // Otherwise use the one they passed in
                return true;
            }
            else
            {
                DebugWarning("'" + key + "' already exists as a transition key");
                return false;
            }
        }

        /// <summary>
        /// Attempts to transition from the current state to the passed parameter
        /// </summary>
        /// <param name="a_To">The state to transition to</param>
        /// <returns>Returns true if the transition completed and false otherwise</returns>
        public bool Transition(T a_To)
        {
            // Converts the current state and the state to transition to into a valid key
            string key = m_CurrentState.ToString() + "->" + a_To.ToString();
            // if they key exists in the transition dictionary
            if (m_Transitions.ContainsKey(key) && m_Transitions[key]())
            {
                m_CurrentState = a_To;  // Set the state
                return true;            // Success
            }
            else
                return false;
        }

        /// <summary>
        /// Grabs each state from the type of enumeration and caches it into a list
        /// </summary>
        /// <returns>Returns true if the type is an enumeration and false if it is not</returns>
        private bool StoreStates()
        {
            // if 'T' is an enumeration type
            if (typeof(T).IsEnum)
            {
                // Iterate through each parsed state 'iState'
                foreach (var iState in Enum.GetValues(typeof(T)))
                    m_States.Add((T)iState);    // Cache it

                m_CurrentState = m_States[0];   // Set the current state to the first found state
                return true;
            }
            else
            {
                DebugError("Incorrect type '" + typeof(T) + "'");
                return false;
            }
        }

        /// <summary>
        /// Prints the cached states in the format:
        /// ORDER - STATE
        /// </summary>
        public void PrintStates()
        {
            for (var i = 0; i < m_States.Count; ++i)
                Console.WriteLine(i + " - " + m_States[i].ToString());
        }
        /// <summary>
        /// Prints the currently defined transitions int the format:
        /// ORDER - STATE_FROM->STATE_TO
        /// </summary>
        public void PrintTransitions()
        {
            var i = 0;
            foreach (var iPair in m_Transitions)
            {
                Console.WriteLine(i + " - " + iPair.Key.ToString());
                i++;
            }
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
