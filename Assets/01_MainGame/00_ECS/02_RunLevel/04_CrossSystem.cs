using Leopotam.Ecs;
using UnityEngine;

namespace Stone {
    sealed class S_04_CrossSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private EcsFilter<CellComponent, WaitForCrossSelectComponent> _filter = null;
        private EcsFilter<StatusComponent, PauseMenuComponent> _pauseFilter = null;


        void IEcsRunSystem.Run()
        {
            if (!_filter.IsEmpty() && _pauseFilter.IsEmpty())
            {
                if (Input.GetMouseButtonDown(0))
                {
                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out var hitInfo) && hitInfo.collider.tag == "Cross")
                    {
                        
                        _filter.Get1(0).obj.GetComponent<StoneScript>().CrossShow(false);
                        _filter.GetEntity(0).Del<WaitForCrossSelectComponent>();

                        Vector2Int dir=Vector2Int.zero;

                        switch (hitInfo.collider.gameObject.name)
                        {
                            case "ArrowUp":
                                dir= Vector2Int.down;
                                break;
                            case "ArrowDown":
                                dir = Vector2Int.up;
                                break;
                            case "ArrowLeft":
                                dir = Vector2Int.left;
                                break;
                            case "ArrowRight":
                                dir = Vector2Int.right;
                                break;
                        }

                        //Debug.Log("Unrool "+dir);
                        _filter.GetEntity(0).Get<UnRoolComponent>().Dir = dir;
                      

                    }
                    else
                    {
                        ReturnToSelect();
                    }
                }
            }
        }

        private void ReturnToSelect()
        {
            

            _filter.Get1(0).obj.GetComponent<StoneScript>().CrossShow(false);
            _filter.GetEntity(0).Del<WaitForCrossSelectComponent>();

            EcsEntity ent = _world.NewEntity();
            ent.Get<StatusComponent>();
            ent.Get<WaitForSelectComponent>();

        }

    }
}