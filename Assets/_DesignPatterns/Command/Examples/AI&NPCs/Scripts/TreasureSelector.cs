using UnityEngine;

namespace DesignPatterns.Command.NPC
{
    public class TreasureSelector : MonoBehaviour
    {
        [SerializeField] private NpcCharacter npc;

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(cameraRay, out hit))
                {
                    if(hit.collider.tag == "Collectible")
                    {
                        NpcCommandDispatcher.ScheduleCommand(new PatrolCommand(npc, hit.transform.position));

                        Chest chest = hit.collider.GetComponent<Chest>();
                        NpcCommandDispatcher.ScheduleCommand(new InspectChestCommand(npc, chest));
                    }
                }
            }
        }
    }
}