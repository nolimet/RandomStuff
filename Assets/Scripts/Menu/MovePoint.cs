using UnityEngine;
using System.Collections;

public class MovePoint : MonoBehaviour {

    public Transform MenuScreen;

    void start()
    {
        transform.LookAt(MenuScreen);
    }
}
