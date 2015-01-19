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
        if (Input.GetKeyDown(KeyCode.Alpha1))
            keyspressed.Add(1);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            keyspressed.Add(2);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            keyspressed.Add(3);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            keyspressed.Add(4);

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
