using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

    public float movesSpeed;
    Vector3 moveToPosition;
    public bool selected;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

       if (Input.GetMouseButtonDown(1) && selected)
            {
            moveToPosition = Camera.main.ViewportToWorldPoint(Input.mousePosition);
            }
        if (transform.position != moveToPosition)
            transform.position = Vector3.Slerp(transform.position,moveToPosition,movesSpeed * Time.deltaTime);

        }
}
