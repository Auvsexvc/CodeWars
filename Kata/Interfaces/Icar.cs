using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Interfaces
{
    public interface ICar
    {
        bool EngineIsRunning { get; }

        void EngineStart();

        void EngineStop();

        void Refuel(double liters);

        void RunningIdle();

        void BrakeBy(int speed);

        void Accelerate(int speed);

        void FreeWheel();
    }
}
