using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Non-default libraries
using UnityEngine.SceneManagement;
using VRTK;

public class ChangeLevelOnTouch : VRTK_InteractableObject {

	public string _newLevel;

	public override void StartUsing(GameObject usingObject)
	{
		base.StartUsing(usingObject);
		changeLevel();
	}

	// Update is called once per frame
	void Update () {
	}

	void changeLevel() {
		SceneManager.LoadScene (_newLevel);

	}
}
