using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gra : MonoBehaviour {

    public static int wysokośćPlanszy = 20;
    public static int szerokośćPlanszy = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public bool sprawdzCzyJestWPlanszy(Vector3 pozycja)
    {
        return ((int) pozycja.x >= 0 && (int)pozycja.x < szerokośćPlanszy && (int)pozycja.y >= 0);
    }

    public Vector2 Round (Vector2 pozycja)
    {
        return new Vector2 (Mathf.Round(pozycja.x), Mathf.Round(pozycja.y));
    }
}
