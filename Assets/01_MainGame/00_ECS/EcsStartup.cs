using Leopotam.Ecs;
using UnityEngine;

namespace Stone
{
    public class EcsStartup : MonoBehaviour
    {
       
        EcsSystems _systems;
        public EcsWorld _world;
        public GlobalData _globalData;

        void Start()
        {
            // void can be switched to IEnumerator for support coroutines.

            _globalData = new GlobalData();
            _globalData.AllLevelMap = new Cell[Const.MaxLevel][,];

            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
            _systems
                // register your systems here, for example:
                // .Add (new TestSystem1 ())
                // .Add (new TestSystem2 ())
                .Add(new InitAllSystem())

                .Add(new S_04_CrossSystem())
                

                .Add(new S_01_RestartSystem())
                .Add(new S_03_SelectSystem())
                .Add(new S_05_UnRoolSystem())

                .Add(new S_06_FinishSystem())



                .Add(new S_07_PausedMenuSystem())



                .Add(new S_10_SoundFxSystem())
                .Add(new S_11_SoundPalySystem())


                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                //.OneFrame<RestartComponent>()
                .OneFrame<FinishComponent>()

                .OneFrame<SoundFxStoneClickComponent>()
                .OneFrame<SoundFxStoneUnroolComponent>()
                .OneFrame<SoundFxButtonClickComponent>()
                .OneFrame<SoundPlayTrackChangeComponent>()


                // inject service instances here (order doesn't important), for example:
                // .Inject (new CameraService ())
                // .Inject (new NavMeshSupport ())

                .Inject(_globalData)

                .Init();
        }

        void Update()
        {
            _systems?.Run();
        }

        void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}