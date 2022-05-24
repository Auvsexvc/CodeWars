using System;

namespace Kata.Classes
{
    /// <summary>
    /// Mission
    /// The aim of this kata is to refactor out the switch statement and replace it with a solution based upon Polymorphism.
    ///     Problem
    /// Although switch statements can execute quickly and are a simple construct to grasp they can become unwieldly and a maintenance nightmare as they grow. Also they do not readily encourage the "Open Closed" principle.With this in mind we will remove the switch statment from the code and replace it with a solution which leverages polymorphism.
    /// Solution
    ///     Your solution will replace the switch case statment in the GetStatusDescription() method with a solution which uses polymorphism. To get you started you will be given a base Status class which you can inherit from.
    /// public abstract class Status
    ///     {
    ///         public abstract string GetStatusDescription();
    ///     }
    ///     Your kata must include a private field of type Status and declared as below;
    /// private readonly Status _status;
    /// How you implement the rest of your solution is up to you.
    /// NOTE: Yes the tests will pass by doing nothing and leaving the switch...case construct present, but the idea of this kata is to give you an insight into removing switch statements from your code and looking for alternative constructs, in this case, a dictionary.
    /// </summary>
    internal class Refactor_out_a_switch_statement_using_polymorphism
    {
        public class Kata
        {
            private readonly Status _status;

            public Kata()
            {
                _status = new Default();
            }

            public Kata(Status status)
            {
                _status = status;
            }
            public string GetStatusDescription() => _status.GetStatusDescription();
            
        }
        
        public abstract class Status
        {
            public abstract string GetStatusDescription();
        }
        public class Default : Status
        {
            public override string GetStatusDescription() => "I have never been set";
        }
        public class NewStatus : Status
        {
            public override string GetStatusDescription() => "I am new!";
        }
        public class ActiveStatus : Status
        {
            public override string GetStatusDescription() => "I am active";
        }
        public class DeactivatedStatus : Status
        {
            public override string GetStatusDescription() => "I have been deactivated";
        }
    }
}
