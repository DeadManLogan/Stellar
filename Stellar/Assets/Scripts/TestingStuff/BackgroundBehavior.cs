using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stellar{
	public class BackgroundBehavior : MonoBehaviour
	{
    
		float scrollSpeed = 10f;
		Vector2 startPos = new Vector2(0,-70);
		
		void Start(){
			transform.position = startPos;
		}

		void Update(){
			float newPos = Mathf.Repeat(Time.time * scrollSpeed,140);
			transform.position = startPos + Vector2.up * newPos;
		}
	}
}
