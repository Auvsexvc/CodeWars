using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Please don't cheat, you need to know about event and delegate concept while developing an application in real world.
    ///     Concept of event and delegate is confusing sometimes, so this kata is going to target it.
    ///     Events and delegates help us to follow SOLID principle and develop loosely coupled application.
    ///     It provide us with a communication method (contract with specific signature) between objects which need to be decoupled.
    /// Basically it provides notifier in one objects so that other objects can subscribe to that.
    /// Suppose you have a list of strings containing names. It shows the order of people who has received some messages, and we want to notify them in every three message.
    /// So, we start counting, and every time we count "Peter" for 3rd, 6th, 9th or n*3th times we send him a text message and Email. this is the logic how we chose a name to send a notification.
    ///     in this list:
    ///     List<string> peopleList = new List<string>()
    ///                 {
    ///                 "Peter", "Mike", "Peter", "Bob", "Peter", "Peter", "Bob", "Mike", "Bob", "Peter", "Peter", "Mike", "Bob"
    /// };
    /// First we inform "Peter", then "Bob", then "Peter", then "Mike".
    /// Here is a class that can do it:
    /// public class NotPublisher
    /// {
    /// public void CountMessages(List<string> peopleList)
    /// {
    /// foreach (string person in peopleList)
    /// {
    /// /*if (some logic to count the person for 3, 6, 9, 12 ... times)
    /// {
    ///   SendTextMessage(person);
    ///   SendEmail(Person)
    /// }*/
    ///             }
    /// }
    /// }
    ///     The objects and components are tightly coupled here.We notify the user by sending a test message or Email. Then what if we want to add another method to inform users by sending a VoiP message?
    ///     We need to create another function here, and it means our application is not easy to extend. We need to recompile and republish the class again.
    /// Your task is to implement the class as a publisher, so text message or Email or VoiP objects can subscribe to it.So, you need to define a delegate, and then define an event based on the delegate.
    /// PersonEventArgs class (based on EventArgs) with Name property(string) is needed to send Name of the person to the subscriber.
    /// ContactNotify is the event handler that you need to implement in the class. Subscriber classes subscribe to this event handler.
    /// </summary>
    internal class Event_and_Delegate
    {
        public class PersonEventArgs : EventArgs
        {
            public string Name { get; set; }
        }

        public class Publisher
        {
            public delegate void EnvetHandler(object source, PersonEventArgs args);

            public event EnvetHandler ContactNotify;

            protected virtual void OnContactNotify(string person)
            {
                if (ContactNotify != null)
                    ContactNotify(this, new PersonEventArgs() { Name = person });
            }

            public void CountMessages(List<string> peopleList)
            {
                var pplCntr = peopleList.Distinct().ToDictionary(d => d, d => 0);
                foreach (string person in peopleList)
                {
                    pplCntr[person]++;
                    if (pplCntr[person] % 3 == 0)
                        OnContactNotify(person);
                }
            }
        }
    }
}