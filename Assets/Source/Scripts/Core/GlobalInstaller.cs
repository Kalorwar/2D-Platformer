using UnityEngine;
using Zenject;

public class GlobalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindInput();
        SceneServiceBind();
    }
    
    private void SceneServiceBind()
    {
        Container.Bind<SceneService>().FromComponentInNewPrefabResource("Core/Services/SceneService").AsSingle();
    }

    private void BindInput()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
            Container.BindInterfacesTo<DesktopInput>().FromNew().AsSingle();
        else
            Container.BindInterfacesTo<MobileInput>().FromNew().AsSingle();
    }
}
