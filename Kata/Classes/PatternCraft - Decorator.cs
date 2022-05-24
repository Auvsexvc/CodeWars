namespace Kata.Classes
{
    /// <summary>
    /// The pattern consists in "incrementing" your base class with extra functionality.
    /// A decorator will receive an instance of the base class and use it to create a new instance with the new things you want "added on it".
    /// Complete the code so that when a Marine gets a WeaponUpgrade it increases the damage by 1, and if it is a ArmorUpgrade then increase the armor by 1.
    ///
    /// </summary>
    internal class PatternCraft___Decorator
    {
        public interface IMarine
        {
            int Damage { get; set; }
            int Armor { get; set; }
        }

        public class Marine : IMarine
        {
            public Marine(int damage, int armor)
            {
                Damage = damage;
                Armor = armor;
            }

            public int Damage { get; set; }
            public int Armor { get; set; }
        }

        public class MarineWeaponUpgrade : IMarine
        {
            private IMarine marine;

            public MarineWeaponUpgrade(IMarine marine)
            {
                Damage = marine.Damage;
                Armor = marine.Armor;
                Damage++;
            }

            public int Damage { get; set; }

            public int Armor { get; set; }
        }

        public class MarineArmorUpgrade : IMarine
        {
            private IMarine marine;

            public MarineArmorUpgrade(IMarine marine)
            {
                Damage = marine.Damage;
                Armor = marine.Armor;
                Armor++;
            }

            public int Damage { get; set; }

            public int Armor { get; set; }
        }
    }
}