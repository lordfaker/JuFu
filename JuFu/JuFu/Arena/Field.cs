using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace JuFu.Arena
{
    class Field : Canvas
    {
        public readonly int Index;
        public bool IsSet { get; set; }
        public Monster.Monster Monster { get; set; }
        
        public Field(int index)
        {
            Index = index;

            base.Width = 50;
            base.Height = 50;

            Rectangle rectangle = new Rectangle();
            rectangle.Fill = new SolidColorBrush(Colors.DarkSeaGreen);
            rectangle.Width = 50;
            rectangle.Height = 50;

            base.Children.Add(rectangle);
        }
         
    }
}
