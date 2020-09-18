using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Once we click on a card we disable it to make it invisible and we call LoadCard and we tell it to load the card that we clicked on that card.

namespace Stellar{
	public class CurrentSelected : MonoBehaviour
	{
		public CardVariable currentCard; //This holds the CardInstance
		public CardViz cardViz;  //this holds a reference to the SelectedCard.

		Transform mTransform;

		public void LoadCard(){


			if(currentCard.value == null){
				return;
			}

			currentCard.value.gameObject.SetActive(false);
			cardViz.LoadCard(currentCard.value.viz.card);
			//cardViz.LoadCard(cardViz.card);
			cardViz.gameObject.SetActive(true);
		}

		public void DropCard(){
			cardViz.gameObject.SetActive(false);
		}

		private void Start(){
			mTransform = this.transform;
			DropCard();
		}

		void Update(){
			mTransform.position = Input.mousePosition;
		}
	}
}
