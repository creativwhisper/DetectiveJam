using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Verb : MonoBehaviour {

	public GameObject currentNote;
	public Dropdown desplegable;

	void Start(){
		desplegable.onValueChanged.AddListener (delegate {
			change();
		});
	}


	void change(){
		currentNote.GetComponent<NoteClick> ().verb = desplegable.value;
	}
}
