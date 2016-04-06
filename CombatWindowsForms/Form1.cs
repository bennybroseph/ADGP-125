using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;

using Combat;

using BennyBroseph;
using BennyBroseph.Contextual;
using MyKeys = BennyBroseph.Contextual.Keys;

namespace CombatWindowsForms
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        Player m_Player;
        List<ToolTip> m_PlayerToolTips;

        Enemy m_Enemy;
        List<ToolTip> m_EnemyToolTips;

        public Form1()
        {
            InitializeComponent();

            AllocConsole();

            m_Player = new Player();
            m_PlayerToolTips = new List<ToolTip>();
            for (int i = 0; i < 4; ++i)
                m_PlayerToolTips.Add(new ToolTip());

            m_Enemy = new Enemy();
            m_EnemyToolTips = new List<ToolTip>();
            for (int i = 0; i < 4; ++i)
                m_EnemyToolTips.Add(new ToolTip());

            InputManager.self.Init(this);
            InputManager.self.AddOnKeyDown(OnKeyDown);

            Publisher.self.Subscribe("Unit Health Changed", UnitHealthChanged);
            Publisher.self.Subscribe("Ability Uses Changed", AbilityUsesChanged);
            Publisher.self.Subscribe("Party Current Unit Switched", BuildUI);
            Publisher.self.Subscribe("Player Load", BuildUI);
            Publisher.self.Subscribe("Player Load", LoadCombatLog);
            Publisher.self.Subscribe("Combat Log Updated", UpdateCombatLog);

            BuildUI(null, null);
        }

        private void BuildUI(string a_Message, object a_Param)
        {
            playerName.Text = "Lvl." + m_Player.party.currentUnit.level.ToString() + "  " + m_Player.party.currentUnit.name + "  '" + m_Player.party.currentUnit.nickname + "'";
            enemyName.Text = "Lvl." + m_Enemy.party.currentUnit.level.ToString() + "  " + m_Enemy.party.currentUnit.name + "  '" + m_Enemy.party.currentUnit.nickname + "'";

            playerStats.Text =
                "Max Health: " + m_Player.party.currentUnit.maxHealth + Environment.NewLine +
                Environment.NewLine +
                "Attack: " + m_Player.party.currentUnit.maxAttack.physical + Environment.NewLine +
                "Sp. Attack: " + m_Player.party.currentUnit.maxAttack.special + Environment.NewLine +
                Environment.NewLine +
                "Defense: " + m_Player.party.currentUnit.maxDefense.physical + Environment.NewLine +
                "Sp. Defense: " + m_Player.party.currentUnit.maxDefense.special + Environment.NewLine +
                Environment.NewLine +
                "Speed: " + m_Player.party.currentUnit.speed;

            enemyStats.Text =
                "Max Health: " + m_Enemy.party.currentUnit.maxHealth + Environment.NewLine +
                Environment.NewLine +
                "Attack: " + m_Enemy.party.currentUnit.maxAttack.physical + Environment.NewLine +
                "Sp. Attack: " + m_Enemy.party.currentUnit.maxAttack.special + Environment.NewLine +
                Environment.NewLine +
                "Defense: " + m_Enemy.party.currentUnit.maxDefense.physical + Environment.NewLine +
                "Sp. Defense: " + m_Enemy.party.currentUnit.maxDefense.special + Environment.NewLine +
                Environment.NewLine +
                "Speed: " + m_Enemy.party.currentUnit.speed;

            
            playerUnitIndicator1.Checked = (m_Player.party.currentUnitIndex == 0) ? true : false;
            playerUnitIndicator2.Checked = (m_Player.party.currentUnitIndex == 1) ? true : false;
            playerUnitIndicator3.Checked = (m_Player.party.currentUnitIndex == 2) ? true : false;
            playerUnitIndicator4.Checked = (m_Player.party.currentUnitIndex == 3) ? true : false;
            playerUnitIndicator5.Checked = (m_Player.party.currentUnitIndex == 4) ? true : false;
            playerUnitIndicator6.Checked = (m_Player.party.currentUnitIndex == 5) ? true : false;

            enemyUnitIndicator1.Checked = (m_Enemy.party.currentUnitIndex == 0) ? true : false;
            enemyUnitIndicator2.Checked = (m_Enemy.party.currentUnitIndex == 1) ? true : false;
            enemyUnitIndicator3.Checked = (m_Enemy.party.currentUnitIndex == 2) ? true : false;
            enemyUnitIndicator4.Checked = (m_Enemy.party.currentUnitIndex == 3) ? true : false;
            enemyUnitIndicator5.Checked = (m_Enemy.party.currentUnitIndex == 4) ? true : false;
            enemyUnitIndicator6.Checked = (m_Enemy.party.currentUnitIndex == 5) ? true : false;

            try
            {
                playerButtonMove1.Text = m_Player.party.currentUnit.abilities[0].name;
                playerButtonMove2.Text = m_Player.party.currentUnit.abilities[1].name;
                playerButtonMove3.Text = m_Player.party.currentUnit.abilities[2].name;
                playerButtonMove4.Text = m_Player.party.currentUnit.abilities[3].name;
            }
            catch { }
            try
            {
                playerMove1.Text = null;
                playerMove1.Text = m_Player.party.currentUnit.abilities[0].uses.ToString() + "/" + m_Player.party.currentUnit.abilities[0].maxUses.ToString();
                playerMove2.Text = null;
                playerMove2.Text = m_Player.party.currentUnit.abilities[1].uses.ToString() + "/" + m_Player.party.currentUnit.abilities[1].maxUses.ToString();
                playerMove3.Text = null;
                playerMove3.Text = m_Player.party.currentUnit.abilities[2].uses.ToString() + "/" + m_Player.party.currentUnit.abilities[2].maxUses.ToString();
                playerMove4.Text = null;
                playerMove4.Text = m_Player.party.currentUnit.abilities[3].uses.ToString() + "/" + m_Player.party.currentUnit.abilities[3].maxUses.ToString();
            }
            catch { }
            try
            {
                enemyMove1.Text = null;
                enemyMove1.Text = m_Enemy.party.currentUnit.abilities[0].name;
                enemyMove2.Text = null;
                enemyMove2.Text = m_Enemy.party.currentUnit.abilities[1].name;
                enemyMove3.Text = null;
                enemyMove3.Text = m_Enemy.party.currentUnit.abilities[2].name;
                enemyMove4.Text = null;
                enemyMove4.Text = m_Enemy.party.currentUnit.abilities[3].name;
            }
            catch { }
            try
            {
                m_PlayerToolTips[0].SetToolTip(playerButtonMove1, m_Player.party.currentUnit.abilities[0].description);
                m_PlayerToolTips[1].SetToolTip(playerButtonMove2, m_Player.party.currentUnit.abilities[1].description);
                m_PlayerToolTips[2].SetToolTip(playerButtonMove3, m_Player.party.currentUnit.abilities[2].description);
                m_PlayerToolTips[3].SetToolTip(playerButtonMove4, m_Player.party.currentUnit.abilities[3].description);
            }
            catch { }
            try
            {
                m_EnemyToolTips[0].SetToolTip(enemyMove1, m_Enemy.party.currentUnit.abilities[0].description);
                m_EnemyToolTips[1].SetToolTip(enemyMove2, m_Enemy.party.currentUnit.abilities[1].description);
                m_EnemyToolTips[2].SetToolTip(enemyMove3, m_Enemy.party.currentUnit.abilities[2].description);
                m_EnemyToolTips[3].SetToolTip(enemyMove4, m_Enemy.party.currentUnit.abilities[3].description);
            }
            catch { }

            try
            {
                playerHealthBar.Value = (int)((m_Player.party.currentUnit.health / m_Player.party.currentUnit.maxHealth) * 100.0f);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                enemyHealthBar.Value = (int)((m_Enemy.party.currentUnit.health / m_Enemy.party.currentUnit.maxHealth) * 100.0f);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                playerSprite.Image = new System.Drawing.Bitmap(m_Player.party.currentUnit.imagePath + "_Mirror.gif");
            }
            catch { }
            try
            {
                enemySprite.Image = new System.Drawing.Bitmap(m_Enemy.party.currentUnit.imagePath + ".gif");
            }
            catch { }
        }

        private void UnitHealthChanged(string a_Message, object a_Param)
        {
            Unit<float> BroadcastUnit = a_Param as Unit<float>;

            if (BroadcastUnit.GetHashCode() == m_Player.party.currentUnit.GetHashCode() && BroadcastUnit.maxHealth > 0)
            {
                try
                {
                    playerHealthBar.Value = (int)((BroadcastUnit.health / BroadcastUnit.maxHealth) * 100.0f);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (BroadcastUnit.GetHashCode() == m_Enemy.party.currentUnit.GetHashCode() && BroadcastUnit.maxHealth > 0)
            {
                try
                {
                    enemyHealthBar.Value = (int)((BroadcastUnit.health / BroadcastUnit.maxHealth) * 100.0f);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void AbilityUsesChanged(string a_Message, object a_Param)
        {
            Ability<float> BroadcastAbility = (Ability<float>)a_Param;

            try
            {
                if (BroadcastAbility.GetHashCode() == m_Player.party.currentUnit.abilities[0].GetHashCode())
                    playerMove1.Text = BroadcastAbility.uses.ToString() + "/" + BroadcastAbility.maxUses.ToString();

                if (BroadcastAbility.GetHashCode() == m_Player.party.currentUnit.abilities[1].GetHashCode())
                    playerMove2.Text = BroadcastAbility.uses.ToString() + "/" + BroadcastAbility.maxUses.ToString();

                if (BroadcastAbility.GetHashCode() == m_Player.party.currentUnit.abilities[2].GetHashCode())
                    playerMove3.Text = BroadcastAbility.uses.ToString() + "/" + BroadcastAbility.maxUses.ToString();

                if (BroadcastAbility.GetHashCode() == m_Player.party.currentUnit.abilities[3].GetHashCode())
                    playerMove4.Text = BroadcastAbility.uses.ToString() + "/" + BroadcastAbility.maxUses.ToString();
            }
            catch { }
        }

        private void LoadCombatLog(string a_Message, object a_Param)
        {
            string TempText = null;

            foreach (string Text in GameController.self.combatLog)
                TempText += Text;

            combatLogBox.Text = TempText;
        }
        private void UpdateCombatLog(string a_Message, object a_Param)
        {
            string BroadcastLog = a_Param as string;

            combatLogBox.AppendText(BroadcastLog);
        }

        private void OnKeyDown(MyKeys a_Key)
        {
            Console.WriteLine(a_Key);
        }

        private void playerButtonMove1_Click(object sender, EventArgs e)
        {
            Publisher.self.Broadcast("Player Used Ability", 0);
        }
        private void playerButtonMove2_Click(object sender, EventArgs e)
        {
            Publisher.self.Broadcast("Player Used Ability", 1);
        }
        private void playerButtonMove3_Click(object sender, EventArgs e)
        {
            Publisher.self.Broadcast("Player Used Ability", 2);
        }
        private void playerButtonMove4_Click(object sender, EventArgs e)
        {
            Publisher.self.Broadcast("Player Used Ability", 3);
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            Publisher.self.Broadcast("Player Load", null);
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            Publisher.self.Broadcast("Player Save", null);
        }
    }
}
