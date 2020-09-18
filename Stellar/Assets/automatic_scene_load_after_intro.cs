using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class automatic_scene_load_after_intro : MonoBehaviour{

        private IEnumerator WaitForSceneLoad(){
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(1);
        }
        private IEnumerator coroutine;

        void Start(){
            coroutine = WaitForSceneLoad();
            StartCoroutine(coroutine);
        }

}
