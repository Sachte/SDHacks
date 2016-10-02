namespace VRTK.Examples
{
    using UnityEngine;

    public class Dial : VRTK_InteractableObject
    {
        Vector3 pos1 = new Vector3(0f, -90f, 83f);
        Vector3 pos2 = new Vector3(-90f, 0f, 0f);

        Vector3 local_rot;

        // Use this for initialization
        protected override void Start()
        {
            base.Start();
            local_rot = this.transform.localRotation.eulerAngles;
        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
        }

        public override void StartTouching(GameObject currentTouchingObject)
        {
            base.StartTouching(currentTouchingObject);
            Debug.Log((object)"its touching");
            if (local_rot == pos1)
            {
                local_rot = pos2;
            } else
            {
                local_rot = pos1;
            }
        }
    }
}
