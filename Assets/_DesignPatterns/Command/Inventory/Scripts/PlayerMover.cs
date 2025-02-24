using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityChan;
using UnityEngine;

namespace DesignPatterns.Command.Inventory
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float speed = 3.0f;
        [SerializeField] private float collectRange = 2.0f;

        private void Update()
        {
            Move();

            if (Input.GetKeyDown(KeyCode.E))
                GetCollectiblesInRange();
            if(Input.GetKeyDown(KeyCode.I))
            {
                InventoryDisplay display = Locator.GetService<InventoryDisplay>();
                display.ToggleInventory();
            }

        }

        private void Move()
        {
            //Move the player based on user input and rotate him to face the movement direction;
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 moveDir = new Vector3(horizontal, 0.0f, vertical).normalized;

            if (moveDir != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveDir);
                transform.position += moveDir * speed * Time.deltaTime;
            }
        }

        private void GetCollectiblesInRange()
        {
            RaycastHit[] hits = Physics.SphereCastAll(transform.position, collectRange, transform.forward, 0.01f);

            Dictionary<CollectibleType, int> itemsCollected = new Dictionary<CollectibleType, int>();

            for(int index = 0; index < hits.Length; ++ index)
            {
                if(hits[index].collider.gameObject.TryGetComponent(out Collectible item))
                {
                    CollectibleType type = item.ItemType;
                    if (!itemsCollected.ContainsKey(type))
                        itemsCollected[type] = 1;
                    else
                        itemsCollected[type]++;

                    Destroy(item.gameObject);
                }
            }

            foreach(KeyValuePair<CollectibleType, int> item in itemsCollected)
            {
                InventoryCommandInvoker.TriggerCommand(new CollectItemCommand(item.Key, item.Value));
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, collectRange);
        }
    }
}