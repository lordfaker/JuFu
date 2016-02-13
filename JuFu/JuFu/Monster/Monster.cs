using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JuFu.Monster
{
    class Monster : AbstractMonster
    {
        public Monster(int strength, int health) : base(strength, health)
        {
            GameObjects.Monster layout = new GameObjects.Monster();
            layout.Visibility = Visibility.Visible;
        }

    }
}
