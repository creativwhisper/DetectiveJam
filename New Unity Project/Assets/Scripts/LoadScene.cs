using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
	
	// Use this for initialization
	public string scene;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown() {
		GameObject.Find("Fade").GetComponent<Fade>().LoadScene(scene);
		//SceneManager.LoadScene(scene);
	}
	
}
