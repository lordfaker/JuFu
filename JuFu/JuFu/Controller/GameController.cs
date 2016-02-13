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

            for (int i=0; i < PITCH_Y; i++)
            {
                player1.MonsterList.Add(new JuFu.Monster.Monster(5,5));
            }
        }

        public void SetMonster()
        {
            
        }

        public void Start(Canvas canvasPitch)
        {
            Pitch pitch = new Pitch();
            canvasPitch.Children.Add(pitch.GetPitch());
        }
        


        public void NextRound()
        {

            RoundsPlayed++;
        }

        public void Checkfield(Field f)
        {
            Field field = f;
        }

        public void CreatePitch()
        {
            
        }
    }
}
