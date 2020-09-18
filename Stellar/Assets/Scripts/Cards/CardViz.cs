using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//MonoBehaviour script to load a card. It has an array of game objects, each game object connects to a UI propety.
// This script loads the card properties of one of our cards to the blank card we have in our hand.

namespace Stellar {
	public class CardViz : MonoBehaviour{

		public Card card;
		public CardVizProperty[] properties;
		public GameObject statsHolder;
		public GameObject outline;


		public void Start(){
			LoadCard(card);
		}

		// has CardProperty 
		// uses it to get CardVizProperty

		public void UpdateProperty(CardProperty cp,string newValue){
			if(cp==null){
				return;
			}
			CardVizProperty p = GetProperty(cp.element);
			p.text.text = newValue;
		}

		public void LoadCard(Card cardToLoad){
			
			if(cardToLoad == null)
				return;

			cardToLoad.cardViz = this;
			card = cardToLoad;
			cardToLoad.cardType.OnSetType(this);

			CloseAll();
			
			for (int i=0; i< card.properties.Length; i++){
				CardProperty cp = card.properties[i]; //we have an element e.g Attack
				CardVizProperty p = GetProperty(cp.element); //Find the Attack UI Object

				if(p==null)
					continue;

				if(cp.element is ElementInt){
					p.text.text = cp.intValue.ToString();
					p.text.gameObject.SetActive(true);
				}
				else if(cp.element is ElementText){
					p.text.text = cp.stringValue;
					p.text.gameObject.SetActive(true);
				}
				else if(cp.element is ElementImage){
					p.image.sprite = cp.sprite;
					p.image.gameObject.SetActive(true);
				}
					
			}
		}

		public void CloseAll(){
			foreach(CardVizProperty p in properties){
				if(p.image != null)
					p.image.gameObject.SetActive(false);
				
				if(p.text != null)
					p.text.gameObject.SetActive(false);
			}
		}

		public CardVizProperty GetProperty(Element e){
			CardVizProperty result = null;
			for(int i=0; i < properties.Length; i++){
				if(properties[i].element == e){
					result = properties[i];
					break;
				}
			}
			return result;
		}
	}
}

