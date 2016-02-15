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
        public Player.Player Player1;
        public Player.Player Player2;
        public int RoundsPlayed;
        public bool PlayerOneTurn;
        Pitch[] pitchLevel = new Pitch[PITCH_Y];

        public GameController(string playerOne, string PlayerTwo)
        {
            // Create new instances of player - objects, assign name
            this.Player1 = new Player.Player(playerOne,1);
            this.Player2 = new Player.Player(PlayerTwo,2);
                         
            
        }


        public void Start(Canvas canvasPitch)
        { 


            // Create pitch, Add monster
            double margin = 0.0d;
            for (int i = 0; i < PITCH_Y; i++)
            {
                pitchLevel[i] = new Pitch(this);
                Canvas.SetTop(pitchLevel[i], margin);
                canvasPitch.Children.Add(pitchLevel[i].GetPitch());
                margin += 50.0d;
            }

            

        }



        public void Move()
        {
            RoundsPlayed++;
            Monster.Monster monster = this.Player1.MonsterList[0];


            Console.WriteLine("Object {0}", Player1.MonsterList[0].GetType());
            monster = Player1.MonsterList[0];
            Console.WriteLine("Target field: {0}", monster.CurrentField.Index);
            monster.TargetField = pitchLevel[0].FieldArray[monster.CurrentField.Index + 1];
            monster.CurrentField = pitchLevel[0].FieldArray[monster.CurrentField.Index];
            if (monster.CanMove())
                {

                    // 
                    Console.WriteLine("Target field: {0}", monster.TargetField.Index);
                    monster.CurrentField.Children.Remove(monster);
                    monster.TargetField.AddChildren(monster);

                    monster.CurrentField.Index++;

            }
            
            

                
        }

        public void Checkfield(Field f)
        {
            Field field = f;
        }

    }
}
