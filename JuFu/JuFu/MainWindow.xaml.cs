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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bStart_Click(object sender, RoutedEventArgs e)
        {
            // Get Player 1 Name, Get Player 2 Name
            string playerOneName = tbPlayerOneName.Text;
            string playerTwoName = tbPlayerTwoName.Text;

            // Set Pitch X Size, Get Pitch Y Size
            int X = 5;
            int Y = 4;
            

            // Start A New Game
            GameController controller = new GameController(playerOneName, playerTwoName,X,Y);
        }

        private void bClose_Click(object sender, RoutedEventArgs e)
        {
            // Close The Game
            this.Close();
        }
    }
}
