using Improbable.Entity.Component;
using Improbable.Unity.Visualizer;
using Improbable.Player;
using Improbable.Worker;
using Improbable.Unity;
using Improbable.Unity.Core;
using Assets.EntityTemplates;
using UnityEngine;

namespace Assets.Gamelogic.Fighters.Behaviours {
    [EngineType(EnginePlatform.FSim)]
    public class PlayerSpawnManager : MonoBehaviour {

        [Require]
        private Spawner.Writer SpawnerWriter;

        // Use this for initialization
        void OnEnable() {
            SpawnerWriter.CommandReceiver.OnSpawnPlayer += OnSpawnPlayer;
        }

        void OnDisable() {
            SpawnerWriter.CommandReceiver.OnSpawnPlayer -= OnSpawnPlayer;
        }

        // Update is called once per frame
        void OnSpawnPlayer(ResponseHandle<Spawner.Commands.SpawnPlayer, SpawnPlayerRequest, SpawnPlayerResponse> responseHandle) {
            SpawnPlayerRequest request = responseHandle.Request;
            Entity playerEntityTemplate = PlayerFighterEntityTemplate.GeneratePlayerFighterEntityTemplate(responseHandle.CallerInfo.CallerWorkerId,
                                                                                                          request.initialPosition);
            SpatialOS.Commands.CreateEntity(SpawnerWriter, "PlayerFighter", playerEntityTemplate, result => {
                if (result.StatusCode != StatusCode.Success) {
                    Debug.LogError("PlayerSpawnManager failed to create entity: " + result.ErrorMessage);
                    return;
                }
                var createdEntityId = result.Response.Value;
                Debug.Log("PlayerSpawnManager created player entity with entity ID: " + createdEntityId);

                // Acknowledge command receipt and provide client with ID for newly created entity
                responseHandle.Respond(new SpawnPlayerResponse(createdEntityId));
            });
        }
    }
}
