using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DesignPatterns.Command.NPC
{
    public class NpcCharacter : MonoBehaviour
    {
        [SerializeField] private float speed = 2.0f;
        [SerializeField] private float inspectDuration = 5.0f;
        [SerializeField] private Transform canvas;
        [SerializeField] private Image inspectImg;

        private bool moveToLocation = false;
        private Vector3 targetPos;

        private void Update()
        {
            if(moveToLocation)
            {
                //Move the character in the direction desired, and stop when it gets close enough
                Vector3 dir = targetPos - transform.position;
                transform.position += dir.normalized * speed * Time.deltaTime;

                //Rotate the npc towards the direction it's walking towards, and make sure the world-space ui faces the camera
                transform.rotation = Quaternion.LookRotation(dir);
                canvas.LookAt(Camera.main.transform.position);

                if (Vector3.Distance(transform.position, targetPos) < 1.0f)
                {
                    //When reaching destination tell the dispatcher that you finished the current command
                    moveToLocation = false;
                    NpcCommandDispatcher.OnFinishedCommand();
                }
            }
        }

        public void MoveToLocation(Vector3 location)
        {
            moveToLocation = true;
            targetPos = location;
        }

        public void InspectChest(Chest chest)
        {
            inspectImg.fillAmount = 0.0f;
            StartCoroutine(InspectChestCoroutine(chest));
        }

        private IEnumerator InspectChestCoroutine(Chest chest)
        {
            //Make a progress bar to get some visual feedback for how long the inspection takes
            float duration = 0.0f;
            while(duration < inspectDuration)
            {
                yield return null;
                duration += Time.deltaTime;
                inspectImg.fillAmount = duration / inspectDuration;
            }
            //At the end, display the treasure type and tell the dispatcher you are finished with your command
            chest.ShowChestType();
            NpcCommandDispatcher.OnFinishedCommand();
            inspectImg.fillAmount = 0.0f;
        }
    }
}