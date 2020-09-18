using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Card Representing the type of card. We have two subclasses spell and creature.
//We need this to disable stats when the card is spell


namespace Stellar{
	public abstract class CardType : ScriptableObject{

		//public bool canAttack;

		public abstract void OnSetType(CardViz viz);

		/*
		public bool TypeAllowsForAttack(CardInstance inst){
			if(canAttack){
				return true;
			}
			else{
				return false;
			}
		}
		*/
	}
}
