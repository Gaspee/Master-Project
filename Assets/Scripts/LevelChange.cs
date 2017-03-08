using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Non-Default Packages
using VRTK;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour {

	public float _timer;
	public string _newLevel;

	private float _timerDefault;

	// Use this for initialization
	void Start () {
		_timerDefault = _timer;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.GetComponent<VRTK_InteractableObject> ().IsTouched ()) {
			if (_timer > 0) {
				_timer -= Time.deltaTime;
			} else {
				changeScene ();
			}
		} else {
			_timer = _timerDefault;
		}
	}

	void changeScene() {
		SceneManager.LoadScene (_newLevel);
	}
}
