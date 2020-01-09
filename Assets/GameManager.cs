using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour {

    private GameObject touchPointer;
    private GameObject backgroundTable;
    public Transform MolePrefab;

	// Use this for initialization
	void Start () {
        touchPointer = GameObject.Find("touchPointer");
        backgroundTable = GameObject.Find("Plane");
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                float touchX = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position).x;
                float touchY = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position).y;
                Vector3 touchPos = new Vector3(touchX, touchY, 0f);
                touchPointer.transform.position = touchPos;

                //write to txt file
                float posX = Camera.main.WorldToScreenPoint(touchPos).x;
                float posY = Camera.main.WorldToScreenPoint(touchPos).y;
                string txt = Time.timeSinceLevelLoad.ToString() + " Player touched at ("
                    + posX.ToString() + "," + posY.ToString() + ").";
                string path = "WhacAMole_Data/Resources/data.txt";
                StreamWriter writer = new StreamWriter(path, true);
                writer.WriteLine(txt);
                writer.Close();

            }
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
