using RimWorld;
using Verse;

namespace MechanoidFigures
{
    // Token: 0x02000003 RID: 3
    public class CompMechanoidFigure : CompArt
    {
        // Token: 0x06000002 RID: 2 RVA: 0x0000206B File Offset: 0x0000026B
        public new void InitializeArt(ArtGenerationContext context)
        {
        }

        // Token: 0x06000003 RID: 3 RVA: 0x0000206E File Offset: 0x0000026E
        public new void InitializeArt(Thing thing)
        {
        }

        // Token: 0x06000004 RID: 4 RVA: 0x00002071 File Offset: 0x00000271
        public void InitializeArt(Thing thing, ArtGenerationContext context)
        {
        }

        // Token: 0x06000005 RID: 5 RVA: 0x00002074 File Offset: 0x00000274
        public override string CompInspectStringExtra()
        {
            return "";
        }

        // Token: 0x06000006 RID: 6 RVA: 0x0000208C File Offset: 0x0000028C
        public override string GetDescriptionPart()
        {
            var result = !Active ? null : "";

            return result;
        }

        // Token: 0x06000007 RID: 7 RVA: 0x000020B1 File Offset: 0x000002B1
        public override void PostDestroy(DestroyMode mode, Map map)
        {
        }

        // Token: 0x06000008 RID: 8 RVA: 0x000020B4 File Offset: 0x000002B4
    }
}