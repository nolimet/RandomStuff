using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MultiLineText : MonoBehaviour {

    public string Text = "wello world";
	[Range(1,256)]
	public int maxLineLenght;
    public string ShowingText;
    private string line1 = "";
    private string line2;
    private string line3;
    private string line4;
    private string line5;
    private string line6;
    private string line7;
    private string line8;
    private string line9;
    private List<string> LinesAbove = new List<string>();
    private List<string> LinesBelow = new List<string>();
    private int currentLine = 0;
    //private string temp = "test";
   // [Range (0,1)]
    private Vector4 pos;
    public GUIStyle Style;
    public float delay;


    [Range(0, 1)]
    public float posX;

    [Range(0, 1)]
    public float posY;

    [Range(0, 1)]
    public float SizeX = 0.1f;
    [Range(0, 1)]
    public float SizeY = 0.1f;

    void Start()
    {
        pos.x = Screen.width * posX; pos.y = Screen.height * posY;
        pos.z=Screen.width * SizeX;pos.w= Screen.height * SizeY;
    }

     void Awake()
        {
            //guiText.text = "";
            StartCoroutine("Typer");
        }


     void OnApplicationStop()
     {
         StopCoroutine("Typer");
     }

     IEnumerator Typer()
     {
         yield return new WaitForSeconds(delay);
         foreach (char c in Text)
         {
             if (c == '\n' || line1.Length>maxLineLenght)
             {
                 LinesAbove.Add(line9);
                 line9 = line8;
                 line8 = line7;
                 line7 = line6;
                 line6 = line5;
                 line5 = line4;
                 line4 = line3;
                 line3 = line2;
                 line2 = line1;
                 line1 = "";

             }
             else if (c != '\n')
             {
                 line1 += c;
             }
            // Debug.Log(ShowingText.Length);
             yield return new WaitForSeconds(Random.RandomRange(0,0.08f));
         }
         StopCoroutine("Typer");
     }

      void OnGUI() {
          GUI.Label(new Rect(pos.x, pos.y, pos.z, pos.w), line1, Style);
         GUI.Label(new Rect(pos.x, pos.y - (Style.fontSize * 1), pos.z, pos.w), line2, Style);
         GUI.Label(new Rect(pos.x, pos.y - (Style.fontSize * 2), pos.z, pos.w), line3, Style);
         GUI.Label(new Rect(pos.x, pos.y - (Style.fontSize * 3), pos.z, pos.w), line4, Style);
         GUI.Label(new Rect(pos.x, pos.y - (Style.fontSize * 4), pos.z, pos.w), line5, Style);
         GUI.Label(new Rect(pos.x, pos.y - (Style.fontSize * 5), pos.z, pos.w), line6, Style);
         GUI.Label(new Rect(pos.x, pos.y - (Style.fontSize * 6), pos.z, pos.w), line7, Style);
         GUI.Label(new Rect(pos.x, pos.y - (Style.fontSize * 7), pos.z, pos.w), line8, Style);
         GUI.Label(new Rect(pos.x, pos.y - (Style.fontSize * 8), pos.z, pos.w), line9, Style);
     }

      void LineUp()
      {
          currentLine++;
          line9 = LinesAbove[currentLine];
          line8 = line9;
          line7 = line8;
          line6 = line7;
          line5 = line6;
          line4 = line5;
          line3 = line4;
          line2 = line3;
          line1 = line2;
      }

      void LineDown()
      {

      }
}
