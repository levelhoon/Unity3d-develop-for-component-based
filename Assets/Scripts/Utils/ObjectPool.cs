using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.GameObject;

class ObjectPool : IEnumerator<Transform>
{
    private static Dictionary<string, ObjectPool> pools;
    private Transform parentObject;
    public Transform Target { get; }
    public List<Transform> Clones { get; }
    private IEnumerator<Transform> Enumerator { get; set; }

    public int ActiveCount
    {
        get;
        private set;
    }
    public bool Active
    {
        get
        {
            return Enumerator.Current.gameObject.activeSelf;
        }
        set
        {
            Enumerator.Current.gameObject.SetActive(value);
            ActiveCount += value ? +1 : -1;
        }
    }
    public bool IsActiveALL
    {
        get
        {
            //활성화된 클론 객체가 모든 클론객체 수 만큼 활성화 되었는지 검사합니다.
            return ActiveCount >= Clones.Count;
        }
    }

    public int Size
    {
        get
        {
            return Clones.Count;
        }
    }
    public void SizeUp(int addSize)
    {
        for (int i = 0; i < addSize; i++)
        {
            var obj = Transform.Instantiate(Target);
            Clones.Add(obj);
            obj.gameObject.SetActive(false);
            obj.name += Size-1;
            obj.transform.SetParent(parentObject);            
        }
        Enumerator = Clones.GetEnumerator();
    }

    public void SetOff(Transform obj)
    {
        obj.gameObject.SetActive(false);
        ActiveCount--;
    }
    public void SetOn()
    {
        //다음 컬렉션데이터가 없으면
        while (!MoveNext())
        {
            //모두 활성화되었을 경우
            if (IsActiveALL)
            {
                //사이즈업한다
                SizeUp(Size);
            }
            else
            {
                //현재 인덱스를 -1으로 리셋함
                Reset();
            }
        }
        //위의 코드 상관없이 현재 인덱스 활성화함
        Active = true;
    }

    public Transform Current
    {
        get
        {
            return Enumerator.Current;
        }
    }
    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }
    public bool MoveNext()
    {
        return Enumerator.MoveNext();
    }
    public void Reset()
    {
        Enumerator.Reset();
    }
    public void Dispose()
    {
        Enumerator.Dispose();
    }

    public static T[] GetComponents<T>(T target) where T : Component
    {
        return ObjectPool<T>.GetComponents(target.transform);
    }

    public static T[] GetComponents<T>(Transform target) where T : Component
    {
        return ObjectPool<T>.GetComponents(target);
    }

    public static void UploadComponents<T>(T target) where T : Component
    {
        ObjectPool<T>.UploadComponents(target.tag);
    }

    public static void UploadComponents<T>(Transform target) where T : Component
    {
        ObjectPool<T>.UploadComponents(target.tag);
    }

    public static ObjectPool Get(string tag)
    {
        return pools[tag];
    }

    public static ObjectPool CreatePool(Transform target, int size)
    {
        return new ObjectPool(target, size);
    }

    protected ObjectPool(Transform target, int size)
    {
        parentObject = new Object(target.name + "Parent").transform;
        Target = target;
        Clones = new List<Transform>();
        SizeUp(size);
        if (!pools.ContainsKey(target.tag))
        {
            pools.Add(target.tag, this);
        }
    }
    static ObjectPool()
    {
        pools = pools ?? new Dictionary<string, ObjectPool>();
    }
}

class ObjectPool<T> : ObjectPool where T: Component
{
    static Dictionary<Transform, T[]> Components { get; }

    public static T[] GetComponents(Transform target)
    {
        return Components[target];
    }

    public static void UploadComponents(string tag)
    {
        for (int i = 0; i < Get(tag).Size; i++)
        {
            var obj = Get(tag).Clones[i];
            Components.Add(obj, obj.GetComponents<T>());
        }
    }
    public static void UploadComponents(Transform target)
    {
        UploadComponents(target.tag);
    }

    ObjectPool(Transform target, int size) : base(target, size)
    {
    }
    static ObjectPool()
    {
        Components = Components ?? new Dictionary<Transform, T[]>();
    }
}
