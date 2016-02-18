using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuFu.Monster;

namespace JuFu.Player
{
    class Player
    {
        public List<Monster.Monster> MonsterList = new List<Monster.Monster>();
        public string Name;
        public int ID;


        public Player(string name, int iD)
        {
            this.Name = name;
            this.ID = iD;
        }

        public void DeselectAll()
        {
            foreach (var m in MonsterList)
                m.Deselect();
        }
    }
}
