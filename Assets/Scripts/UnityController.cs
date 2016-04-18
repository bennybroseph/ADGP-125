using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

using Combat;

using BennyBroseph;
using BennyBroseph.Contextual;

public class UnityController : MonoBehaviour
{
    private Player m_Player;
    private Enemy m_Enemy;

    private Texture2D m_PlayerSprite;
    private Texture2D m_EnemySprite;

    private Texture2D m_PlayerHealthBar;
    private Texture2D m_EnemyHealthBar;

    [SerializeField]
    private Text m_CombatLog;

    // Use this for initialization
    void Start()
    {
        m_Player = new Player();
        m_Enemy = new Enemy();

        m_PlayerHealthBar = new Texture2D(1, 1);
        m_PlayerHealthBar.Resize(375, 50);
        m_PlayerHealthBar.Apply();

        m_EnemyHealthBar = new Texture2D(1, 1);
        m_EnemyHealthBar.Resize(375, 50);
        m_EnemyHealthBar.Apply();

        Publisher.self.Subscribe("Unit Health Changed", UnitHealthChanged);
        Publisher.self.Subscribe("Ability Uses Changed", AbilityUsesChanged);
        Publisher.self.Subscribe("Party Current Unit Switched", BuildUI);
        Publisher.self.Subscribe("Player Load", BuildUI);
        Publisher.self.Subscribe("Player Load", LoadCombatLog);
        Publisher.self.Subscribe("Combat Log Updated", UpdateCombatLog);

        BuildUI(null, null);
        Publisher.self.Broadcast("Player Used Ability", 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnGUI()
    {
        GUI.color = new Color(0, 1, 0.25f, 1);
        GUI.DrawTexture(new Rect(25, 25, m_PlayerHealthBar.width, m_PlayerHealthBar.height), m_PlayerHealthBar);
        GUI.DrawTexture(new Rect(Screen.width - m_EnemyHealthBar.width - 25, Screen.height - m_EnemyHealthBar.height - 225, m_EnemyHealthBar.width, m_EnemyHealthBar.height), m_EnemyHealthBar);

        GUI.color = Color.white;
        GUI.DrawTexture(new Rect(150, 100, m_PlayerSprite.width, m_PlayerSprite.height), m_PlayerSprite);
        GUI.DrawTexture(new Rect(Screen.width - 250, Screen.height - 150, m_EnemySprite.width, m_EnemySprite.height), m_EnemySprite);
    }

    private void BuildUI(string a_Message, object a_Param)
    {
        m_PlayerSprite = Resources.Load("Images/" + m_Player.party.currentUnit.name + "_Mirror") as Texture2D;
        m_EnemySprite = Resources.Load("Images/" + m_Enemy.party.currentUnit.name) as Texture2D;
        LoadCombatLog(null, null);
    }

    private void UnitHealthChanged(string a_Message, object a_Param)
    {
        Unit<float> BroadcastUnit = a_Param as Unit<float>;

        if (BroadcastUnit.GetHashCode() == m_Player.party.currentUnit.GetHashCode() && BroadcastUnit.maxHealth > 0)
        {
            m_PlayerHealthBar.width = (int)((BroadcastUnit.health / BroadcastUnit.maxHealth) * 100.0f);
        }
        if (BroadcastUnit.GetHashCode() == m_Enemy.party.currentUnit.GetHashCode() && BroadcastUnit.maxHealth > 0)
        {
            m_EnemyHealthBar.width = (int)((BroadcastUnit.health / BroadcastUnit.maxHealth) * 100.0f);
        }
    }

    private void AbilityUsesChanged(string a_Message, object a_Param)
    {
        Ability<float> BroadcastAbility = (Ability<float>)a_Param;

        //try
        //{
        //    if (BroadcastAbility.GetHashCode() == m_Player.party.currentUnit.abilities[0].GetHashCode())
        //        playerMove1.Text = BroadcastAbility.uses.ToString() + "/" + BroadcastAbility.maxUses.ToString();

        //    if (BroadcastAbility.GetHashCode() == m_Player.party.currentUnit.abilities[1].GetHashCode())
        //        playerMove2.Text = BroadcastAbility.uses.ToString() + "/" + BroadcastAbility.maxUses.ToString();

        //    if (BroadcastAbility.GetHashCode() == m_Player.party.currentUnit.abilities[2].GetHashCode())
        //        playerMove3.Text = BroadcastAbility.uses.ToString() + "/" + BroadcastAbility.maxUses.ToString();

        //    if (BroadcastAbility.GetHashCode() == m_Player.party.currentUnit.abilities[3].GetHashCode())
        //        playerMove4.Text = BroadcastAbility.uses.ToString() + "/" + BroadcastAbility.maxUses.ToString();
        //}
        //catch { }
    }

    private void LoadCombatLog(string a_Message, object a_Param)
    {
        string TempText = null;

        foreach (string Text in GameController.self.combatLog)
            TempText += Text;

        m_CombatLog.text = TempText;
    }
    private void UpdateCombatLog(string a_Message, object a_Param)
    {
        string BroadcastLog = a_Param as string;

        m_CombatLog.text += BroadcastLog;
    }
}
