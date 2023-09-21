using UnityEngine;
using Zenject;

public class CameraInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject _camera;
    
    public override void InstallBindings()
    {
        CameraPoint cameraInstance = Container.InstantiateComponent<CameraPoint>(_camera);
        Container.Bind<CameraPoint>().FromInstance(cameraInstance).AsSingle().NonLazy();
    }
}