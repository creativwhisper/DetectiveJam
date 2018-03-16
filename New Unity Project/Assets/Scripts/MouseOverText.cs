using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOverText : MonoBehaviour {

    /// <summary>
    /// Ésta clase es sólo para mostrar un mouse over al pasar el ratón por encima de las pistas y que de una idea general
    /// Por ejemplo: Informe forense, Foto exterior de la casa, Nombre-de-sospechoso, etc.
    /// Utiliza el tag ahora mismo pero eso puede ser ineficiente y requerir cambiarse.
    /// </summary>
  
    public Text mouseOverText;

    private RaycastHit hit;

	
	// Update is called once per frame
	void Update () {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider.tag != "Untagged")
            {
                mouseOverText.text = hit.collider.name;
            } else
            {
                mouseOverText.text = " ";
            }
        }

    }
}
