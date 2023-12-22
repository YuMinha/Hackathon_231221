using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMeshRendererByLayer : MonoBehaviour
{
    public GameObject targetObject; // 대상 오브젝트

    void Start()
    {
        DisableMeshRenderersInChildren(targetObject);
    }

    void DisableMeshRenderersInChildren(GameObject target)
    {
        if (target != null)
        {
            // 대상 오브젝트와 그 자식들의 MeshRenderer 비활성화
            MeshRenderer[] renderers = target.GetComponentsInChildren<MeshRenderer>(true);
            foreach (MeshRenderer renderer in renderers)
            {
                renderer.enabled = false;
            }
        }
        else
        {
            Debug.LogError("대상 오브젝트가 설정되지 않았습니다!");
        }
    }
}