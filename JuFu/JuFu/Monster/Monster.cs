using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace JuFu.Monster
{
    class Monster : AbstractMonster
    {
        public Monster(int strength, int health, Player.Player player) : base(strength, health, player)
        {
            Rectangle monster = new Rectangle();

            if(player.ID ==1)
            {
                monster.Fill = new SolidColorBrush(Colors.Blue);
            }
            else
            {
                monster.Fill = new SolidColorBrush(Colors.Red);
            }
            monster.Width = 40;
            monster.Height = 40;

            base.Children.Add(monster);
        }

        
    }
}
