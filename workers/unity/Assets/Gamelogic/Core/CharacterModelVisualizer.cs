﻿using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;

namespace Assets.Gamelogic.Core
{
    [EngineType(EnginePlatform.Client)]
    public class CharacterModelVisualizer : MonoBehaviour
    {
        [SerializeField] private GameObject Model;

        public void SetModelVisibility(bool isVisible)
        {
            Model.SetActive(isVisible);
        }
    }
}
