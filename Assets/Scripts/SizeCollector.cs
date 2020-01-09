using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SizeCollector : MonoBehaviour {

    public Transform pos1;
    private Vector3 pos1_screen;
    public Transform pos2;
    private Vector3 pos2_screen;
    public float distance;
	// Use this for initialization
	void Start () {
        pos1_screen = Camera.main.WorldToScreenPoint(pos1.position);
        pos2_screen = Camera.main.WorldToScreenPoint(pos2.position);

        distance = Distance(pos1_screen.x, pos2_screen.x, pos1_screen.y, pos2_screen.y);

        //write to txt file
        string txt = "size of mole: " + distance.ToString();
        string path = "WhacAMole_Data/Resources/data.txt";
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(txt);
        writer.Close();
    }
    
    float Distance(float x1, float x2, float y1, float y2)
    {
        return Mathf.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
    }
}
