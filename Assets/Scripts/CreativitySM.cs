using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class CreativitySM : MonoBehaviour {

	//declarations
	private float qtimer;
	public Text question, e1, e2, e3, e4;
	public GameObject submit, next;
	
	private int qnum;

	// Use this for initialization
	void Start () {
		next.SetActive(false);
		qnum = 1;
		qtimer = 120.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		qtimer -= Time.deltaTime;
		if(qtimer < 0 && qnum <= 1){
			qnum = 2;
			question.text = "2. What would be the results if everyone suddenly lost the ability to read and write?";
			e1.text = "No newspapes or magazines";
			e2.text = "No liabraries";
			e3.text = "No mail or letters";
			e4.text = "TV sales increase";
			qtimer = 120.0f;
		}else if(qtimer < 0 && qnum == 2){
			qnum = 3;
			question.text = "3. What would be the results if human life continued on earth without death??";
			e1.text = "Overpopulation";
			e2.text = "More old people";
			e3.text = "Housing shortage";
			e4.text = "No more funerals";
			qtimer = 120.0f;
		}else if(qtimer < 0 && qnum == 3){
			qnum++;
			question.text = "4. What would be the results if the force of gravity was suddenly cut in half?";
			e1.text = "Jump higher";
			e2.text = "More accidents";
			e3.text = "Less effort to work";
			e4.text = "Easier to lift things";
			qtimer = 120.0f;
		}else if(qtimer < 0 && qnum > 3){
			question.text = "You have completed this exercise. We will now move on to the next exercise.";
			next.SetActive(true);
			submit.SetActive(false);
		}
	}

	public void SubmitAnswers(){
		qtimer = 1.0f;
	}

	//provides the delay associated with the scene change
	IEnumerator waitaTick(float waitTime) {

		yield return new WaitForSeconds(waitTime);
		ChangeToSR_CInstructionsScene ();
	}

	//provides a brief delay before changing scenes
	public void Hesitate(){
		StartCoroutine (waitaTick (0.75f));
	}

	//changes the scene
	void ChangeToSR_CInstructionsScene(){
		SceneManager.LoadScene ("SR_B Instructions");
	}
}
