using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

using BennyBroseph;
using BennyBroseph.Contextual;

namespace Combat
{
    public enum PartyState
    {
        INIT,
        IDLE,
        TAKING_TURN,
        DEFEATED,
    }

    [Serializable]
    public struct Party<T>
    {
        private List<Unit<T>> m_Units;
        private int m_CurrentUnitIndex;

        private FiniteStateMachine<PartyState> m_PartyFSM;

        public List<Unit<T>> units { get { return m_Units; } set { m_Units = value; } }
        public Unit<T> currentUnit { get { return m_Units[m_CurrentUnitIndex]; } set { m_Units[m_CurrentUnitIndex] = value; Publisher.self.Broadcast("Party Current Unit Changed", this); } }

        public FiniteStateMachine<PartyState> partyFSM { get { return m_PartyFSM; } }

        public Party(List<Unit<T>> a_Units)
        {
            m_Units = a_Units;
            m_CurrentUnitIndex = 0;

            m_PartyFSM = new FiniteStateMachine<PartyState>();
            SetFMS();
        }

        public Party(List<Unit<T>> a_Units, int a_UnitIndex)
        {
            m_Units = a_Units;
            m_CurrentUnitIndex = a_UnitIndex;

            m_PartyFSM = new FiniteStateMachine<PartyState>();
            SetFMS();
        }

        private void SetFMS()
        {
            m_PartyFSM.AddTransition(PartyState.INIT, PartyState.IDLE);
            m_PartyFSM.AddTransition(PartyState.IDLE, PartyState.TAKING_TURN);
            m_PartyFSM.AddTransition(PartyState.IDLE, PartyState.DEFEATED);

            m_PartyFSM.Transition(PartyState.IDLE);
        }
    }

    [Serializable]
    public sealed class Controller : Singleton<Controller>
    {
        private List<Party<float>> m_Parties;

        private int m_CurrentPartyIndex;
        private int m_CurrentTargetPartyIndex;

        private string m_Path = Environment.CurrentDirectory + "\\SaveFile.xml";

        public List<Party<float>> parties
        {
            get { return m_Parties; }
            set { m_Parties = value; Publisher.self.Broadcast("Parties Changed", m_Parties); }
        }

        public Party<float> currentParty
        {
            get { return m_Parties[m_CurrentPartyIndex]; }
            set { m_Parties[m_CurrentPartyIndex] = value; Publisher.self.Broadcast("Current Party Changed", m_Parties[m_CurrentPartyIndex]); }
        }
        public Party<float> currentTargetParty
        {
            get { return m_Parties[m_CurrentTargetPartyIndex]; }
            set { m_Parties[m_CurrentTargetPartyIndex] = value; Publisher.self.Broadcast("Current Target Party Changed", m_Parties[m_CurrentTargetPartyIndex]); }
        }

        public Controller()
        {
            m_Parties = new List<Party<float>>();

            Publisher.self.Subscribe("Unit Action", EventRaised);
        }

        public void Save()
        {
            FileStream SaveFile = File.Create(m_Path);

            XmlSerializer Writer = new XmlSerializer(GetType());
            Writer.Serialize(SaveFile, this);

            SaveFile.Close();
        }
        public void Load()
        {
            XmlSerializer Reader = new XmlSerializer(GetType());

            StreamReader SaveFile = new StreamReader(m_Path);

            Controller Me = Reader.Deserialize(SaveFile) as Controller;

            m_Parties = Me.m_Parties;

            SaveFile.Close();
        }

        public void AddParty(Party<float> a_Party)
        {
            m_Parties.Add(a_Party);
        }

        private void EventRaised(string a_Message, object a_Param)
        {
            Console.WriteLine(a_Message + ": " + a_Param.ToString());
        }
    }
}
