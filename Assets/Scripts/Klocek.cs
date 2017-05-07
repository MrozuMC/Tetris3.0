using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Klocek : MonoBehaviour
{

    float fall = 0;
    public float fallSpeed = 1;
    public bool dopuśćRotacje = true;
    public bool ogarniczRotacje = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Sterowanie();
    }
    public void Sterowanie()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (SprawdzCzyJestWDobrejPozycji())
            {
               FindObjectOfType<Gra>().AktualizowanieSiatki(this); // tu tez cos zmienialem xd
            }
            else
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (SprawdzCzyJestWDobrejPozycji())
            {

            }
            else
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (dopuśćRotacje)
            {
                if (ogarniczRotacje)
                {

                    if (transform.rotation.eulerAngles.z >= 90)
                    {
                        transform.Rotate(0, 0, -90);
                    }
                    else
                    {
                        transform.Rotate(0, 0, 90);
                    }

                }
                else
                {
                    transform.Rotate(0, 0, 90);
                }
                if (SprawdzCzyJestWDobrejPozycji())
                {
                    FindObjectOfType<Gra>().AktualizowanieSiatki(this); //tu tez
                }
                else
                {
                    if (ogarniczRotacje)
                    {
                        if (transform.rotation.eulerAngles.z >= 90)
                        {
                            transform.Rotate(0, 0, -90);
                        }
                        else
                        {
                            transform.Rotate(0, 0, 90);
                        }
                    }
                    else
                    {
                        transform.Rotate(0, 0, -90);
                    }

                }
            }

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - fall >= fallSpeed)
        {
            transform.position += new Vector3(0, -1, 0);
            if (SprawdzCzyJestWDobrejPozycji())
            {
                FindObjectOfType<Gra>().AktualizowanieSiatki(this); // tuuu
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);
                FindObjectOfType<Gra>().UsunWiersz();
                if (FindObjectOfType<Gra>().SprawdzCzyJestPowyzejSiatki(this))
                {
                    FindObjectOfType<Gra>().KoniecGry();
                }
                enabled = false;
                FindObjectOfType<Gra>().SpawnNowegoKlocka();
            }
            fall = Time.time;
        }
    }

    bool SprawdzCzyJestWDobrejPozycji()
    {
        foreach (Transform klocek in transform)
        {
            Vector2 pozycja = FindObjectOfType<Gra>().Round(klocek.position);
            if (FindObjectOfType<Gra>().SprawdzCzyJestWPlanszy(pozycja) == false)
            {
                return false;
            }
            if (FindObjectOfType<Gra>().GetTransformAtGridPosition(pozycja) != null && FindObjectOfType<Gra>().GetTransformAtGridPosition(pozycja).parent != transform) // tu tez zmienic nazwe na to co tam
            {
                return false;
            }
        }
        return true;
    }

}