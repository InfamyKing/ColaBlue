using System.Collections;
using System.Collections.Generic;
using Improbable.General;
using Improbable.Math;
using Improbable.Player;
using Improbable.Unity.Core.Acls;
using Improbable.Worker;
using UnityEngine;

namespace Assets.EntityTemplates {
    public class PlayerFighterEntityTemplate : MonoBehaviour {
        // Template definition for a PlayerFigher snapshot entity
        static public Entity GeneratePlayerFighterEntityTemplate(string clientWorkerId, Coordinates initialPosition) {
            var playerEntityTemplate = new Entity();
            // Define components attached to entity
            playerEntityTemplate.Add(new WorldTransform.Data(new WorldTransformData(initialPosition, 0)));
            playerEntityTemplate.Add(new Health.Data(new HealthData(100)));

            // Grant component access permissions
            var acl = Acl.Build()
                .SetReadAccess(CommonPredicates.PhysicsOrVisual)
                .SetWriteAccess<WorldTransform>(CommonPredicates.PhysicsOnly)
                .SetWriteAccess<Health>(CommonPredicates.PhysicsOnly);
            playerEntityTemplate.SetAcl(acl);

            return playerEntityTemplate;
        }
    }
}
