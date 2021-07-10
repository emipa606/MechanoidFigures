using RimWorld;
using Verse;
using Verse.Sound;

namespace MechanoidFigures
{
    // Token: 0x02000006 RID: 6
    public class Building_MechanoidFigure : Building_Art
    {
        // Token: 0x06000013 RID: 19 RVA: 0x0000219C File Offset: 0x0000039C
        public override void Destroy(DestroyMode mode = DestroyMode.Vanish)
        {
            var spawned = Spawned;
            var map = Map;
            SmoothableWallUtility.Notify_BuildingDestroying(this, mode);
            base.Destroy(mode);
            InstallBlueprintUtility.CancelBlueprintsFor(this);
            if (mode == DestroyMode.Deconstruct && spawned)
            {
                SoundDefOf.Building_Deconstructed.PlayOneShot(new TargetInfo(Position, map));
            }

            if (mode == DestroyMode.KillFinalize && spawned)
            {
                var thingDef_MechanoidFigure = (ThingDef_MechanoidFigure) def;
                thingDef_MechanoidFigure?.soundDestroy?.PlayOneShot(new TargetInfo(Position, map));
            }

            if (Find.PlaySettings.autoRebuild && mode == DestroyMode.KillFinalize && Faction == Faction.OfPlayer &&
                spawned && def.blueprintDef != null && def.IsResearchFinished && map.areaManager.Home[Position] &&
                GenConstruct.CanPlaceBlueprintAt(def, Position, Rotation, map).Accepted)
            {
                GenConstruct.PlaceBlueprintForBuild(def, Position, map, Rotation, Faction.OfPlayer, Stuff);
            }
        }
    }
}