using System.Collections.Generic;

using BennyBroseph;

namespace Combat
{
    public class Player
    {
        private Party<float> m_Party;

        public Party<float> party { get { return m_Party; } set { m_Party = value; } }

        public Player()
        {
            m_Party = new Party<float>(
                new List<Unit<float>>
                {
                    new Unit<float>(
                        "Charizard",
                        "Smokey",
                        new Stats<float>(10, 5, new StatType<float>(5, 3), new StatType<float>(5, 2)),
                        new List<Ability<float>>()
                        {
                            new Ability<float>(Abilities.s_Slash),
                            new Ability<float>(Abilities.s_FlameThrower),
                        }),
                     new Unit<float>(
                        "Blastoise",
                        "Roy",
                        new Stats<float>(10, 5, new StatType<float>(5, 3), new StatType<float>(5, 2)),
                        new List<Ability<float>>()
                        {
                            new Ability<float>(Abilities.s_Slash),
                        }),
                });

            Controller.self.AddParty(m_Party);

            Publisher.self.Subscribe("Player Used Ability", UseAbility);
        }

        private void UseAbility(string a_Message, object a_Param)
        {
            int BroadcastIndex = (int)a_Param;
            
            if(m_Party.partyFSM.currentState == PartyState.TAKING_TURN)
            {
                m_Party.currentUnit.abilities[BroadcastIndex].action(BroadcastIndex);
            }
        }
    }
}
