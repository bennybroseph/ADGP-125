using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat
{
    public class Player
    {
        private List<Unit<float>> m_Party;

        public List<Unit<float>> party { get { return m_Party; } set { m_Party = value; } }

        public Player()
        {
            m_Party = new List<Unit<float>>()
            {
                new Unit<float>(
                    new Stats<float>(10, 5, new StatType<float>(5, 3), new StatType<float>(5, 2)),
                    new List<Ability<float>>()
                    {
                        new Ability<float>(Abilities.s_Slash),
                        new Ability<float>(Abilities.s_FlameThrower),
                    })
            };

            Controller.self.AddParty(m_Party);
        }
    }
}
