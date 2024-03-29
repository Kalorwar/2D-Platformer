using UnityEngine;
using Zenject;

public class GlobalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindInput();
    }

    private void BindInput()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
            Container.BindInterfacesTo<DesktopInput>().FromNew().AsSingle();
        else
            Container.BindInterfacesTo<MobileInput>().FromNew().AsSingle();
    }
}
