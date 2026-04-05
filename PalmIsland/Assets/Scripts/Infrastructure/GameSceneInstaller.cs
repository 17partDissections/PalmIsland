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

        public override void InstallBindings()
        {
            BindAudioHandler();
            BindCinemachineBrain();
            BindPlayer();
        }
        private void BindAudioHandler()
        {
            Container
                .Bind<AudioHandler>()
                .FromInstance(_audioHandler)
                .AsSingle()
                .NonLazy();
        }
        private void BindCinemachineBrain()
        {
            Container
                .Bind<CinemachineBrain>()
                .FromInstance(_cinemachineBrain)
                .AsSingle()
                .NonLazy();
        }
        private void BindPlayer()
        {
            Container
                .Bind<Player.Player>()
                .FromInstance(_playerInstance)
                .AsSingle()
                .NonLazy();
        }
        public void Awake()
        {
            _playerInstance.Init(_audioHandler, _cinemachineBrain);
        }
    }
}
