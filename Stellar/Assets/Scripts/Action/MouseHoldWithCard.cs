using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


//Action of us dragging the card around

namespace Stellar.GameStates{

	[CreateAssetMenu(menuName = "Actions/MouseHoldWithCard")]
	public class MouseHoldWithCard : Action
	{
		public CardVariable currentCard;
		public GameState playerControlState;
		public SO.GameEvent onPlayerControlState;

		public override void Execute(float d){
			bool mouseIsDown = Input.GetMouseButton(0);
			// Sound.PlaySound("card_hover0"); epeidi kaleitai sinexeia an einai megalo akougetai kai afou to afisoume
			// an einai mikro px 1s akougetai san thorivos.

			if(!mouseIsDown){
				List<RaycastResult> results = Settings.GetUIObjs();

				bool isDropped = false;
				
				foreach(RaycastResult r in results){
					GameElements.DropArea a = r.gameObject.GetComponentInParent<GameElements.DropArea>();

					if(a!= null){
						a.OnDrop();
						break;
					}
				}

				if(!isDropped){
					currentCard.value.gameObject.SetActive(true);
				}
				else{
					currentCard.value = null;
				}

				Settings.gameManager.SetState(playerControlState);
				onPlayerControlState.Raise();			
				return;
			}
		}
	}
}
