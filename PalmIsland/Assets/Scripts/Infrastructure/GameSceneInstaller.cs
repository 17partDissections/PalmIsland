using Q17pD.PalmIsland.Factories;
using Q17pD.PalmIsland.Interface;
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
        private ItemObjectPool _itemObjectPool;

        public override void InstallBindings()
        {
            BindAudioHandler();
            BindCinemachineBrain();
            BindPlayer();
            BindObjectPool();
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
        private void BindObjectPool()
        {
            _itemObjectPool = new ItemObjectPool();
            Container
                .Bind<ItemObjectPool>()
                .FromInstance(_itemObjectPool)
                .AsSingle()
                .Lazy();
        }
        public void Awake()
        {
            _playerInstance.Init(_audioHandler, _cinemachineBrain, _itemObjectPool);
        }
    }
}
