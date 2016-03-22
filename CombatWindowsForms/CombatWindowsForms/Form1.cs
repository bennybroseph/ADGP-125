using System;
using System.Collections.Generic;
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

        Unit<float> Player;

        public Form1()
        {
            InitializeComponent();

            AllocConsole();

            InputManager.self.Init(this);
            InputManager.self.AddOnKeyDown(OnKeyDown);

            Publisher.self.Subscribe("Unit Health Changed", UnitHealthChanged);

            Player = new Unit<float>(
                new Stats<float>(10, 5, new StatType<float>(5, 3), new StatType<float>(5, 2)),
                new List<Ability<float>>()
                {
                    Abilities.s_Struggle,
                });

            try
            {
                playerButtonMove1.Text = Player.abilities[0].name;
                playerButtonMove2.Text = Player.abilities[1].name;
                playerButtonMove3.Text = Player.abilities[2].name;
                playerButtonMove4.Text = Player.abilities[3].name;
            }
            catch { }
            try
            {
                playerMove1.Text = Player.abilities[0].uses.ToString() + "/" + Player.abilities[0].maxUses.ToString();
                playerMove2.Text = Player.abilities[1].description;
                playerMove3.Text = Player.abilities[2].description;
                playerMove4.Text = Player.abilities[3].description;
            }
            catch { }
            try
            {
                ToolTip ToolTip1 = new ToolTip();
                ToolTip1.SetToolTip(playerButtonMove1, Player.abilities[0].description);
                ToolTip ToolTip2 = new ToolTip();
                ToolTip2.SetToolTip(playerButtonMove1, Player.abilities[1].description);
                ToolTip ToolTip3 = new ToolTip();
                ToolTip3.SetToolTip(playerButtonMove1, Player.abilities[2].description);
                ToolTip ToolTip4 = new ToolTip();
                ToolTip4.SetToolTip(playerButtonMove1, Player.abilities[3].description);
            }
            catch { }
            
        }

        private void UnitHealthChanged(string a_Message, object a_Param)
        {
            Unit<float> BroadcastUnit = a_Param as Unit<float>;

            if (BroadcastUnit.GetHashCode() == Player.GetHashCode() && BroadcastUnit.maxHealth > 0)
            {
                playerHealthBar.Value = (int)((BroadcastUnit.health / BroadcastUnit.maxHealth) * 100.0f);                
            }
        }

        private void OnKeyDown(MyKeys a_Key)
        {
            Console.WriteLine(a_Key);
        }
    }
}
