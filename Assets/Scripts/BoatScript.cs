using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoatScript : MonoBehaviour {


    public float movesSpeed;
    [Range(1,6)]public int crew;
    public float fuel;
    float currentFuel;
    Vector3 moveToPosition;
    [HideInInspector] public bool selected;
    GameObject boatAttributes,fuelBar;
    RaycastHit hit;

	// Use this for initialization
	void Start () {
        movesSpeed /= 100;
        boatAttributes = transform.Find("BoatAttributes").gameObject;
        boatAttributes.transform.Find("CrewSize").GetComponent<Text>().text = "Crew: " + crew;
        fuelBar = boatAttributes.transform.Find("BaseFuel").transform.Find("FuelLevel").gameObject;
        moveToPosition = transform.position;
        currentFuel = fuel;
    }
	
	// Update is called once per frame
	void Update () {

       if (Input.GetMouseButtonDown(1) && selected)
            {
            Debug.Log("Selected");
            moveToPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moveToPosition.z = transform.position.z;
            StartCoroutine("ReduceFuel");
            }
        if (transform.position != moveToPosition)
            {
            Debug.DrawRay(transform.position,transform.forward*10);
            Collider2D[] hits = Physics2D.OverlapCircleAll((transform.position - new Vector3(0,0,3f)),1f);
            if (hits.Length > 0)
                {
                foreach (Collider2D grid in hits)
                    {
                    if (grid.gameObject.GetComponent<GridScript>())
                        grid.gameObject.GetComponent<GridScript>().Disable();
                    }
                }
            transform.position = Vector3.Lerp(transform.position,moveToPosition,movesSpeed * Time.deltaTime);
            }

        }

    IEnumerator ReduceFuel ()
        {
        while (Vector3.Distance(transform.position,moveToPosition)>0.5f)
            {
            currentFuel -= 0.01f;
            fuelBar.GetComponent<RectTransform>().sizeDelta = new Vector2(fuelBar.GetComponent<RectTransform>().sizeDelta.x * currentFuel / fuel,fuelBar.GetComponent<RectTransform>().sizeDelta.y);
           // Debug.Log(currentFuel);
             yield return new WaitForSeconds(0.1f);
            }
        }
}
