using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using JuFu.Monster;
using JuFu.Player;
using JuFu.Arena;
using System.Windows;
using System.ComponentModel;

namespace JuFu.Controller
{
    class GameController
    {
        
        public const int PITCH_X = 5;
        public const int PITCH_Y = 4;
        public Player.Player Player1;
        public Player.Player Player2;
        public int RoundsPlayed;
        //public bool PlayerOneTurn; NEINNEINEINEINEINTAUSEND!
        Pitch[] pitchLevel = new Pitch[PITCH_Y];
        public int CurrentPlayerID { get; set; }

        public Monster.Monster selectedMonster { get; set; }

        public GameController(string playerOne, string PlayerTwo)
        {
            // Create new instances of player - objects, assign name
            this.Player1 = new Player.Player(playerOne,1);
            this.Player2 = new Player.Player(PlayerTwo,2);
                         
            
        }


        public void Start(Canvas canvasPitch)
        {
            CurrentPlayerID = 1;

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
            if (selectedMonster != null)
            {
                if (selectedMonster.CanMove())
                {
                    Pitch pitch = null;
                    foreach(var pi in pitchLevel)
                    {
                        if (pi == selectedMonster.CurrentField.Parent)
                        {
                            pitch = pi;
                        }
                    }

                    if (pitch == null)
                        throw new Exception("Pitch not found");

                    selectedMonster.CurrentField.Children.Remove(selectedMonster);
                    selectedMonster.CurrentField.IsSet = false;
                    selectedMonster.CurrentField = selectedMonster.TargetField;
                    selectedMonster.CurrentField.AddChildren(selectedMonster);

                    switch (CurrentPlayerID)
                    {
                        case 1:
                            selectedMonster.TargetField = pitch.FieldArray[selectedMonster.CurrentField.Index + 1];
                            break;
                        case 2:
                            selectedMonster.TargetField = pitch.FieldArray[selectedMonster.CurrentField.Index - 1];
                            break;
                        default: break;
                    }

                    RoundsPlayed++;
                }
            }
            else
            {
                // perhaps show some kind of message
            }


            /*RoundsPlayed++;
            Monster.Monster monster = this.Player1.MonsterList[0];


            Console.WriteLine("Object {0}", Player1.MonsterList[0].GetType());
            monster = Player1.MonsterList[0];
            Console.WriteLine("Target field: {0}", monster.CurrentField.Index);
            monster.TargetField = pitchLevel[0].FieldArray[monster.CurrentField.Index + 1];
            monster.CurrentField = pitchLevel[0].FieldArray[monster.CurrentField.Index];
            if (monster.CanMove())
            { 
                Console.WriteLine("Target field: {0}", monster.TargetField.Index);
                monster.CurrentField.Children.Remove(monster);
                monster.TargetField.AddChildren(monster);

                monster.CurrentField.Index++;
            }*/
            
            

                
        }

        public void Checkfield(Field f)
        {
            Field field = f;
        }

        public bool SelectMonster(Monster.Monster m)
        {
            if (m != null)
            {
                if (m.Player.ID == CurrentPlayerID)
                {
                    if (!m.Selected)
                    {
                        m.Player.DeselectAll();

                        m.Select();
                        this.selectedMonster = m;

                        return true;
                    }
                }
            }
            else
            {
                switch (CurrentPlayerID)
                {
                    case 1: Player1.DeselectAll();
                        break;
                    case 2: Player2.DeselectAll();
                        break;
                    default: break;
                }
                this.selectedMonster = null;
            }

            return false;
        }

    }
}
