using UnityEngine;
using System.Collections;

public class AngleT : MonoBehaviour
{

    public Transform target;

    private float distance;
    private float diameter;
    private float angularSize;
    public float pixelSize;
    private Vector3 scrPos;

    void Start()
    {
        diameter = target.GetComponent<Collider>().bounds.extents.magnitude;
        distance = Vector3.Distance(target.position, Camera.main.transform.position);
        angularSize = (diameter / distance) * Mathf.Rad2Deg;
        pixelSize = ((angularSize * Screen.height) / Camera.main.fieldOfView);
        scrPos = Camera.main.WorldToScreenPoint(target.position);
    }
}