using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using Stone;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    public EcsStartup esc;

    public void onRestart()
    {
        EcsEntity ent = esc._world.NewEntity();
        ent.Get<RestartComponent>();
    }

}
