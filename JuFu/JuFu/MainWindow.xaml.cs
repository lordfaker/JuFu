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
            // player1 blue
            cPicker1ColorBlue = createColorPickerCanvas(Brushes.Blue, 265, 13, 0, 0, cPicker1Select_MouseDown);
            picker1List.Add(cPicker1ColorBlue);
            gMainGrid.Children.Add(cPicker1ColorBlue);
            // player1 green
            cPicker1ColorGreen = createColorPickerCanvas(Brushes.Green, 290, 13, 0, 0, cPicker1Select_MouseDown);
            picker1List.Add(cPicker1ColorGreen);
            gMainGrid.Children.Add(cPicker1ColorGreen);
            // player1 orange
            cPicker1ColorOrange = createColorPickerCanvas(Brushes.Orange, 315, 13, 0, 0, cPicker1Select_MouseDown);
            picker1List.Add(cPicker1ColorOrange);
            gMainGrid.Children.Add(cPicker1ColorOrange);
            // player1 red
            cPicker1ColorRed = createColorPickerCanvas(Brushes.Red, 340, 13, 0, 0, cPicker1Select_MouseDown);
            picker1List.Add(cPicker1ColorRed);
            gMainGrid.Children.Add(cPicker1ColorRed);
            // player2 red
            cPicker2ColorRed = createColorPickerCanvas(Brushes.Red, 265, 45, 0, 0, cPicker2Select_MouseDown);
            picker2List.Add(cPicker2ColorRed);
            gMainGrid.Children.Add(cPicker2ColorRed);
            // player2 orange
            cPicker2ColorOrange = createColorPickerCanvas(Brushes.Orange, 290, 45, 0, 0, cPicker2Select_MouseDown);
            picker2List.Add(cPicker2ColorOrange);
            gMainGrid.Children.Add(cPicker2ColorOrange);
            // player2 green
            cPicker2ColorGreen = createColorPickerCanvas(Brushes.Green, 315, 45, 0, 0, cPicker2Select_MouseDown);
            picker2List.Add(cPicker2ColorGreen);
            gMainGrid.Children.Add(cPicker2ColorGreen);
            // player2 blue
            cPicker2ColorBlue = createColorPickerCanvas(Brushes.Blue, 340, 45, 0, 0, cPicker2Select_MouseDown);
            picker2List.Add(cPicker2ColorBlue);
            gMainGrid.Children.Add(cPicker2ColorBlue);
            
            
            
        }

        private Canvas createColorPickerCanvas(SolidColorBrush color, double left, double top, double right, double bottom, MouseButtonEventHandler eventHandler)
        {
            Canvas c = new Canvas();
            c.HorizontalAlignment = HorizontalAlignment.Left;
            c.Margin = new Thickness(left, top, right, bottom);
            c.VerticalAlignment = VerticalAlignment.Top;
            c.Width = 20;
            c.Height = 23;
            c.Background = color;
            c.Visibility = Visibility.Hidden;
            c.MouseDown += eventHandler;

            return c;
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
