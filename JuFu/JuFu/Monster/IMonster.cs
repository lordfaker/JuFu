using JuFu.Arena;
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

        void Move(Field nextTarget);

        void Fight();

        void Die();

        void Select();

        void Deselect();
    }
}
