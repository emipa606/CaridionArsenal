using Verse;

namespace CaridionArsenal
{
    // Token: 0x02000002 RID: 2
    internal class Projectile_SnowMaker : Projectile
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        protected override void Impact(Thing hitThing)
        {
            GenExplosion.DoExplosion(Position, Map, def.projectile.explosionRadius, def.projectile.damageDef, launcher,
                def.projectile.GetDamageAmount(launcher), -1, SoundDef.Named("Interact_Ignite"), def, equipmentDef);
            SnowCreation(Position, def.projectile.explosionRadius, Map);
            CellRect.CenteredOn(Position, 3).ClipInsideMap(Map);
            base.Impact(hitThing);
        }

        // Token: 0x06000002 RID: 2 RVA: 0x00002104 File Offset: 0x00000304
        protected void SnowCreation(IntVec3 pos, float radius, Map map)
        {
            var depthToAdd = 10f;
            foreach (var a in GenRadial.RadialPatternInRadius(radius))
            {
                var c = a + pos;
                if (c.InBounds(map))
                {
                    map.snowGrid.AddDepth(c, depthToAdd);
                }
            }

            map.snowGrid.AddDepth(pos, depthToAdd);
        }
    }
}