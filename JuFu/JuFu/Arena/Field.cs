using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuFu.Arena
{
    class Field
    {
        public readonly int Index;
        public bool IsSet { get; set; }
        public Monster.Monster Monster { get; set; }

        public Field(int index)
        {
            Index = index;
        }
    }
}
