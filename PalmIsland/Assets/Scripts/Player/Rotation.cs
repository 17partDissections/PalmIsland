using UnityEngine;
using UnityEngine.InputSystem;

namespace Q17pD.PalmIsland.Player
{
    public class Rotation : MonoBehaviour
    {
        [Range(1,20)][SerializeField] private float _sensitivity = 10f;
        [SerializeField] private bool _inverted;
        private float _x, _y;
        private Vector2 _lookDelta;

        public void Init(PlayerActionMap actionMap)
        {
            actionMap.Player.Look.performed += Look;
            actionMap.Player.Look.canceled += StopLook;
        }
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _x = transform.eulerAngles.x; _y = transform.eulerAngles.y;
        }
        private void Look(InputAction.CallbackContext context) { _lookDelta = context.ReadValue<Vector2>(); }
        private void StopLook(InputAction.CallbackContext context) { _lookDelta = Vector2.zero; }
        private void Update()
        {
            _x += (_inverted ? 1 : -1) * _lookDelta.y * Time.deltaTime * _sensitivity;
            _y += (_inverted ? -1 : 1) * _lookDelta.x * Time.deltaTime * _sensitivity;
            _x = Mathf.Clamp(_x, -90f, 90f);
            transform.rotation = Quaternion.Euler(_x, _y, 0f);
        }
    }
}