using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    /// <summary>
    /// Ŀ���b��λ�ã���Ҫ�b�����w�ĸ���
    /// </summary>
    public Transform target;
    /// <summary>
    /// Ҫ�b���ģ��
    /// </summary>
    public SkinnedMeshRenderer model;
    /// <summary>
    /// �oҪ�b���ģ��ȡһ������
    /// </summary>
    public string objName;
    /// <summary>
    /// ���й�����Ϣ��ģ�ͣ����b���ģ����Ҫ���ѽ��b����@��ģ�͵Ĺ�����ָ�]�Լ��Ĺ����Ӯ�
    /// </summary>
    public SkinnedMeshRenderer targetModel;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ModelAdder.Replace(target, objName, model, targetModel);
        }
    }
}
