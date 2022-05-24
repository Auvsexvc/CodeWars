using Kata.Interfaces;
using System;

namespace Kata.Classes
{
    /// <summary>
    /// You have to construct a car. Step by Step. Kata by Kata.
    /// First you have to implement the engine and the fuel tank.
    /// The default fuel level of a car is 20 liters.
    /// The maximum size of the tank is 60 liters.
    /// Of course every car's life begins with an engine not running. ;-)
    /// Every call of a method from the car correlates to 1 second.
    /// The fuel consumption in running idle is 0.0003 liter/second.
    /// For convenience the start of the engine consumes nothing and we don't care, if the engine is warm or cold.
    /// The fuel tank is on reserve, if the level is under 5 liters.
    /// The fuel tank display shows the level as rounded for 2 decimal places.
    /// Internally an accuracy up to 10 decimal places should be more than enough.
    /// In difference to most real cars, the fuel tank display is always showing its information, also when the the engine is not running.
    /// And consider the locigal things about fuel and engine... ;-)
    /// In all tests only the whole car will be tested. Feel free to write your own tests for the other classes.
    /// As second step you have to implement the logic for driving, which includes accelerating, braking and free-wheeling.
    /// If the car is free-wheeling (no pedal is used), it slows down the car by 1 km/h by air resistance and rolling resistance.
    /// Braking is BY a speed. Accelerating is TO a speed. (Remember: Every call of a method from the car correlates to 1 second.)
    /// For every car the default acceleration is at most 10 km/h per second.
    /// In a new further constructor of the car it should be possible to set a higher acceleration. The value has always to be in a range from 5 to 20. Correct if under minimum or above maximum.
    /// Every car brakes at most 10 km/h per second. (Very bad brakes, I know... This car would braking bad. :D)
    /// The maximum speed of a car is 250 km/h and of course it cannot have a negative speed.
    /// The consumption for a driving car is be taken from these ranges:
    /// 1 - 60 km/h -> 0.0020 liter/second
    /// 61 - 100 km/h -> 0.0014 liter/second
    /// 101 - 140 km/h -> 0.0020 liter/second
    /// 141 - 200 km/h -> 0.0025 liter/second
    /// 201 - 250 km/h -> 0.0030 liter/second
    /// (When the car brakes or freewheels with getting slower, there is no fuel consumption as in modern cars, when the car "powers" the engine.)
    /// For convenience the accelerations and brakings are always linear and consumption is only for the speed at the end of every second. No considering on higher consumption while accelerating within a second
    /// In all tests only the whole car will be tested. Feel free to write your own tests for the other classes.
    /// </summary>
    internal class Constructing_a_car
    {
        public class Car : ICar
        {
            public IFuelTankDisplay fuelTankDisplay;
            private IEngine engine;
            private IFuelTank fuelTank;
            public IDrivingInformationDisplay drivingInformationDisplay;
            private IDrivingProcessor drivingProcessor;

            public bool EngineIsRunning { get => engine.IsRunning; }

            public Car(double fuelLevel = 20, int maxAcceleration = 10) // car #2
            {
                drivingProcessor = new DrivingProcessor(maxAcceleration);
                drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);
                fuelTank = new FuelTank(fuelLevel);
                engine = new Engine(fuelTank);
                fuelTankDisplay = new FuelTankDisplay(fuelTank);
            }

            public void EngineStart()
            {
                if(!EngineIsRunning && fuelTank.FillLevel >= 0.0003)
                    engine.Start();
            }

            public void EngineStop()
            {
                if(EngineIsRunning)
                    engine.Stop();
            }

            public void Refuel(double liters)
            {
                fuelTank.Refuel(liters);
            }

            public void RunningIdle()
            {
                engine.Consume(0.0003);
            }

            public void BrakeBy(int speed)
            {
                drivingProcessor.ReduceSpeed(speed);
                RunningIdle();
            }

            public void Accelerate(int speed)
            {
                if (engine.IsRunning)
                {
                    drivingProcessor.IncreaseSpeedTo(speed);
                    if (drivingProcessor.ActualSpeed >= 1 && drivingProcessor.ActualSpeed <= 60)
                        engine.Consume(0.0020);
                    else if (drivingProcessor.ActualSpeed >= 61 && drivingProcessor.ActualSpeed <= 100)
                        engine.Consume(0.0014);
                    else if (drivingProcessor.ActualSpeed >= 101 && drivingProcessor.ActualSpeed <= 140)
                        engine.Consume(0.0020);
                    else if (drivingProcessor.ActualSpeed >= 141 && drivingProcessor.ActualSpeed <= 200)
                        engine.Consume(0.0025);
                    else if(drivingProcessor.ActualSpeed >= 141 && drivingProcessor.ActualSpeed <= 250)
                        engine.Consume(0.0030);
                    else
                        RunningIdle();
                }
                if (speed < drivingProcessor.ActualSpeed)
                    FreeWheel();
            }

