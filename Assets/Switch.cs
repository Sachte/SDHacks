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
        static bool nonePresent;

        protected override void Start()
        {
            base.Start();
            local_rot = this.transform.eulerAngles;
            isDisplayed = false;
            nonePresent = true;
        }

        protected override void Update()
        {
            base.Update();
        }

        public override void StartTouching(GameObject currentTouchingObject)
        {
            base.StartTouching(currentTouchingObject);

            StartCoroutine(Stall());
        }

        public override void StopTouching(GameObject previousTouchingObject)
        {
            base.StopTouching(previousTouchingObject);
            
            GameObject.Destroy(tootip, 0f);
            Debug.Log("is Destroyed");
            
            nonePresent = true;
            isDisplayed = false;

        }

        IEnumerator Stall()
        {
            if (!isDisplayed && nonePresent)
            {
                isDisplayed = true;

                nonePresent = false;

                tootip = GameObject.Instantiate<GameObject>(TooltipPrefab);

                tootip.GetComponent<VRTK_ObjectTooltip>().displayText = name;
                tootip.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));

                tootip.transform.position = new Vector3(1.7f, 2.5f, -3.1f);

                tootip.GetComponent<VRTK_ObjectTooltip>().drawLineFrom = this.transform;
                tootip.GetComponent<VRTK_ObjectTooltip>().drawLineTo = tootip.transform;

            }
            yield return new WaitForSeconds(4);
            

        }
        
    }
}
