using System;
using System.Collections.Generic;
using UnityEngine;

public class ShipBuilder : MonoBehaviour
{
    public int Health = 100;
    public float Speed = 10f;

    public void Instantiate(ShipPartWithMaterial<HullSO> hull, ShipPartWithMaterial<EngineSO> engine, ShipPartWithMaterial<WeaponSO> weapons)
    {
        List<StatModifiers> mods = new List<StatModifiers>() {
            hull.shippart.BaseModifiers,
            engine.shippart.BaseModifiers,
            weapons.shippart.BaseModifiers,
        };
        CalculateStats(mods);
        Transform back = transform.Find("Front");
        SpriteRenderer backSprite = back.GetComponent<SpriteRenderer>();
        backSprite.sprite = engine.shippart.Sprite;
        backSprite.color = engine.material;

        Transform hullObject = transform.Find("Hull");
        SpriteRenderer hullSprite = hullObject.GetComponent<SpriteRenderer>();
        hullSprite.sprite = hull.shippart.Sprite;
        hullSprite.color = hull.material;

        GameObject weaponsInstance = Instantiate(weapons.shippart.Prefab, new Vector3(0, 0.2f), Quaternion.identity);
        SpriteRenderer weaponSprite = weaponsInstance.GetComponent<SpriteRenderer>();
        weaponSprite.color = weapons.material;
    }

    private void CalculateStats(List<StatModifiers> modifiers)
    {
        StatModifiers combinedMod = new StatModifiers()
        {
            healthMultiplier = 1,
            speedMultiplier = 1,
            damageMultiplier = 1,
            costMultiplier = 1,
        };

        foreach (StatModifiers modifier in modifiers)
        {
            combinedMod *= modifier;
        }

        Health = (int)Mathf.Floor(Health * combinedMod.healthMultiplier);
        Speed *= combinedMod.speedMultiplier;
    }

}

public struct ShipPartWithMaterial<T>
{
    public Color material;
    public T shippart;
}
