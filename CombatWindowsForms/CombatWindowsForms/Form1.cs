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

        Unit Player;

        public Form1()
        {
            InitializeComponent();

            AllocConsole();

            InputManager.self.Init(this);
            InputManager.self.AddOnKeyDown(OnKeyDown);

            Publisher.self.Subscribe("Unit Health Changed", PlayerHealthChanged);

            Player = new Unit(10, 5, 3, new StatType<int>(3, 5), new StatType<int>(2, 6));
            PlayerHealthChanged(null, Player);
        }

        private void PlayerHealthChanged(string a_Message, object a_Param)
        {
            Unit BroadcastUnit = a_Param as Unit;

            if(BroadcastUnit.GetHashCode() == Player.GetHashCode() && BroadcastUnit.maxHealth > 0)
                playerHealthBar.Value = (BroadcastUnit.health / BroadcastUnit.maxHealth) * 100;
        }

        private void OnKeyDown(MyKeys a_Key)
        {
            Console.WriteLine(a_Key);
        }
    }
}
