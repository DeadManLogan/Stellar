using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Stellar{
	public class CardInstance : MonoBehaviour, IClickable
	{
	
		public CardViz viz;
		
		public Stellar.GameElements.GE_Logic currentLogic;
		public bool isFlatfooted = true;

		void Start(){
			viz = GetComponent<CardViz>();	
		}

		public bool CanAttack(){
			return !isFlatfooted;
		}
		
		public void OnClick(){

			if(currentLogic == null)
				return;
		
			currentLogic.OnClick(this);
		}
	
		public void OnHighlight(){
			if(currentLogic == null)
				return;

			currentLogic.OnHighlight(this);

			GameManager gm = GameManager.singleton;
			GameObject highlightedCard = gm.highlightedCard;
			highlightedCard.SetActive(true);
			CardViz v = highlightedCard.GetComponent<CardViz>();
			v.LoadCard(this.viz.card);

		}
	}
}
