using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnityEngine.Scripting;

namespace GameFrameX.Config.Runtime
{
    public interface IDataTable
    {
        /// <summary>
        /// 异步加载
        /// </summary>
        /// <returns></returns>
        Task LoadAsync();

        /// <summary>
        /// 获取数据表中对象的数量
        /// </summary>
        /// <returns></returns>
        int Count { get; }
    }

    /// <summary>
    /// 数据表基础接口
    /// </summary>
    [Preserve]
    public interface IDataTable<T> : IDataTable where T : class
    {
        /// <summary>
        /// 根据ID获取对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        /// 根据ID获取对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(long id);

        /// <summary>
        /// 根据ID获取对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(string id);

        /// <summary>
        /// 尝试根据整数ID获取对象
        /// </summary>
        /// <param name="id">要获取的对象的整数ID</param>
        /// <param name="value">当找到对应ID的对象时，返回该对象；否则返回默认值</param>
        /// <returns>如果找到对应ID的对象则返回true，否则返回false</returns>
        bool TryGet(int id, out T value);

        /// <summary>
        /// 尝试根据长整数ID获取对象
        /// </summary>
        /// <param name="id">要获取的对象的长整数ID</param>
        /// <param name="value">当找到对应ID的对象时，返回该对象；否则返回默认值</param>
        /// <returns>如果找到对应ID的对象则返回true，否则返回false</returns>
        bool TryGet(long id, out T value);

        /// <summary>
        /// 尝试根据字符串ID获取对象
        /// </summary>
        /// <param name="id">要获取的对象的字符串ID</param>
        /// <param name="value">当找到对应ID的对象时，返回该对象；否则返回默认值</param>
        /// <returns>如果找到对应ID的对象则返回true，否则返回false</returns>
        bool TryGet(string id, out T value);

        /// <summary>
        /// 根据列表索引获取对象
        /// </summary>
        /// <param name="index">索引值</param>
        /// <returns></returns>
        T this[int index] { get; }

        /// <summary>
        /// 获取数据表中第一个对象
        /// </summary>
        /// <returns></returns>
        T FirstOrDefault { get; }

        /// <summary>
        /// 获取数据表中最后一个对象
        /// </summary>
        /// <returns></returns>
        T LastOrDefault { get; }

        /// <summary>
        /// 获取数据表中所有对象
        /// </summary>
        /// <returns></returns>
        T[] All { get; }

        /// <summary>
        /// 获取数据表中所有对象
        /// </summary>
        /// <returns></returns>
        T[] ToArray();

        /// <summary>
        /// 获取数据表中所有对象
        /// </summary>
        /// <returns></returns>
        List<T> ToList();

        /// <summary>
        /// 根据条件查找
        /// </summary>
        /// <param name="func">查询条件</param>
        /// <returns></returns>
        T Find(System.Func<T, bool> func);

        /// <summary>
        /// 根据条件查找
        /// </summary>
        /// <param name="func">查询条件</param>
        /// <returns></returns>
        T[] FindListArray(System.Func<T, bool> func);

        /// <summary>
        /// 根据条件查找
        /// </summary>
        /// <param name="func">查询条件</param>
        /// <returns></returns>
        List<T> FindList(Func<T, bool> func);

        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="func">查询条件</param>
        void ForEach(Action<T> func);

        /// <summary>
        /// 取最大值
        /// </summary>
        /// <param name="func">查询条件</param>
        /// <returns></returns>
        TK Max<TK>(Func<T, TK> func);

        /// <summary>
        /// 取最小值
        /// </summary>
        /// <param name="func">查询条件</param>
        /// <typeparam name="TK">返回值类型</typeparam>
        /// <returns></returns>
        TK Min<TK>(Func<T, TK> func);

        /// <summary>
        /// 求和
        /// </summary>
        /// <param name="func">查询条件</param>
        /// <returns></returns>
        int Sum(Func<T, int> func);

        /// <summary>
        /// 求和
        /// </summary>
        /// <param name="func">查询条件</param>
        /// <returns></returns>
        long Sum(Func<T, long> func);

        /// <summary>
        /// 求和
        /// </summary>
        /// <param name="func">查询条件</param>
        /// <returns></returns>
        float Sum(Func<T, float> func);

        /// <summary>
        /// 求和
        /// </summary>
        /// <param name="func">查询条件</param>
        /// <returns></returns>
        double Sum(Func<T, double> func);

        /// <summary>
        /// 求和
        /// </summary>
        /// <param name="func">查询条件</param>
        /// <returns></returns>
        decimal Sum(Func<T, decimal> func);
    }
}