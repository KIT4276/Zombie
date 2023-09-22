using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject _playerPrefab;
    [SerializeField]
    private GameObject _cameraPrefab;

    [SerializeField]
    private AIDTrigger _aidPrefab;

    public override void InstallBindings()
    {
        InstallAidFactory();

        InstallPlayer();
        InstallCamera();

        InstallPostSystem();
        InstallAddressSystem();

        
    }

    private void InstallPlayer()
    {
        Player playerInstance = Container.InstantiatePrefabForComponent<Player>
            (_playerPrefab, new Vector3(0, 2, -35), new Quaternion(0, 90, 0, 0), null);
        Container.Bind<Player>().FromInstance(playerInstance).AsSingle().NonLazy();
    }

    private void InstallCamera()
    {
        CameraPoint cameraInstance = Container.InstantiatePrefabForComponent<CameraPoint>
            (_cameraPrefab, Vector3.zero, Quaternion.identity, null);
        Container.Bind<CameraPoint>().FromInstance(cameraInstance).AsSingle().NonLazy();
    }

    private void InstallPostSystem()
    {
        PostSystem postSystemInstance = Container.Instantiate<PostSystem>();
        Container.Bind<PostSystem>().FromInstance(postSystemInstance);
    }

    private void InstallAddressSystem()
    {
        AddressSystem addressSystemInstance = Container.Instantiate<AddressSystem>();
        Container.Bind<AddressSystem>().FromInstance(addressSystemInstance);
    }

    private void InstallAidFactory()
    {
        Container.Bind<AIDFactoriy>().AsSingle();
        Container.BindMemoryPool<AIDTrigger, AIDTrigger.Pool>().FromComponentInNewPrefab(_aidPrefab);
    }


}