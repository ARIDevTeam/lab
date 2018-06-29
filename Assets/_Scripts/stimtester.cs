using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stimtester : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    float elapsed;
    // Update is called once per frame
    void Update() {
        if (elapsed > 0.5f) {
            Stim stim = new Stim();
            print(stim.ToString());
            elapsed = 0;
        }
        elapsed += Time.deltaTime;
        
    }
}
