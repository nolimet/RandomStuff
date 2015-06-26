using UnityEngine;
using System.Collections;

public class ThreadedJob
{
    [SerializeField]
    protected bool m_IsActive = false;
    protected bool m_IsDone = false;
    protected bool m_IsCanceled = false;

    public bool IsDone
    {
        get
        {
            return m_IsDone;
        }
    }
    public bool IsActive
    {
        get
        {
            return m_IsActive;
        }
    }
    public bool IsCanceled
    {
        get
        {
            return m_IsCanceled;
        }
    }

    public System.DateTime start;

    public void run()
    {
        m_IsDone = false;
        if (!m_IsCanceled)
        {
            ThreadFunction();
        }
        m_IsDone = true;
        if (!m_IsCanceled)
        {
            OnFinished();
        }
    }

    public virtual void cancel()
    {
        m_IsCanceled = true;
        Debug.Log("JobCanceled");
	}

    public void SetActive()
    {
        m_IsActive = true;
    }

    public int ThreadTime(string name)
    {
        return(int)(System.DateTime.Now - start).TotalMilliseconds;
    }

    protected virtual void ThreadFunction() { }
    protected virtual void OnFinished() { }
}

