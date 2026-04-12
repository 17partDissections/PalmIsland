using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Q17pD.PalmIsland.Menu
{
    public class Logos : MonoBehaviour
    {
        [SerializeField] private bool _skip;
        [SerializeField] private List<Logo> _logos;
        [SerializeField] private Image _logosBg;
        [SerializeField] private Image _logosDarkeningPanel;
        [SerializeField] private float _darkeningTime = 1f;
        [SerializeField] private List<GameObject> _mainObjs;
        [SerializeField] private List<GameObject> _otherObjs;
        [SerializeField] private UIHighlight _mainDarkeningPanel;

        private IEnumerator Start()
        {
            foreach (var obj in _otherObjs) obj.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            foreach (var obj in _otherObjs) obj.SetActive(false);
            if (_skip) { foreach (var obj in _mainObjs) obj.SetActive(true); _logosDarkeningPanel.enabled = false; _logosBg.enabled = false; StopAllCoroutines(); }
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            yield return new WaitForSeconds(_darkeningTime);
            foreach(Logo logo in _logos)
            {
                logo._logoObj.SetActive(true);
                _logosDarkeningPanel.DOFade(0f, _darkeningTime);
                yield return new WaitForSeconds(_darkeningTime);
                yield return new WaitForSeconds(logo._time);
                _logosDarkeningPanel.DOFade(1f, _darkeningTime);
                yield return new WaitForSeconds(_darkeningTime);
                logo._logoObj.SetActive(false);
                
            }
            _mainDarkeningPanel.gameObject.SetActive(true);
            foreach (var obj in _mainObjs) obj.SetActive(true);
            _logosDarkeningPanel.enabled = false;
            _logosBg.enabled = false;
            yield return new WaitForSeconds(_darkeningTime);
            _mainDarkeningPanel.UnHighlightImage(_darkeningTime);
            yield return new WaitForSeconds(_darkeningTime);
            _mainDarkeningPanel.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            gameObject.SetActive(false);
            
        }
    }
    [System.Serializable] public class Logo{ public GameObject _logoObj; [SerializeField] public float _time; }
}
