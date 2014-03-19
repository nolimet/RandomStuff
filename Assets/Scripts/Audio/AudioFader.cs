using UnityEngine;
using System.Collections;

public class AudioFader : MonoBehaviour {

	public Soundcontroler[] Git;
	public Soundcontroler[] Bass;
	public Soundcontroler[] Drums;
	public Soundcontroler[] Key;

	[Range(-1,3)]
	public int GitSec =-1;

	[Range(-1,3)]
	public int BassSec =-1;

	[Range(-1,3)]
	public int DrumsSec =-1;

	[Range(-1,3)]
	public int KeySec =-1;

	private int GitLast;
	private int BassLast;
	private int DrumsLast;
	private int KeyLast;

	void Start() {
		foreach(Soundcontroler g in Git){
			g.Stop();
			//Debug.Log (g);
		}
		foreach(Soundcontroler b in Bass){
			b.Stop();
			//Debug.Log (b);
		}
		foreach(Soundcontroler d in Drums){
			d.Stop();
			//Debug.Log (d);
		}
		foreach(Soundcontroler k in Key){
			k.Stop();
			//Debug.Log (k);
		}
	}
    void LateUpdate()
    {
        //int GitSec = GitSec-1;
        //int BassSec = BassSec-1;
        //int KeySec = KeySec-1;
        //int DrumsSec = DrumsSec-1;
        //Debug.Log (GitSec +" " +BassSec+" " +KeySec+" " +DrumsSec);
        //Debug.Log(GitLast + " " + BassLast + " " + KeyLast + " " + DrumsSec);
        //Debug.Log (Git.Length);
        if (GitLast != GitSec)
        {
            if (GitSec == -1)
            {
                Git[GitLast].Stop();
            }
            else if (GitSec > -1)
            {
                if (GitLast > -1) { Git[GitLast].Stop(); }
                Git[GitSec].Play();
            }
            //GitLast = GitSec;
        }
        if (BassLast != BassSec)
        {
            if (BassSec == -1)
            {
                Bass[BassLast].Stop();
            }
            else if (BassSec > -1)
            {
                if (BassLast > -1) { Bass[BassLast].Stop(); }
                Bass[BassSec].Play();
            }
        }
        if (DrumsLast != DrumsSec)
        {

            if (DrumsSec == -1)
            {
                Drums[DrumsLast].Stop();
            }
            else if (DrumsSec > -1)
            {
                if (DrumsLast > -1) { Drums[DrumsLast].Stop(); }
                Drums[DrumsSec].Play();
            }
        }
        if (KeyLast != KeySec)
        {
            if (KeySec == -1)
            {
                Key[KeyLast].Stop();
            }
            else if (KeySec > -1)
            {
                if (KeyLast > -1) { Key[KeyLast].Stop(); }
                Key[KeySec].Play();
            }
            //KeyLast=KeySec;
        }
        GitLast = GitSec;
        BassLast = BassSec;
        DrumsLast = DrumsSec;
        KeyLast = KeySec;
    }

    public void StopAll()
    {
        Debug.LogWarning("stopedAll");
        GitSec = -1;
        BassSec = -1;
        DrumsSec = -1;
        KeySec = -1;

        GitLast = GitSec;
        BassLast = BassSec;
        DrumsLast = DrumsSec;
        KeyLast = KeySec;

        foreach (Soundcontroler g in Git)
        {
            g.StopImidiate();
            //Debug.Log (g);
        }
        foreach (Soundcontroler b in Bass)
        {
            b.StopImidiate();
            //Debug.Log (b);
        }
        foreach (Soundcontroler d in Drums)
        {
            d.StopImidiate();
            //Debug.Log (d);
        }
        foreach (Soundcontroler k in Key)
        {
            k.StopImidiate();
            //Debug.Log (k);
        }
    }
}
