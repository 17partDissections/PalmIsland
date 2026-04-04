using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace Q17pD.PalmIsland.Infrastructure
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private AudioHandler _audioHandler;
        [SerializeField] private CinemachineBrain _cinemachineBrain;

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
    }
}
