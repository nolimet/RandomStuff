using UnityEngine;
using System.Collections;

public class GotToLevel : MonoBehaviour {

    public string GoToLevel ;
    public bool Disabled = false;
    void Start()
    {
        if (Disabled||GoToLevel == "")
        {
         //   Destroy(this.gameObject);
            SpriteRenderer spr = GetComponent<SpriteRenderer>();
            spr.color = Color.gray;
            Disabled = true;
        }
    }
    public void IWillDo()
    {
        if (!Disabled||GoToLevel != "")
        {
            transform.parent.gameObject.GetComponent<Loader>().SyncLoadLevel(GoToLevel);
        }
    }
}
