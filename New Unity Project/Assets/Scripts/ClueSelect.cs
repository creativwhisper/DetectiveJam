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

	// Use this for initialization
	void Start () {
		
	}

	public void changeDialogue(int i){
		phone.GetComponent<DialogueEvent> ().currentDialogue = i;
		phone.GetComponent<DialogueEvent> ().LaunchDialogue ();
		phone.GetComponent<DialogueEvent> ().currentDialogue = 0;
	}
		
	public void isOK(GameObject clue){
		string obj1 = clue.gameObject.GetComponent<NoteClick>().obj1;
		string obj2 = clue.gameObject.GetComponent<NoteClick>().obj2;
		int verb = clue.gameObject.GetComponent<NoteClick>().verb;

		if (pista1 && pista2 && pista3) {
			//Win game dialogue:
			this.changeDialogue (5);
			return;
		}

		if ((obj1 == "time of death" || obj2 == "time of death") && (obj1 == "freezing cold" || obj2 == "freezing cold") && (verb == 2)) {
			if (!pista1) {
				pista1 = true;
				//Pista correcta:
				this.changeDialogue (2);
			} else
				//Ya me has dicho esa pista
				this.changeDialogue (4);
		} else {
			/*if (obj1 == "Casa" || obj2 == "Casa")
				//this.changeDialogue ();
			if (obj1 == "Cama" || obj2 == "Cama")
				//this.changeDialogue ();
			if (verb == 2)
				//this.changeDialogue ();
			else
				//No hay nada bien
				this.changeDialogue (3);*/
		}
	}


	// Update is called once per frame
	void Update () {
		if(activated){
			if (numberOfClues == 0) {
				Continue.interactable = true;
				activated = false;
				//No tienes ninguna pista.
				this.changeDialogue (1);
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
