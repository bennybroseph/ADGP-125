using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BennyBroseph;

namespace Combat
{
    [Serializable]
    public struct StatType<T>
    {
        private T m_Physical, m_Special;

        public T physical { get { return m_Physical; } set { m_Physical = value; } }
        public T special { get { return m_Special; } set { m_Special = value; } }

        public StatType(T a_Physical, T a_Special)
        {
            m_Physical = a_Physical;
            m_Special = a_Special;
        }
    }

    public enum Recipient
    {
        SELF,
        TARGET,
        ALL_ENEMY,
        ALL_ALLY,
        ALL,
    }

    public enum AbilityType
    {
        OFFENSIVE,
        DEFENSIVE,
        BUFF,
        DEBUFF,
    }
    
    [Serializable]
    public class Ability<T>
    {
        private string m_Name;
        private string m_Description;

        private List<AbilityType> m_Type;
        private List<Recipient> m_Recipient;

        private List<T> m_Power;
        private List<T> m_Accuracy;

        private T m_Uses;
        private T m_MaxUses;

        public delegate void Action(int a_AbilityIndex);

        private Action m_Action;

        public string name { get { return m_Name; } }
        public string description { get { return m_Description; } }

        public List<AbilityType> type { get { return m_Type; } }

        public List<T> power { get { return m_Power; } }
        public List<T> accuracy { get { return m_Accuracy; } }

        public T uses { get { return m_Uses; } set { m_Uses = value; Publisher.self.Broadcast("Ability Uses Changed", this); } }
        public T maxUses { get { return m_MaxUses; } }

        public Action action { get { return m_Action; } }

        private Ability() { }

        public Ability(string a_Name, string a_Description, List<AbilityType> a_Type, List<Recipient> a_Recipient, List<T> a_Power, List<T> a_Accuracy, T a_Uses, Action a_Action)
        {
            m_Name = a_Name;
            m_Description = a_Description;

            m_Type = a_Type;
            m_Recipient = a_Recipient;

            m_Power = a_Power;
            m_Accuracy = a_Accuracy;

            m_Uses = a_Uses;
            m_MaxUses = m_Uses;

            m_Action = a_Action;
        }

        public Ability(Ability<T> a_Reference)
        {
            m_Name = a_Reference.m_Name;
            m_Description = a_Reference.m_Description;

            m_Type = a_Reference.m_Type;
            m_Recipient = a_Reference.m_Recipient;

            m_Power = a_Reference.m_Power;
            m_Accuracy = a_Reference.m_Accuracy;

            m_Uses = a_Reference.m_Uses;
            m_MaxUses = a_Reference.m_MaxUses;

            m_Action = a_Reference.m_Action;
        }
    }

    public interface ICombatable<T>
    {
        T health { get; set; }
        T maxHealth { get; set; }

        StatType<T> attack { get; set; }
        StatType<T> maxAttack { get; set; }

        StatType<T> defense { get; set; }
        StatType<T> maxDefense { get; set; }

        T speed { get; set; }
        T maxSpeed { get; set; }
    }

    [Serializable]
    public struct Stats<T>
    {      
        private T m_Health;
        private T m_MaxHealth;

        private T m_Speed;
        private T m_MaxSpeed;

        private StatType<T> m_Attack;
        private StatType<T> m_MaxAttack;

        private StatType<T> m_Defense;
        private StatType<T> m_MaxDefense;

        public T health { get { return m_Health; } set { m_Health = value; } }
        public T maxHealth { get { return m_MaxHealth; } set { m_MaxHealth = value; } }

        public T speed { get { return m_Speed; } set { m_Speed = value; } }
        public T maxSpeed { get { return m_MaxSpeed; } set { m_MaxSpeed = value; } }

        public StatType<T> attack { get { return m_Attack; } set { m_Attack = value; } }
        public StatType<T> maxAttack { get { return m_MaxAttack; } set { m_MaxAttack = value; } }

        public StatType<T> maxDefense { get { return m_MaxDefense; } set { m_MaxDefense = value; } }
        public StatType<T> defense { get { return m_Defense; } set { m_Defense = value; } }

        public Stats(T a_Health, T a_Speed, StatType<T> a_Attack, StatType<T> a_Defense)
        {
            m_Health = a_Health;
            m_MaxHealth = m_Health;

            m_Speed = a_Speed;
            m_MaxSpeed = m_Speed;

            m_Attack = a_Attack;
            m_MaxAttack = m_Attack;

            m_Defense = a_Defense;
            m_MaxDefense = m_Defense;
        }
    }
}
