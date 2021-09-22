using Leopotam.Ecs;
using UnityEngine;

namespace Stone
{
    sealed class S_01_RestartSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private GlobalData _globalData = null;

        private EcsFilter<RestartComponent> _restartFilter = null;
        private EcsFilter<CellComponent> _allCell = null;
        private EcsFilter<StatusComponent> _statusFilter = null;
        void IEcsRunSystem.Run()
        {
            if (!_restartFilter.IsEmpty())
            {
                DeleteGameEnt();
                CopyLevelMap();
                CreateGameLevel();


                EcsEntity ent = _world.NewEntity();
                ent.Get<StatusComponent>();
                ent.Get<WaitForSelectComponent>();
            }
        }


        private void CreateGameLevel()
        {
            GameObject o;
            EcsEntity ent;

            for (int y = 0; y < Const.MapSize; y++)
            {
                for (int x = 0; x < Const.MapSize; x++)
                {
                    switch (_globalData.CurrentLevelMap[x, y].type)
                    {
                        case CellType.Filled:
                            o = GameObject.Instantiate(_globalData.StonePrefab);
                            o.transform.position = Const.Map2World(new Vector2Int(x, y));
                            
                            ent = _world.NewEntity();
                            ent.Get<CellComponent>().pos = new Vector2Int(x, y);
                            ent.Get<CellComponent>().obj = o;
                            break;

                        case CellType.Value:
                            o = GameObject.Instantiate(_globalData.StonePrefab);
                            o.transform.position = Const.Map2World(new Vector2Int(x, y));
                            o.GetComponent<StoneScript>().ShowNum(_globalData.CurrentLevelMap[x, y].value);

                            ent = _world.NewEntity();
                            ent.Get<CellComponent>().pos = new Vector2Int(x, y);
                            ent.Get<CellComponent>().obj = o;
                            break;

                        case CellType.Finish:
                            o = GameObject.Instantiate(_globalData.FinishPrefab);
                            o.transform.position = Const.Map2World(new Vector2Int(x, y));

                            ent = _world.NewEntity();
                            ent.Get<CellComponent>().pos = new Vector2Int(x, y);
                            o.GetComponent<FinishScript>().ShowRune(_globalData.CurrentLevel);
                            ent.Get<CellComponent>().obj = o;

                            break;

                    }
                }
            }

        }

        
        private void DeleteGameEnt()
        {
            foreach (int i in _allCell)
            {
                GameObject.Destroy(_allCell.Get1(i).obj);
                _allCell.GetEntity(i).Destroy();
                //ref var entity = ref _allCell.GetEntity(i);
                //entity.Destroy();
            }

            foreach (int i in _statusFilter)
            {
                _statusFilter.GetEntity(i).Destroy();
            }

            foreach (int i in _restartFilter)
            {
                _restartFilter.GetEntity(i).Destroy();
            }
        }

        
        private void CopyLevelMap()
        {

            _globalData.CurrentLevelMap = new Cell[Const.MapSize, Const.MapSize];

            for (int y = 0; y < Const.MapSize; y++)
            {
                for (int x = 0; x < Const.MapSize; x++)
                {
                    _globalData.CurrentLevelMap[x, y] = new Cell();

                    _globalData.CurrentLevelMap[x, y].value =
                        _globalData.AllLevelMap[_globalData.CurrentLevel][x, y].value;

                    _globalData.CurrentLevelMap[x, y].type =
                        _globalData.AllLevelMap[_globalData.CurrentLevel][x, y].type;
                }
            }
        }



    }
    }