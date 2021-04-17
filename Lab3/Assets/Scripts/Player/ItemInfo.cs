using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="Item", menuName ="Items")]
public class ItemInfo : ScriptableObject
{
    public ItemId ItemId;
    public Mesh itemMesh;
    public Material itemMaterial;
    public Sprite itemSprite;

}
public enum ItemId
{
    None,
    Sword,
    Shield,
    Armor
}
