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
        private Canvas cPicker1ColorBlue;
        private Canvas cPicker1ColorGreen;
        private Canvas cPicker1ColorOrange;
        private Canvas cPicker1ColorRed;
        private Canvas cPicker2ColorRed;
        private Canvas cPicker2ColorOrange;
        private Canvas cPicker2ColorGreen;
        private Canvas cPicker2ColorBlue;
        private List<Canvas> picker1List;
        private List<Canvas> picker2List;

        public MainWindow()
        {
            InitializeComponent();
            load();

            bMove.IsEnabled = false;
            bFight.IsEnabled = false;
        }

        private void load()
        {
            cPlayer1Color.Background = Brushes.Blue;
            cPlayer2Color.Background = Brushes.Red;

            picker1List = new List<Canvas>();
            picker2List = new List<Canvas>();
            // create color picker Elements
            cPicker1ColorBlue = new Canvas();
            cPicker1ColorBlue.HorizontalAlignment = HorizontalAlignment.Left;
            cPicker1ColorBlue.Margin = new Thickness(265, 13, 0, 0);
            cPicker1ColorBlue.VerticalAlignment = VerticalAlignment.Top;
            cPicker1ColorBlue.Width = 20;
            cPicker1ColorBlue.Height = 23;
            cPicker1ColorBlue.Background = Brushes.Blue;
            cPicker1ColorBlue.Visibility = Visibility.Hidden;
            cPicker1ColorBlue.MouseDown += cPicker1Select_MouseDown;
            picker1List.Add(cPicker1ColorBlue);
            gMainGrid.Children.Add(cPicker1ColorBlue);
            cPicker1ColorGreen = new Canvas();
            cPicker1ColorGreen.HorizontalAlignment = HorizontalAlignment.Left;
            cPicker1ColorGreen.Margin = new Thickness(290, 13, 0, 0);
            cPicker1ColorGreen.VerticalAlignment = VerticalAlignment.Top;
            cPicker1ColorGreen.Width = 20;
            cPicker1ColorGreen.Height = 23;
            cPicker1ColorGreen.Background = Brushes.Green;
            cPicker1ColorGreen.Visibility = Visibility.Hidden;
            cPicker1ColorGreen.MouseDown += cPicker1Select_MouseDown;
            picker1List.Add(cPicker1ColorGreen);
            gMainGrid.Children.Add(cPicker1ColorGreen);
            cPicker1ColorOrange = new Canvas();
            cPicker1ColorOrange.HorizontalAlignment = HorizontalAlignment.Left;
            cPicker1ColorOrange.Margin = new Thickness(315, 13, 0, 0);
            cPicker1ColorOrange.VerticalAlignment = VerticalAlignment.Top;
            cPicker1ColorOrange.Width = 20;
            cPicker1ColorOrange.Height = 23;
            cPicker1ColorOrange.Background = Brushes.Orange;
            cPicker1ColorOrange.Visibility = Visibility.Hidden;
            cPicker1ColorOrange.MouseDown += cPicker1Select_MouseDown;
            picker1List.Add(cPicker1ColorOrange);
            gMainGrid.Children.Add(cPicker1ColorOrange);
            cPicker1ColorRed = new Canvas();
            cPicker1ColorRed.HorizontalAlignment = HorizontalAlignment.Left;
            cPicker1ColorRed.Margin = new Thickness(340, 13, 0, 0);
            cPicker1ColorRed.VerticalAlignment = VerticalAlignment.Top;
            cPicker1ColorRed.Width = 20;
            cPicker1ColorRed.Height = 23;
            cPicker1ColorRed.Background = Brushes.Red;
            cPicker1ColorRed.Visibility = Visibility.Hidden;
            cPicker1ColorRed.MouseDown += cPicker1Select_MouseDown;
            picker1List.Add(cPicker1ColorRed);
            gMainGrid.Children.Add(cPicker1ColorRed);

            cPicker2ColorRed = new Canvas();
            cPicker2ColorRed.HorizontalAlignment = HorizontalAlignment.Left;
            cPicker2ColorRed.Margin = new Thickness(265, 45, 0, 0);
            cPicker2ColorRed.VerticalAlignment = VerticalAlignment.Top;
            cPicker2ColorRed.Width = 20;
            cPicker2ColorRed.Height = 23;
            cPicker2ColorRed.Background = Brushes.Red;
            cPicker2ColorRed.Visibility = Visibility.Hidden;
            cPicker2ColorRed.MouseDown += cPicker2Select_MouseDown;
            picker2List.Add(cPicker2ColorRed);
            gMainGrid.Children.Add(cPicker2ColorRed);
            cPicker2ColorOrange = new Canvas();
            cPicker2ColorOrange.HorizontalAlignment = HorizontalAlignment.Left;
            cPicker2ColorOrange.Margin = new Thickness(290, 45, 0, 0);
            cPicker2ColorOrange.VerticalAlignment = VerticalAlignment.Top;
            cPicker2ColorOrange.Width = 20;
            cPicker2ColorOrange.Height = 23;
            cPicker2ColorOrange.Background = Brushes.Orange;
            cPicker2ColorOrange.Visibility = Visibility.Hidden;
            cPicker2ColorOrange.MouseDown += cPicker2Select_MouseDown;
            picker2List.Add(cPicker2ColorOrange);
            gMainGrid.Children.Add(cPicker2ColorOrange);
            cPicker2ColorGreen = new Canvas();
            cPicker2ColorGreen.HorizontalAlignment = HorizontalAlignment.Left;
            cPicker2ColorGreen.Margin = new Thickness(315, 45, 0, 0);
            cPicker2ColorGreen.VerticalAlignment = VerticalAlignment.Top;
            cPicker2ColorGreen.Width = 20;
            cPicker2ColorGreen.Height = 23;
            cPicker2ColorGreen.Background = Brushes.Green;
            cPicker2ColorGreen.Visibility = Visibility.Hidden;
            cPicker2ColorGreen.MouseDown += cPicker2Select_MouseDown;
            picker2List.Add(cPicker2ColorGreen);
            gMainGrid.Children.Add(cPicker2ColorGreen);
            cPicker2ColorBlue = new Canvas();
            cPicker2ColorBlue.HorizontalAlignment = HorizontalAlignment.Left;
            cPicker2ColorBlue.Margin = new Thickness(340, 45, 0, 0);
            cPicker2ColorBlue.VerticalAlignment = VerticalAlignment.Top;
            cPicker2ColorBlue.Width = 20;
            cPicker2ColorBlue.Height = 23;
            cPicker2ColorBlue.Background = Brushes.Blue;
            cPicker2ColorBlue.Visibility = Visibility.Hidden;
            cPicker2ColorBlue.MouseDown += cPicker2Select_MouseDown;
            picker2List.Add(cPicker2ColorBlue);
            gMainGrid.Children.Add(cPicker2ColorBlue);
            
            
            
        }

        private void bStart_Click(object sender, RoutedEventArgs e)
        {
            // Get Player 1 Name, Get Player 2 Name
            string playerOneName = tbPlayerOneName.Text;
            string playerTwoName = tbPlayerTwoName.Text;


            // Start A New Game
            controller = new GameController(this, playerOneName, playerTwoName);
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
            if (sender.GetType() == typeof(Canvas))
            {
                Point hit = e.GetPosition((Canvas)sender);
                HitTestResult result = VisualTreeHelper.HitTest((Canvas)sender, hit);
                if (result != null)
                {
                    if (result.VisualHit is Rectangle)
                    {
                        Rectangle item = (Rectangle)result.VisualHit;
                        if (item.Parent is Monster.Monster)
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

        private void switchVisibility(List<Canvas> list)
        {
            foreach(var c in list)
            {
                if (c.Visibility == Visibility.Hidden)
                    c.Visibility = Visibility.Visible;
                else
                    c.Visibility = Visibility.Hidden;
            }
        }

        private void checkPlayersColorChoice()
        {
            if (cPlayer1Color.Background == cPlayer2Color.Background)
            {
                bStart.IsEnabled = false;
                // write message to user?
            }
            else
            {
                bStart.IsEnabled = true;
            }
        }

        private void cPicker1Select_MouseDown(object sender, MouseButtonEventArgs e)
        {
            cPlayer1Color.Background = ((Canvas)sender).Background;
            if(controller != null)
                controller.Player1.color = (SolidColorBrush)cPlayer1Color.Background;
            switchVisibility(picker1List);

            checkPlayersColorChoice();
        }

        private void cPicker2Select_MouseDown(object sender, MouseButtonEventArgs e)
        {
            cPlayer2Color.Background = ((Canvas)sender).Background;
            if (controller != null)
                controller.Player2.color = (SolidColorBrush)cPlayer2Color.Background;
            switchVisibility(picker2List);

            checkPlayersColorChoice();
        }

        private void cPlayer1Color_MouseDown(object sender, MouseButtonEventArgs e)
        {
            switchVisibility(picker1List);
        }

        private void cPlayer2Color_MouseDown(object sender, MouseButtonEventArgs e)
        {
            switchVisibility(picker2List);
        }
    }
}
