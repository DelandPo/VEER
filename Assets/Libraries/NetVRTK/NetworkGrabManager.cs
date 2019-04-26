namespace NetVRTK {
    using UnityEngine;
    using VRTK;
    using NetBase;
    using Hashtable = ExitGames.Client.Photon.Hashtable;
    using System.Collections;

    [RequireComponent(typeof(VRTK_InteractableObject))]
    public class NetworkGrabManager : NetworkBehaviour {
        public PhotonView[] ownAdditionalPhotonviews;
        private int grabOwner;

        private VRTK_InteractableObject io;
        private NetworkReference nref;
        private Rigidbody rb;
        public int currentGrabOwner {
            get {
                return grabOwner;
            }
        }

        void Awake() {
            io = GetComponent<VRTK_InteractableObject>();
            nref = NetworkReference.FromObject(this.gameObject);
            propKey = PROP_KEY_ID + nref.parentHandleId + "$" + (nref.pathFromParent != null ? nref.pathFromParent : "") + "$";
            var dummy = PropertyEventHandler.Instance;
        }

        void OnEnable() {
            io.InteractableObjectGrabbed += HandleGrab;
            io.InteractableObjectUngrabbed += HandleUngrab;
            if (nref.IsPhotonView) {
                InitState(nref.GetPhotonView().ownerId);
            }
        }

        void OnDisable() {
            io.InteractableObjectGrabbed -= HandleGrab;
            io.InteractableObjectUngrabbed -= HandleUngrab;
        }

        private void HandleGrab(object sender, InteractableObjectEventArgs e) {

            if (nref.IsPhotonView) {
                nref.GetPhotonView().TransferOwnership(PhotonNetwork.player);
            }
            foreach (PhotonView pv in ownAdditionalPhotonviews) {
                pv.TransferOwnership(PhotonNetwork.player);
            }
            InitState(PhotonNetwork.player.ID);
            SendState();
        }

        private void HandleUngrab(object sender, InteractableObjectEventArgs e) {

            float speed = 2.5f;
            var origin = transform.position;
           transform.position =  new Vector3(origin.x, 0, origin.z);
            InitState(0);
            SendState();
        }

        private void InitState(int ownerId) {
            grabOwner = ownerId;
            io.isGrabbable = (grabOwner == 0);
        }

        private IEnumerator move(Vector3 origin, Vector3 destination, float speed)
        {
            while (transform.position != destination)
            {
                transform.position = Vector3.Lerp(origin, destination, Time.deltaTime * speed);
                yield return new WaitForEndOfFrame();

            }
        }

        //
        // Syncing states
        //

        private string propKey;

        public const string PROP_KEY_ID = "ngm$";

        protected override string PropKey {
            get {
                return propKey;
            }
        }

        private void SendState() {
            Hashtable content = new Hashtable();
            content.Add("go", grabOwner);
            SetProperties(content);
        }

        protected override void RecvState(Hashtable content) {
            InitState((int)content["go"]);
        }
    }
}
