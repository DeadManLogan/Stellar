using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stellar{
    [CreateAssetMenu(menuName = "Player Profile")]
    public class PlayerProfile : ScriptableObject{
        public string[] cardIds;
    }
}