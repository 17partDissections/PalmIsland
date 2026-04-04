using Q17pD;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Q17pD.PalmIsland.Player
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _jumpForce = 10f;
        [SerializeField] private float _gravityMultiplier = 2f;
        [SerializeField] private AudioClip _jumpSound;
        [SerializeField] private GameObject _rotation;
        private Rigidbody _rigidbody;
        private Vector2 _moveInput;
        private GroundCheck _groundCheck;
        private AudioHandler _audioHandler;

        public void Init(PlayerActionMap actionMap, AudioHandler audioHandler, GroundCheck groundCheck)
        {
            _audioHandler = audioHandler;
            _groundCheck = groundCheck;
            _rigidbody = GetComponent<Rigidbody>();

            actionMap.Player.Move.performed += Move;
            actionMap.Player.Move.canceled += StopMove;
            actionMap.Player.Jump.performed += Jump;
        }
        private void Move(InputAction.CallbackContext context) { _moveInput = context.ReadValue<Vector2>(); _groundCheck.IsMoving = true; }
        private void StopMove(InputAction.CallbackContext context) { _moveInput = Vector2.zero; _groundCheck.IsMoving = false; }
        private void Jump(InputAction.CallbackContext context)
        {
            if (_groundCheck.Grounded && _jumpForce > 0)
            {
                _audioHandler.PlaySFX(_jumpSound);
                _rigidbody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
            }
        }
        private void FixedUpdate()
        {
            ApplyExtraGravity();
            GroundedRigidbodySync();
            ControlTheSpeed();
            Vector3 direction = _rotation.transform.TransformDirection(new Vector3(_moveInput.x, 0, _moveInput.y));
            _rigidbody.AddForce(direction.normalized * _speed, ForceMode.Force);
        }
        private void GroundedRigidbodySync()
        {
            if (_groundCheck.Grounded)
                _rigidbody.linearDamping = 5f;
            else
                _rigidbody.linearDamping = 0;
        }
        private void ControlTheSpeed()
        {
            Vector3 currentVel = new Vector3(_rigidbody.linearVelocity.x, 0, _rigidbody.linearVelocity.z);
            if (currentVel.magnitude > _speed)
            {
                Vector3 controlledSpeed = currentVel.normalized * _speed;
                _rigidbody.linearVelocity = new Vector3(controlledSpeed.x, _rigidbody.linearVelocity.y, controlledSpeed.z);
            }
        }
        private void ApplyExtraGravity() { if (!_groundCheck.Grounded) _rigidbody.AddForce(Physics.gravity * _gravityMultiplier, ForceMode.Acceleration); }
    }
}