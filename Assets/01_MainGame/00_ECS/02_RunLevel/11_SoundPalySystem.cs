using Leopotam.Ecs;

namespace Stone
{
    sealed class S_11_SoundPalySystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private GlobalData _globalData = null;

        private EcsFilter<SoundPlayTrackChangeComponent> _trackChangeFilter = null;

        void IEcsRunSystem.Run()
        {
            if (!_trackChangeFilter.IsEmpty())
            {
                _globalData.SoundPlayScript.PlayRandomTrack();
            }
        }
    }
}