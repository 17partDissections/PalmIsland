using Q17pD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Q17pD.PalmIsland.Player
{
    public class GroundCheck : MonoBehaviour
    {
        [HideInInspector] public bool Grounded, IsMoving;
        private WaitForSeconds _sleep = new WaitForSeconds(0.5f);
        private AudioHandler _audioHandler;
        private Floor _floor;

        public void Init(AudioHandler audioHandler) { _audioHandler = audioHandler; StartCoroutine(WalkSoundsCoroutine()); }
        private void OnTriggerEnter(Collider other) { if (other.TryGetComponent(out _floor)) Grounded = true; }
        private void OnTriggerExit(Collider other) { if (other.GetComponent<Floor>()) Grounded = false; }
        private void OnTriggerStay(Collider other) { if (other.GetComponent<Floor>()) Grounded = true; }
        private IEnumerator WalkSoundsCoroutine()
        {
            while (true)
            {
                if (IsMoving && Grounded) _audioHandler.PlaySFX(_floor.WalkSounds[Random.Range(0, _floor.WalkSounds.Count - 1)]);
                yield return _sleep;
            }
        }
    }
}
