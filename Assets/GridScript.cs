using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GridScript : MonoBehaviour {

    SpriteRenderer gridSprite;

	// Use this for initialization
	void Start () {
        gridSprite = GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Disable ()
        {
        Color alpha = gridSprite.color;
        alpha.a = 0.0f;
        gridSprite.color = alpha;
        StartCoroutine("Enable");
        }

   

    IEnumerator Enable ()
        {
        while (gridSprite.color.a < 0.8f)
            {
            Color alpha = gridSprite.color;
            alpha.a += 0.1f;
            gridSprite.color = alpha;
            yield return new WaitForSeconds(2f);
            }
        }
}
