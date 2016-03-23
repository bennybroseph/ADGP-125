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
            delegate(ref List<List<Unit<float>>> a_Parties, ref ICombatable<float> a_Target, ref ICombatable<float> a_Self, ref Ability<float> a_Ability) 
            {
                a_Target.health -= s_Struggle.power[0];
                a_Self.health -= s_Struggle.power[1];
            });

        static public Ability<float> s_FlameThrower = new Ability<float>(
            "Flamethrower",
            "Bathes the enemy in flames",
            new List<AbilityType>()
            {
                AbilityType.OFFENSIVE,
            },
            new List<Recipient>()
            {
                Recipient.TARGET,
            },
            new List<float>()
            {
                75.0f,
            },
            new List<float>()
            {
                100.0f,
            },
            15.0f,
            delegate (ref List<List<Unit<float>>> a_Parties, ref ICombatable<float> a_Target, ref ICombatable<float> a_Self, ref Ability<float> a_Ability)
            {
                a_Target.health -= s_FlameThrower.power[0];
                a_Ability.uses--;
            });
        static public Ability<float> s_Slash = new Ability<float>(
            "Slash",
            "Rips into the enemies flesh with sharp claws",
            new List<AbilityType>()
            {
                AbilityType.OFFENSIVE,
            },
            new List<Recipient>()
            {
                Recipient.TARGET,
            },
            new List<float>()
            {
                75.0f,
            },
            new List<float>()
            {
                100.0f,
            },
            15.0f,
            delegate (ref List<List<Unit<float>>> a_Parties, ref ICombatable<float> a_Target, ref ICombatable<float> a_Self, ref Ability<float> a_Ability)
            {
                a_Target.health -= s_FlameThrower.power[0];
                a_Ability.uses--;
            });
        static public Ability<float> s_SwordDance = new Ability<float>(
            "Nasty Plot",
            "Greatly increases the user's Special Attack",
            new List<AbilityType>()
            {
                AbilityType.OFFENSIVE,
            },
            new List<Recipient>()
            {
                Recipient.TARGET,
            },
            new List<float>()
            {
                75.0f,
            },
            new List<float>()
            {
                100.0f,
            },
            15.0f,
            delegate (ref List<List<Unit<float>>> a_Parties, ref ICombatable<float> a_Target, ref ICombatable<float> a_Self, ref Ability<float> a_Ability)
            {
                float phys = a_Self.attack.physical;
                float specialAtt = a_Self.attack.special * 1.5f;
                StatType<float> st = new StatType<float>(0, phys);
                a_Self.attack = st;

                a_Self.attack = new StatType<float>(a_Self.attack.physical, a_Self.attack.special * 1.5f);
                
                //a_Self.attack.special *= 1.5f;
                
                
                a_Ability.uses--;
            });
    }
}
