using System;
using Zenject;

public class MobileInput : IInput, ITickable
{
    public event Action OnClickUp;
    public event Action OnClickLeft;
    public event Action OnClickRight;
    
    public void Tick()
    {
        
    }
}