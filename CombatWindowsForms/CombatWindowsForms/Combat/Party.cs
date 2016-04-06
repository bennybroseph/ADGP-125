using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using BennyBroseph;
using BennyBroseph.Contextual;
using System.Runtime.Serialization.Formatters.Binary;

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
    public class Party<T>
    {
        private string m_Name;

        private List<Unit<T>> m_Units;
        private int m_CurrentUnitIndex;

        private FiniteStateMachine<PartyState> m_PartyFSM;

        public string name { get { return m_Name; } set { m_Name = value; } }

        public List<Unit<T>> units { get { return m_Units; } set { m_Units = value; } }
        public Unit<T> currentUnit { get { return m_Units[m_CurrentUnitIndex]; } set { m_Units[m_CurrentUnitIndex] = value; Publisher.self.Broadcast("Party Current Unit Changed", this); } }

        public FiniteStateMachine<PartyState> partyFSM { get { return m_PartyFSM; } }

        private Party() { }

        public Party(string a_Name, List<Unit<T>> a_Units)
        {
            m_Name = a_Name;

            m_Units = a_Units;
            m_CurrentUnitIndex = 0;

            m_PartyFSM = new FiniteStateMachine<PartyState>();
            SetFMS();
        }

        public Party(string a_Name, List<Unit<T>> a_Units, int a_UnitIndex)
        {
            m_Name = a_Name;

            m_Units = a_Units;
            m_CurrentUnitIndex = a_UnitIndex;

            m_PartyFSM = new FiniteStateMachine<PartyState>();
            SetFMS();
        }

        public void SwitchCurrentUnit(int a_NewUnitIndex)
        {
            if (m_Units.Count > a_NewUnitIndex)
            {
                m_CurrentUnitIndex = a_NewUnitIndex;

                Publisher.self.Broadcast("Party Current Unit Switched", this);
            }
        }

        public void AutoSwitchCurrentUnit()
        {
            if (m_Units.Count > m_CurrentUnitIndex + 1)
                SwitchCurrentUnit(m_CurrentUnitIndex + 1);
            else
                Publisher.self.Broadcast("Party Out of Combatable Units", this);
        }
        private void SetFMS()
        {
            m_PartyFSM.AddTransition(PartyState.INIT, PartyState.IDLE);
            m_PartyFSM.AddTransition(PartyState.IDLE, PartyState.TAKING_TURN);
            m_PartyFSM.AddTransition(PartyState.TAKING_TURN, PartyState.IDLE);
            m_PartyFSM.AddTransition(PartyState.TAKING_TURN, PartyState.DEFEATED);
            m_PartyFSM.AddTransition(PartyState.IDLE, PartyState.DEFEATED);

            m_PartyFSM.Transition(PartyState.IDLE);
        }
    }

    public enum GameControllerState
    {
        INIT,
        IDLE,
        PLAYER_TURN,
        ENEMY_TURN,
        END,
    }

    [Serializable]
    public sealed class GameController : Singleton<GameController>
    {
        private List<Party<float>> m_Parties;

        private FiniteStateMachine<GameControllerState> m_GameControllerFSM;

        private int m_CurrentPartyIndex = 0;
        private int m_CurrentTargetPartyIndex = 1;

        private string m_SavePath = Environment.CurrentDirectory + "\\SaveFile";

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

        public GameController()
        {
            m_Parties = new List<Party<float>>();

            m_GameControllerFSM = new FiniteStateMachine<GameControllerState>();
            SetFSM();

            Publisher.self.Subscribe("Unit Action", EventRaised);
            Publisher.self.Subscribe("Player End Turn", UnitEndTurn);
            Publisher.self.Subscribe("Enemy End Turn", UnitEndTurn);
            Publisher.self.Subscribe("Party Out of Combatable Units", PartyWiped);
        }

        public void Save()
        {
            FileStream SaveFile = File.Create(m_SavePath);
            BinaryFormatter Formatter = new BinaryFormatter();

            try
            {
                Formatter.Serialize(SaveFile, this);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize: " + e.Message);
            }

            SaveFile.Close();
        }
        public void Load()
        {
            FileStream SaveFile = File.Open(m_SavePath, FileMode.Open);
            BinaryFormatter Formatter = new BinaryFormatter();

            try
            {
                GameController DeserializedData = Formatter.Deserialize(SaveFile) as GameController;

                m_Parties = DeserializedData.m_Parties;

                m_CurrentPartyIndex = DeserializedData.m_CurrentPartyIndex;
                m_CurrentTargetPartyIndex = DeserializedData.m_CurrentTargetPartyIndex;

                m_GameControllerFSM = DeserializedData.m_GameControllerFSM;
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize: " + e.Message);
            }

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

        private void UnitEndTurn(string a_Message, object a_Param)
        {
            if (a_Message == "Player End Turn")
            {
                if (m_GameControllerFSM.Transition(GameControllerState.ENEMY_TURN))
                {
                    var TempIndex = m_CurrentPartyIndex;
                    m_CurrentPartyIndex = m_CurrentTargetPartyIndex;
                    m_CurrentTargetPartyIndex = TempIndex;

                    Publisher.self.Broadcast("Enemy Turn", null);
                }
            }
            if (a_Message == "Enemy End Turn")
            {
                if (m_GameControllerFSM.Transition(GameControllerState.PLAYER_TURN))
                {
                    var TempIndex = m_CurrentPartyIndex;
                    m_CurrentPartyIndex = m_CurrentTargetPartyIndex;
                    m_CurrentTargetPartyIndex = TempIndex;

                    Publisher.self.Broadcast("Player Turn", null);
                }
            }
        }

        private void PartyWiped(string a_Message, object a_Param)
        {
            Party<float> BroadcastParty = a_Param as Party<float>;

            m_GameControllerFSM.Transition(GameControllerState.END);
            Console.WriteLine(BroadcastParty.name + " has been wiped out!");
        }

        private void SetFSM()
        {
            m_GameControllerFSM.AddTransition(GameControllerState.INIT, GameControllerState.IDLE);
            m_GameControllerFSM.AddTransition(GameControllerState.IDLE, GameControllerState.PLAYER_TURN);
            m_GameControllerFSM.AddTransition(GameControllerState.PLAYER_TURN, GameControllerState.ENEMY_TURN);
            m_GameControllerFSM.AddTransition(GameControllerState.ENEMY_TURN, GameControllerState.PLAYER_TURN);
            m_GameControllerFSM.AddTransition(GameControllerState.PLAYER_TURN, GameControllerState.END);
            m_GameControllerFSM.AddTransition(GameControllerState.ENEMY_TURN, GameControllerState.END);

            m_GameControllerFSM.Transition(GameControllerState.IDLE);
            m_GameControllerFSM.Transition(GameControllerState.PLAYER_TURN);

            Publisher.self.Broadcast("Player Turn", null);
        }
    }
}
