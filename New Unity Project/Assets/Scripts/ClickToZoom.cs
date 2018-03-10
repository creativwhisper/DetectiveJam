using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToZoom : MonoBehaviour {

    public Transform clickedObjectTransform; // referencia del objeto que hemos clickeado
    public Vector3 objectStartPosition; // referencia a donde empezó el objeto para volver a dejarlo en el mismo sitio

    [SerializeField]
    private Vector3 ObjectPositionAfterZoomed; // posición fija que tendrá el objeto frente a cámara cuando esté zoomeado
    private bool IsZoomActive = false; 
    
    		
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(1)) // Click con el botón derecho del ratón
        {
            if (!IsZoomActive) // Si el zoom no está activo es posible activarlo
            {
                RaycastHit hit; // almacenar el objeto golpeado por el rayo
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // lanza rayo a la posición del mouse
                if (ray == "Clue" && !IsZoomActive)
                {
                    ZoomClickedObject(hit.transform); // mandamos la info del hit a la función de zoomear.
                }
            } else if (IsZoomActive)
            {
                ReturnObjectToStartPosition(); // si hay un objeto zoomeado y volvemos a pulsar el botón derecho, deja de estar zoomeado
            } else
            {
                return; // cualquier otro hit sale del if y no hace nada.
            }
        }
	}

    void ZoomClickedObject(Transform clickedObjectTransform)
    {
        IsZoomActive = true;
        objectStartPosition = clickedObjectTransform.position; // almacenamos la posición del objeto antes de moverlo.
        clickedObjectTransform.Translate(ObjectPositionAfterZoomed); // movemos el objeto a donde queremos que se muestre.
        
    }

    void ReturnObjectToStartPosition()
    {
        if(clickedObjectTransform == null) // si no hay ningún objeto almacenado en su sitio, salimos de la función.
        {
            return; 
        } else
        {
            clickedObjectTransform.Translate(objectStartPosition); // volvemos a poner el objeto en donde estaba originalmente.
            clickedObjectTransform = null; // vaciamos la referencia
        }
    }
}
