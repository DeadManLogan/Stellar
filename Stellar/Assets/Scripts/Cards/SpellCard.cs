using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Stellar{
	[CreateAssetMenu(menuName = "Cards/Spell")]
	public class SpellCard : CardType{
	
		public override void OnSetType(CardViz viz){
			
			viz.statsHolder.SetActive(false);
		}		
	}
}
