using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class ThreadManager : MonoBehaviour
{
    public static Dictionary<string, ThreadedJob> jobs = new Dictionary<string, ThreadedJob>();
    public static Dictionary<string, ThreadedJob> finishedJobs = new Dictionary<string, ThreadedJob>();
    public static int jobIndex;
    private static System.Random random = new System.Random((int)System.DateTime.Now.Ticks); // randomSeed;

    private Thread m_thread;
    private bool threadRunning = true, threadIsOn = false;
    const float timerLength = 1;
    float timer;

    #region static Functions
    /// <summary>
    /// Adds a job to jobList
    /// </summary>
    /// <param name="j">Job to done by the thread</param>
    /// <returns>Key that can be used to track the job</returns>
    public static string addJob(ThreadedJob j){
        string key = RandomString(8);
        jobs.Add(key, j);
        jobIndex++;
        return key;
    }

    /// <summary>
    /// remove a job from the finsished jobList
    /// </summary>
    /// <param name="key">Key used to track it</param>
    public static void removeJob(string key)
    {
		if(finishedJobs.ContainsKey(key))
		{
			finishedJobs.Remove(key);
		}

    }

    public static void CancelAll()
    {
        foreach (ThreadedJob j in jobs.Values)
            j.cancel();
        foreach (ThreadedJob j in finishedJobs.Values)
            j.cancel();
    }

    /// <summary>
    /// Generates a randomString
    /// </summary>
    /// <param name="size">The length of the string</param>
    /// <returns>A random String</returns>
    private static string RandomString(int size)
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = System.Convert.ToChar(System.Convert.ToInt32(System.Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }

        return builder.ToString();
    }
    #endregion
    #region internalFunctions
    //if thread was stoped it restarts
    void OnApplicationFocus(bool focus)
    {
      //stop the thread as the application has closed
        if(!Application.isEditor)
            stopThread();
        
    }

    public void OnApplicationQuit()
    {
        stopThread();
    }

    void Update()
    {
        if (timer <= 0)
        {
            if (!threadRunning && !threadIsOn && jobs.Count > 0)
                startThread();
            if (jobs.Count <= 0)
                stopThread();

            if (!threadRunning && threadIsOn && timer < -10f)
                forceThreadStop();
            
            if(!threadRunning)
                timer = timerLength;
        }

		//Debug.Log("Jobs Lenght: " + jobs.Count + " Finished Jobs: " + finishedJobs.Count);
        timer -= Time.deltaTime;
    }
    
    void stopThread()
    {
        jobs.Clear();
        threadRunning = false;
        
    }

    void startThread()
    {
        jobIndex = 0;
        threadRunning = true;
        finishedJobs.Clear();
        m_thread = new Thread(threadUpdate);
        m_thread.Start();
    }

    void forceThreadStop()
    {
        if(m_thread!=null)
            m_thread.Abort();
        jobs.Clear();
        threadIsOn = false;
    }

    public void OnDestroy()
    {
        CancelAll();
        forceThreadStop();
    }

    //thread Loop
    void threadUpdate()
    {
        Debug.Log("<color=yellow>Calc Thread Started</color>");
        threadIsOn = threadRunning = true;
        List<string> keys;
        while (threadRunning)
        {
            if (jobs.Count > 0)
            {
                keys = new List<string>();
                Debug.Log("<color=yellow>Calc Thread Running</color> " + "JobIndex " + jobIndex);
                foreach (string i in jobs.Keys)
                    keys.Add(i);
                
                for (int i = 0; i < keys.Count; i++)
                {
                    Debug.Log("<color=cyan>Starting Job " + keys[i] + "</color>");
                    try
                    {
                        if (jobs.ContainsKey(keys[i]) && !jobs[keys[i]].IsActive && !jobs[keys[i]].IsCanceled)
                        {
                            jobs[keys[i]].SetActive();
                            jobs[keys[i]].run();
                            if (jobs.ContainsKey(keys[i]))
                                finishedJobs.Add(keys[i], jobs[keys[i]]);
                            jobs.Remove(keys[i]);
                        }

						if(jobs.ContainsKey(keys[i]) && jobs[keys[i]].IsCanceled){
							jobs[keys[i]].cancel();
							finishedJobs.Add(keys[i], jobs[keys[i]]);
							jobs.Remove(keys[i]);
						}
                    }
                    catch(System.Exception e)
                    {
                        Debug.LogWarning("Invalid Job Or a Error in the job. Restarting Thread");
                        //Debug.LogError(e.Message + "At" + e.Source + " StackTrace: " + e.StackTrace);
                        Debug.LogException(e);
                        
						if(jobs.ContainsKey(keys[i]))
						{
                       		jobs[keys[i]].cancel();
                        	finishedJobs.Add(keys[i], jobs[keys[i]]);
							jobs.Remove(keys[i]);
						}
                        threadRunning = false;
                    }
                }
                timer = timerLength * 5;
            }
            Thread.Sleep(50);

        }
        threadIsOn = threadRunning = false;
        Debug.Log("<color=yellow>Calc Thread Stoped</color>");
    }
    #endregion
}
