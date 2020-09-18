using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Stellar{
	public class CardInstance : MonoBehaviour, IClickable{


		public enum State {
			InHand,
			Idle,
			Flatfooted,
			Attacking
		}

		public State state;
		public CardViz viz;
		public Stellar.GameElements.GE_Logic currentLogic;

		void Start(){
			viz = GetComponent<CardViz>();	
			state = State.InHand;
		}

		public bool CanAttack(){
			if(state==State.Idle){
				return true;
			}
			else{
				return false;
			}
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
