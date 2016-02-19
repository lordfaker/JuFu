using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using JuFu.Controller;

namespace JuFu
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameController controller;

        public MainWindow()
        {
            InitializeComponent();

            bMove.IsEnabled = false;
            bFight.IsEnabled = false;
        }

        private void bStart_Click(object sender, RoutedEventArgs e)
        {
            // Get Player 1 Name, Get Player 2 Name
            string playerOneName = tbPlayerOneName.Text;
            string playerTwoName = tbPlayerTwoName.Text;


            // Start A New Game
            controller = new GameController(playerOneName, playerTwoName);
            controller.Start(CanvasPitch);
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            // Close The Game
            this.Close();
        }

        private void bMove_Click(object sender, RoutedEventArgs e)
        {
            controller.Move();
        }

        private void bFight_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CanvasPitch_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(sender.GetType() == typeof(Canvas))
            {
                Point hit = e.GetPosition((Canvas)sender);
                HitTestResult result = VisualTreeHelper.HitTest((Canvas)sender, hit);
                if(result != null)
                {
                    if (result.VisualHit is Rectangle)
                    {
                        Rectangle item = (Rectangle)result.VisualHit;
                        if(item.Parent is Monster.Monster)
                        {
                            Monster.Monster monster = (Monster.Monster)item.Parent;

                            if (!monster.Selected)
                            {
                                if (controller.SelectMonster(monster))
                                {
                                    if (!bMove.IsEnabled)
                                        bMove.IsEnabled = true;
                                    if (!bFight.IsEnabled)
                                        bFight.IsEnabled = true;
                                }
                            }
                        }
                        else
                        {
                            controller.SelectMonster(null);
                          
                            if (bMove.IsEnabled)
                                bMove.IsEnabled = false;
                            if (bFight.IsEnabled)
                                bFight.IsEnabled = false;
                        }
                    }
                }
                //controller.SelectMonster(e.GetPosition((Canvas)sender));
            }
            
        }
    }
}
