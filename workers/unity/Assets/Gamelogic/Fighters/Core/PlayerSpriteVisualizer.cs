using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Gamelogic.Core {
    public class PlayerSpriteVisualizer : MonoBehaviour {

        [SerializeField]
        private SpriteRenderer SpriteRenderer;

        public void SetSpriteVisibility(bool isVisible) {
            SpriteRenderer.enabled = isVisible;
        }
    }
}
