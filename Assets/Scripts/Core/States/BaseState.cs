using System;

namespace FlareSurvivors.Core.States
{
    /// <summary>
    ///   Base class for all states.
    /// </summary>
    public abstract class BaseState : IDisposable
    {
        public abstract void Enter();
        public abstract void Tick();
        public abstract void Exit();
        public abstract void Dispose();
    }
}
