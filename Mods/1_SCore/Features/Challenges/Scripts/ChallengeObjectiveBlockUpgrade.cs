using System.Globalization;
using System.Xml.Linq;
using UnityEngine;

namespace Challenges {
    
    // <objective type="BlockUpgradeSCore,SCore" block="frameShapes:VariantHelper" count="10" held="meleeToolRepairT0StoneAxe" needed_resource="resourceWood" needed_resource_count="8" />
    // <objective type="BlockUpgradeSCore,SCore" block_tags="wood" count="10" held="meleeToolRepairT0StoneAxe" needed_resource="resourceWood" needed_resource_count="8" />
    // <objective type="BlockUpgradeSCore,SCore" block_tags="wood" count="10" biome="burnt_forest" />



    public class ChallengeObjectiveBlockUpgradeSCore : ChallengeObjectiveSCoreBase {
        public override ChallengeObjectiveType ObjectiveType =>
            (ChallengeObjectiveType)ChallengeObjectiveTypeSCore.ChallengeObjectiveBlockUpgradeSCore;
     
        public override void HandleAddHooks() {
            QuestEventManager.Current.BlockUpgrade += this.Current_BlockUpgrade;
        }

        public override void HandleRemoveHooks() {
            QuestEventManager.Current.BlockUpgrade -= this.Current_BlockUpgrade;
        }

        private void Current_BlockUpgrade(string block, Vector3i blockPos) {
            if (!CheckBlockName(block)) return;
            if (!CheckBiome()) return;
            if (!CheckHoldingItems()) return;
            Current++;
            CheckObjectiveComplete();
        }
       
        public override BaseChallengeObjective Clone() {
            return new ChallengeObjectiveBlockUpgradeSCore {
                biome = this.biome,
                targetName = this.targetName,
                entityTag = this.entityTag,
                itemClass = itemClass,
                itemTag = itemTag,
                isDebug = this.isDebug,
                item_material = this.item_material,
                blockName = this.blockName,
                blockTag = this.blockTag,
                neededResourceID = this.neededResourceID,
                neededResourceCount = this.neededResourceCount
            };
        }
     
    }
}