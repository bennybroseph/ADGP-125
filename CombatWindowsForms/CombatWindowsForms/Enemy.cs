using System.Collections.Generic;

using BennyBroseph;

namespace Combat
{
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
                        new Stats<float>(210, 45, new StatType<float>(50, 30), new StatType<float>(50, 20)),
                        new List<Ability<float>>()
                        {
                            new Ability<float>(Abilities.s_FlameWheel),
                            new Ability<float>(Abilities.s_FlameThrower),
                        }),
                     new Unit<float>(
                        "Feraligatr",
                        "Alex",
                        new Stats<float>(180, 50, new StatType<float>(30, 50), new StatType<float>(50, 20)),
                        new List<Ability<float>>()
                        {
                            new Ability<float>(Abilities.s_Slash),
                        }),
                });  

            Publisher.self.Subscribe("Enemy Turn", UseAbility);
            Publisher.self.Subscribe("Unit Health Changed", UnitHealthChanged);

            GameController.self.AddParty(m_Party);
        }

        private void UseAbility(string a_Message, object a_Param)
        {
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
                    m_Party.currentUnit.health = 0;
            }
        }
    }
}
