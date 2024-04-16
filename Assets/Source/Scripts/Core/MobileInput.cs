using System;
using Zenject;

public class MobileInput : IInput, ITickable
{
    public event Action OnClickUp;
    public event Action OnClickLeft;
    public event Action OnClickRight;
    public event Action NotClickUp;
    public event Action OnButtonUp;
    public event Action OnButtonAction;
    public event Action NotClickRight;

    public void Tick()
    {
        
    }
}