using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Non-Default
using VRTK;
using DigitalRuby.Tween;

public class ScaleBackOnDrop : VRTK_InteractableObject {

	private Vector3 _originalScale;

	void Start () {
		_originalScale = this.gameObject.transform.localScale;
	}
		
	public override void Ungrabbed(GameObject previousGrabbingObject) {
		base.Ungrabbed (previousGrabbingObject);
		if (this.gameObject.transform.localScale != _originalScale) {
			tweenToOriginalScale ();
		}
	}

	void tweenToOriginalScale() {
		TweenFactory.Tween(null, this.gameObject.transform.localScale, _originalScale, .4f, TweenScaleFunctions.QuadraticEaseInOut, (t) =>
			{
				//Progress
				this.gameObject.transform.localScale = t.CurrentValue;
			}, (t) =>
			{
				// Completion
			});
	}
}