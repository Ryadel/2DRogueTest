using UnityEngine;

public class TickManager
{
    public event System.Action OnTick;
    private int m_TickCount;

    public TickManager()
    {
        m_TickCount = 1;
    }

    public void Tick()
    {
        OnTick?.Invoke();
        m_TickCount += 1;
        Debug.Log("Current tick count : " + m_TickCount);
    }

}
