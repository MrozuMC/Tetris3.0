using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gra : MonoBehaviour
{

    public static int wysokośćPlanszy = 20;
    public static int szerokośćPlanszy = 10;
    public static Transform[,] grid = new Transform[szerokośćPlanszy, wysokośćPlanszy];


    // Use this for initialization
    void Start()
    {
        spawnNowegoKlocka();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void aktualizowanieSiatki(Klocek klocek) { //chyba dobrze xd
      for (int y = 0; y <wysokośćPlanszy; ++y) {
        for (int x = 0; y <szerokośćPlanszy; ++x) {
            if(grid[x,y] !=null) {
            if (grid[x,y].parent == klocek.transform) {
        grid[x,y] = null;
            }
          }
        }
      }
    foreach (Transform kloc in klocek.transform){ //nie bic mnie za kloca;
    Vector2 poz = Round (kloc.pozycja);
        if (poz.y < wysokośćPlanszy) {
            grid[(int)poz.x, (int)poz.y] = kloc;
        }
      }
    
    }
    public Transform GetTransformAtGridPosition (Vector2 poz) { // zmienic nazwe xd
        if (poz.y > wysokośćPlanszy - 1)
        {
            return null;
        }
        else { }
    }
        public void spawnNowegoKlocka()
    {
        GameObject nowyKlocek = (GameObject)Instantiate(Resources.Load(pobierzRandomowyKlocek(), typeof(GameObject)), new Vector2(5.0f, 20.0f), Quaternion.identity);
    }
    public bool sprawdzCzyJestWPlanszy(Vector3 pozycja)
    {
        return ((int)pozycja.x >= 0 && (int)pozycja.x < szerokośćPlanszy && (int)pozycja.y >= 0);
    }

    public Vector2 Round(Vector2 pozycja)
    {
        return new Vector2(Mathf.Round(pozycja.x), Mathf.Round(pozycja.y));
    }

    string pobierzRandomowyKlocek()
    {
        int randomKlocek = Random.Range(1, 8);
        string nazwaRandomowegoKlocka = "Prefabs/T";

        switch (randomKlocek)
        {
            case 1:
                nazwaRandomowegoKlocka = "Prefabs/T";
                break;
            case 2:
                nazwaRandomowegoKlocka = "Prefabs/I";
                break;
            case 3:
                nazwaRandomowegoKlocka = "Prefabs/S";
                break;
            case 4:
                nazwaRandomowegoKlocka = "Prefabs/Z";
                break;
            case 5:
                nazwaRandomowegoKlocka = "Prefabs/J";
                break;
            case 6:
                nazwaRandomowegoKlocka = "Prefabs/L";
                break;
            case 7:
                nazwaRandomowegoKlocka = "Prefabs/O";
                break;
            case 8:
                nazwaRandomowegoKlocka = "Prefabs/T";
                break;
        }
        return nazwaRandomowegoKlocka;
    }
}