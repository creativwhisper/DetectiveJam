using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueSelect : MonoBehaviour {

	private RaycastHit hit;
	public bool activated = false;
	public Button Continue;
	public int numberOfClues = 0;
	public Button phone;

	// Use this for initialization
	void Start () {
		
	}

	public void isOK(GameObject clue){
		string obj1 = clue.gameObject.GetComponent<NoteClick>().obj1;
		string obj2 = clue.gameObject.GetComponent<NoteClick>().obj2;
		int verb = clue.gameObject.GetComponent<NoteClick>().verb;
		if(obj1 == "Casa" || obj2 == "Casa" ){
			if(obj1 == "Cama" || obj2 == "Cama"){
				if (verb == 2) {
					phone.GetComponent<DialogueEvent> ().currentDialogue = 2;
					phone.GetComponent<DialogueEvent> ().LaunchDialogue ();
					phone.GetComponent<DialogueEvent> ().currentDialogue = 0;
					return;
				}
			}
		}

		phone.GetComponent<DialogueEvent> ().currentDialogue = 3;
		phone.GetComponent<DialogueEvent> ().LaunchDialogue ();
		phone.GetComponent<DialogueEvent> ().currentDialogue = 0;
	}

	// Update is called once per frame
	void Update () {
		if(activated){
			if (numberOfClues == 0) {
				Continue.interactable = true;
				activated = false;
				phone.GetComponent<DialogueEvent> ().currentDialogue = 1;
				phone.GetComponent<DialogueEvent> ().LaunchDialogue ();
				phone.GetComponent<DialogueEvent> ().currentDialogue = 0;
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
