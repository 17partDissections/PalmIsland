using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace Q17pD.PalmIsland
{
    public class LightStalk : MonoBehaviour
    {
        [Range(0, 180)][SerializeField] private int _curve = 45;
        private CinemachineBrain _cinemachineBrain;
        [Inject] private void Construct(CinemachineBrain cinemachineBrain) { _cinemachineBrain = cinemachineBrain; }
        void Update() { transform.rotation = _cinemachineBrain.transform.rotation * Quaternion.Euler(_curve, 0, 0); }
    }
}
