using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteClick : MonoBehaviour {

	public string obj1;
	public string obj2;
	public int verb;
	public Dropdown desplegable;
	public GameObject panel;
	private bool aux = false;

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			panel.SetActive (false);
			if (aux) {
				GameObject.Find ("Main Camera").GetComponent<MouseClick> ().canIPut = true;
				aux = false;		
			}
		}
	}

	private void OnMouseDown() {
		GameObject.Find ("Main Camera").GetComponent<MouseClick>().canIPut = false;
		panel.SetActive (true);
		desplegable.GetComponent<Verb> ().currentNote = this.gameObject;
		desplegable.value = verb;
		aux = true;
	}
}
