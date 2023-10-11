using System;
using FlareSurvivors.Input.Interfaces;
using UnityEngine;

namespace FlareSurvivors.Input
{
    public class InputReader : IInputReader, IDisposable
    {
        
        private readonly FlareInputActions _controls;
        
        
        
        
        public Vector2 MoveInput => _controls.Player.Move.ReadValue<Vector2>();

        public InputReader()
        {
            _controls = new FlareInputActions();
            _controls.Enable();
        }

        public void Dispose()
        {
            _controls.Disable();
        }
    }
}
