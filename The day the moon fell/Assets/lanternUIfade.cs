using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanternUIfade : MonoBehaviour
{
	[SerializeField] float fadeamount;
	CanvasGroup canvasopacity;
	private void OnEnable()
	{
		canvasopacity = GetComponent<CanvasGroup>();
		canvasopacity.alpha= 1.0f;
		StartCoroutine(fade());
	}

	IEnumerator fade()
	{
		while (canvasopacity.alpha > 0.0f)
		{
			canvasopacity.alpha = canvasopacity.alpha - fadeamount;
			yield return new WaitForFixedUpdate();
		}
		this.enabled= false;
	}
}
