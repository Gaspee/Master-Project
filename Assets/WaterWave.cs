using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.Tween;

public class WaterWave : MonoBehaviour {

	private float _counterDefault;

	public float _counter;

	// Use this for initialization
	void Start () {
		_counterDefault = _counter;
	}
	
	// Update is called once per frame
	void Update () {
		if (_counter > 0) {
			_counter -= Time.deltaTime;
		} else {
			_counter = _counterDefault;
			wave ();
		}
	}

	void wave () {
		Vector3 pos = this.transform.position;
		float newY = this.transform.position.y + Random.value;

		TweenFactory.Tween(null, this.transform.position.y, newY, 5f, TweenScaleFunctions.QuadraticEaseInOut, (t1) =>
			{
				// Progress
				this.transform.position = new Vector3(this.transform.position.x, t1.CurrentValue, this.transform.position.z);
			}, (t1) =>
			{
				// Completion
				TweenFactory.Tween(null, newY, pos.y, 5f, TweenScaleFunctions.QuadraticEaseInOut, (t2) =>
					{
						// Progress
						this.transform.position = new Vector3(this.transform.position.x, t2.CurrentValue, this.transform.position.z);
					}, (t) =>
					{
						// Completion

					});
			});
		}
}
