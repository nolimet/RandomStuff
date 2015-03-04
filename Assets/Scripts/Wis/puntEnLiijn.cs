using UnityEngine;
using System.Collections;

public class puntEnLiijn : MonoBehaviour {

    Transform[] punten = new Transform[3];
    LineRenderer[] Lines = new LineRenderer[2];

    [SerializeField]
    private Mesh pMesh;
    [SerializeField]
    private Shader pShader;
    void Start()
    {
        Material pm = new Material(pShader);
        for (int i = 0; i < punten.Length; i++)
        {
            GameObject p = new GameObject();
            punten[i] = p.transform;

            p.AddComponent<MeshFilter>().mesh=pMesh;
            p.AddComponent<MeshRenderer>().material = pm;

            //p.transform.position = new Vector3(0, i * 2);
            p.name = "punt" + i;
            
        }

        punten[1].position = new Vector3(-5, 5);
        punten[0].position = new Vector3(5, -5);

        punten[0].gameObject.GetComponent<Renderer>().material.color = Color.blue;
        punten[1].gameObject.GetComponent<Renderer>().material.color = Color.red;
        punten[2].gameObject.GetComponent<Renderer>().material.color = Color.yellow;

        for (int j = 0; j < Lines.Length; j++)
        {
            GameObject l = new GameObject();
            Lines[j] = l.AddComponent<LineRenderer>();

            Lines[j].material = pm;
            Lines[j].SetWidth(0.2f, 0.2f);
            l.name = "lineRender" + j;
        }
    }

    void Update()
    {
        Lines[0].SetPosition(0, punten[0].position);
        Lines[0].SetPosition(1, punten[1].position);
    }
}

/*
package wiskunde 
{
 import flash.display.Graphics;
 import flash.display.Sprite;
 import flash.events.Event;

 public class LoodRechtenLijnen extends Sprite
 {
  public var A:WPoint = new WPoint(15, 0x000000, true);
  public var B:WPoint = new WPoint(15, 0x000000, true);
  public var C:WPoint = new WPoint(15, 0x000000, true);
  public var lijn:Lijn = new Lijn(0, 0, 0);
  public var lijn2:Lijn = new Lijn(0, 0, 0);

  private var g:Graphics;

  public function LoodRechtenLijnen() 
  {
   g = this.graphics;

   A.x = 100; A.y = 100;
   B.x = 700; B.y = 300;
   C.x = 700; C.y = 100;
   addChild(angel); addChild(beer); addChild(coffee);
   addEventListener(Event.ENTER_FRAME, Teken);
   }

  private function Teken(e:Event):void
  {
   g.clear();
   g.lineStyle(5, 0x000000);

   var RightSideOfScreen:Number = stage.width * 10;
   var LeftSideOfScreen:Number = -stage.width * 10;

   lijn.a = A.y - B.y;
   lijn.b = B.x - A.x;
   lijn.c = lijn.a * A.x + lijn.b * A.y;

   g.moveTo(LeftSideOfScreen, lijn.berekenY(LeftSideOfScreen));
   g.lineTo(RightSideOfScreen, lijn.berekenY(RightSideOfScreen));

   lijn2.a = -lijn.b;
   lijn2.b = lijn.a;
   lijn2.c = lijn2.a * C.x + lijn2.b * C.y;

   g.moveTo(LeftSideOfScreen, lijn2.berekenY(LeftSideOfScreen));
   g.lineTo(RightSideOfScreen, lijn2.berekenY(RightSideOfScreen));



  }
 }

}*/