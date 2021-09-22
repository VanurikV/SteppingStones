using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using Stone;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedScript : MonoBehaviour
{
    public EcsStartup esc;

    public void onRestart()
    {
        EcsEntity ent = esc._world.NewEntity();
        ent.Get<RestartComponent>();

        gameObject.SetActive(false);
    }

    public void onResume()
    {

        EcsEntity ent = esc._world.NewEntity();
        ent.Get<StatusComponent>();
        ent.Get<ResumeMenuComponent>();

        gameObject.SetActive(false);
    }


    public void onExit()
    {
        SceneManager.LoadScene(0);
    }



    public void SetActive(bool b)
    {
        gameObject.SetActive(b);
    }

}
