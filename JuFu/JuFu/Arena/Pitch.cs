using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using JuFu.Controller;


namespace JuFu.Arena
{
    class Pitch : Canvas
    {
        public Pitch() : base()
        {
            base.Width = 50*GameController.PITCH_X;
            base.Height = 50;
        }

        public Pitch GetPitch()
        {
            Field[] pitch = new Field[GameController.PITCH_X];
            for (int i = 0; i < pitch.Length; i++)
            {
                pitch[i] = new Field(i);
            }

            return this;
        }
    }
}
