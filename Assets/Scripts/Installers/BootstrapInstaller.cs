using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject _playerPrefab;
    [SerializeField]
    private GameObject _cameraPrefab;

    public override void InstallBindings()
    {
        InstallPlayer();
        InstallCamera();
    }

    private void InstallPlayer()
    {
        Player playerInstance = Container.InstantiatePrefabForComponent<Player>
            (_playerPrefab, new  Vector3(16,2,0), new Quaternion(0,90,0,0), null);
        Container.Bind<Player>().FromInstance(playerInstance).AsSingle().NonLazy();
    }

    private void InstallCamera()
    {
        CameraPoint cameraInstance = Container.InstantiatePrefabForComponent<CameraPoint>
            (_cameraPrefab, Vector3.zero, Quaternion.identity, null);
        Container.Bind<CameraPoint>().FromInstance(cameraInstance).AsSingle().NonLazy();
    }
}