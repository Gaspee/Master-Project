using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Non-Default Packages
using VRTK;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour {

	public string _newLevel;
	public bool _isLocked;

	// Use this for initialization
	void Start () {
		if (_isLocked) {
			this.gameObject.GetComponent<Renderer> ().material.color = Color.red;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.GetComponent<VRTK_InteractableObject> ().IsTouched () && !_isLocked) {
			changeScene ();
		}
	}

	void changeScene() {
		SceneManager.LoadScene (_newLevel);
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Key" && _isLocked) {
			_isLocked = false;
			this.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			Destroy (col.gameObject);
		}
	}
}
