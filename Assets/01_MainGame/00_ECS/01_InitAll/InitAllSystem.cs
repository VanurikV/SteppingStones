using Leopotam.Ecs;
using UnityEngine;

namespace Stone
{
    sealed partial class InitAllSystem : IEcsInitSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private GlobalData _globalData = null;


        public void Init ()
        {
            LoadLevels();

            LoadLevelData();

            //LoadPrefab();
            _globalData.StonePrefab = Resources.Load<GameObject>("Stone");
            _globalData.FinishPrefab = Resources.Load<GameObject>("Finish");

            //Init sound
            InitSound();

            EcsEntity ent = _world.NewEntity();
            ent.Get<SoundPlayTrackChangeComponent>();
            
            ent = _world.NewEntity();
            ent.Get<RestartComponent>();
        }

        
        public void LoadLevelData()
        {
            if (PlayerPrefs.HasKey("CurrentLevel"))
            {
                _globalData.CurrentLevel = PlayerPrefs.GetInt("CurrentLevel");
            }
            else
            {
                PlayerPrefs.SetInt("CurrentLevel", 0);
                PlayerPrefs.Save();
                _globalData.CurrentLevel = 0;
            }
        }


        public void InitSound()
        {

            _globalData.SoundFxScript = GameObject.Find("AudioFx").GetComponent<SoundFxScript>();
            _globalData.SoundPlayScript = GameObject.Find("AudioPlay").GetComponent<SoundPlayScript>();

            float vol = PlayerPrefs.GetFloat("PlayVolume");
            float fx = PlayerPrefs.GetFloat("FxVolume");


            GameObject.Find("AudioFx").GetComponent<AudioSource>().volume = fx;
            GameObject.Find("AudioPlay").GetComponent<AudioSource>().volume = vol;

        }


    }
}