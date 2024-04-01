using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerConfig _playerConfig;
    public override void InstallBindings()
    {
        BindMovement();
        BindPlayer();
    }

    private void BindPlayer()
    {
        Container.Bind<PlayerConfig>().FromInstance(_playerConfig);
        Player player = Container.InstantiatePrefabForComponent<Player>(_player, _playerSpawnPoint.position, Quaternion.identity, null);
        Container.BindInterfacesAndSelfTo<Player>().FromInstance(player).AsSingle();
    }

    private void BindMovement()
    {
        Container.BindInterfacesAndSelfTo<MovementHandler>().AsSingle().NonLazy();
    }
}