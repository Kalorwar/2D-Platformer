using System;

public interface ITrigger
{
    public event Action<string> OnTriggerEnter;
    public event Action OnTriggerExit;
}