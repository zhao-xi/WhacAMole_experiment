using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;

public class MoleGenerator : MonoBehaviour {

    public float interval = 1.0f;
    int count = 15;// to count how many times moles show up
    GameObject pointer;
    public Transform mole;
    public Text endText;
    public bool EndFlag = false;

    public Vector3[] molePos;
    private Text[] result_showUpTime;

    private int[] intArray = new int[15]; // contains 1-15 in random order

    // Use this for initialization
    void Start () {
        EndFlag = false;
        for(int i = 0; i < 15; i++)
        {
            intArray[i] = i;
        }
        Shuffle(intArray);

        pointer = GameObject.Find("touchPointer");

        molePos = new Vector3[15];
        // mole positions initialization
        molePos[0] = new Vector3(-6f, 3f, 0f); molePos[5] = new Vector3(-6f, 0f, 0f); molePos[10] = new Vector3(-6f, -3f, 0f);
        molePos[1] = new Vector3(-3f, 3f, 0f); molePos[6] = new Vector3(-3f, 0f, 0f); molePos[11] = new Vector3(-3f, -3f, 0f);
        molePos[2] = new Vector3(0f, 3f, 0f); molePos[7] = new Vector3(0f, 0f, 0f); molePos[12] = new Vector3(0f, -3f, 0f);
        molePos[3] = new Vector3(3f, 3f, 0f); molePos[8] = new Vector3(3f, 0f, 0f); molePos[13] = new Vector3(3f, -3f, 0f);
        molePos[4] = new Vector3(6f, 3f, 0f); molePos[9] = new Vector3(6f, 0f, 0f); molePos[14] = new Vector3(6f, -3f, 0f);

        //showUpTime initialization
        result_showUpTime = new Text[15];
        result_showUpTime[0] = GameObject.Find("Text_showup").GetComponent<Text>();
        result_showUpTime[1] = GameObject.Find("Text_showup (1)").GetComponent<Text>();
        result_showUpTime[2] = GameObject.Find("Text_showup (2)").GetComponent<Text>();
        result_showUpTime[3] = GameObject.Find("Text_showup (3)").GetComponent<Text>();
        result_showUpTime[4] = GameObject.Find("Text_showup (4)").GetComponent<Text>();
        result_showUpTime[5] = GameObject.Find("Text_showup (5)").GetComponent<Text>();
        result_showUpTime[6] = GameObject.Find("Text_showup (6)").GetComponent<Text>();
        result_showUpTime[7] = GameObject.Find("Text_showup (7)").GetComponent<Text>();
        result_showUpTime[8] = GameObject.Find("Text_showup (8)").GetComponent<Text>();
        result_showUpTime[9] = GameObject.Find("Text_showup (9)").GetComponent<Text>();
        result_showUpTime[10] = GameObject.Find("Text_showup (10)").GetComponent<Text>();
        result_showUpTime[11] = GameObject.Find("Text_showup (11)").GetComponent<Text>();
        result_showUpTime[12] = GameObject.Find("Text_showup (12)").GetComponent<Text>();
        result_showUpTime[13] = GameObject.Find("Text_showup (13)").GetComponent<Text>();
        result_showUpTime[14] = GameObject.Find("Text_showup (14)").GetComponent<Text>();

        InvokeRepeating("MoleShowUp", 3.0f, interval);
    }
	
    
    void MoleShowUp()
    {
        if (count > 0)
        {
            count--;
            pointer.transform.position = new Vector3(100f, 100f, 0f);// first move away the pointer
            Instantiate(mole, molePos[intArray[count]], Quaternion.identity);
            string time = Time.timeSinceLevelLoad.ToString();

            //write to result
            int result_idx = returnIndex(molePos[intArray[count]]);
            result_showUpTime[result_idx].text = time;

            //write to txt file
            float posX = Camera.main.WorldToScreenPoint(molePos[count]).x;
            float posY = Camera.main.WorldToScreenPoint(molePos[count]).y;
            string txt = time + " Mole showed up at ("
                + posX.ToString() + "," + posY.ToString() + ").";
            string path = "WhacAMole_Data/Resources/data.txt";
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(txt);
            writer.Close();
        }
        else
        {
            CancelInvoke();
            EndFlag = true;
            endText.text = "Thank you so much for your cooperation!";
            DestroyImmediate(GameObject.Find("Gaze"));
            
            GameObject.Find("GameManager").GetComponent<AudioSource>().Play();
        }
    }

    public void Shuffle(int[] obj)
    {
        for (int i = 0; i < obj.Length; i++)
        {
            int temp = obj[i];
            int objIndex = Random.Range(0, obj.Length);
            obj[i] = obj[objIndex];
            obj[objIndex] = temp;
        }
    }
    private void RandomUnique()
    {
        for (int i = 0; i < 100; i++)
        {
            intArray[i] = i;
        }
        Shuffle(intArray);
    }

    private int returnIndex(Vector3 pos)
    {
        if (pos == new Vector3(-6f, 3f, 0f))
        {
            return 0;
        }
        if (pos == new Vector3(-3f, 3f, 0f))
        {
            return 1;
        }
        if (pos == new Vector3(0f, 3f, 0f))
        {
            return 2;
        }
        if (pos == new Vector3(3f, 3f, 0f))
        {
            return 3;
        }
        if (pos == new Vector3(6f, 3f, 0f))
        {
            return 4;
        }
        if (pos == new Vector3(-6f, 0f, 0f))
        {
            return 5;
        }
        if (pos == new Vector3(-3f, 0f, 0f))
        {
            return 6;
        }
        if (pos == new Vector3(0f, 0f, 0f))
        {
            return 7;
        }
        if (pos == new Vector3(3f, 0f, 0f))
        {
            return 8;
        }
        if (pos == new Vector3(6f, 0f, 0f))
        {
            return 9;
        }
        if (pos == new Vector3(-6f, -3f, 0f))
        {
            return 10;
        }
        if (pos == new Vector3(-3f, -3f, 0f))
        {
            return 11;
        }
        if (pos == new Vector3(0f, -3f, 0f))
        {
            return 12;
        }
        if (pos == new Vector3(3f, -3f, 0f))
        {
            return 13;
        }
        if (pos == new Vector3(6f, -3f, 0f))
        {
            return 14;
        }
        else return -1;
    }
}


