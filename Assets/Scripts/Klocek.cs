using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Klocek : MonoBehaviour
{
	float LastInputTime;
	const float cooldown = 0.1f;

    float fall = 0;
    private float fallSpeed;

    public bool dopuśćRotacje = true;
    public bool ogarniczRotacje = false;
    // Use this for initialization
    void Start()
    {
        fallSpeed = GameObject.Find("GameScripts").GetComponent<Gra>().fallSpeed;
    }

    // Update is called once per frame
    void Update()
    {
		if (Time.time <= LastInputTime + cooldown)
		{
			return; // not enough time has passed.

		}

        Sterowanie();

    }

    public void Wprawo()
    {
        LastInputTime = Time.time;
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

    public void Wlewo()
    {
        LastInputTime = Time.time;
        transform.position += new Vector3(-1, 0, 0);
        if (SprawdzCzyJestWDobrejPozycji())
        {

        }
        else
        {
            transform.position += new Vector3(1, 0, 0);
        }
    }

    public void Obrot()
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

    public void Opadanie()
    {
        LastInputTime = Time.time;
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

    public void Sterowanie()
    {
		if (Input.GetKey("right"))
        {
            Wprawo();
        }
		if (Input.GetKey("left"))
        {
            Wlewo();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Obrot();
        }
		if (Input.GetKey("down") || Time.time - fall >= fallSpeed)
        {
            Opadanie();
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