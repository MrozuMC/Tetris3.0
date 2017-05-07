using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gra : MonoBehaviour
{

    public static int wysokośćPlanszy = 20;
    public static int szerokośćPlanszy = 10;
    public static Transform[,] siatka = new Transform[szerokośćPlanszy, wysokośćPlanszy];

    public int punktyZaJednaLinie = 40;
    public int punktyZaDwieLinie = 100;
    public int punktyZaTrzyLinie = 300;
    public int punktyZaCzteryLinie = 1200;

    private int liczbaPelnychWierszyTejTury = 0;
    private int aktualnePunkty = 0;

    public Text hud_punkty;
    // Use this for initialization
    void Start()
    {
        SpawnNowegoKlocka();
    }

    // Update is called once per frame
    void Update()
    {
        AktualizujPunkty();
        AktualizujUi();
    }

    public bool SprawdzCzyJestPowyzejSiatki(Klocek klocek)
    {
        for (int x = 0; x < szerokośćPlanszy; ++x)
        {
            foreach (Transform kloc in klocek.transform)
            {
                Vector2 pos = Round(kloc.position);
                if (pos.y > wysokośćPlanszy - 1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void AktualizujUi()
    {
        hud_punkty.text = aktualnePunkty.ToString();
    }

    public void AktualizujPunkty()
    {
        if (liczbaPelnychWierszyTejTury > 0)
        {
            if (liczbaPelnychWierszyTejTury == 1)
            {
                WyczyszczonoJednaLinie();
            }
            else if (liczbaPelnychWierszyTejTury == 2)
            {
                WyczyszczonoDwieLinie();
            }
            else if (liczbaPelnychWierszyTejTury == 3)
            {
                WyczyszczonoTrzyLinie();
            }
            else if (liczbaPelnychWierszyTejTury == 4)
            {
                WyczyszczonoCzteryLinie();
            }
            liczbaPelnychWierszyTejTury = 0;
        }
    }

    public void WyczyszczonoJednaLinie()
    {
        aktualnePunkty += punktyZaJednaLinie;
    }

    public void WyczyszczonoDwieLinie()
    {
        aktualnePunkty += punktyZaDwieLinie;
    }

    public void WyczyszczonoTrzyLinie()
    {
        aktualnePunkty += punktyZaTrzyLinie;
    }

    public void WyczyszczonoCzteryLinie()
    {
        aktualnePunkty += punktyZaCzteryLinie;
    }

    public bool CzyWierszJestPelny(int y)
    {
        for (int x = 0; x < szerokośćPlanszy; ++x)
        {
            if (siatka[x, y] == null)
            {
                return false;
            }
        }
        liczbaPelnychWierszyTejTury++;
        return true;
    }

    public void UsunKlocki(int y)
    {
        for (int x = 0; x < szerokośćPlanszy; ++x)
        {
            Destroy(siatka[x, y].gameObject);
            siatka[x, y] = null;
        }
    }

    public void PrzesynWierszWdol(int y)
    {
        for (int x = 0; x < szerokośćPlanszy; ++x)
        {
            if (siatka[x, y] != null)
            {
                siatka[x, y - 1] = siatka[x, y];
                siatka[x, y] = null;
                siatka[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public void UsunWiersz()
    {
        for (int y = 0; y < wysokośćPlanszy; ++y)
        {
            if (CzyWierszJestPelny(y))
            {
                UsunKlocki(y);
                PrzesynWierszeWdol(y + 1);
                --y;
            }
        }
    }

    public void PrzesynWierszeWdol(int y)
    {
        for (int i = y; i < wysokośćPlanszy; ++i)
            PrzesynWierszWdol(i);
    }

    public void AktualizowanieSiatki(Klocek klocek) { //chyba dobrze xd
      for (int y = 0; y < wysokośćPlanszy; ++y) {
        for (int x = 0; x < szerokośćPlanszy; ++x) {
            if(siatka[x,y] !=null) {
                if (siatka[x,y].parent == klocek.transform) {
                    siatka[x,y] = null;
                }
          }
        }
      }
    foreach (Transform kloc in klocek.transform){ //nie bic mnie za kloca;
    Vector2 poz = Round (kloc.position);
        if (poz.y < wysokośćPlanszy) {
            siatka[(int)poz.x, (int)poz.y] = kloc;
        }
      }
    
    }

    public Transform GetTransformAtGridPosition (Vector2 poz) { // zmienic nazwe xd
        if (poz.y > wysokośćPlanszy - 1)
        {
            return null;
        }
        else {
            return siatka[(int)poz.x, (int)poz.y];
        }
    }

    public void SpawnNowegoKlocka()
    {
        GameObject nowyKlocek = (GameObject)Instantiate(Resources.Load(PobierzRandomowyKlocek(), typeof(GameObject)), new Vector2(5.0f, 20.0f), Quaternion.identity);
    }

    public bool SprawdzCzyJestWPlanszy(Vector3 pozycja)
    {
        return ((int)pozycja.x >= 0 && (int)pozycja.x < szerokośćPlanszy && (int)pozycja.y >= 0);
    }

    public Vector2 Round(Vector2 pozycja)
    {
        return new Vector2(Mathf.Round(pozycja.x), Mathf.Round(pozycja.y));
    }

    string PobierzRandomowyKlocek()
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

    public void KoniecGry()
    {
        Application.LoadLevel("GameOver");
    }
}