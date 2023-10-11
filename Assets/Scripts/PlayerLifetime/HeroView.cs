using UnityEngine;

namespace FlareSurvivors.PlayerLifetime
{
    [AddComponentMenu("Flare Survivors/Player Lifetime/Hero View")]
    public class HeroView : MonoBehaviour
    {
        private Animator _animator;
        private Rigidbody2D _rigidbody2D;
        
        public Animator Animator => _animator;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        
        private Vector2 _moveInput;
        private float _speed = 0f;
        private static readonly int X = Animator.StringToHash("X");
        private static readonly int Y = Animator.StringToHash("Y");
        private static readonly int Speed = Animator.StringToHash("Speed");

        public void Move(Vector2 direction)
        {
            _moveInput = direction;
            _speed = direction.magnitude;
            
            _rigidbody2D.MovePosition( _rigidbody2D.position + _moveInput * Time.fixedDeltaTime);

            UpdateAnimator();
        }

        public void Idle()
        {
            _speed = 0f;
            UpdateAnimator();

        }

        private void UpdateAnimator()
        {
            _animator.SetFloat(Speed, _speed);
            _animator.SetFloat(X, _moveInput.x);
            _animator.SetFloat(Y, _moveInput.y);
        }
    }
}
