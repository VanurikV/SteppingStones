using Leopotam.Ecs;
using UnityEngine;

namespace Stone
{
    sealed class S_05_UnRoolSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private GlobalData _globalData = null;
        private EcsFilter<CellComponent, UnRoolComponent> _filter = null;

        void IEcsRunSystem.Run()
        {
            if (!_filter.IsEmpty())
            {
                Vector2Int pos = _filter.Get1(0).pos;
                Vector2Int dir = _filter.Get2(0).Dir;

                EcsEntity ent;

                _filter.Get1(0).obj.GetComponent<StoneScript>().ShowNum(0);

                int len = _globalData.CurrentLevelMap[pos.x, pos.y].value;
                Vector2Int newPos=pos;
                
                _filter.GetEntity(0).Del<UnRoolComponent>();

                _globalData.CurrentLevelMap[pos.x, pos.y].value = 0;

                while (len > 0)
                {
                    newPos = newPos + dir;

                    if(newPos.x<0 || newPos.y<0) break;
                    if (newPos.x >= Const.MapSize || newPos.y >= Const.MapSize) break;

                    if (_globalData.CurrentLevelMap[newPos.x, newPos.y].type == CellType.Value)
                    {
                        continue;
                    }

                    if (_globalData.CurrentLevelMap[newPos.x, newPos.y].type == CellType.Filled)
                    {
                        continue;
                    }

                    if (_globalData.CurrentLevelMap[newPos.x, newPos.y].type == CellType.Empty)
                    {
                        len--;

                        _globalData.CurrentLevelMap[newPos.x, newPos.y].value = 0;
                        _globalData.CurrentLevelMap[newPos.x, newPos.y].type = CellType.Filled;

                        GameObject o = GameObject.Instantiate(_globalData.StonePrefab);
                        o.transform.position = Const.Map2World(new Vector2Int(newPos.x, newPos.y));

                        ent = _world.NewEntity();
                        ent.Get<CellComponent>().pos = newPos;
                        ent.Get<CellComponent>().obj = o;
                        
                    }

                    if (_globalData.CurrentLevelMap[newPos.x, newPos.y].type == CellType.Finish)
                    {
                        ent = _world.NewEntity();
                        ent.Get<FinishComponent>();
                        return;
                    }
                }

                _world.NewEntity().Get<SoundFxStoneUnroolComponent>();

                ent = _world.NewEntity();
                ent.Get<StatusComponent>();
                ent.Get<WaitForSelectComponent>();


            }
        }
    }
}