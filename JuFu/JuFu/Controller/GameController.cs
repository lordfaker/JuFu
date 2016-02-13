using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuFu.Monster;
using JuFu.Player;

namespace JuFu.Controller
{
    class GameController
    {
        private int _pitchX;
        private int _pitchY;

        public GameController(string playerOne, string PlayerTwo, int gridX, int gridY)
        {
            _pitchX = gridX;
            _pitchY = gridY;
        }

        public void SetPlayer()
        {

        }

        public void SetMonster()
        {

        }

        /*public void Start<P, M>() where P : JuFu.Player.Player, new() where M : JuFu.Monster.Monster
        {

        }
        */
        public void NextRound()
        {

        }

        public void Checkfield()
        {

        }

        public void CreatePitch()
        {
            
        }
    }
}
