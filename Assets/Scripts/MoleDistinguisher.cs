using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class MoleDistinguisher : MonoBehaviour {

    Material moleHit;
    int score;

    private GameObject[] resultLights;
    private GameObject gameManager;

    public Text scoreText;

    private Text[] result_hit;

    int result_idx = 0;
	// Use this for initialization
	void Start () {

        score = 0;
        scoreText.transform.position = new Vector3(Screen.width - 100, Screen.height - 50);
        moleHit = Resources.Load("moleHit", typeof(Material)) as Material;
        GameObject.Find("Button").transform.position = new Vector3(Screen.width - 100, 50);

        // assign the result lights
        resultLights = new GameObject[15];
        resultLights[0] = GameObject.Find("1");
        resultLights[1] = GameObject.Find("2");
        resultLights[2] = GameObject.Find("3");
        resultLights[3] = GameObject.Find("4");
        resultLights[4] = GameObject.Find("5");
        resultLights[5] = GameObject.Find("6");
        resultLights[6] = GameObject.Find("7");
        resultLights[7] = GameObject.Find("8");
        resultLights[8] = GameObject.Find("9");
        resultLights[9] = GameObject.Find("10");
        resultLights[10] = GameObject.Find("11");
        resultLights[11] = GameObject.Find("12");
        resultLights[12] = GameObject.Find("13");
        resultLights[13] = GameObject.Find("14");
        resultLights[14] = GameObject.Find("15");

        //assign the result text
        result_hit = new Text[15];
        result_hit[0] = GameObject.Find("Text_hit").GetComponent<Text>();
        result_hit[1] = GameObject.Find("Text_hit (1)").GetComponent<Text>();
        result_hit[2] = GameObject.Find("Text_hit (2)").GetComponent<Text>();
        result_hit[3] = GameObject.Find("Text_hit (3)").GetComponent<Text>();
        result_hit[4] = GameObject.Find("Text_hit (4)").GetComponent<Text>();
        result_hit[5] = GameObject.Find("Text_hit (5)").GetComponent<Text>();
        result_hit[6] = GameObject.Find("Text_hit (6)").GetComponent<Text>();
        result_hit[7] = GameObject.Find("Text_hit (7)").GetComponent<Text>();
        result_hit[8] = GameObject.Find("Text_hit (8)").GetComponent<Text>();
        result_hit[9] = GameObject.Find("Text_hit (9)").GetComponent<Text>();
        result_hit[10] = GameObject.Find("Text_hit (10)").GetComponent<Text>();
        result_hit[11] = GameObject.Find("Text_hit (11)").GetComponent<Text>();
        result_hit[12] = GameObject.Find("Text_hit (12)").GetComponent<Text>();
        result_hit[13] = GameObject.Find("Text_hit (13)").GetComponent<Text>();
        result_hit[14] = GameObject.Find("Text_hit (14)").GetComponent<Text>();

        gameManager = GameObject.Find("GameManager");
    }
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + score.ToString();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Mole")
        {
            other.GetComponent<Renderer>().material = moleHit;
            score++;
            GetComponent<AudioSource>().Play();
            result_idx = returnIndex(other.transform.position);
            string time = Time.timeSinceLevelLoad.ToString();

            //turn result light
            resultLights[result_idx].GetComponent<Renderer>().material = moleHit;
            //write to result text
            result_hit[result_idx].text = time;

            //write to txt file
            float posX = Camera.main.WorldToScreenPoint(other.transform.position).x;
            float posY = Camera.main.WorldToScreenPoint(other.transform.position).y;
            string txt = time + " Mole at ("
                + posX.ToString() + "," + posY.ToString() + ") is hit.";
            string path = "WhacAMole_Data/Resources/data.txt";
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(txt);
            writer.Close();
        }
    }

    private int returnIndex(Vector3 pos)
    {
        if(pos == new Vector3(-6f, 3f, 0f))
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
