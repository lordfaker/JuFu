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
            double margin = 0.0d;
            Field[] pitch = new Field[GameController.PITCH_X];
            for (int i = 0; i < pitch.Length; i++)
            {
                pitch[i] = new Field(i);
                if (i == 0 || i == GameController.PITCH_X) pitch[i].Monster = new Monster.Monster(50, 100);
                Canvas.SetLeft(pitch[i], margin);
                Children.Add(pitch[i]);
                margin += 50.0d;
            }

            return this;
        }
    }
}
