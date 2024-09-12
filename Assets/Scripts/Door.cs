using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject door;
    [SerializeField] private Vector3 offset;
    private Vector3 final;
    private Vector3 initial;

    private void Start()
    {
        initial = transform.position;
        final = transform.position + offset;
    }

    private void Update()
    {
        //transform.position = Vector3.Lerp(door.transform.position, final, 0.3f * Time.deltaTime);
    }

    public void lowerDoor()
    {
        transform.position = Vector3.Lerp(door.transform.position, final, 0.3f * Time.deltaTime);
    }

    public void raiseDoor()
    {
        transform.position = Vector3.Lerp(door.transform.position, initial, 0.3f * Time.deltaTime);
    }
}
