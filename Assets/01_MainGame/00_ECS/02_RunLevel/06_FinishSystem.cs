using System.Linq;
using Leopotam.Ecs;
using UnityEngine;

namespace Stone
{
    sealed class S_06_FinishSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private GlobalData _globalData = null;

        private EcsFilter<FinishComponent> _finishFilter = null;

        void IEcsRunSystem.Run()
        {
            if (!_finishFilter.IsEmpty())
            {
                SaveGameProggress();

                 GameObject.Find("Canvas").gameObject
                    .GetComponentsInChildren(typeof(LevelCompliteScript), true).First().gameObject.SetActive(true);

                GameObject.Find("AudioFx").GetComponent<SoundFxScript>().LevelCompliteFxPlay();


                //EcsEntity ent = _world.NewEntity();
                //ent.Get<RestartComponent>();
            }
        }


        public void SaveGameProggress()
        {
            _globalData.CurrentLevel++;

            if (_globalData.CurrentLevel >= Const.MaxLevel)
                _globalData.CurrentLevel = 0;

            PlayerPrefs.SetInt("CurrentLevel", _globalData.CurrentLevel);
            PlayerPrefs.Save();

            int MaxLevel = PlayerPrefs.GetInt("MaxCompliteLevel");
            if (MaxLevel < _globalData.CurrentLevel)
            {

                PlayerPrefs.SetInt("MaxCompliteLevel", _globalData.CurrentLevel);
                PlayerPrefs.Save();
            }

        }

    }
}