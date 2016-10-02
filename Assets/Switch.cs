namespace VRTK.examples
{
    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;

    public class Switch : VRTK_InteractableObject
    {
        Vector3 local_rot;
        public GameObject TooltipPrefab;
        public string name;
        public GameObject tootip;
        protected bool isDisplayed;

        protected override void Start()
        {
            base.Start();
            local_rot = this.transform.eulerAngles;
            isDisplayed = false;
        }

        protected override void Update()
        {
            base.Update();
        }

        public override void StartTouching(GameObject currentTouchingObject)
        {
            base.StartTouching(currentTouchingObject);
            /*  Debug.Log((object) "its touching");
              if (isOpen) {
                  Debug.Log((object) "aasdfasdf");
                  this.transform.Rotate(Vector3.right, 47.495f, Space.Self);
                  Vector3 close = this.transform.position;
                  this.transform.Translate(close.x + 0f, close.y - 1.70955f, close.z - 0.7199778f, Space.Self);
                  isOpen = false;
              } else {
                  Debug.Log((object)"asdfasdfasdf");
                  this.transform.Rotate(Vector3.right, -47.495f , Space.Self);
                  Vector3 open = this.transform.position;
                  this.transform.Translate(open.x + 0f, open.y + 1.70955f, open.z + 0.7199778f, Space.Self);
                  isOpen = t rue;*/
            //}
            //VRTK_ObjectTooltip tip = new VRTK_ObjectTooltip();
            //tip.displayText = name;
            if (!isDisplayed)
            {
                
                tootip = GameObject.Instantiate<GameObject>(TooltipPrefab);
                isDisplayed = true;

                tootip.GetComponent<VRTK_ObjectTooltip>().displayText = name;
                tootip.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));

                tootip.transform.position = new Vector3(1.7f, 2.5f, -3.1f);
              
                tootip.GetComponent<VRTK_ObjectTooltip>().drawLineFrom = this.transform;
                tootip.GetComponent<VRTK_ObjectTooltip>().drawLineTo = tootip.transform;

            }
            // transform position rotation
            // set drawline transforms
            // set text
            // change rotation to face the head.
        }

        public override void StopTouching(GameObject previousTouchingObject)
        {
            base.StopTouching(previousTouchingObject);
            
            Object.Destroy(tootip, 3f);
    
            isDisplayed = false;
        }

    }
}
