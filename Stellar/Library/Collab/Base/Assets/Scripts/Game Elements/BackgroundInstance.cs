using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stellar{
    public class BackgroundInstance : MonoBehaviour, IClickable
    {
        public void OnClick(){
            Debug.Log("Why are u clicking the background, YOU WEIRDO!?");
		}
	
		public void OnHighlight(){
			GameManager gm = GameManager.singleton;
			GameObject highlightedCard = gm.highlightedCard;
            highlightedCard.SetActive(false);

		}
    }
}
