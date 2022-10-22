using Verse;

namespace CaridionArsenal;

internal class Projectile_SnowMaker : Projectile
{
    protected override void Impact(Thing hitThing, bool blockedByShield = false)
    {
        GenExplosion.DoExplosion(Position, Map, def.projectile.explosionRadius, def.projectile.damageDef, launcher,
            def.projectile.GetDamageAmount(launcher), -1, SoundDef.Named("Interact_Ignite"), def, equipmentDef);
        SnowCreation(Position, def.projectile.explosionRadius, Map);
        CellRect.CenteredOn(Position, 3).ClipInsideMap(Map);
        base.Impact(hitThing, blockedByShield);
    }

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