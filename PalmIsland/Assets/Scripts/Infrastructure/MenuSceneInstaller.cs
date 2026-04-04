using Zenject;
using UnityEngine;

namespace Q17pD.PalmIsland.Infrastructure
{
    public class MenuSceneInstaller : MonoInstaller
    {
        [SerializeField] private AudioHandler _audioHandler;

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