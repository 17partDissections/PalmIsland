using DG.Tweening;
using UnityEngine;

namespace Q17pD.PalmIsland.Menu
{
    public class MenuButtonsRotate : MonoBehaviour
    {
        [SerializeField] private GameObject _objToRotate;
        [SerializeField] private float _duration = 0.3f;
        [SerializeField] private Ease _rotateEase = Ease.OutBack;
        [SerializeField] private Ease _resetEase = Ease.InOutQuad;
        public void Rotate(float value)
        {
            _objToRotate.transform.DOKill();
            _objToRotate.transform.DORotate(new Vector3(0, 0, value), _duration).SetEase(_rotateEase);
        }
        public void ResetRotation(bool kill)
        {
            if(kill) _objToRotate.transform.DOKill();
            _objToRotate.transform.DORotate(Vector3.zero, _duration).SetEase(_resetEase);
        }
    }
}
