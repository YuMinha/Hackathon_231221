using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMeshRendererByLayer : MonoBehaviour
{
    public GameObject targetObject; // ��� ������Ʈ

    void Start()
    {
        DisableMeshRenderersInChildren(targetObject);
    }

    void DisableMeshRenderersInChildren(GameObject target)
    {
        if (target != null)
        {
            // ��� ������Ʈ�� �� �ڽĵ��� MeshRenderer ��Ȱ��ȭ
            MeshRenderer[] renderers = target.GetComponentsInChildren<MeshRenderer>(true);
            foreach (MeshRenderer renderer in renderers)
            {
                renderer.enabled = false;
            }
        }
        else
        {
            Debug.LogError("��� ������Ʈ�� �������� �ʾҽ��ϴ�!");
        }
    }
}