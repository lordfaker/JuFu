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

        private bool gameOver = false;
        private string Winner;

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
                throw new NotImplementedException("GameController.parentWindow must not be null.");

            CurrentPlayer = Player1;
            gameOver = false;
            Winner = null;

            // Create pitch, Add monster
            double margin = 0.0d;
            for (int i = 0; i < PITCH_Y; i++)
            {
                pitchLevel[i] = new Pitch(this);
                Canvas.SetTop(pitchLevel[i], margin);
                canvasPitch.Children.Add(pitchLevel[i].GetPitch());
                margin += 50.0d;
            }

            parentWindow.bEndRound.Visibility = Visibility.Visible;
            parentWindow.tWinner.Visibility = Visibility.Hidden;
            UpdateRound();
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
                        if (pi == ((Monster.Monster)selectedMonster).CurrentField.Parent)
                        {
                            pitch = pi;
                        }
                    }

                    if (pitch == null)
                        throw new Exception("Pitch not found");

                    // TODO: Add check for array out of bounds.
                    Field moveTo = null;
                    try
                    {
                        moveTo = (CurrentPlayer.ID == 1) ? pitch.FieldArray[((Monster.Monster)selectedMonster).CurrentField.Index + 2] : pitch.FieldArray[((Monster.Monster)selectedMonster).CurrentField.Index - 2];
                    } catch (IndexOutOfRangeException e)
                    {
                        try
                        {
                            moveTo = (CurrentPlayer.ID == 1) ? pitch.FieldArray[((Monster.Monster)selectedMonster).CurrentField.Index + 1] : pitch.FieldArray[((Monster.Monster)selectedMonster).CurrentField.Index - 1];
                        } catch (IndexOutOfRangeException e1) {}
                    }


                    selectedMonster.Move(moveTo);

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

            UpdateRound();
        }

        public void Fight()
        {
            if (!CurrentPlayer.CanAct())
                return; //perhaps show some kind of message or throw an exception

            selectedMonster.Fight();
            CurrentPlayer.Act();

            UpdateRound();
        }

        private void CheckWinningCondition()
        {
            List<bool> oneMonster = new List<bool>();
            foreach (var p in pitchLevel)
            {
                int monsterCount = 0;
                foreach (var f in p.FieldArray)
                {
                    if (f.Monster != null)
                        monsterCount++;
                }

                oneMonster.Add((monsterCount > 1) ? false : true);
            }

            bool winnerPossible = true;

            foreach (var b in oneMonster)
            {
                if (!b) winnerPossible = false;
            }

            if (winnerPossible)
                CalculateWinner();
        }

        private void CalculateWinner()
        {
            int playerOneHealth = 0;
            int playerTwoHealth = 0;

            foreach (var p in pitchLevel)
            {
                foreach (var f in p.FieldArray)
                {
                    if (f.Monster != null)
                    {
                        if (f.Monster.Player.ID == 1)
                        {
                            playerOneHealth += f.Monster.Health;
                        }
                        else
                        {
                            playerTwoHealth += f.Monster.Health;
                        }
                    }
                }
            }

            Winner = (playerOneHealth > playerTwoHealth) ? Player1.Name : Player2.Name;
            //Console.WriteLine("And the WINNER IIIIIIS: " + winner + "!!!!");
            gameOver = true;
        }

        private void UpdateRound()
        {
            CheckWinningCondition();
            UpdateButtons();
            UpdateLabels();

        }

        private void UpdateButtons()
        {
            parentWindow.bMove.IsEnabled = (!gameOver && CurrentPlayer.CanAct() && selectedMonster != null && ((Monster.Monster)selectedMonster).CanMove()) ? true : false;
            parentWindow.bFight.IsEnabled = (!gameOver && CurrentPlayer.CanAct() && selectedMonster != null && ((Monster.Monster)selectedMonster).HasTarget()) ? true : false;
            parentWindow.bStart.Content = (gameOver) ? "Restart" : "Start";
            parentWindow.bEndRound.Visibility = (gameOver) ? Visibility.Hidden : Visibility.Visible;
        }

        private void UpdateLabels()
        {
            if (gameOver)
            {
                parentWindow.tWinner.Text = "Winner: " + Winner;
                parentWindow.tWinner.Visibility = Visibility.Visible;
            }
            else
            {
                parentWindow.lActionsLeftNumber.Content = CurrentPlayer.ActionsLeft;

                for (int i = 0; i < CurrentPlayer.MonsterList.Count; i++)
                {
                    parentWindow.healthLabels[i].Content = CurrentPlayer.MonsterList.ElementAt(i).Health;
                }

                parentWindow.lPlayerTurnNumber.Content = CurrentPlayer.ID;
                parentWindow.lPlayerTurnNumber.Foreground = CurrentPlayer.color;
            }
            
        }

        public void Checkfield(Field f)
        {
            Field field = f;
        }

        public void EndRound()
        {
            this.SelectMonster(null);
            changePlayer();
            UpdateRound();
        }

        public void SelectMonster(Monster.Monster m)
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
            CurrentPlayer = (CurrentPlayer.ID == 1) ? Player2 : Player1;
            CurrentPlayer.ActionsLeft = 3;
        }

    }
}
