using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

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

        Player m_Player = new Player();

        public Form1()
        {
            InitializeComponent();

            AllocConsole();

            InputManager.self.Init(this);
            InputManager.self.AddOnKeyDown(OnKeyDown);

            Controller.self.Save();
            Controller.self.Load();

            Publisher.self.Subscribe("Unit Health Changed", UnitHealthChanged);
            Publisher.self.Subscribe("Ability Uses Changed", AbilityUsesChanged);

            AttatchUI();
        }

        private void AttatchUI()
        {
            playerName.Text = m_Player.party.currentUnit.name + "  '" + m_Player.party.currentUnit.nickname + "'";

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
                playerMove1.Text = m_Player.party.currentUnit.abilities[0].uses.ToString() + "/" + m_Player.party.currentUnit.abilities[0].maxUses.ToString();
                playerMove2.Text = m_Player.party.currentUnit.abilities[1].uses.ToString() + "/" + m_Player.party.currentUnit.abilities[1].maxUses.ToString();
                playerMove3.Text = m_Player.party.currentUnit.abilities[2].uses.ToString() + "/" + m_Player.party.currentUnit.abilities[2].maxUses.ToString();
                playerMove4.Text = m_Player.party.currentUnit.abilities[3].uses.ToString() + "/" + m_Player.party.currentUnit.abilities[3].maxUses.ToString();
            }
            catch { }
            try
            {
                ToolTip ToolTip1 = new ToolTip();
                ToolTip1.SetToolTip(playerButtonMove1, m_Player.party.currentUnit.abilities[0].description);
                ToolTip ToolTip2 = new ToolTip();
                ToolTip2.SetToolTip(playerButtonMove2, m_Player.party.currentUnit.abilities[1].description);
                ToolTip ToolTip3 = new ToolTip();
                ToolTip3.SetToolTip(playerButtonMove3, m_Player.party.currentUnit.abilities[2].description);
                ToolTip ToolTip4 = new ToolTip();
                ToolTip4.SetToolTip(playerButtonMove4, m_Player.party.currentUnit.abilities[3].description);
            }
            catch { }
        }

        private void UnitHealthChanged(string a_Message, object a_Param)
        {
            Unit<float> BroadcastUnit = a_Param as Unit<float>;

            if (BroadcastUnit.GetHashCode() == m_Player.GetHashCode() && BroadcastUnit.maxHealth > 0)
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
        }

        private void AbilityUsesChanged(string a_Message, object a_Param)
        {
            Ability<float> BroadcastAbility = (Ability<float>)a_Param;

            if (BroadcastAbility.GetHashCode() == m_Player.party.currentUnit.abilities[0].GetHashCode())
                playerMove1.Text = BroadcastAbility.uses.ToString() + "/" + BroadcastAbility.maxUses.ToString();

            if (BroadcastAbility.GetHashCode() == m_Player.party.currentUnit.abilities[1].GetHashCode())
                playerMove2.Text = BroadcastAbility.uses.ToString() + "/" + BroadcastAbility.maxUses.ToString();
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
