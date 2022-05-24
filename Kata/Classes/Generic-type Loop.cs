using System.Collections.Generic;

namespace Kata.Classes
{
    /// <summary>
    /// You have seen many generic-type collections like Lists. When you want to use a List, you can create it for any type like List of int, List of string, List of arrays or ...
    ///     Your task is easy; you have to create a customized generic class named Loop; (it is a closed loop like a circle to rotate left and right)
    /// It has specific functionalities:
    /// You can add objects to it.It adds the object to the end of the Loop.The loop can also use collection initializer. (like a List)
    /// You can rotate it to the Right or Left.So the end and beginning of the loop are changed.I refer the test case to see more details.
    /// You can ShowFirst or PopOut the first item. Show just return the first item, while PopOut returns the first item while removing it from the loop.
    /// There is no situation to face empty list. You don't need to handle any exception.
    /// </summary>
    internal class Generic_type_Loop
    {
        public class Loop<T> : List<T>
        {
            private int _currentIndex;

            public int CurrentIndex
            {
                get
                {
                    if (_currentIndex > Count - 1) { _currentIndex = 0; }
                    if (_currentIndex < 0) { _currentIndex = Count - 1; }
                    return _currentIndex;
                }
                set => _currentIndex = value;
            }

            public int NextIndex
            {
                get
                {
                    if (_currentIndex == Count - 1) return 0;
                    return _currentIndex + 1;
                }
            }

            public int PreviousIndex
            {
                get
                {
                    if (_currentIndex == 0) return Count - 1;
                    return _currentIndex - 1;
                }
            }

            public void Left()
            {
                CurrentIndex = NextIndex;
            }

            public void Rigth()
            {
                CurrentIndex = PreviousIndex;
            }

            public T PopOut()
            {
                T popOut = this[CurrentIndex];
                RemoveAt(CurrentIndex);
                return popOut;
            }

            public T ShowFirst() => this[CurrentIndex];
        }
    }
}