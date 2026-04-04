using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace Q17pD.PalmIsland.Infrastructure
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private AudioHandler _audioHandler;
        [SerializeField] private CinemachineBrain _cinemachineBrain;
        [SerializeField] private Player.Player _playerInstance;
        [SerializeField] private List<Palm> _palms;

        public override void InstallBindings()
        {
            BindAudioHandler();
        }
        private void BindAudioHandler()
        {
            Container
                .Bind<AudioHandler>()
                .FromInstance(_audioHandler)
                .AsSingle()
                .NonLazy();
        }
        public void Awake()
        {
            _playerInstance.Init(_audioHandler, _cinemachineBrain);
            foreach (var palm in _palms) palm.Init(_playerInstance);
        }
    }
}
