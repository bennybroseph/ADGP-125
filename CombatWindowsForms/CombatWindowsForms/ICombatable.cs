using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat
{
    public struct StatType<T>
    {
        private T m_Magic, m_Physical;

        public T magic { get { return m_Magic; } }
        public T physical { get { return m_Physical; } }

        public StatType(T a_Magic, T a_Physical)
        {
            m_Magic = a_Magic;
            m_Physical = a_Physical;
        }
    }

    public enum ActionType
    {
        ATTACK,
        SPELL,
        BUFF,
        DEBUFF,
    }

    public interface ICombatable<T>
    {
        void ReceiveAction(StatType<T> a_OtherAttack, ActionType a_ActionType);
        void PerformAction(ICombatable<T> a_Other, ActionType a_ActionType);
    }

    public interface IStats<T> : ICombatable<T>
    {
        T maxHealth { get; set; }
        T maxArmor { get; set; }

        T health { get; set; }
        T armor { get; set; }

        T maxSpeed { get; set; }

        T speed { get; set; }

        StatType<T> maxAttack { get; set; }
        StatType<T> maxDefense { get; set; }

        StatType<T> attack { get; set; }
        StatType<T> defense { get; set; }
    }
}
