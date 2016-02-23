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
                return false;

            if (this.TargetField.IsSet)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public virtual bool HasTarget()
        {
            return (this.TargetField != null && this.TargetField.IsSet) ? true : false;
        }

        public void Move(Field nextTarget)
        {
            if (nextTarget == null)
                throw new NotImplementedException("Field target must not be null.");

            if (this.CurrentField == null)
                throw new NotImplementedException("CurrentField must not be null.");

            this.CurrentField.RemoveChild(this);
            this.CurrentField = this.TargetField;
            this.CurrentField.AddChildren(this);

            this.TargetField = (this.CurrentField != nextTarget) ? nextTarget : null;
        }


        /// <summary>
        /// Get monster from and target field and calculate
        /// fighting behavior.
        /// </summary>
        public void Fight()
        {
            Monster enemyMonster = this.TargetField.Monster;

            // Let's fight...
            enemyMonster.Health -= this.Strength;
            if (enemyMonster.Health <= 0) enemyMonster.Die();
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
