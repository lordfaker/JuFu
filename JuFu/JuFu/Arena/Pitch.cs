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
        private Player.Player playerOne;
        private Player.Player playerTwo;
        public Field[] FieldArray = new Field[GameController.PITCH_X];

        public Pitch(GameController gameController) : base()
        {
            base.Width = 50*GameController.PITCH_X;
            base.Height = 50;
            this.playerOne = gameController.Player1;
            this.playerTwo = gameController.Player2;

            for (var i = 0; i < FieldArray.Length; i++)
                FieldArray[i] = new Field(i);
                
        }

        public Pitch GetPitch()
        {

            double margin = 0.0d;
            

            for (int i = 0; i < FieldArray.Length; i++)
            {
                
                if (i == 0 || i == GameController.PITCH_X - 1)
                {
                    

                    if (i == 0)
                    {
                        Monster.Monster monster = new Monster.Monster(50, 100, playerOne);
                        monster.CurrentField = FieldArray[i];
                        monster.TargetField = FieldArray[i + 1];
                        playerOne.MonsterList.Add(monster);
                        FieldArray[i].Monster = monster;
                        FieldArray[i].AddChildren(monster);
                    }
                        else
                    {
                        Monster.Monster monster = new Monster.Monster(50, 100, playerTwo);
                        monster.CurrentField = FieldArray[i];
                        monster.TargetField = FieldArray[i - 1];
                        playerTwo.MonsterList.Add(monster);
                        FieldArray[i].Monster = monster;
                        FieldArray[i].AddChildren(monster);
                    }

                    
                    
                };
                Canvas.SetLeft(FieldArray[i], margin);
                Children.Add(FieldArray[i]);
                margin += 50.0d;
            }

            return this;
        }
    }
}
