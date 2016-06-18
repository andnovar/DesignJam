using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public GameObject activeObject;

	// Use this for initialization
	void Start () {

        if (instance == null)
            instance = this;
        else
            Debug.Log("No Instance");

	}

    void OnMouseDown ()
        {
       

        }

	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
            {
           
            Collider2D[] hits = Physics2D.OverlapCircleAll(Camera.main.ScreenToWorldPoint(Input.mousePosition),0.1f);
            if (hits.Length>0 && hits[0]!= null && hits[0].tag!="Map")
                {
                if (activeObject != null)
                activeObject.GetComponent<MovementScript>().selected = false;
                activeObject = hits[0].gameObject;
                activeObject.GetComponent<MovementScript>().selected = true;
               //Debug.Log(activeObject);
                }
            }
	
	}
}
