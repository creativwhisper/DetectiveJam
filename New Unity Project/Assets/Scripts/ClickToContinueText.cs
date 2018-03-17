using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToContinueText : MonoBehaviour {

    public GameObject[] listOfLines;
    public int lineCounter = 0;
	
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetMouseButtonDown(0))
        {
            if (lineCounter == 4)
            {
                lineCounter = 0;
                GameObject.Find("Fade").GetComponent<Fade>().LoadScene("Case Intro");
                
            }
            else
            {
                listOfLines[lineCounter].SetActive(true);
                lineCounter++;
            }
        }
	}
}
