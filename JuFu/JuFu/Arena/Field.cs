using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace JuFu.Arena
{
    class Field : Canvas
    {
        public int Index;
        public bool IsSet { get; set; }
        public Monster.Monster Monster { get; set; }
        
        public Field(int index)
        {
            Index = index;
            IsSet = false;
            base.Width = 50;
            base.Height = 50;

            Rectangle rectangle = new Rectangle();
            rectangle.Fill = new SolidColorBrush(Colors.DarkSeaGreen);
            rectangle.Width = 50;
            rectangle.Height = 50;
            rectangle.Stroke = new SolidColorBrush(Colors.Black);

            base.Children.Add(rectangle);
        }

        public void AddChildren(UIElement uiElement)
        {
            IsSet = true;
            this.Monster = (Monster.Monster)uiElement;
            base.Children.Add(uiElement);
        }
         
    }
}
