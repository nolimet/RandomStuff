using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class InputSpell : MonoBehaviour
{
    List<int> keyspressed = new List<int>();
    [SerializeField]
    List<spell> spells;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            keyspressed.Add(1);
        if (Input.GetKeyDown(KeyCode.W))
            keyspressed.Add(2);
        if (Input.GetKeyDown(KeyCode.E))
            keyspressed.Add(3);
        if (Input.GetKeyDown(KeyCode.R))
            keyspressed.Add(4);
        if (Input.GetKeyDown(KeyCode.A))
            keyspressed.Add(5);
        if (Input.GetKeyDown(KeyCode.S))
            keyspressed.Add(6);
        if (Input.GetKeyDown(KeyCode.D))
            keyspressed.Add(7);
        if (Input.GetKeyDown(KeyCode.F))
            keyspressed.Add(8);

        if (Input.GetKeyDown(KeyCode.C))
            Cast();
    }

    void Cast()
    {
        foreach (spell s in spells)
        {
            if (compairIntList(s.combo, keyspressed))
            {
                print(s.name);
                keyspressed = new List<int>();
                return;
            }
        }
        print("did not find spell");
        keyspressed = new List<int>();
    }

    bool compairIntList(List<int> valueA, List<int> valueB)
    {
        if (valueA.Count != valueB.Count)
            return false;
        else
        {
            int l = valueA.Count;
            for (int i = 0; i < l; i++)
            {
                if (valueA[i] != valueB[i])
                    return false;
            }
                return true;
        }
    }

    void OnGUI()
    {
        string output = "Keys Pressed: ";

        int l = keyspressed.Count;
        for (int i = 0; i < l; i++)
        {
            output += keyspressed[i];

            if (i < l - 1)
                output += ", ";
        }

        GUI.Label(new Rect(10, 10, 400, 25), output);


    }

    [System.Serializable]
    public class spell
    {
        public string name = "";
        public List<int> combo = new List<int>();
    }
}
