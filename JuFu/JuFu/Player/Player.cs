using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuFu.Monster;
using System.Windows.Media;

namespace JuFu.Player
{
    class Player
    {
        public List<Monster.Monster> MonsterList = new List<Monster.Monster>();
        public string Name;
        public int ID;
        public int ActionsLeft { get; set; }
        public SolidColorBrush color
        {
            get { return color; }

            set
            {
                color = value;

                if (color == Brushes.Blue)
                    strokeColor = Brushes.Aqua;
                if (color == Brushes.Green)
                    strokeColor = Brushes.LightGreen;
                if (color == Brushes.Red)
                    strokeColor = Brushes.Beige;
                if (color == Brushes.Orange)
                    strokeColor = Brushes.Yellow;

            }
        }
        public SolidColorBrush strokeColor { get; private set; }

        public Player(string name, int iD)
        {
            this.Name = name;
            this.ID = iD;
            this.ActionsLeft = 3;
        }

        public void DeselectAll()
        {
            foreach (var m in MonsterList)
                m.Deselect();
        }

        public bool hasActionsLeft()
        {
            return (ActionsLeft > 0) ?  true : false;
        }
    }
}
