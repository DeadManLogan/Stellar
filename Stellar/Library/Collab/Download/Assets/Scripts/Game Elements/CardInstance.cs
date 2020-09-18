using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//DoCombat
//ResolveCombat
//CardInstance attacker;
//CardInstance defender;


namespace Stellar{
	public class CardInstance : MonoBehaviour, IClickable, Damageable{

		public enum State {
			InHand,
			Idle,
			Flatfooted,
			Attacking,
			Tired
		}

		public State state;
		public CardViz viz;
		public Stellar.GameElements.GE_Logic currentLogic;

		private int attack;
		private int health;
		private int elementalPower;
		
		void Start(){
			viz = GetComponent<CardViz>();
			Card thiscard = viz.card;
			if(thiscard.cardType is CreatureCard){
				attack = thiscard.GetProperty("Attack").intValue;
				health = thiscard.GetProperty("Health").intValue;
				elementalPower = thiscard.GetProperty("ElementalPower").intValue;
			}
			state = State.InHand;
		}

		public void Damage(int v){
			health = health - v;
			if(health<=0){
				Destroy(gameObject);
				Settings.gameManager.currentPlayer.downCards.Remove(this);
			}
			CardProperty healthProperty = viz.card.GetProperty("Health");
			viz.UpdateProperty(healthProperty,health.ToString());
		}

		public bool CanAttack(){
			if(state==State.Idle || state==State.Attacking){
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

		public int GetAttack(){
			return this.attack;
		}
		public void SetAttack(int attack){
			this.attack = attack;
		}
		public int GetHealth(){
			return this.health;
		}
		public void SetHealth(int health){
			this.health = health;
		}
		public int GetElementalPower(){
			return this.elementalPower;
		}
		public void SetElementalPower(int elementalPower){
			this.elementalPower = elementalPower;
		}


	}
}
