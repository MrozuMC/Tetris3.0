using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	public void NowaGraB(string Level)
	{
		SceneManager.LoadScene (Level);
	}
	public void WyjdzB()
	{
		Application.Quit ();
	}
    public void ZagrajPonownie()
    {
        Application.LoadLevel("Level");
    }
}
