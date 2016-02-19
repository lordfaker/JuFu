using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuFu.Monster
{
    interface IMonster
    {
        bool CanMove();

        void Fight();

        void Die();

        void Select();

        void Deselect();
    }
}
