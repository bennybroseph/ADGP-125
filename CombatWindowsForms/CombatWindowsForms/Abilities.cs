using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat
{
    static public class Abilities
    {
        static public Ability<float> s_Struggle = new Ability<float>(
            "Struggle",
            "Flails wildly at the enemy. Takes a damage in return",
            new List<AbilityType>()
            {
                AbilityType.OFFENSIVE,
                AbilityType.OFFENSIVE,
            },
            new List<Recipient>()
            {
                Recipient.TARGET,
                Recipient.SELF,
            },
            new List<float>()
            {
                50.0f,
                50.0f,
            },
            new List<float>()
            {
                100.0f,
                100.0f,
            },
            -404.0f,
            delegate(ref List<List<ICombatable<float>>> a_Parties, ref ICombatable<float> a_Target, ref ICombatable<float> a_Self) 
            {
                foreach(List<ICombatable<float>> Party in a_Parties)
                {
                    foreach(ICombatable<float> Other in Party)
                    {
                        if (Other.GetHashCode() != a_Self.GetHashCode())
                            ;
                    }
                }
            });
    }
}
