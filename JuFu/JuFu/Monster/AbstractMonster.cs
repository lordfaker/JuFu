using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuFu.Arena;
using JuFu.Controller;

namespace JuFu.Monster
{
    abstract class AbstractMonster : IMonster
    {
        protected int Position { get; set; }
        protected int Strength { get; set; }
        protected int Health { get; set; }
        protected bool Moved;
        protected bool IsAlive = true;
        protected Field CurrentField;
        protected Field TargetField;

        protected AbstractMonster(int strength, int health)
        {
            this.Strength = strength;
            this.Health = health;
        }

        /// <summary>
        /// Check if target field is free and move or fight.
        /// </summary>
        /// <param name="playerNumber"></param>
        public virtual void Move(int playerNumber)
        {
            switch (playerNumber)
            {
                case 1:
                    if (this.TargetField.IsSet)
                    {
                        Fight();
                    }
                    else
                    {
                        if (this.Position < GameController.PITCH_X) this.Position++;
                    }
                    break;
                case 2:
                    if (this.TargetField.IsSet)
                    {
                        Fight();
                    }
                    else
                    {
                        if (this.Position > 0) this.Position--;
                    }
                    break;
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
