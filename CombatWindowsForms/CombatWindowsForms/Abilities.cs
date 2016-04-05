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
            delegate (int a_AbilityIndex)
            {
                GameController.self.currentTargetParty.currentUnit.health -= s_Struggle.power[0];
                GameController.self.currentParty.currentUnit.health -= s_Struggle.power[1];
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
                GameController.self.currentTargetParty.currentUnit.health -= s_FlameThrower.power[0];

                GameController.self.currentParty.currentUnit.abilities[a_AbilityIndex].uses--;
            });
        static public Ability<float> s_Surf = new Ability<float>(
            "Surf",
            "Heavy waves crash into the enemy at high speed",
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
                GameController.self.currentTargetParty.currentUnit.health -= s_Surf.power[0];

                GameController.self.currentParty.currentUnit.abilities[a_AbilityIndex].uses--;
            });
        static public Ability<float> s_FlameWheel = new Ability<float>(
            "Flame-wheel",
            "Covers the user in flames before executing a burning tackle",
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
                GameController.self.currentTargetParty.currentUnit.health -= s_FlameWheel.power[0];

                GameController.self.currentParty.currentUnit.abilities[a_AbilityIndex].uses--;
            });
        static public Ability<float> s_Slash = new Ability<float>(
            "Slash",
            "Rips into the enemy's flesh with sharp claws",
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
                GameController.self.currentTargetParty.currentUnit.health -= s_Slash.power[0];

                GameController.self.currentParty.currentUnit.abilities[a_AbilityIndex].uses--;
            });
        static public Ability<float> s_SwordDance = new Ability<float>(
            "Nasty Plot",
            "Greatly increases the user's Special Attack",
            new List<AbilityType>()
            {
                AbilityType.BUFF,
            },
            new List<Recipient>()
            {
                Recipient.SELF,
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
                GameController.self.currentParty.currentUnit.attack = new StatType<float>(
                    GameController.self.currentParty.currentUnit.attack.physical,
                    GameController.self.currentParty.currentUnit.attack.special * 1.5f);

                GameController.self.currentParty.currentUnit.abilities[a_AbilityIndex].uses--;
            });
    }
}
