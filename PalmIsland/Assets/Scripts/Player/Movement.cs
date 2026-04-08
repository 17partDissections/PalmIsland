using Q17pD;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Q17pD.PalmIsland.Player
{
    public class Movement : MonoBehaviour
    {
        [Range(1, 10)][SerializeField] private float _speed = 6;
        private GameObject _rotation;
        private Rigidbody _rigidbody;
        private Vector2 _moveInput;
        private GroundCheck _groundCheck;
        private AudioHandler _audioHandler;

        public void Init(PlayerActionMap actionMap, AudioHandler audioHandler, GroundCheck groundCheck, GameObject rotation)
        {
            _audioHandler = audioHandler;
            _groundCheck = groundCheck;
            _rotation = rotation;
            _rigidbody = GetComponent<Rigidbody>();
            actionMap.Player.Move.performed += Move;
            actionMap.Player.Move.canceled += StopMove;
        }
        private void Move(InputAction.CallbackContext context) { _moveInput = context.ReadValue<Vector2>(); _groundCheck.IsMoving = true; }
        private void StopMove(InputAction.CallbackContext context) { _moveInput = Vector2.zero; _groundCheck.IsMoving = false; }
        private void FixedUpdate()
        {
            GroundedRigidbodySync();
            ControlTheSpeed();
            Vector3 forward = _rotation.transform.forward;
            Vector3 right = _rotation.transform.right;
            forward.y = 0; forward.Normalize(); 
            right.y = 0; right.Normalize();
            Vector3 direction = (forward * _moveInput.y + right * _moveInput.x).normalized;
            _rigidbody.AddForce(direction * _speed * 10, ForceMode.Force);
        }
        private void GroundedRigidbodySync()
        {
            if (_groundCheck.Grounded) _rigidbody.linearDamping = 5f;
            else _rigidbody.linearDamping = 0; 
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
    }
}