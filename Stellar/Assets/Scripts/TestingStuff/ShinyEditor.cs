using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShinyEditor : MonoBehaviour{

	Image rend;

	void Start(){
		rend = GetComponent<Image>();
		rend.material.shader = Shader.Find("Shader");
	}

	
	void Update(){
		float shininess = Mathf.PingPong(Time.time, 1.0f);
		rend.material.SetFloat("_Shininess",shininess);
	}
}
