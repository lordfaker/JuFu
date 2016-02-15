using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuFu.Arena;
using JuFu.Controller;
using System.Windows.Controls;

namespace JuFu.Monster
{
    abstract class AbstractMonster : Canvas, IMonster 
    {
        public int Position { get; set; }
        public int Strength { get; set; }
        public int Health { get; set; }
        public bool Moved;
        public Player.Player Player { get; set; }
        public bool IsAlive = true;
        public Field CurrentField;
        public Field TargetField;

        protected AbstractMonster(int strength, int health, Player.Player player)
        {
            this.Strength = strength;
            this.Health = health;
            this.Player = player;

        }

        /// <summary>
        /// Check if target field is free and move or fight.
        /// </summary>
        /// <param name="playerNumber"></param>
        public virtual bool CanMove()
        {

            if (this.TargetField.IsSet)
            {
                return false;

            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// Get monster from and target field and calculate
        /// fighting behavior.
        /// </summary>
        public void Fight()
        {
            Monster enemyMonster = TargetField.Monster;
            int enemyHealth = enemyMonster.Health;
            int enemyStrength = enemyMonster.Strength;

            // Let's fight...
            enemyHealth -= this.Strength;
            if (enemyHealth <= 0) enemyMonster.Die();
        }

        /// <summary>
        /// May call destructor.
        /// </summary>
        public void Die()
        {
            IsAlive = false;
        }
    }
}
