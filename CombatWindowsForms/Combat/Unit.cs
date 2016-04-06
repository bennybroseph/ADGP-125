using System;
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

    [Serializable]
    public class Unit<T> : ICombatable<T>
    {
        protected string m_Name;
        protected string m_Nickname;

        protected string m_ImagePath;

        protected int m_Level;
        protected int m_Experience;

        protected List<Ability<T>> m_Abilities;
        protected Stats<T> m_Stats;

        protected FiniteStateMachine<UnitStates> m_UnitFSM;

        public virtual string name { get { return m_Name; } }
        public virtual string nickname
        {
            get { return m_Nickname; }
            set { m_Nickname = value; Publisher.self.Broadcast("Unit Nickname Changed", this); }
        }

        public virtual string imagePath { get { return m_ImagePath; } }

        public virtual int level { get { return (int)(Math.Pow(m_Experience, (1.0f / 3.0f))); } }
        public virtual int experience
        {
            get { return m_Experience; }
            set { m_Experience = value; Publisher.self.Broadcast("Unit Experience Changed", this); }
        }

        public virtual List<Ability<T>> abilities
        {
            get { return m_Abilities; }
            set { m_Abilities = value; }
        }

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

        public Unit(string a_Name, string a_Nickname, Stats<T> a_Stats, int a_Level, List<Ability<T>> a_Actions)
        {
            m_Name = a_Name;
            m_Nickname = a_Nickname;

            m_ImagePath = Environment.CurrentDirectory + "\\Images\\" + m_Name;

            m_Stats = a_Stats;
            m_Abilities = a_Actions;

            m_Experience = (int)Math.Pow(a_Level, 3);
        }
    }
}
