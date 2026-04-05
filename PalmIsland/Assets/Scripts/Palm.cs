using Q17pD.PalmIsland.Interface;
using UnityEngine;
using UnityEngine.AI;

namespace Q17pD.PalmIsland
{
    public class Palm : MonoBehaviour, IObservable
    {
        [SerializeField] private string _palmNameKey;
        [SerializeField] private bool _doPatrol, _isAgressive;
        private NavMeshAgent _agent;
        private Player.Player _player;
        public string NameKey { get => _palmNameKey; }
        public ObservableType Type { get => ObservableType.Interact; }

        public void Init(Player.Player player)
        {
            _player = player;
            _agent = GetComponent<NavMeshAgent>();
        }
        private void Update()
        {
            LookAtPlayer();
        }
        private void LookAtPlayer() { transform.rotation = Quaternion.LookRotation(_player.transform.position - transform.position); }
    }
}
