using Q17pD;
using System.Collections;
using UnityEngine;

namespace Q17pD.PalmIsland.Player
{
    public class GroundCheck : MonoBehaviour
    {
        [HideInInspector] public bool Grounded, IsMoving;
        [Range(0.1f, 1f)][SerializeField] private float _maxDistance = 0.15f;
        Vector3 RaycastOrigin => transform.position + Vector3.up * 0.001f;
        float RaycastDistance => _maxDistance;

        private WaitForSeconds _sleep = new WaitForSeconds(0.5f);
        private AudioHandler _audioHandler;
        private Floor _floor;

        public void Update() { Grounded = Physics.Raycast(RaycastOrigin, Vector3.down, _maxDistance * 2); }
        public void Init(AudioHandler audioHandler) { _audioHandler = audioHandler; StartCoroutine(WalkSoundsCoroutine()); }
        private void OnTriggerEnter(Collider other) { other.TryGetComponent(out _floor); }
        private void OnTriggerExit(Collider other) { _floor = null; }
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
