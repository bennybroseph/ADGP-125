using System;

namespace ConsoleApplication1
{
    enum ActionType { ATTACK, SPELL, BUFF, DEBUFF, };

    struct StatType
    {
        private int m_Magic, m_Physical;

        public int magic { get { return m_Magic; } }
        public int physical { get { return m_Physical; } }

        public StatType(int a_Magic, int a_Physical)
        {
            m_Magic = a_Magic;
            m_Physical = a_Physical;
        }
    }

    interface IStats<T>
    {
        T health { get; }
        T armor { get; }

        StatType attack { get; }
        StatType defense { get; }
    }
    interface ICombatable<T> : IStats<T>
    {
        void ReceiveAction(StatType a_OtherAttack, ActionType a_ActionType);
        void PerformAction(ICombatable<T> a_Other, ActionType a_ActionType);
    }
}
