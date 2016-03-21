using System;

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

    public class Unit : IStats<int>
    {
        protected int m_Health;
        protected int m_Armor;

        protected int m_MaxHealth;
        protected int m_MaxArmor;

        protected int m_Speed;

        protected int m_MaxSpeed;

        protected StatType<int> m_Attack;
        protected StatType<int> m_Defense;

        protected StatType<int> m_MaxAttack;
        protected StatType<int> m_MaxDefense;

        protected FiniteStateMachine<UnitStates> m_UnitFSM;

        public int armor
        {
            get { return m_Armor; }
            set { Publisher.self.Broadcast("Unit Armor Changed", this); m_Armor = value; }
        }

        public StatType<int> attack
        {
            get { return m_Attack; }
            set { Publisher.self.Broadcast("Unit Attack Changed", this); m_Attack = value; }
        }

        public StatType<int> defense
        {
            get { return m_Defense; }
            set { throw new NotImplementedException(); }
        }

        public int health
        {
            get { return m_Health; }
            set { Publisher.self.Broadcast("Unit Health Changed", this); m_Health = value; }
        }

        public int speed
        {
            get { return m_Speed; }
            set { throw new NotImplementedException(); }
        }

        public int maxHealth
        {
            get { return m_MaxHealth; }
            set { throw new NotImplementedException(); }
        }

        public int maxArmor
        {
            get { return m_MaxArmor; }
            set { throw new NotImplementedException(); }
        }

        public int maxSpeed
        {
            get { return m_MaxSpeed; }
            set { throw new NotImplementedException(); }
        }

        public StatType<int> maxAttack
        {
            get { return m_MaxAttack; }
            set { throw new NotImplementedException(); }
        }

        public StatType<int> maxDefense
        {
            get { return m_MaxDefense; }
            set { throw new NotImplementedException(); }
        }

        protected Unit()
        {

        }

        public Unit(int a_Health, int a_Armor, int a_Speed, StatType<int> a_Attack, StatType<int> a_Defense)
        {
            m_Health = a_Health;
            m_Armor = a_Armor;

            m_Speed = a_Speed;

            m_Attack = a_Attack;
            m_Defense = a_Defense;

            m_MaxHealth = m_Health;
            m_MaxArmor = m_Armor;

            m_MaxSpeed = m_Speed;

            m_MaxSpeed = m_Speed;
            m_MaxDefense = m_Defense;
        }

        public void PerformAction(ICombatable<int> a_Other, ActionType a_ActionType)
        {
            throw new NotImplementedException();
        }

        public void ReceiveAction(StatType<int> a_OtherAttack, ActionType a_ActionType)
        {
            throw new NotImplementedException();
        }
    }
}
