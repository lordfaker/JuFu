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
using System.Windows.Media;

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
        //private int CurrentPlayerID { get; set; }
        private Player.Player CurrentPlayer { get; set; }

        public IMonster selectedMonster { get; set; }
        public MainWindow parentWindow { get; set; }

        public GameController(MainWindow parentWindow, string playerOne, string PlayerTwo)
        {
            // Create new instances of player - objects, assign name
            this.Player1 = new Player.Player(playerOne,1);
            this.Player2 = new Player.Player(PlayerTwo,2);
            this.parentWindow = parentWindow;

            this.Player1.color = (SolidColorBrush)parentWindow.cPlayer1Color.Background;
            this.Player2.color = (SolidColorBrush)parentWindow.cPlayer2Color.Background;
        }


        public void Start(Canvas canvasPitch)
        {
            if (this.parentWindow == null)
                throw new NotImplementedException("GameController.parentWindow must be set.");

            CurrentPlayer = Player1;

            // Create pitch, Add monster
            double margin = 0.0d;
            for (int i = 0; i < PITCH_Y; i++)
            {
                pitchLevel[i] = new Pitch(this);
                Canvas.SetTop(pitchLevel[i], margin);
                canvasPitch.Children.Add(pitchLevel[i].GetPitch());
                margin += 50.0d;
            }

            parentWindow.lPlayerTurnNumber.Foreground = Player1.color;
        }



        public void Move()
        {
            if (!CurrentPlayer.CanAct())
                return; //Perhaps show some kind of message or throw an exception

            if (selectedMonster != null)
            {
                if (selectedMonster.CanMove())
                {
                    Pitch pitch = null;
                    foreach(var pi in pitchLevel)
                    {
                        if (pi == ((AbstractMonster)selectedMonster).CurrentField.Parent)
                        {
                            pitch = pi;
                        }
                    }

                    if (pitch == null)
                        throw new Exception("Pitch not found");

                    switch (CurrentPlayer.ID)
                    {
                        case 1:
                            selectedMonster.Move(pitch.FieldArray[((AbstractMonster)selectedMonster).CurrentField.Index + 1]);
                            break;
                        case 2:
                            selectedMonster.Move(pitch.FieldArray[((AbstractMonster)selectedMonster).CurrentField.Index - 1]);
                            break;
                        default: break;
                    }

                    CurrentPlayer.Act();

                    RoundsPlayed++; // what is this var used for?


                }
                else
                {
                    // perhaps show some kind of message
                }
            } else
            {
                throw new NotImplementedException("selectedMonster must not be null!");
            }
        }

        public void Fight()
        {
            if (!CurrentPlayer.CanAct())
                return; //perhaps show some kind of message or throw an exception


        }

        private void UpdateRound()
        {


            UpdateButtons();
            //UpdateVisuals();
        }

        private void UpdateButtons()
        {
            if (CurrentPlayer.CanAct())
            {
                parentWindow.bMove.IsEnabled = (selectedMonster != null) ? true : false;
                parentWindow.bFight.IsEnabled = (selectedMonster != null && ((AbstractMonster)selectedMonster).TargetField.IsSet) ? true : false;
                // update end round button?
            }
            else
            {
                parentWindow.bMove.IsEnabled = false;
                parentWindow.bFight.IsEnabled = false;
                // enable end round button
            }
        }

        private void UpdateLabels()
        {

        }

        public void Checkfield(Field f)
        {
            Field field = f;
        }

        public void SelectMonster(AbstractMonster m)
        {
            if (m != null)
            {
                if (m.Player.ID == CurrentPlayer.ID)
                {
                    if (!m.Selected)
                    {
                        m.Player.DeselectAll();

                        m.Select();
                        this.selectedMonster = m;
                    }
                }
            }
            else
            {
                CurrentPlayer.DeselectAll();
                this.selectedMonster = null;
            }

            UpdateButtons();
        }
        

        private void changePlayer()
        {
            if (CurrentPlayer.ID == 1)
            {
                CurrentPlayer = Player2;
                parentWindow.lPlayerTurnNumber.Content = CurrentPlayer.ID;
                parentWindow.lPlayerTurnNumber.Foreground = CurrentPlayer.color;
            }
            else
            {
                CurrentPlayer.ID = 1;
                parentWindow.lPlayerTurnNumber.Content = CurrentPlayer.ID;
                parentWindow.lPlayerTurnNumber.Foreground = CurrentPlayer.color;
            }
        }

    }
}
