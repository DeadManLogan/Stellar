using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stellar.GameElements{

	[CreateAssetMenu(menuName = "Game Elements/My Hand Card")]
	public class HandCard : GE_Logic
	{
	
		public SO.GameEvent onCurrentCardSelected;
		public CardVariable currentCard;
		public CardVariable highlightedCard;
		public Stellar.GameStates.GameState holdingCard;

		public override void OnClick(CardInstance instance){
			currentCard.Set(instance);
			Settings.gameManager.SetState(holdingCard);
			onCurrentCardSelected.Raise();
		}
		public override void OnHighlight(CardInstance instance){
			//highlightedCard.viz.LoadCard(instance.viz.card);
		}
	}
}
