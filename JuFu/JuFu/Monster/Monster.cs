using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace JuFu.Monster
{
    class Monster : AbstractMonster
    {
        public Rectangle Rectangle { get; set; }
        public bool Selected { get; set; }
        private Brush animPlayer1Selected { get; set; }
        private Brush animPlayer2Selected { get; set; }
        private Brush player1Brush = new SolidColorBrush(Colors.Blue);
        private Brush player2Brush = new SolidColorBrush(Colors.Red);

        public Monster(int strength, int health, Player.Player player) : base(strength, health, player)
        {
            Rectangle = new Rectangle();

            animPlayer1Selected = CreateAnimBrush(Colors.DarkSeaGreen, Brushes.Azure.Color, 0.5);
            animPlayer2Selected = CreateAnimBrush(Colors.DarkSeaGreen, Brushes.Beige.Color, 0.5);

            if (player.ID == 1)
            {
                this.Rectangle.Fill = player1Brush;
                this.Rectangle.Stroke = animPlayer1Selected;
            }
            else
            {
                this.Rectangle.Fill = player2Brush;
                this.Rectangle.Stroke = animPlayer2Selected;
            }
            this.Rectangle.Width = 40;
            this.Rectangle.Height = 40;
            this.Rectangle.StrokeThickness = 0;

            if (this.CurrentField != null)
            {
                this.SetValue(Canvas.LeftProperty, (this.CurrentField.Width - this.Rectangle.Width) / 2);
                this.SetValue(Canvas.TopProperty, (this.CurrentField.Height - this.Rectangle.Height) / 2);
            }
            else
            {
                this.SetValue(Canvas.LeftProperty, (50 - this.Rectangle.Width) / 2);
                this.SetValue(Canvas.TopProperty, (50 - this.Rectangle.Height) / 2);
            }

            base.Children.Add(this.Rectangle);

            
        }

        public new void Select()
        {
            this.Rectangle.StrokeThickness = 1;
            this.Selected = true;
        }

        public new void Deselect()
        {
            this.Rectangle.StrokeThickness = 0;
            this.Selected = false;
        }

        private Brush CreateAnimBrush(Color fromColor, Color toColor, double seconds)
        {

            ColorAnimation ani = new ColorAnimation();
            ani.From = fromColor;
            ani.To = toColor;
            ani.RepeatBehavior = RepeatBehavior.Forever;
            ani.Duration = new Duration(TimeSpan.FromSeconds(seconds));
            ani.AutoReverse = true;

            SolidColorBrush brush = new SolidColorBrush(fromColor);
            brush.BeginAnimation(SolidColorBrush.ColorProperty, ani);

            return brush;
        }
    }
}
