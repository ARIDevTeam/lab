using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {



	// Use this for initialization
	void Start () {
        //SceneManager.LoadScene("Instructions A", LoadSceneMode.Additive);
	}
	
	// Update is called once per frame
    public void LoadInstructionsB(){
        SceneManager.LoadScene("Instructions B");
        
    }
    public void LoadInstructionsC()
    {
        SceneManager.LoadScene("Instructions C");

    }
    public void LoadPractice()
    {
        SceneManager.LoadScene("Practice");
        print("Load practice scene"); 

    }
}
