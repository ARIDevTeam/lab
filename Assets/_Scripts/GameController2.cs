using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController2 : MonoBehaviour {

    public Text numberText, equationText, feedback; //the textbox to show number, equation, feedback (set in inspector)
    public GameObject trueButton, falseButton; //user input buttons (set in inspector)
    Stim currentStim = new Stim(); //the current stimulus object
    List<int> numbersList = new List<int>(); //the sequence of numbers shown to the user
    float numElapsed = 0, numTime = 1, numHideTime, equationElapsed = 0, equationShow = 3, equationHide = 7;
    //if showingNumber is false, then the equation is being shown
    bool guessed, equationDisplayed, firstStim, showingNumber;
    int numPresentations = 2;

    void Start() {
        numPresentations = GlobalData.presentationCap;
        int nextNumber = UnityEngine.Random.Range(0, 9);
        numbersList.Add(nextNumber);
        numberText.text = nextNumber.ToString();
        numElapsed = 0;
        numPresentations--;
        GlobalData.faults = 0;
    }

    // Update is called once per frame
    void Update () {
        GlobalData.elapsedTime += Time.deltaTime;
        if (GlobalData.elapsedTime > (60*10)) SceneManager.LoadScene("EndScene");
        numElapsed += Time.deltaTime;
        equationElapsed += Time.deltaTime;
        //if equation should be displayed, display it and update number
        if (numElapsed > 4) {
            numberText.text = "";
            toggleEquation(true);
            equationText.text = currentStim.ToString();
        }
        //if equation time is up, generate new stim
        if (numElapsed > 8) {
            feedback.text = "";
            if (!firstStim && !guessed) {
                GlobalData.faults++;
                GlobalData.totalFaults++;
            }
            toggleEquation(false);
            firstStim = false;
            currentStim = new Stim();
            guessed = false;
            equationShow = UnityEngine.Random.Range(5, 10);
            numElapsed = 0;
            //if they've seen all the presentations
            if (numPresentations == 0) {
                //if the equation is also finished
                if (equationText.text == "") {
                    //load new scene
                    SceneManager.LoadScene("_Scenes/InputAnswer");
                    GlobalData.currentSequence = numbersList;
                }
            //else if there are more presentations
            } else {
                int nextNumber = UnityEngine.Random.Range(0, 9);
                numbersList.Add(nextNumber);
                numberText.text = nextNumber.ToString();
                numElapsed = 0;
                numPresentations--;
            }
        }
	}

    public void choose(bool choice) {
        guessed = true;
        if (choice == currentStim.getAnswer()) {
            feedback.text = "Right";
        } else {
            feedback.text = "Wrong";
            GlobalData.faults++;
            GlobalData.totalFaults++;
        }
        equationHide = equationElapsed + 1;
    }

    //hides or shows buttons and resets equation text
    void toggleEquation(bool onOff) {
        trueButton.SetActive(onOff); falseButton.SetActive(onOff); equationText.text = "";
        equationDisplayed = onOff;
    }
}
