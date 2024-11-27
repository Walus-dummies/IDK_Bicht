using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    // variables publicas
    public float radius;
    public GameObject interactionText;

    // Variables privadas
    private InteractableObject interactableObject;
    private void Update()
    {
        SearchForObject();
        Interact();
    }

    // funcion de interaccion
    void Interact()
    {
        // si presionamos la letra E
        if (Input.GetKeyDown(KeyCode.E) && interactableObject != null)
        {
            interactableObject.Interaction();
        }
    }

    void SearchForObject()
    {
        InteractableObject _interactableObject = null;
        float _distanceFromObject = radius + 1f;

        // Buscamos objetos interactuables cercanos
        RaycastHit[] _objects = Physics.SphereCastAll(transform.position, radius, transform.forward);

        // Si colisiono con objetos
        if (_objects != null)
        {
            // Buscamos el objeto interactuable más cercano
            foreach (RaycastHit _collidedObject in _objects)
            {
                // Si el objeto es un objeto interactuable
                if (_collidedObject.collider.gameObject.GetComponent<InteractableObject>() != null)
                {
                    // si esta mas cerca que el anterior
                    if (Vector3.Distance(transform.position, _collidedObject.collider.transform.position) < _distanceFromObject)
                    {
                        // Guardamos el objeto y su distancia
                        _distanceFromObject = Vector3.Distance(transform.position, _collidedObject.collider.transform.position);
                        _interactableObject = _collidedObject.collider.gameObject.GetComponent<InteractableObject>();
                    }
                }
            }

            // si encontramos un objeto interactuable entonces interactuamos con el
            if (_interactableObject != null)
            {
                interactableObject = _interactableObject;
                interactionText.SetActive(true);
                interactionText.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(interactableObject.transform.position);
            }
            else
            {
                interactableObject = null;
                interactionText.SetActive(false);
            }
        }
    }
}
