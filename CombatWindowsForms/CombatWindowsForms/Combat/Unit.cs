using System.Collections.Generic;

using BennyBroseph;

namespace Combat
{
    public enum UnitStates
    {
        INIT,
        IDLE,
        ATTACKING,
        DEFENDING,
        DEAD,
    }

    public class Unit<T> : ICombatable<T>
    {
        protected List<Ability<T>> m_Abilities;
        protected Stats<T> m_Stats;

        protected FiniteStateMachine<UnitStates> m_UnitFSM;

        public List<Ability<T>> abilities { get { return m_Abilities; } } 

        public virtual T health
        {
            get { return m_Stats.health; }
            set { m_Stats.health = value; Publisher.self.Broadcast("Unit Health Changed", this); }
        }
        public virtual T maxHealth
        {
            get { return m_Stats.maxHealth; }
            set { m_Stats.maxHealth = value; Publisher.self.Broadcast("Unit MaxHealth Changed", this); }
        }

        public virtual StatType<T> attack
        {
            get { return m_Stats.attack; }
            set { m_Stats.attack = value; Publisher.self.Broadcast("Unit Attack Changed", this); }
        }
        public virtual StatType<T> maxAttack
        {
            get { return m_Stats.maxAttack; }
            set { m_Stats.maxAttack = value; Publisher.self.Broadcast("Unit MaxAttack Changed", this); }
        }

        public virtual StatType<T> defense
        {
            get { return m_Stats.defense; }
            set { m_Stats.defense = value; Publisher.self.Broadcast("Unit Defense Changed", this); }
        }
        public virtual StatType<T> maxDefense
        {
            get { return m_Stats.maxDefense; }
            set { m_Stats.maxDefense = value; Publisher.self.Broadcast("Unit MaxDefense Changed", this); }
        }

        public virtual T speed
        {
            get { return m_Stats.speed; }
            set { m_Stats.speed = value; Publisher.self.Broadcast("Unit Speed Changed", this); }
        }   
        public virtual T maxSpeed
        {
            get { return m_Stats.maxSpeed; }
            set { m_Stats.maxSpeed = value; Publisher.self.Broadcast("Unit MaxSpeed Changed", this); }
        }   

        protected Unit() { }    // No default constructor available

        public Unit(Stats<T> a_Stats, List<Ability<T>> a_Actions)
        {
            m_Stats = a_Stats;
            m_Abilities = a_Actions;
        }
    }
}
