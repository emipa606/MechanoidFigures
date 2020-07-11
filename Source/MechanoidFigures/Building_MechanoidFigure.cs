using System;
using RimWorld;
using Verse;
using Verse.Sound;

namespace MechanoidFigures
{
	// Token: 0x02000006 RID: 6
	public class Building_MechanoidFigure : Building_Art
	{
		// Token: 0x06000013 RID: 19 RVA: 0x0000219C File Offset: 0x0000039C
		public override void Destroy(DestroyMode mode)
		{
			bool spawned = base.Spawned;
			Map map = base.Map;
			SmoothableWallUtility.Notify_BuildingDestroying(this, mode);
			base.Destroy(mode);
			InstallBlueprintUtility.CancelBlueprintsFor(this);
			if (mode == DestroyMode.Deconstruct && spawned)
			{
				SoundDefOf.Building_Deconstructed.PlayOneShot(new TargetInfo(base.Position, map, false));
			}
			if (mode == DestroyMode.KillFinalize && spawned)
			{
				ThingDef_MechanoidFigure thingDef_MechanoidFigure = (ThingDef_MechanoidFigure)this.def;
				if (thingDef_MechanoidFigure != null)
				{
					if (thingDef_MechanoidFigure.soundDestroy != null)
					{
						thingDef_MechanoidFigure.soundDestroy.PlayOneShot(new TargetInfo(base.Position, map, false));
					}
				}
			}
			if (Find.PlaySettings.autoRebuild && mode == DestroyMode.KillFinalize && base.Faction == Faction.OfPlayer && spawned && this.def.blueprintDef != null && this.def.IsResearchFinished && map.areaManager.Home[base.Position] && GenConstruct.CanPlaceBlueprintAt(this.def, base.Position, base.Rotation, map, false, null).Accepted)
			{
				GenConstruct.PlaceBlueprintForBuild(this.def, base.Position, map, base.Rotation, Faction.OfPlayer, base.Stuff);
			}
		}
	}
}
