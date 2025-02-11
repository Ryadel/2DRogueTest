using UnityEngine;

public class TickManager
{
    private int m_TickCount;

    public TickManager()
    {
        m_TickCount = 1;
    }

    public void Tick()
    {
        m_TickCount += 1;
        Debug.Log("Current tick count : " + m_TickCount);
    }

}
