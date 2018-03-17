using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class ClueSelect : MonoBehaviour {

	private RaycastHit hit;
	public bool activated = false;
	public Button Continue;
	public int numberOfClues = 0;
	public Button phone;

	//Pistas a encontrar:
	private bool pista1 = false;
	private bool pista2 = false;
	private bool pista3 = false;
	private int nCorrect = 0;
	private bool si = false;

	private ArrayList cluesArray;

	// Use this for initialization
	void Start () {
		cluesArray = new ArrayList ();
		cluesArray.Add ("time of death");
		cluesArray.Add ("freezing cold");
		cluesArray.Add ("secure");
		cluesArray.Add ("coupleProblems");
		cluesArray.Add ("closeRoom");
		cluesArray.Add ("air conditioner");
		
	}

	public void changeDialogue(int i, bool t=false){
		phone.GetComponent<DialogueEvent> ().currentDialogue = i;
		phone.GetComponent<DialogueEvent> ().LaunchDialogue (t);
		phone.GetComponent<DialogueEvent> ().currentDialogue = 0;
	}
		
	public void isOK(GameObject clue){
		string obj1 = clue.gameObject.GetComponent<NoteClick>().obj1;
		string obj2 = clue.gameObject.GetComponent<NoteClick>().obj2;
		int verb = clue.gameObject.GetComponent<NoteClick>().verb;

	
		if ((obj1 == "time of death" || obj2 == "time of death") && (obj1 == "freezing cold" || obj2 == "freezing cold") && (verb == 2)) {
			if (!pista1) {
				pista1 = true;
				nCorrect++;
				si = true;
				//Pista correcta:
				this.changeDialogue (5);
			} else
				//Ya me has dicho esa pista
				this.changeDialogue (3);
		}else if ((obj1 == "secure" || obj2 == "secure") && (obj1 == "coupleProblems" || obj2 == "coupleProblems") && (verb == 3)) {
			if (!pista2) {
				pista2 = true;
				nCorrect++;
				si = true;
				//Pista correcta:
				this.changeDialogue (4);
			} else
				//Ya me has dicho esa pista
				this.changeDialogue (3);
		}else if((obj1 == "closeRoom" || obj2 == "closeRoom") && (obj1 == "air conditioner" || obj2 == "air conditioner") && (verb == 6)){
			if (!pista3) {
				pista3 = true;
				si = true;
				nCorrect++;
				//Pista correcta:
				this.changeDialogue (6);
			} else
				//Ya me has dicho esa pista
				this.changeDialogue (3);
		} else {
			bool aux1 = cluesArray.Contains ("closeRoom");
			bool aux2 = cluesArray.Contains ("secure");
			bool aux3 = cluesArray.Contains ("coupleProblems");
			bool aux4 = cluesArray.Contains ("air conditioner");
			bool aux5 = cluesArray.Contains ("time of death");
			bool aux6 = cluesArray.Contains ("freezing cold");

			if (aux1 || aux2 || aux3 || aux4 || aux5 || aux6)
				this.changeDialogue (11);
			else
				this.changeDialogue (10);
		}

		if (si) {
			if (nCorrect == 1) {
				this.changeDialogue (7, true);
			} else if (nCorrect == 2) {
				this.changeDialogue (8, true);
			} else if (nCorrect == 3) {
				this.changeDialogue (9, true);
			}
		
			si = false;
		}
	}


	// Update is called once per frame
	void Update () {
		if(activated){
			if (numberOfClues == 0) {
				Continue.interactable = true;
				activated = false;
				//No tienes ninguna pista.
				this.changeDialogue (2);
				activated = false;
			} else {
				if (Input.GetButtonDown ("Fire1")) {
					Plane plane = new Plane (Vector3.forward, 0);
		            
					float dist;
					Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
					if (plane.Raycast (ray, out dist)) {	
						Vector3 point = ray.GetPoint (dist);
						Physics.Raycast (ray, out hit);
						if (hit.collider.gameObject.name == "Note(Clone)") {
							activated = false;
							Continue.interactable = true;
							GameObject.Find ("Dialogue Manager").GetComponent<DialogueManager> ().EndOfDialogue ();
							isOK (hit.collider.gameObject);
						}
					}
				}
			}
		}
	}
}
