using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
   
    [SerializeField] MeshRenderer itemMeshRenderer;
    [SerializeField] MeshFilter itemMeshFilter;
    [SerializeField] Collider itemCollider;
    [SerializeField] ItemInfo itemInfo;
    public void Destroy(PlayerCreature player)
    {

        if (player.inventory.AddItem(itemInfo))
        {
            Destroy(gameObject);
        }

    }
    public void Init(Mesh itemMesh, Material itemMaterial, ItemInfo itemInfo)
    {
        itemMeshRenderer.material = itemMaterial;
        itemMeshFilter.mesh = itemMesh;
        this.itemInfo = itemInfo;
    }
  
}
