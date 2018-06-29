using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialMan2 : MonoBehaviour {

	//declarations
	public Text operand1;
	public Text opSign;
	public Text operand2;
	public Text operand3;
	public Text equalSign;
	public Text consequent;
	public Text truthiness;

	private bool trueAnswer;

	private int ant1;
	private int ant2;
	private int ant3;
	private int cons;

	private float intervalNumber;

	// Use this for initialization
	void Start () {
		intervalNumber = 6.0f;
		createStim ();
	}
	
	// Update is called once per frame, every six seconds it presents a random correct or false stimuli
	void Update () {
		intervalNumber -= Time.deltaTime;
		if (intervalNumber <= 0) {
			createStim ();
			intervalNumber = 6.0f;
		}
	}

	//creates the problem displayed
	public void createStim(){

		rightOrWrong ();

		if (trueAnswer != true) {
			trueStim ();
		} else {
			falseStim ();

		}
		//print ("true answers: " + posCount + " sneaky answers: " + negCount + " additions: " + addCount + " subs: " + subCount);
		operand1.text = ant1.ToString ();
		operand2.text = ant2.ToString ();
		operand3.text = ant3.ToString ();
		consequent.text = cons.ToString ();
	}

	//determines whether the stimuli will have a correct answer or a wrong answer
	void rightOrWrong(){
		int temp = UnityEngine.Random.Range (0, 29);

		if (temp % 2 == 0) {
			trueAnswer = true;

		} else {
			trueAnswer = false;

		}

	}

	//generates correct answers
	void trueStim(){
		//print ("true stim was called");

		//calls the addition part of the simuli
		makeAdditionProblem ();

		//calls the subtraction part of the stimuli
		makeSubtractionProblem();
		cons -= ant3;

		truthiness.text = "True";

	}

	// this will take the antecedants and create a false stim
	void falseStim(){
		print ("false stim was called");

		//this will offset the answer from being correct
		int offset = UnityEngine.Random.Range (1, 3);

		//calls the addition part of the stimuli
		makeAdditionProblem ();

		makeSubtractionProblem();
		cons -= ant3;
		if (cons % 2 == 0  && cons - offset > 0) {
			cons -= offset;
		} else {
			cons += offset;
		}
		truthiness.text = "False";
	}

	//this is a mutator method that sets ant1 and ant2 up for a random addition problem
	void makeAdditionProblem(){
		//print ("make addition got called");
		int max = 9;
		ant1 = UnityEngine.Random.Range (0, 9);
		ant2 = UnityEngine.Random.Range (0, 9);
		while (ant1 + ant2 > max) {
			ant1 = UnityEngine.Random.Range (0, 9);
			ant2 = UnityEngine.Random.Range (0, 9);
		}
		cons = ant1 + ant2;
	}


	//this is a mutator method that sets ant1 and ant2 up for a random subtraction problem
	void makeSubtractionProblem(){
		//print ("make sub got called");
		int min = 0;
		ant3 = UnityEngine.Random.Range (0, 9);
		while (cons - ant3 < 0) {
			ant3 = UnityEngine.Random.Range (0, 9);
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
		print ("I got clicked");
		SceneManager.LoadScene ("_Scenes/Tutorial3");
	}

}
