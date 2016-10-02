namespace VRTK.Examples
{
    using UnityEngine;
    using System.Collections;

    public class Switch : VRTK_InteractableObject
    {
        enum Toggle { ON, OFF };
        Toggle buttonStatus;
        Vector3 local_rot;

        protected override void Start()
        {
            buttonStatus = Toggle.OFF;
            base.Start();
            local_rot = this.transform.eulerAngles;
        }

        protected override void Update()
        {
            base.Update();
        }

        public override void StartTouching(GameObject currentTouchingObject)
        {
            base.StartTouching(currentTouchingObject);
            Debug.Log((object) "its touching");
            if (buttonStatus == Toggle.OFF) {
                Debug.Log((object) "aasdfasdf");
                this.transform.Rotate(Vector3.right, 47.495f, Space.Self);
            } else {
                Debug.Log((object)"asdfasdfasdf");
                this.transform.Rotate(Vector3.right, -47.495f , Space.Self);
            }
        }

    }
}
