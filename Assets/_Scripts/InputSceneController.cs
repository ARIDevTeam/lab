using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//in this scene the user needs to input the numbers from the presentations in the correct order.
//the input scene then needs to send the users inputs back to the gc.
public class InputSceneController : MonoBehaviour {

	//declarations
    public InputField userInput;
    public GameObject inputParent;
    public GameObject textBox;
    private bool waitingToTransition; // set to true when the user needs to click OK to proceed
    float answerRatio;

    void Start() {
        //set inputs active based on number of numbers shown
        for (int i = inputParent.transform.childCount-1; i > GlobalData.presentationCap-1; i--)
            inputParent.transform.GetChild(i).gameObject.SetActive(false);
        //calculate right/wrong answer ratio
        answerRatio = (float)(GlobalData.presentationCap - GlobalData.faults) / (float)GlobalData.presentationCap;
        textBox.SetActive(false);
    }

    void Update() {
        GlobalData.elapsedTime += Time.deltaTime;
        if (GlobalData.elapsedTime > (60 * 10)) SceneManager.LoadScene("EndScene");
    }

    public void getInput() {
        if (answerRatio < 0.66f) {
            wrongAnswer();
            return;
        }
        //build userInput string
        string userInput = "";
        //get all input objects
        foreach (Transform child in inputParent.transform)
            //if the object is active
            if (child.gameObject.activeSelf)
                //get all text objects 
                foreach (Text t in child.gameObject.GetComponentsInChildren<Text>())
                    //if it's a userinput, append to answer string
                    if (t.CompareTag("userInput")) userInput += t.text;
        //build answer string
        string answer = "";
        foreach (int x in GlobalData.currentSequence) answer += x.ToString();
        //if waiting for user input (not waiting to transition to next scene
        if (!waitingToTransition) {
            //if the answer is right
            if (answer.Equals(userInput)) {
                GlobalData.numberFailedTests = 0;
                //if they finished the last round
                if (GlobalData.presentationCap == 10) {
                    SceneManager.LoadScene("_Scenes/EndScene");
                //if they have more rounds left
                } else {
                    GlobalData.presentationCap++;
                    SceneManager.LoadScene("_Scenes/NumExposure2");
                }
            //if the answer was wrong
            } else {
                wrongAnswer();
            }
        }
	}

    public void wrongAnswer() {
        waitingToTransition = true;
        GlobalData.numberFailedTests++;
        GlobalData.totalFailedTests++;
        if (GlobalData.numberFailedTests >= 2) {
            SceneManager.LoadScene("_Scenes/EndScene");
            return;
        }
        textBox.SetActive(true);
    }

    public void restart() {
        SceneManager.LoadScene("_Scenes/NumExposure2");
    }
}
