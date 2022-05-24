using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kata.Classes.PatternCraft___Visitor;

namespace Kata.Classes
{
    /// <summary>
    /// The Visitor Design Pattern can be used, for example, to determine how an attack deals a different amount of damage to a unit in the StarCraft game.
    /// The pattern consists of delegating the responsibility to a different class.
    /// When a unit takes damage it can tell the visitor what to do with itself.
    /// 
    /// Complete the code so that when a Tank attacks a Marine it takes 21 damage and when a Tank attacks a Marauder it takes 32 damage.
    /// The Marine's initial health should be set to 100 and the Marauder's health should be set to 125.
    /// </summary>
    internal class PatternCraft___Visitor
    {
        public interface IVisitor
        {
            void VisitLight(ILightUnit unit);
            void VisitArmored(IArmoredUnit unit);
        }

        public interface ILightUnit
        {
            int Health { get; set; }

            void Accept(IVisitor visitor);
        }

        public interface IArmoredUnit
        {
            int Health { get; set; }

            void Accept(IVisitor visitor);
        }

        public class Marine : ILightUnit
        {
            public int Health { get; set; } = 100;

            public Marine()
            {
                Health = 100;
            }

            public void Accept(IVisitor visitor)
{
                visitor.VisitLight(this);
            }
        }

        public class Marauder : IArmoredUnit
        {

            public int Health { get; set; } = 125;

            public void Accept(IVisitor visitor)
            {

                visitor.VisitArmored(this);
                
            }
        }

        public class TankBullet : IVisitor
        {

            public void VisitLight(ILightUnit unit)
            {
                unit.Health -= 21;
            }

            public void VisitArmored(IArmoredUnit unit)
            {
                unit.Health -= 32;
            }
        }

    }
}
