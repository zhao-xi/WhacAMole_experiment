using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SelfDestinguisher : MonoBehaviour {
    GameObject moleGenerator;
	// Use this for initialization
	void Start () {
        moleGenerator = GameObject.Find("MoleGenerator");
        MoleGenerator moleGenScript = moleGenerator.GetComponent<MoleGenerator>();
        Destroy(gameObject, moleGenScript.interval);
    }
}
