using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartCountDown : MonoBehaviour {

    public float CountdownFrom = 3.0f;
    public Text textbox;
    public Text textbox0;
    public Text textbox1;

    GameObject gaze;

    void Update()
    {
        float time = CountdownFrom - Time.timeSinceLevelLoad;
        if (time > 0)
        {
            textbox.text = time.ToString("0.00") + "s";
        }
        if (time <= 0f)
        {
            TimeUp();
        }
    }
    void TimeUp()
    {
        DestroyImmediate(textbox);
        DestroyImmediate(textbox0);
        DestroyImmediate(textbox1);
    }
}
