using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndSceneManagement : MonoBehaviour {

	//Declarations
	public Text EndMessage;
	//making an edit so I can save the script, scene, and project
	public Button btnOk;

	private string goodJob;
	private string youFailed;

	private int score;
	private int messageScore;

    // Use this for initialization
    void Start() {
        if (GlobalData.elapsedTime > 60*10) {
            EndMessage.text = "You have exceeded the time alloted for this exercise. We will now move on to the next exercise";
        } else if (GlobalData.numberFailedTests >= 2) {
			EndMessage.text = "Thank you. You have completed this exercise. We will now move on to the next exercise.";
        } else {
			EndMessage.text = "Well done. We will now move on to the next exercise.";
		}
	}

	//provides the delay associated with the scene change
	IEnumerator waitaTick(float waitTime) {

		yield return new WaitForSeconds(waitTime);
		ChangeScene ();
	}

	//provides a brief delay before changing scenes
	public void hesitate(){
		StartCoroutine (waitaTick (0.75f));
	}

	//changes the scene
	void ChangeScene(){
		SceneManager.LoadScene ("Scenes/Background Instructions");
	}

}
