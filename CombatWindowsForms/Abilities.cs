using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat
{
    static public class Abilities
    {
        static public void BasicDealDamage(float a_AttackStat, float a_DefenseStat, Ability<float> a_Ability)
        {
            Unit<float> Attacker = GameController.self.currentParty.currentUnit;
            Unit<float> Defender = GameController.self.currentTargetParty.currentUnit;

            float Damage = (((((2 * Attacker.level / 2 + 5) * a_AttackStat * a_Ability.power[0]) / a_DefenseStat) / 50) + 2);

            GameController.self.AddToCombatLog(GameController.self.currentParty.currentUnit.nickname + " dealt " + ((int)Damage).ToString() + " damage to " + GameController.self.currentTargetParty.currentUnit.nickname);
            GameController.self.currentTargetParty.currentUnit.health -= Damage;           
        }

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
            "The target is scorched with an intense blast of fire",
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
                90.0f,
            },
            new List<float>()
            {
                100.0f,
            },
            15.0f,
            delegate (int a_AbilityIndex)
            {
                BasicDealDamage(
                    GameController.self.currentParty.currentUnit.attack.special,
                    GameController.self.currentTargetParty.currentUnit.defense.special,
                    GameController.self.currentParty.currentUnit.abilities[a_AbilityIndex]);

                GameController.self.currentParty.currentUnit.abilities[a_AbilityIndex].uses--;
            });
        static public Ability<float> s_FlameWheel = new Ability<float>(
            "Flame Wheel",
            "The user cloaks itself in fire and charges at the target",
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
                60.0f,
            },
            new List<float>()
            {
                100.0f,
            },
            25.0f,
            delegate (int a_AbilityIndex)
            {
                BasicDealDamage(
                    GameController.self.currentParty.currentUnit.attack.physical,
                    GameController.self.currentTargetParty.currentUnit.defense.physical,
                    GameController.self.currentParty.currentUnit.abilities[a_AbilityIndex]);

                GameController.self.currentParty.currentUnit.abilities[a_AbilityIndex].uses--;
            });
        static public Ability<float> s_Surf = new Ability<float>(
            "Surf",
            "The user attacks everything around it by swamping its surroundings with a giant wave",
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
                90.0f,
            },
            new List<float>()
            {
                100.0f,
            },
            15.0f,
            delegate (int a_AbilityIndex)
            {
                BasicDealDamage(
                    GameController.self.currentParty.currentUnit.attack.special,
                    GameController.self.currentTargetParty.currentUnit.defense.special,
                    GameController.self.currentParty.currentUnit.abilities[a_AbilityIndex]);

                GameController.self.currentParty.currentUnit.abilities[a_AbilityIndex].uses--;
            });
        static public Ability<float> s_WaterGun = new Ability<float>(
            "Water Gun",
            "The target is blasted with a forceful shot of water",
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
                40.0f,
            },
            new List<float>()
            {
                100.0f,
            },
            25.0f,
            delegate (int a_AbilityIndex)
            {
                BasicDealDamage(
                    GameController.self.currentParty.currentUnit.attack.special,
                    GameController.self.currentTargetParty.currentUnit.defense.special,
                    GameController.self.currentParty.currentUnit.abilities[a_AbilityIndex]);

                GameController.self.currentParty.currentUnit.abilities[a_AbilityIndex].uses--;
            });
        static public Ability<float> s_LeafBlade = new Ability<float>(
            "Leaf Blade",
            "The user handles a sharp leaf like a sword and attacks by cutting its target",
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
                90.0f,
            },
            new List<float>()
            {
                100.0f,
            },
            15.0f,
            delegate (int a_AbilityIndex)
            {
                BasicDealDamage(
                    GameController.self.currentParty.currentUnit.attack.physical,
                    GameController.self.currentTargetParty.currentUnit.defense.physical,
                    GameController.self.currentParty.currentUnit.abilities[a_AbilityIndex]);

                GameController.self.currentParty.currentUnit.abilities[a_AbilityIndex].uses--;
            });
        static public Ability<float> s_EnergyBall = new Ability<float>(
            "Energy Ball",
            "The user draws power from nature and fires it at the target",
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
                90.0f,
            },
            new List<float>()
            {
                100.0f,
            },
            15.0f,
            delegate (int a_AbilityIndex)
            {
                BasicDealDamage(
                    GameController.self.currentParty.currentUnit.attack.special,
                    GameController.self.currentTargetParty.currentUnit.defense.special,
                    GameController.self.currentParty.currentUnit.abilities[a_AbilityIndex]);

                GameController.self.currentParty.currentUnit.abilities[a_AbilityIndex].uses--;
            });
        static public Ability<float> s_Slash = new Ability<float>(
            "Slash",
            "The target is attacked with a slash of claws or blades",
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
                70.0f,
            },
            new List<float>()
            {
                100.0f,
            },
            20.0f,
            delegate (int a_AbilityIndex)
            {
                BasicDealDamage(
                    GameController.self.currentParty.currentUnit.attack.physical,
                    GameController.self.currentTargetParty.currentUnit.defense.physical,
                    GameController.self.currentParty.currentUnit.abilities[a_AbilityIndex]);

                GameController.self.currentParty.currentUnit.abilities[a_AbilityIndex].uses--;
            });
        static public Ability<float> s_SwordDance = new Ability<float>(
            "Sword Dance",
            "Greatly increases the user's Physical Attack",
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
                    GameController.self.currentParty.currentUnit.attack.physical * 1.5f,
                    GameController.self.currentParty.currentUnit.attack.special);

                GameController.self.AddToCombatLog(GameController.self.currentParty.currentUnit.nickname + " raised its Attack Power to " + ((int)GameController.self.currentParty.currentUnit.attack.physical).ToString());
                GameController.self.currentParty.currentUnit.abilities[a_AbilityIndex].uses--;
            });
        static public Ability<float> s_NastyPlot = new Ability<float>(
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

                GameController.self.AddToCombatLog(GameController.self.currentParty.currentUnit.nickname + " raised its Special Attack Power to " + ((int)GameController.self.currentParty.currentUnit.attack.special).ToString());
                GameController.self.currentParty.currentUnit.abilities[a_AbilityIndex].uses--;
            });
    }
}
