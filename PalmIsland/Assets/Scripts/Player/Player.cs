using Q17pD;
using Q17pD.PalmIsland.Factories;
using Unity.Cinemachine;
using UnityEngine;

namespace Q17pD.PalmIsland.Player
{
    public class Player : MonoBehaviour
    {
        private PlayerActionMap _actionMap;
        private Movement _movement; private GroundCheck _groundCheck; private Rotation _rotation;
        private Inventory _inventory; private EntityDetector _entityDetector; private Canvas.Canvas _canvas;
        
        public void Init(AudioHandler audioHandler, CinemachineBrain cinemachineBrain, ItemObjectPool itemObjectPool)
        {
            _actionMap = new PlayerActionMap();
            _actionMap.Player.Enable();

            _groundCheck = GetComponentInChildren<GroundCheck>();
            _groundCheck.Init(audioHandler);

            _rotation = GetComponentInChildren<Rotation>();
            _rotation.Init(_actionMap);

            TryGetComponent<Movement>(out _movement); TryGetComponent<Inventory>(out _inventory);
            _movement.Init(_actionMap, audioHandler, _groundCheck, _rotation.gameObject); _inventory.Init(audioHandler, itemObjectPool, cinemachineBrain);

            _canvas = GetComponentInChildren<Canvas.Canvas>();
            _canvas.Init(_actionMap, _inventory);

            _entityDetector = GetComponentInChildren<EntityDetector>();
            _entityDetector.Init(_actionMap, _inventory, _canvas, cinemachineBrain.GetComponent<Camera>());

        }
        private void OnDestroy() { _actionMap.Disable(); _actionMap.Dispose(); }
    }
}
