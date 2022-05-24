using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Kata.Classes.Regular_Ball_Super_Ball;

namespace Kata.Classes
{
    /// <summary>
    /// The Grandpa always asked his daughter (“Mom”) and son (“Uncle”) to keep some habits in their minds, He wrote them in a paper for them:
    ///     Takes the garbage out
    ///     Like one specific food
    ///     Like one specific fruit
    ///     ...
    /// They follow grandpa advices.Then the grandchild (“Son”) was grown up, he inherits all the behaviors from his Mom.But he only takes the garbage out like his Uncle.
    /// Please, complete the class that shows Son's behavior. GrandpaPaper is an Interface declaring some methods. Mom and Uncle are classes that implement methods of GrandpaPaper. Son is the class you have to complete, it inherits from Mom except one method: "string TakeTheGarbageOut()"
    /// </summary>
    internal class GrandChild_get_the_habit_from_Uncle
    {
        public class Mom : GrandpaPaper
        {
            public string LikeFood()
            {
                throw new NotImplementedException();
            }

            public string LikeFruit()
            {
                throw new NotImplementedException();
            }

            public string TakeTheGarbageOut()
            {
                return "";
            }
        }
        public class Uncle : GrandpaPaper
        {
            public string LikeFood()
            {
                throw new NotImplementedException();
            }

            public string LikeFruit()
            {
                throw new NotImplementedException();
            }

            public string TakeTheGarbageOut()
            {
                return "";
            }
        }

        public class Son : Mom
        {
            public new string TakeTheGarbageOut() =>
                new Uncle().TakeTheGarbageOut();
        }

        public interface GrandpaPaper
        {
            public string TakeTheGarbageOut();
            public string LikeFood();
            public string LikeFruit();
        }
    }
}
