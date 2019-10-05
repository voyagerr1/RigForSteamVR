
/*
MIT License
Copyright(c) [2019]
[Garrett Hickey]
[AJRPG]
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Valve.VR.InteractionSystem;

public class RigObjectForVR
{


    [MenuItem("GameObject/Rig For VR/Box Collider", false, 0)]
    private static void RigForVRBox()
    {
       GameObject selectedObject = Selection.activeGameObject;
       GameObject[] selectedObjects = Selection.gameObjects;
        if (selectedObject == null || selectedObjects.Length < 1)
            return;

        if (selectedObjects.Length > 1)
        {

            for (int i = 0; i < selectedObjects.Length; i++)
            {
                GameObject go = new GameObject();
                go.transform.position = selectedObjects[i].transform.position;
                go.transform.rotation = selectedObjects[i].transform.rotation;
                go.name = selectedObjects[i].name;

                if (!selectedObjects[i].GetComponent<Collider>())
                    selectedObjects[i].AddComponent<BoxCollider>();
                selectedObjects[i].transform.SetParent(go.transform);

                go.AddComponent<Rigidbody>();
                go.AddComponent<Interactable>();
                Throwable throwable = go.AddComponent<Throwable>();
                throwable.attachmentFlags = Hand.AttachmentFlags.DetachFromOtherHand | Hand.AttachmentFlags.ParentToHand | Hand.AttachmentFlags.VelocityMovement | Hand.AttachmentFlags.TurnOnKinematic;
            }

        }
        else
        {
            GameObject go = new GameObject();
            go.transform.position = selectedObject.transform.position;
            go.transform.rotation = selectedObject.transform.rotation;
            go.name = selectedObject.name;

            if (!selectedObject.GetComponent<Collider>())
                selectedObject.AddComponent<BoxCollider>();
            selectedObject.transform.SetParent(go.transform);

            go.AddComponent<ObjectAudioHandler>();
            go.AddComponent<Rigidbody>();
            go.AddComponent<Interactable>();
            Throwable throwable = go.AddComponent<Throwable>();
            throwable.attachmentFlags = Hand.AttachmentFlags.DetachFromOtherHand | Hand.AttachmentFlags.ParentToHand | Hand.AttachmentFlags.VelocityMovement | Hand.AttachmentFlags.TurnOnKinematic;
        }

    }

    [MenuItem("GameObject/Rig For VR/Mesh Collider", false, 0)]
    private static void RigForVRMesh()
    {
        GameObject selectedObject = Selection.activeGameObject;
        GameObject[] selectedObjects = Selection.gameObjects;
        if (selectedObject == null || selectedObjects.Length < 1)
            return;

        if (selectedObjects.Length > 1)
        {

            for (int i = 0; i < selectedObjects.Length; i++)
            {
                GameObject go = new GameObject();
                go.transform.position = selectedObjects[i].transform.position;
                go.transform.rotation = selectedObjects[i].transform.rotation;
                go.name = selectedObjects[i].name;

                if (!selectedObjects[i].GetComponent<Collider>())
                {
                    MeshCollider m = selectedObjects[i].AddComponent<MeshCollider>();
                    m.convex = true;
                }
                selectedObjects[i].transform.SetParent(go.transform);

                go.AddComponent<Rigidbody>();
                go.AddComponent<Interactable>();
                Throwable throwable = go.AddComponent<Throwable>();
                throwable.attachmentFlags = Hand.AttachmentFlags.DetachFromOtherHand | Hand.AttachmentFlags.ParentToHand | Hand.AttachmentFlags.VelocityMovement | Hand.AttachmentFlags.TurnOnKinematic;
            }

        }
        else
        {
            GameObject go = new GameObject();
            go.transform.position = selectedObject.transform.position;
            go.transform.rotation = selectedObject.transform.rotation;
            go.name = selectedObject.name;

            if (!selectedObject.GetComponent<Collider>())
            {
                MeshCollider m = selectedObject.AddComponent<MeshCollider>();
                m.convex = true;
            }
            selectedObject.transform.SetParent(go.transform);

            go.AddComponent<ObjectAudioHandler>();
            go.AddComponent<Rigidbody>();
            go.AddComponent<Interactable>();
            Throwable throwable = go.AddComponent<Throwable>();
            throwable.attachmentFlags = Hand.AttachmentFlags.DetachFromOtherHand | Hand.AttachmentFlags.ParentToHand | Hand.AttachmentFlags.VelocityMovement | Hand.AttachmentFlags.TurnOnKinematic;
        }

    }


}
