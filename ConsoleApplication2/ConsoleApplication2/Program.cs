using System;
using System.Collections.Generic;

namespace ConsoleApplication2
{
    public class FSM
    {
        private List<Enum> m_States = new List<Enum>();

        public delegate void StateChange(string a_TransitionState);

        private Dictionary<string, StateChange> m_Transitions = new Dictionary<string, StateChange>();

        private StateChange m_MyStateChange;

        public FSM()
        {
            m_MyStateChange = MyStateChange;
        }

        public bool LoadStates<T>(T a_States)
        {
            if (typeof(T) == typeof(Type))
            {
                foreach (object obj in Enum.GetValues(a_States as Type))
                    m_States.Add((Enum)obj);

                foreach (Enum obj in m_States)
                    Console.WriteLine(obj);

                return true;
            }
            else
            {
                foreach (object obj in Enum.GetValues(typeof(T)))
                    m_States.Add((Enum)obj);

                foreach (Enum obj in m_States)
                    Console.WriteLine(obj);

                return true;
            }
        }

        public bool AddTransition(string a_Transition, StateChange a_Delegate)
        {
            if (m_Transitions.ContainsKey(a_Transition))
            {
                m_Transitions[a_Transition] += a_Delegate;
                return true;
            }
            else
            {

            }
        }

        private void MyStateChange(string a_TransitionState)
        {

        }
    }
    class Program
    {
        private enum PlayerState { INIT, RUN, IDLE, WALK };
        private enum GameState { INIT, PAUSE, RUNNING };

        static void Main(string[] args)
        {
            FSM PlayerFSM = new FSM();
            FSM EnemyFSM = new FSM();
            
            PlayerFSM.LoadStates(typeof(PlayerState));
            EnemyFSM.LoadStates(typeof(GameState));

            PlayerFSM.AddTransition("INIT->RUN", PlayerStateChange);
        }

        static public void PlayerStateChange(string a_TransitionState)
        {

        }
    }
}
