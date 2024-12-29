/*
 * New Mdeol 
 */
using UnityEngine;

public class ModelAdder : MonoBehaviour
{
    /// <summary>
    /// �b��W��ģ�͵�Ŀ�����w�ϣ���name��_���@�����d�ľW��ģ��
    /// </summary>
    /// <param objName="target">Ŀ�˒��d�c��������mesh��ֱ�Ӹ���</param>
    /// <param objName="name">��Ҫ�b��þW��ģ�͵����֣��Á���R�@���W�����w</param>
    /// <param objName="mesh">��Ҫ���b���ϵľW��ģ��</param>
    public static void Replace(Transform target, string name, SkinnedMeshRenderer mesh, SkinnedMeshRenderer targetMesh)
    {
        if (target == null || string.IsNullOrEmpty(name) || mesh == null)
        {
            return;
        }

        RemoveMeshIfFoundGivenName(target, name);
        // �}�uҪ�b��þW��ģ�͵Ĕ������b��һ��GameObject��
        var modelObj = CloneSkinnedMesh(mesh);
        modelObj.name = name;
        // �O��Unity�еĸ����P�S
        modelObj.transform.parent = target.transform;

        modelObj.GetComponent<SkinnedMeshRenderer>().bones = targetMesh.bones;
    }

    private static void RemoveMeshIfFoundGivenName(Transform target, string name)
    {
        // �@ȡSkinnedMeshRenderer �M����Unity�ѾW����Ϣ�������Y��
        var targetParts = target.GetComponents<SkinnedMeshRenderer>();
        foreach (var part in targetParts)
        {
            // �����ִ_���b��������w������ѽ��b�䣬�̈́h��ԭ���������w���b�µ�
            if (part.name == name)
            {
                Destroy(part);
            }
        }
    }

    private static GameObject CloneSkinnedMesh(SkinnedMeshRenderer mesh)
    {

        if (mesh == null)
        {
            return null;
        }

        var partObj = new GameObject();
        //partObj.objName = mesh.objName;
        partObj.AddComponent<SkinnedMeshRenderer>();
        partObj.GetComponent<SkinnedMeshRenderer>().sharedMesh = mesh.sharedMesh;
        //partObj.GetComponent<SkinnedMeshRenderer>().bones = mesh.bones;
        partObj.GetComponent<SkinnedMeshRenderer>().materials = mesh.sharedMaterials;

        return partObj;
    }
}
