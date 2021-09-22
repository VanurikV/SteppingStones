using Leopotam.Ecs;

namespace Stone {
    sealed class S_10_SoundFxSystem : IEcsRunSystem
    {
        // auto-injected fields.
        //readonly EcsWorld _world = null;
        private GlobalData _globalData = null;

        private EcsFilter<SoundFxStoneClickComponent> _stoneClickFilter = null;
        private EcsFilter<SoundFxStoneUnroolComponent> _stoneUnroolFilter = null;
        private EcsFilter<SoundFxButtonClickComponent> _buttonFilter = null;


        void IEcsRunSystem.Run ()
        {
            if (!_stoneClickFilter.IsEmpty())
            {
                _globalData.SoundFxScript.PlayFx(SoundFx.StoneClick);
            }

            if (!_stoneUnroolFilter.IsEmpty())
            {
                _globalData.SoundFxScript.PlayFx(SoundFx.StoneUnrool);
            }

            if (!_buttonFilter.IsEmpty())
            {
                _globalData.SoundFxScript.PlayFx(SoundFx.ButtonClick);
            }

        }
    }
}