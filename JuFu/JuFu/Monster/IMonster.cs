﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuFu.Monster
{
    interface IMonster
    {
        void Move(int playerNumber);

        void Fight();

        void Die();
    }
}
