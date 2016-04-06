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
                        new Stats<float>(153, 120, new StatType<float>(104, 129), new StatType<float>(98, 105)),
                        50,
                        new List<Ability<float>>()
                        {
                            new Ability<float>(Abilities.s_Slash),
                            new Ability<float>(Abilities.s_FlameThrower),
                        }),
                     new Unit<float>(
                        "Blastoise",
                        "Roy",
                        new Stats<float>(154, 98, new StatType<float>(103, 105), new StatType<float>(120, 125)),
                        50,
                        new List<Ability<float>>()
                        {
                            new Ability<float>(Abilities.s_Slash),
                            new Ability<float>(Abilities.s_Surf),
                            new Ability<float>(Abilities.s_WaterGun),
                        }),
                     new Unit<float>(
                        "Venusaur",
                        "Alan",
                        new Stats<float>(155, 100, new StatType<float>(102, 120), new StatType<float>(103, 136)),
                        50,
                        new List<Ability<float>>()
                        {
                            new Ability<float>(Abilities.s_Slash),
                            new Ability<float>(Abilities.s_EnergyBall),
                            new Ability<float>(Abilities.s_NastyPlot),
                        }),
                });

            Publisher.self.Subscribe("Player Turn", MyTurn);
            Publisher.self.Subscribe("Player Used Ability", UseAbility);
            Publisher.self.Subscribe("Unit Health Changed", UnitHealthChanged);

            GameController.self.AddParty(m_Party);

            Publisher.self.Subscribe("Player Load", Load);
        }

        private void Load(string a_Message, object a_Param)
        {
            m_Party = GameController.self.parties[0];
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
                    GameController.self.AddToCombatLog("Player's Turn");
                    if (m_Party.currentUnit.abilities[BroadcastIndex].uses > 0)
                    {
                        m_Party.currentUnit.abilities[BroadcastIndex].action(BroadcastIndex);
                        m_Party.partyFSM.Transition(PartyState.IDLE);

                        Publisher.self.Broadcast("Player End Turn", null);
                    }
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
