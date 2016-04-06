using System;
using System.Collections.Generic;

using BennyBroseph;

namespace Combat
{
    [Serializable]
    public class Player
    {
        private Party<float> m_Party;

        public Party<float> party { get { return m_Party; } set { m_Party = value; } }

        public Player()
        {
            m_Party = new Party<float>(
                "Player",
                new List<Unit<float>>
                {
                    new Unit<float>(
                        "Charizard",
                        "Smokey",                       
                        new Stats<float>(210, 45, new StatType<float>(50, 30), new StatType<float>(50, 20)),
                        new List<Ability<float>>()
                        {
                            new Ability<float>(Abilities.s_Slash),
                            new Ability<float>(Abilities.s_FlameThrower),
                        }),
                     new Unit<float>(
                        "Blastoise",
                        "Roy",
                        new Stats<float>(180, 50, new StatType<float>(30, 50), new StatType<float>(50, 20)),
                        new List<Ability<float>>()
                        {
                            new Ability<float>(Abilities.s_Slash),
                            new Ability<float>(Abilities.s_Surf),
                            new Ability<float>(Abilities.s_WaterGun),
                        }),
                     new Unit<float>(
                        "Venusaur",
                        "Alan",
                        new Stats<float>(180, 50, new StatType<float>(30, 50), new StatType<float>(50, 20)),
                        new List<Ability<float>>()
                        {
                            new Ability<float>(Abilities.s_Slash),
                        }),
                });

            Publisher.self.Subscribe("Player Turn", MyTurn);
            Publisher.self.Subscribe("Player Used Ability", UseAbility);
            Publisher.self.Subscribe("Unit Health Changed", UnitHealthChanged);

            GameController.self.AddParty(m_Party);
        }

        private void MyTurn(string a_Message, object a_Param)
        {
            m_Party.partyFSM.Transition(PartyState.TAKING_TURN);
        }

        private void UseAbility(string a_Message, object a_Param)
        {
            int BroadcastIndex = (int)a_Param;

            if (m_Party.partyFSM.currentState == PartyState.TAKING_TURN)
            {
                try
                {
                    m_Party.currentUnit.abilities[BroadcastIndex].action(BroadcastIndex);
                    m_Party.partyFSM.Transition(PartyState.IDLE);

                    Publisher.self.Broadcast("Player End Turn", null);
                }
                catch { }
            }
        }

        private void UnitHealthChanged(string a_Message, object a_Param)
        {
            Unit<float> BroadcastUnit = a_Param as Unit<float>;

            if (BroadcastUnit.GetHashCode() == m_Party.currentUnit.GetHashCode())
            {
                if (BroadcastUnit.health < 0)
                {
                    m_Party.currentUnit.health = 0;

                    Publisher.self.Broadcast("Unit Died", m_Party.currentUnit);
                    m_Party.AutoSwitchCurrentUnit();
                }
            }
        }
    }
}
