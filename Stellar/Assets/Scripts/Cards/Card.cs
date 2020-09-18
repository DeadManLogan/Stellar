using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Represents a UI Card. A Card is made of properties and it's type.

namespace Stellar {

	[CreateAssetMenu(menuName = "Card")]
	public class Card : ScriptableObject{

		[System.NonSerialized]
		public int instId;

		[System.NonSerialized]
		public CardViz cardViz;

		
		public CardProperty[] properties;
		public int cost;
		public CardType cardType;
		public CardElement element;

		public CardProperty GetProperty(Element e){
			for(int i=0;i<properties.Length;i++){
				if(properties[i].element == e){
					return properties[i];
				}
			}
			return null;
		}

		public CardProperty GetProperty(string name){
			for(int i=0;i<properties.Length;i++){
				if(properties[i].element.elementName == name){
					return properties[i];
				}
			}
			return null;
		}

	}
}