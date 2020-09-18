using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Stellar{
	public class SessionManager : MonoBehaviour{
		public static SessionManager singleton;
		public delegate void OnSceneLoaded();
		public OnSceneLoaded onSceneLoaded;


		private void Awake(){
			if(singleton == null){
				singleton = this;
				DontDestroyOnLoad(this.gameObject);
			}
			else{
				Destroy(this.gameObject);
			}
		}

		public void LoadGameLevel(OnSceneLoaded callback){
			onSceneLoaded = callback;
			SceneManager.LoadScene(1);
			// StartCoroutine(LoadLevel("Scene1"));
		}

		public void LoadMenu(){
			StartCoroutine("Menu");
		}

		IEnumerator LoadLevel(string level){
			yield return SceneManager.LoadSceneAsync(level, LoadSceneMode.Single);
			if(onSceneLoaded != null){
				onSceneLoaded();
				onSceneLoaded = null;
			}
		}

	}
}
