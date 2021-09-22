using Leopotam.Ecs;
using UnityEditor.UIElements;
using UnityEngine;

namespace Stone {
    sealed class S_03_SelectSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;

        private GlobalData _globalData = null;

        private EcsFilter<CellComponent> _filter = null;
        private EcsFilter<StatusComponent,WaitForSelectComponent> _select = null;
        private EcsFilter<StatusComponent, PauseMenuComponent> _pauseFilter = null;

        void IEcsRunSystem.Run ()
        {
            if (!_select.IsEmpty() && _pauseFilter.IsEmpty())
            {
                if (Input.GetMouseButtonDown(0))
                {
                    var currentLayer = LayerMask.GetMask("Stone");
                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out var hitInfo, currentLayer) && hitInfo.collider.tag=="Stone")
                    {
                        //Debug.Log(hitInfo.collider);

                        foreach (int i in _filter)
                        {
                            if (_filter.Get1(i).obj == hitInfo.collider.gameObject.transform.parent.gameObject)
                            {
                                if (_globalData.CurrentLevelMap[_filter.Get1(i).pos.x, _filter.Get1(i).pos.y].value > 0)
                                {
                                    _filter.GetEntity(i).Get<WaitForCrossSelectComponent>();

                                    
                                    _select.GetEntity(0).Destroy();

                                    _filter.Get1(i).obj.GetComponent<StoneScript>().CrossShow(true);

                                    if (_filter.Get1(i).pos.x == 0) _filter.Get1(i).obj.GetComponent<StoneScript>().CrossHide(Cross.ArrowLeft);
                                    if (_filter.Get1(i).pos.x == Const.MapSize - 1) _filter.Get1(i).obj.GetComponent<StoneScript>().CrossHide(Cross.ArrowRight);
                                    if (_filter.Get1(i).pos.y == 0) _filter.Get1(i).obj.GetComponent<StoneScript>().CrossHide(Cross.ArrowUp);
                                    if (_filter.Get1(i).pos.y == Const.MapSize - 1) _filter.Get1(i).obj.GetComponent<StoneScript>().CrossHide(Cross.ArrowDown);

                                    _world.NewEntity().Get<SoundFxStoneClickComponent>();

                                    break;
                                }
                            }
                        }

                        
                    }
                }
            }
        }
    }
}