using DFTGames.Localization;
using Q17pD.PalmIsland.Interface;
using Q17pD.PalmIsland.Items;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Q17pD.PalmIsland.Player
{
    public class EntityDetector : MonoBehaviour
    {
        private Camera _camera;
        private RectTransform _crosshair;
        private WaitForSeconds _sleep = new WaitForSeconds(0.1f);
        private LocalizeTMPro _nameText;
        private IObservable _lastObservableItem;
        private Canvas.Canvas _canvas;
        private Inventory _inventory;

        public void Init(PlayerActionMap actionMap, Inventory inventory, Canvas.Canvas canvas, Camera camera)
        {
            _inventory = inventory;
            _canvas = canvas;
            _nameText = _canvas.ItemNameText;
            _crosshair = _canvas.Crosshair.rectTransform;
            actionMap.Player.Interact.performed += Interact;
            _camera = camera;
        }
        private IEnumerator Start()
        {
            while (true)
            {
                yield return _sleep;
                Ray ray = RectTransformUtility.ScreenPointToRay(_camera, _crosshair.position);
                if (Physics.Raycast(ray, out RaycastHit hit, 5))
                {
                    if (hit.transform.TryGetComponent<IObservable>(out IObservable observableItem))
                    {
                        observableItem.ShowName(_nameText);
                        _lastObservableItem = observableItem;
                    }
                    else if (_lastObservableItem != null)
                    {
                        _lastObservableItem.HideName(_nameText);
                        _lastObservableItem = null;
                    }
                }
            }
        }
        private void Interact(InputAction.CallbackContext context)
        {
            Ray ray = RectTransformUtility.ScreenPointToRay(_camera, _crosshair.position);
            if (Physics.Raycast(ray, out RaycastHit hit, 5))
            {
                if (hit.transform.TryGetComponent<IInterectable>(out IInterectable interectableItem))
                    if(interectableItem is InGameItem)
                        interectableItem.Interact(_inventory, _canvas);
            }
        }

    }
}
