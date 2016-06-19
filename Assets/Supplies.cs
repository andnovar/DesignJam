using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Supplies : MonoBehaviour {

    enum Types { Alcohol, Food, Miscelaneous };
    public enum Uncertain_level { Certain, Somewhat_certain, Uncertain};
    public string container;
    public double value;
    public double weight;
    public double radius;
    public Uncertain_level uncertainty;
    public GameObject uncertain_circle;
    private double min_value = 250;
    private double max_value = 3000;
    private double min_weight = 30;
    private double max_weight = 300;

    // Use this for initialization
    void Start () {
        Types mytypes = Types.Alcohol;
        double diffval = max_value - min_value;
        transform.localPosition = new Vector2(Random.Range(-5,5), Random.Range(-4, 4));
        transform.localScale = new Vector2((float)((value / 5500) + 0.4545), (float)((value / 5500) + 0.4545));
        if (uncertainty == Uncertain_level.Somewhat_certain)
            uncertain_circle.transform.localScale = new Vector2((float)2.0, (float)2.0);
        else if (uncertainty == Uncertain_level.Uncertain)
            uncertain_circle.transform.localScale = new Vector2((float)2.0, (float)2.0);
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
