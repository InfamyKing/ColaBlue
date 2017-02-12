using Improbable.Player;
using Improbable.General;
using Improbable.Worker;
using Improbable.Math;
using Improbable.Unity.Core.Acls;
using UnityEngine;

namespace Assets.EntityTemplates {
    public class PlayerSpawnerEntityTemplate : MonoBehaviour {

        public static SnapshotEntity GeneratePlayerSpawnerSnapshotEntityTemplate() {
            SnapshotEntity playerSpawner = new SnapshotEntity {Prefab = "PlayerSpawner"};

            playerSpawner.Add(new WorldTransform.Data(Coordinates.ZERO, 0));
            playerSpawner.Add(new Spawner.Data(new SpawnerData()));
            //playerSpawner.Add(new PlayerLifecycle.Data(new PlayerLifecycleData()));

            //Acl acl = Acl.GenerateServerAuthoritativeAcl(playerSpawner);
            Acl acl = Acl.Build()
                .SetReadAccess(CommonPredicates.PhysicsOrVisual)
                .SetWriteAccess<WorldTransform>(CommonPredicates.PhysicsOnly)
                .SetWriteAccess<Spawner>(CommonPredicates.PhysicsOnly);
            playerSpawner.SetAcl(acl);

            return playerSpawner;
        }
    }
}
