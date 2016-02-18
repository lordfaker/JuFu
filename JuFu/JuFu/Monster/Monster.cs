using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace JuFu.Monster
{
    class Monster : AbstractMonster
    {
        public Rectangle Rectangle { get; set; }
        public bool Selected { get; set; }

        public Monster(int strength, int health, Player.Player player) : base(strength, health, player)
        {
            Rectangle = new Rectangle();

            if(player.ID ==1)
            {
                this.Rectangle.Fill = new SolidColorBrush(Colors.Blue);
            }
            else
            {
                this.Rectangle.Fill = new SolidColorBrush(Colors.Red);
            }
            this.Rectangle.Width = 40;
            this.Rectangle.Height = 40;
            this.Rectangle.Stroke = Brushes.Azure;
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
    }
}
