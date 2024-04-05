using System;
using UnityEngine;
using Zenject;

public class DesktopInput : IInput, ITickable
{
    public event Action OnClickUp;
    public event Action OnClickLeft;
    public event Action OnClickRight;
    public event Action OnButtonUp;

    public void Tick()
    {
        if (Input.GetKey(KeyCode.A))
            OnClickLeft?.Invoke();
        if(Input.GetKey(KeyCode.D))
            OnClickRight?.Invoke();
        if (Input.GetKeyDown(KeyCode.W))
            OnClickUp?.Invoke();
        if (Input.GetKeyUp(KeyCode.A))
            OnButtonUp?.Invoke();
        if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
            OnButtonUp?.Invoke();
    }
}