using RimWorld;
using Verse;

namespace MechanoidFigures
{
    // Token: 0x02000004 RID: 4
    public class CompMechanoidFigureQuality : ThingComp
    {
        // Token: 0x04000001 RID: 1

        // Token: 0x17000001 RID: 1
        // (get) Token: 0x0600000A RID: 10 RVA: 0x000020C8 File Offset: 0x000002C8
        public QualityCategory Quality { get; private set; } = QualityCategory.Normal;

        // Token: 0x0600000B RID: 11 RVA: 0x000020E0 File Offset: 0x000002E0
        public void SetQuality(QualityCategory q, ArtGenerationContext source)
        {
            Quality = QualityCategory.Normal;
            var compArt = parent.TryGetComp<CompArt>();
            compArt.InitializeArt(source);
        }

        // Token: 0x0600000C RID: 12 RVA: 0x00002109 File Offset: 0x00000309

        // Token: 0x0600000D RID: 13 RVA: 0x00002113 File Offset: 0x00000313
        public override void PostPostGeneratedForTrader(TraderKindDef trader, int forTile, Faction forFaction)
        {
            SetQuality(QualityCategory.Normal, ArtGenerationContext.Outsider);
        }

        // Token: 0x0600000E RID: 14 RVA: 0x00002120 File Offset: 0x00000320
        public override bool AllowStackWith(Thing other)
        {
            return other.TryGetQuality(out var qualityCategory) && Quality == qualityCategory;
        }

        // Token: 0x0600000F RID: 15 RVA: 0x0000214E File Offset: 0x0000034E
        public override void PostSplitOff(Thing piece)
        {
            base.PostSplitOff(piece);
            piece.TryGetComp<CompMechanoidFigureQuality>().Quality = Quality;
        }

        // Token: 0x06000010 RID: 16 RVA: 0x0000216C File Offset: 0x0000036C
        public override string CompInspectStringExtra()
        {
            return ".";
        }
    }
}