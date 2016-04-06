using System;
using System.Collections.Generic;

using BennyBroseph;

namespace Combat
{
    [Serializable]
    public class Enemy
    {
        private Party<float> m_Party;

        public Party<float> party { get { return m_Party; } set { m_Party = value; } }

        public Enemy()
        {
            m_Party = new Party<float>(
                "Enemy",
                new List<Unit<float>>
                {                    
                    new Unit<float>(
                        "Typhlosion",
                        "Rex",
                        new Stats<float>(153, 120, new StatType<float>(104, 129), new StatType<float>(98, 105)),
                        50,
                        new List<Ability<float>>()
                        {
                            new Ability<float>(Abilities.s_FlameWheel),
                            new Ability<float>(Abilities.s_FlameThrower),
                        }),
                     new Unit<float>(
                        "Feraligatr",
                        "Crunch",
                        new Stats<float>(160, 98, new StatType<float>(125, 99), new StatType<float>(120, 103)),
                        50,
                        new List<Ability<float>>()
                        {
                            new Ability<float>(Abilities.s_Slash),
                            new Ability<float>(Abilities.s_WaterGun),
                        }),
                     new Unit<float>(
                        "Meganium",
                        "Jenny",
                        new Stats<float>(155, 100, new StatType<float>(102, 103), new StatType<float>(120, 120)),
                        50,
                        new List<Ability<float>>()
                        {
                            new Ability<float>(Abilities.s_LeafBlade),
                        }),
                });  
            Publisher.self.Subscribe("Enemy Turn", UseAbility);
            Publisher.self.Subscribe("Unit Health Changed", UnitHealthChanged);

            GameController.self.AddParty(m_Party);

            Publisher.self.Subscribe("Player Load", Load);
        }

        private void Load(string a_Message, object a_Param)
        {
            m_Party = GameController.self.parties[1];
        }

        private void UseAbility(string a_Message, object a_Param)
        {
            GameController.self.AddToCombatLog("Enemy's Turn");
            m_Party.partyFSM.Transition(PartyState.TAKING_TURN);
            if (m_Party.partyFSM.currentState == PartyState.TAKING_TURN)
            {
                m_Party.currentUnit.abilities[0].action(0);
                m_Party.partyFSM.Transition(PartyState.IDLE);

                Publisher.self.Broadcast("Enemy End Turn", null);
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
