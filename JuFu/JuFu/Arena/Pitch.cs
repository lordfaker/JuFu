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
        public Field[] fieldArray = new Field[GameController.PITCH_X];

        public Pitch(Player.Player playerOne, Player.Player playerTwo) : base()
        {
            base.Width = 50*GameController.PITCH_X;
            base.Height = 50;
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
            
        }

        public Pitch GetPitch()
        {

            double margin = 0.0d;
            

            for (int i = 0; i < fieldArray.Length; i++)
            {
                fieldArray[i] = new Field(i);
                
                if (i == 0 || i == GameController.PITCH_X - 1)
                {
                    

                    if (i == 0)
                    {
                        Monster.Monster monster = new Monster.Monster(50, 100, playerOne);
                        monster.CurrentField = fieldArray[i];
                        playerOne.MonsterList.Add(monster);
                        fieldArray[i].Monster = monster;
                        fieldArray[i].AddChildren(monster);
                    }
                        else
                    {
                        Monster.Monster monster = new Monster.Monster(50, 100, playerTwo);
                        monster.CurrentField = fieldArray[i];
                        playerTwo.MonsterList.Add(monster);
                        fieldArray[i].Monster = monster;
                        fieldArray[i].AddChildren(monster);
                    }

                    
                    
                };
                Canvas.SetLeft(fieldArray[i], margin);
                Children.Add(fieldArray[i]);
                margin += 50.0d;
            }

            return this;
        }
    }
}
