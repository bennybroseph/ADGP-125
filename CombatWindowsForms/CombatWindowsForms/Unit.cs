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
            set { m_Armor = value; Publisher.self.Broadcast("Unit Armor Changed", this); }
        }

        public StatType<int> attack
        {
            get { return m_Attack; }
            set { m_Attack = value; Publisher.self.Broadcast("Unit Attack Changed", this); }
        }

        public StatType<int> defense
        {
            get { return m_Defense; }
            set { m_Defense = value; Publisher.self.Broadcast("Unit Defense Changed", this); }
        }

        public int health
        {
            get { return m_Health; }
            set { m_Health = value; Publisher.self.Broadcast("Unit Health Changed", this); }
        }

        public int speed
        {
            get { return m_Speed; }
            set { m_Speed = value; Publisher.self.Broadcast("Unit Speed Changed", this); }
        }

        public int maxHealth
        {
            get { return m_MaxHealth; }
            set { m_MaxHealth = value; Publisher.self.Broadcast("Unit MaxHealth Changed", this); }
        }

        public int maxArmor
        {
            get { return m_MaxArmor; }
            set { m_MaxArmor = value; Publisher.self.Broadcast("Unit MaxArmor Changed", this); }
        }

        public int maxSpeed
        {
            get { return m_MaxSpeed; }
            set { m_MaxSpeed = value; Publisher.self.Broadcast("Unit MaxSpeed Changed", this); }
        }

        public StatType<int> maxAttack
        {
            get { return m_MaxAttack; }
            set { m_MaxAttack = value; Publisher.self.Broadcast("Unit MaxAttack Changed", this); }
        }

        public StatType<int> maxDefense
        {
            get { return m_MaxDefense; }
            set { m_MaxDefense = value; Publisher.self.Broadcast("Unit MaxDefense Changed", this); }
        }

        protected Unit() { }    // No default constructor available

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
