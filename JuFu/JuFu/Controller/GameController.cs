using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using JuFu.Monster;
using JuFu.Player;
using JuFu.Arena;

namespace JuFu.Controller
{
    class GameController
    {
        
        public const int PITCH_X = 5;
        public const int PITCH_Y = 4;
        
        public int RoundsPlayed;
        public bool PlayerOneTurn;

        public GameController(string playerOne, string PlayerTwo)
        {
            Player.Player player1 = new Player.Player(playerOne);
            Player.Player player2 = new Player.Player(PlayerTwo);

            for (int i = 0; i < PITCH_Y; i++)
            {
                player1.MonsterList.Add(new JuFu.Monster.Monster(5, 5));
            }
            for (int i = 0; i < PITCH_Y; i++)
            {
                player2.MonsterList.Add(new JuFu.Monster.Monster(5, 5));
            }
        }


        public void Start(Canvas canvasPitch)
        {
            double margin = 0.0d;
            for (int i = 0; i < PITCH_Y; i++)
            {
                Pitch pitchLevel = new Pitch();
                Canvas.SetTop(pitchLevel, margin);
                canvasPitch.Children.Add(pitchLevel.GetPitch());
                margin += 50.0d;
            }

            

        }
        


        public void NextRound()
        {
            
            RoundsPlayed++;
        }

        public void Checkfield(Field f)
        {
            Field field = f;
        }

    }
}
