using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace Stone
{
    public class LevelCompliteScript : MonoBehaviour
    {
        public EcsStartup esc;

        public void onLevelComplite()
        {
            this.transform.gameObject.SetActive(false);

            EcsEntity ent = esc._world.NewEntity();
            ent.Get<RestartComponent>();

            ent = esc._world.NewEntity();
            ent.Get<SoundPlayTrackChangeComponent>();

        }
    }
}
