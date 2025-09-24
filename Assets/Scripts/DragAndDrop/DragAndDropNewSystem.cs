using UnityEngine;
using UnityEngine.EventSystems; // �Muy importante incluir esta l�nea!

public class DragAndDropNewSystem : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [Tooltip("La altura que se elevar� el objeto al ser arrastrado.")]
    public float liftHeight = 0.5f;

    private Camera mainCamera;
    private Vector3 worldOffset;
    private Plane dragPlane;
    private float initialY;
    private Rigidbody rb;

    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Se ejecuta al hacer clic
    public void OnPointerDown(PointerEventData eventData)
    {
        // 1. Guarda la altura Y inicial del objeto
        initialY = transform.position.y;

        // 2. Eleva el objeto
        transform.position += new Vector3(0, liftHeight, 0);

        // 3. Crea un plano horizontal a la nueva altura del objeto
        dragPlane = new Plane(Vector3.up, transform.position);

        // 4. Calcula el desfase inicial para un arrastre suave
        Ray ray = mainCamera.ScreenPointToRay(eventData.position);
        if (dragPlane.Raycast(ray, out float distance))
        {
            Vector3 hitPoint = ray.GetPoint(distance);
            worldOffset = transform.position - hitPoint;
        }

        // Desactiva la f�sica mientras arrastras
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    // Se ejecuta mientras arrastras
    public void OnDrag(PointerEventData eventData)
    {
        // Lanza un rayo desde la c�mara hacia el plano horizontal
        Ray ray = mainCamera.ScreenPointToRay(eventData.position);

        // Encuentra el punto donde el rayo intersecta el plano
        if (dragPlane.Raycast(ray, out float distance))
        {
            Vector3 pointOnPlane = ray.GetPoint(distance);

            // La nueva posici�n ser� el punto en el plano m�s el desfase
            // La altura Y se mantiene constante porque nos movemos sobre el plano
            transform.position = pointOnPlane + worldOffset;
        }
    }

    // Se ejecuta al soltar el clic
    public void OnPointerUp(PointerEventData eventData)
    {
        // Devuelve el objeto a su altura Y original
        transform.position = new Vector3(transform.position.x, initialY, transform.position.z);

        // Reactiva la f�sica
        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }
}