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
            delegate(int a_AbilityIndex) 
            {
                Controller.self.currentTargetParty.currentUnit.health -= s_Struggle.power[0];
                Controller.self.currentParty.currentUnit.health -= s_Struggle.power[1];
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
            delegate (int a_AbilityIndex)
            {
                Controller.self.currentTargetParty.currentUnit.health -= s_FlameThrower.power[0];

                var temp = Controller.self.currentParty.currentUnit.abilities[a_AbilityIndex];
                temp.uses--;
                Controller.self.currentParty.currentUnit.abilities[a_AbilityIndex] = temp;
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
            delegate (int a_AbilityIndex)
            {
                Controller.self.currentTargetParty.currentUnit.health -= s_Slash.power[0];

                var temp = Controller.self.currentParty.currentUnit.abilities[a_AbilityIndex];
                temp.uses--;
                Controller.self.currentParty.currentUnit.abilities[a_AbilityIndex] = temp;
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
            delegate (int a_AbilityIndex)
            {
                Controller.self.currentParty.currentUnit.attack = new StatType<float>(
                    Controller.self.currentParty.currentUnit.attack.physical, 
                    Controller.self.currentParty.currentUnit.attack.special * 1.5f);

                var temp = Controller.self.currentParty.currentUnit.abilities[a_AbilityIndex];
                temp.uses--;
                Controller.self.currentParty.currentUnit.abilities[a_AbilityIndex] = temp;
            });
    }
}
