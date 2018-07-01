using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour {

	[SerializeField]
	[Range(0f, 5f)]
	float duration = 0.5f;
	float elapsed = 0;

	public IEnumerator Fade() {
		Image image = GetComponent<Image>();
		Color color = image.color;
		
		yield return new WaitForSeconds(1);

		while (elapsed <= duration) {
			color.a = Mathf.Lerp(0,1,elapsed / duration);
			image.color = color;
			elapsed += Time.deltaTime;
			yield return null;
		} 
		
		StopAllCoroutines();
	}

}
