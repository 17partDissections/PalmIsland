using DFTGames.Localization;
using Q17pD.PalmIsland.Interface;
using Q17pD.PalmIsland.Entities;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Q17pD.PalmIsland.Player
{
    public class EntityDetector : MonoBehaviour
    {
        [Range(1,50)][SerializeField] private int _distance = 10;
        private Camera _camera;
        private RectTransform _crosshair;
        private WaitForSeconds _sleep = new WaitForSeconds(0.1f);
        private IObservable _lastObservableItem;
        private Canvas.Canvas _canvas;
        private Inventory _inventory;

        public void Init(PlayerActionMap actionMap, Inventory inventory, Canvas.Canvas canvas, Camera camera)
        {
            _inventory = inventory;
            _canvas = canvas;
            _crosshair = _canvas.Crosshair.rectTransform;
            actionMap.Player.Interact.started += Interact;
            _camera = camera;
        }
        private IEnumerator Start()
        {
            while (true)
            {
                yield return _sleep;
                Ray ray = RectTransformUtility.ScreenPointToRay(_camera, _crosshair.position);

                if (Physics.Raycast(ray, out RaycastHit hit, _distance))
                {
                    if (hit.transform.TryGetComponent<IObservable>(out IObservable observableItem))
                    {
                        _canvas.ChangeCrosshair(observableItem.Type, observableItem.NameKey);
                        _lastObservableItem = observableItem;
                    }
                    else if (_lastObservableItem != null) { _canvas.ChangeCrosshair(); _lastObservableItem = null; }
                }
                else if (_lastObservableItem != null) { _canvas.ChangeCrosshair(); _lastObservableItem = null; }
            }
        }
        private void Interact(InputAction.CallbackContext context)
        {
            Ray ray = RectTransformUtility.ScreenPointToRay(_camera, _crosshair.position);
            if (Physics.Raycast(ray, out RaycastHit hit, _distance))
            {
                if (hit.transform.TryGetComponent<IInterectable>(out IInterectable interectableItem)) interectableItem.Interact(_inventory, _canvas);
            }
        }
    }
}