            public void FreeWheel()
            {
                if (drivingProcessor.ActualSpeed > 0)
                    drivingProcessor.ReduceSpeed(1);
                else
                    RunningIdle();
            }
        }

        public class DrivingInformationDisplay : IDrivingInformationDisplay // car #2
        {
            private IDrivingProcessor _drivingProcessor;
            public int ActualSpeed { get => _drivingProcessor.ActualSpeed; }

            public DrivingInformationDisplay(IDrivingProcessor drivingProcessor)
            {
                _drivingProcessor = drivingProcessor;
            }
        }

        public class DrivingProcessor : IDrivingProcessor // car #2
        {
            private int _actualSpeed;
            private int _maxSpeed = 250;
            private int _acceleration = 10;
            private int _maxAcc = 20;
            private int _minAcc = 5;
            private int _maxBraking = 10;

            public int ActualSpeed { get => _actualSpeed; }

            public DrivingProcessor(int acceleration)
            {
                if(acceleration < _minAcc)
                    _acceleration = _minAcc;
                else if (acceleration > _maxAcc)
                    _acceleration = _maxAcc;
                else
                    _acceleration = acceleration;
            }

            public void IncreaseSpeedTo(int speed)
            {
                if (speed >= _maxSpeed)
                    speed = _maxSpeed;

                if (_actualSpeed < speed)
                {
                    if(speed >=_actualSpeed + _acceleration)
                        _actualSpeed += _acceleration;
                    else
                        _actualSpeed += speed - _actualSpeed;
                }
            }

            public void ReduceSpeed(int speed)
            {
                if (speed <= 0 )
                {
                    speed = 0;
                }
                if (_actualSpeed >= speed)
                {
                    if (speed <= _maxBraking)
                        _actualSpeed -= speed;
                    else
                        _actualSpeed -= _maxBraking;
                }
                else
                    _actualSpeed -= _actualSpeed;
            }
        }

        public class Engine : IEngine
        {
            private bool _isRunning = false;
            private IFuelTank _fuelTank;

            public bool IsRunning { get => _isRunning; }

            public Engine(IFuelTank fuelTank)
            {
                _fuelTank = fuelTank;
            }

            public void Consume(double liters)
            {
                if (_isRunning)
                {
                    _fuelTank.Consume(liters);
                    if (_fuelTank.FillLevel == 0)
                        Stop();
                }
            }

            public void Start()
            {
                _isRunning = true;
            }

            public void Stop()
            {
                _isRunning = false;
            }
        }

        public class FuelTank : IFuelTank
        {
            private double _fillLevel;
            private double _tankCap = 60;
            private double _defaultFill = 20;
            private double _reserve = 5;

            public double FillLevel { get => _fillLevel; }
            public bool IsOnReserve { get => _fillLevel < _reserve; }
            public bool IsComplete { get => _fillLevel == _tankCap; }

            public FuelTank()
            {
                _fillLevel = _defaultFill;
            }

            public FuelTank(double fuelLevel)
            {
                if (fuelLevel < 0)
                    fuelLevel = 0;
                if (fuelLevel > _tankCap)
                    fuelLevel = _tankCap;
                _fillLevel = fuelLevel;
            }

            public void Consume(double liters)
            {
                if (_fillLevel > 0)
                {
                    _fillLevel -= liters;
                    _fillLevel = Math.Round(_fillLevel, 10);
                }
                else
                    _fillLevel = 0;
            }

            public void Refuel(double liters)
            {
                _fillLevel += liters;
                if (_fillLevel > _tankCap)
                    _fillLevel = _tankCap;
            }
        }

        public class FuelTankDisplay : IFuelTankDisplay
        {
            private IFuelTank _fuelTank;

            public double FillLevel { get => Math.Round(_fuelTank.FillLevel, 2); }
            public bool IsOnReserve { get => _fuelTank.IsOnReserve; }
            public bool IsComplete { get => _fuelTank.IsComplete; }

            public FuelTankDisplay(IFuelTank fuelTank)
            {
                _fuelTank = fuelTank;
            }
        }
    }
}