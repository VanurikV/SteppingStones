using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace Stone
{
    public class LevelCompleteScript : MonoBehaviour
    {
        public EcsStartup esc;

        public void onLevelComplete()
        {
            this.transform.gameObject.SetActive(false);

            EcsEntity ent = esc._world.NewEntity();
            ent.Get<RestartComponent>();

            ent = esc._world.NewEntity();
            ent.Get<SoundPlayTrackChangeComponent>();

        }
    }
}
