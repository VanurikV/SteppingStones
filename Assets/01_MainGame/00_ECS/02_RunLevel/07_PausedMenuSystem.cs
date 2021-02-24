using System.Linq;
using Leopotam.Ecs;
using UnityEngine;

namespace Stone {
    sealed class S_07_PausedMenuSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private EcsFilter<StatusComponent, PauseMenuComponent> _pauseFilter = null;
        private EcsFilter<StatusComponent, ResumeMenuComponent> _resumeFilter = null;

        private float btnTime=0;


        private PausedScript PauseObject;

        void IEcsRunSystem.Run ()
        {
            if (PauseObject == null)
            {
                PauseObject = GameObject.Find("Canvas").gameObject.GetComponentsInChildren(typeof(PausedScript), true).First().gameObject.GetComponent<PausedScript>();
            }

            if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Menu))
            {

                if ( (Time.fixedTime - btnTime)<1 )
                {
                    return;
                }

                _world.NewEntity().Get<SoundFxButtonClickComponent>();

                btnTime = Time.time;


                if (PauseObject.gameObject.active==false)
                {
                    PauseObject.SetActive(true);

                    EcsEntity ent = PauseObject.esc._world.NewEntity();
                    ent.Get<StatusComponent>();
                    ent.Get<PauseMenuComponent>();
                }
                else
                {
                    PauseObject.SetActive(false);

                    foreach (int i in _pauseFilter)
                    {
                        ref var entity = ref _pauseFilter.GetEntity(i);
                        entity.Destroy();
                    }

                }
            }

            if (!_resumeFilter.IsEmpty())
            {
                PauseObject.SetActive(false);

                foreach (int i in _pauseFilter)
                {
                    ref var entity = ref _pauseFilter.GetEntity(i);
                    entity.Destroy();
                }

                foreach (int i in _resumeFilter)
                {
                    ref var entity = ref _resumeFilter.GetEntity(i);
                    entity.Destroy();
                }

            }

        }
    }
}