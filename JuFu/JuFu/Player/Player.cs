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
        SolidColorBrush _color;
        public SolidColorBrush color
        {
            get { return _color; }

            set
            {
                _color = value;

                if (_color == Brushes.Blue)
                    strokeColor = Brushes.Aqua;
                if (_color == Brushes.Green)
                    strokeColor = Brushes.LightGreen;
                if (_color == Brushes.Red)
                    strokeColor = Brushes.Beige;
                if (_color == Brushes.Orange)
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
