using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    private void Start()
    {
        TBPunktyEnd.text = PlayerPrefs.GetInt("TBPunktyEnd").ToString();
    }
    public Text TBPunktyEnd;

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
