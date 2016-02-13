using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;


namespace JuFu.Arena
{
    class Field
    {
        public readonly int Index;
        public bool IsSet { get; set; }
        public Monster.Monster Monster { get; set; }
        private readonly Rectangle rectangle = new Rectangle();
        
        public Field(int index)
        {
            Index = index;
            rectangle.Fill = new SolidColorBrush(Colors.DarkSeaGreen);
            rectangle.Width = 50;
            rectangle.Height = 50;
        }
    }
}
