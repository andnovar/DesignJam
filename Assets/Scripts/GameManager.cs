﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    [HideInInspector] public GameObject activeObject;
    public GameObject gridImage;
    float scale,gridWidth;
    Vector3 gridPlace;

    // Use this for initialization
    void Start () {

        if (instance == null)
            instance = this;
        else
            Debug.Log("No Instance");
        gridImage.transform.position = new Vector3(gridImage.transform.position.x,gridImage.transform.position.y,1);
        Color alpha = gridImage.GetComponent<SpriteRenderer>().color;
        alpha.a = 1f;
        gridImage.GetComponent<SpriteRenderer>().color = alpha;
        gridPlace = Camera.main.ScreenToWorldPoint(new Vector3(0,0,0));
        gridPlace.z = 1f;
        gridWidth = gridImage.GetComponent<SpriteRenderer>().sprite.rect.width;
        scale = Screen.width / gridWidth;
        Debug.Log(scale + Screen.width);
        while (Camera.main.WorldToScreenPoint(gridPlace).y <= Screen.height)
            {
            gridPlace.x = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
            while (Camera.main.WorldToScreenPoint(gridPlace).x <= Screen.width)
                {
                Instantiate(gridImage,gridPlace,Quaternion.identity);
                // gridPlace.x += gridImage.transform.localScale.x;
                gridPlace.x += gridImage.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
                }
            gridPlace.y += gridImage.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
            }
        }

    void OnMouseDown ()
        {
       

        }

	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
            {
           
            Collider2D[] hits = Physics2D.OverlapCircleAll(Camera.main.ScreenToWorldPoint(Input.mousePosition),0.1f);
            if (hits.Length>0 && hits[0]!= null && hits[0].tag=="Player")
                {
                if (activeObject != null)
                activeObject.GetComponent<BoatScript>().selected = false;
                activeObject = hits[0].gameObject;
                activeObject.GetComponent<BoatScript>().selected = true;
               //Debug.Log(activeObject);
                }
            }
	
	}
}
