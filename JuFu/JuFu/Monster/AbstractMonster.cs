using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuFu.Arena;
using JuFu.Controller;
using System.Windows.Controls;
using System.Windows;

namespace JuFu.Monster
{
    abstract class AbstractMonster : Canvas, IMonster 
    {
        public Point Position { get; set; }
        public int Strength { get; set; }
        public int Health { get; set; }
        public bool Moved;
        public Player.Player Player { get; set; }
        public bool IsAlive = true;
        public Field CurrentField;
        public Field TargetField;
        public bool Selected { get; set; }

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
            if (this.TargetField == null)
                throw new NotImplementedException("TargetField must not be null.");

            if (this.TargetField.IsSet)
            {
                return false;

            }
            else
            {
                return true;
            }
        }

        public void Move(Field nextTarget)
        {
            if (nextTarget == null)
                throw new NotImplementedException("Field target must not be null.");

            if (this.CurrentField == null)
                throw new NotImplementedException("CurrentField must not be null.");

            this.CurrentField.Children.Remove(this);
            this.CurrentField.IsSet = false;
            this.CurrentField = this.TargetField;
            this.CurrentField.AddChildren(this);
            this.TargetField = nextTarget;
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
            Selected = false;
        }

        public void Select()
        {
            throw new NotImplementedException();
        }

        public void Deselect()
        {
            throw new NotImplementedException();
        }
    }
}
