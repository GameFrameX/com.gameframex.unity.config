// ==========================================================================================
//  GameFrameX 组织及其衍生项目的版权、商标、专利及其他相关权利
//  GameFrameX organization and its derivative projects' copyrights, trademarks, patents, and related rights
//  均受中华人民共和国及相关国际法律法规保护。
//  are protected by the laws of the People's Republic of China and relevant international regulations.
// 
//  使用本项目须严格遵守相应法律法规及开源许可证之规定。
//  Usage of this project must strictly comply with applicable laws, regulations, and open-source licenses.
// 
//  本项目采用 MIT 许可证与 Apache License 2.0 双许可证分发，
//  This project is dual-licensed under the MIT License and Apache License 2.0,
//  完整许可证文本请参见源代码根目录下的 LICENSE 文件。
//  please refer to the LICENSE file in the root directory of the source code for the full license text.
// 
//  禁止利用本项目实施任何危害国家安全、破坏社会秩序、
//  It is prohibited to use this project to engage in any activities that endanger national security, disrupt social order,
//  侵犯他人合法权益等法律法规所禁止的行为！
//  or infringe upon the legitimate rights and interests of others, as prohibited by laws and regulations!
//  因基于本项目二次开发所产生的一切法律纠纷与责任，
//  Any legal disputes and liabilities arising from secondary development based on this project
//  本项目组织与贡献者概不承担。
//  shall be borne solely by the developer; the project organization and contributors assume no responsibility.
// 
//  GitHub 仓库：https://github.com/GameFrameX
//  GitHub Repository: https://github.com/GameFrameX
//  Gitee  仓库：https://gitee.com/GameFrameX
//  Gitee Repository:  https://gitee.com/GameFrameX
//  官方文档：https://gameframex.doc.alianblank.com/
//  Official Documentation: https://gameframex.doc.alianblank.com/
// ==========================================================================================

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.Scripting;

namespace GameFrameX.Config.Runtime
{
    /// <summary>
    /// 数据表非泛型基础接口。
    /// </summary>
    /// <remarks>
    /// Non-generic base interface for data tables.
    /// </remarks>
    [Preserve]
    public interface IDataTable
    {
        /// <summary>
        /// 异步加载数据表。
        /// </summary>
        /// <remarks>
        /// Asynchronously loads the data table.
        /// </remarks>
        /// <returns>表示异步操作的任务 / A task representing the asynchronous operation</returns>
        [Preserve]
        Task LoadAsync();

        /// <summary>
        /// 获取数据表中对象的数量。
        /// </summary>
        /// <remarks>
        /// Gets the number of objects in the data table.
        /// </remarks>
        /// <value>数据表中对象的数量 / Number of objects in the data table</value>
        [Preserve]
        int Count { get; }
    }

    /// <summary>
    /// 数据表泛型基础接口。
    /// </summary>
    /// <remarks>
    /// Generic base interface for data tables.
    /// </remarks>
    /// <typeparam name="T">数据表中元素的类型 / Type of elements in the data table</typeparam>
    [Preserve]
    public interface IDataTable<T> : IDataTable where T : class
    {
        /// <summary>
        /// 根据整数ID获取对象。
        /// </summary>
        /// <remarks>
        /// Gets an object by integer ID.
        /// </remarks>
        /// <param name="id">要获取的对象的整数ID / Integer ID of the object to get</param>
        /// <returns>与指定ID关联的对象；如果找不到则返回 null / The object associated with the specified ID; null if not found</returns>
        [Obsolete("请使用TryGet方法")]
        [Preserve]
        T Get(int id);

        /// <summary>
        /// 根据长整数ID获取对象。
        /// </summary>
        /// <remarks>
        /// Gets an object by long integer ID.
        /// </remarks>
        /// <param name="id">要获取的对象的长整数ID / Long integer ID of the object to get</param>
        /// <returns>与指定ID关联的对象；如果找不到则返回 null / The object associated with the specified ID; null if not found</returns>
        [Obsolete("请使用TryGet方法")]
        [Preserve]
        T Get(long id);

        /// <summary>
        /// 根据字符串ID获取对象。
        /// </summary>
        /// <remarks>
        /// Gets an object by string ID.
        /// </remarks>
        /// <param name="id">要获取的对象的字符串ID / String ID of the object to get</param>
        /// <returns>与指定ID关联的对象；如果找不到则返回 null / The object associated with the specified ID; null if not found</returns>
        [Obsolete("请使用TryGet方法")]
        [Preserve]
        T Get(string id);

        /// <summary>
        /// 尝试根据整数ID获取对象。
        /// </summary>
        /// <remarks>
        /// Tries to get an object by integer ID.
        /// </remarks>
        /// <param name="id">要获取的对象的整数ID / Integer ID of the object to get</param>
        /// <param name="value">当找到对应ID的对象时，返回该对象；否则返回默认值 / The object when found; otherwise the default value</param>
        /// <returns>如果找到对应ID的对象则返回 <c>true</c>；否则返回 <c>false</c> / <c>true</c> if the object is found; otherwise <c>false</c></returns>
        [Preserve]
        bool TryGet(int id, out T value);

        /// <summary>
        /// 尝试根据长整数ID获取对象。
        /// </summary>
        /// <remarks>
        /// Tries to get an object by long integer ID.
        /// </remarks>
        /// <param name="id">要获取的对象的长整数ID / Long integer ID of the object to get</param>
        /// <param name="value">当找到对应ID的对象时，返回该对象；否则返回默认值 / The object when found; otherwise the default value</param>
        /// <returns>如果找到对应ID的对象则返回 <c>true</c>；否则返回 <c>false</c> / <c>true</c> if the object is found; otherwise <c>false</c></returns>
        [Preserve]
        bool TryGet(long id, out T value);

        /// <summary>
        /// 尝试根据字符串ID获取对象。
        /// </summary>
        /// <remarks>
        /// Tries to get an object by string ID.
        /// </remarks>
        /// <param name="id">要获取的对象的字符串ID / String ID of the object to get</param>
        /// <param name="value">当找到对应ID的对象时，返回该对象；否则返回默认值 / The object when found; otherwise the default value</param>
        /// <returns>如果找到对应ID的对象则返回 <c>true</c>；否则返回 <c>false</c> / <c>true</c> if the object is found; otherwise <c>false</c></returns>
        [Preserve]
        bool TryGet(string id, out T value);

        /// <summary>
        /// 根据整数主键获取数据表中的对象。
        /// </summary>
        /// <remarks>
        /// Gets an object from the data table by integer primary key.
        /// </remarks>
        /// <param name="id">要获取的对象的整数主键 / Integer primary key of the object to get</param>
        /// <value>与指定主键关联的数据对象；如果找不到则返回 null / The data object associated with the specified key; null if not found</value>
        [Preserve]
        T this[int id] { get; }

        /// <summary>
        /// 根据长整数主键获取数据表中的对象。
        /// </summary>
        /// <remarks>
        /// Gets an object from the data table by long integer primary key.
        /// </remarks>
        /// <param name="id">要获取的对象的长整数主键 / Long integer primary key of the object to get</param>
        /// <value>与指定主键关联的数据对象；如果找不到则返回 null / The data object associated with the specified key; null if not found</value>
        [Preserve]
        T this[long id] { get; }

        /// <summary>
        /// 根据字符串键获取数据表中的对象。
        /// </summary>
        /// <remarks>
        /// Gets an object from the data table by string key.
        /// </remarks>
        /// <param name="id">要获取的对象的字符串键 / String key of the object to get</param>
        /// <value>与指定键关联的数据对象；如果找不到则返回 null / The data object associated with the specified key; null if not found</value>
        [Preserve]
        T this[string id] { get; }

        /// <summary>
        /// 获取数据表中第一个对象。
        /// </summary>
        /// <remarks>
        /// Gets the first object in the data table.
        /// </remarks>
        /// <value>如果数据表为空，则返回 <c>null</c>；否则返回第一个对象 / <c>null</c> if the data table is empty; otherwise the first object</value>
        [Preserve]
        T FirstOrDefault { get; }

        /// <summary>
        /// 获取数据表中最后一个对象。
        /// </summary>
        /// <remarks>
        /// Gets the last object in the data table.
        /// </remarks>
        /// <value>如果数据表为空，则返回 <c>null</c>；否则返回最后一个对象 / <c>null</c> if the data table is empty; otherwise the last object</value>
        [Preserve]
        T LastOrDefault { get; }

        /// <summary>
        /// 获取数据表中所有对象。
        /// </summary>
        /// <remarks>
        /// Gets all objects in the data table.
        /// </remarks>
        /// <value>包含数据表中所有对象的数组 / Array containing all objects in the data table</value>
        [Preserve]
        T[] All { get; }

        /// <summary>
        /// 将数据表中所有对象复制到新数组。
        /// </summary>
        /// <remarks>
        /// Copies all objects in the data table to a new array.
        /// </remarks>
        /// <returns>包含数据表中所有对象的新数组 / A new array containing all objects in the data table</returns>
        [Preserve]
        T[] ToArray();

        /// <summary>
        /// 将数据表中所有对象复制到新列表。
        /// </summary>
        /// <remarks>
        /// Copies all objects in the data table to a new list.
        /// </remarks>
        /// <returns>包含数据表中所有对象的新列表 / A new list containing all objects in the data table</returns>
        [Preserve]
        List<T> ToList();

        /// <summary>
        /// 根据条件查找第一个匹配的对象。
        /// </summary>
        /// <remarks>
        /// Finds the first object that matches the specified condition.
        /// </remarks>
        /// <param name="func">用于定义匹配条件的函数 / Function to define the matching condition</param>
        /// <returns>如果找到匹配的对象，则返回该对象；否则返回 <c>null</c> / The matching object if found; otherwise <c>null</c></returns>
        [Preserve]
        T Find(System.Func<T, bool> func);

        /// <summary>
        /// 根据条件查找所有匹配的对象并返回数组。
        /// </summary>
        /// <remarks>
        /// Finds all objects that match the specified condition and returns them as an array.
        /// </remarks>
        /// <param name="func">用于定义匹配条件的函数 / Function to define the matching condition</param>
        /// <returns>包含所有匹配对象的数组 / Array containing all matching objects</returns>
        [Preserve]
        T[] FindListArray(System.Func<T, bool> func);

        /// <summary>
        /// 根据条件查找所有匹配的对象并返回列表。
        /// </summary>
        /// <remarks>
        /// Finds all objects that match the specified condition and returns them as a list.
        /// </remarks>
        /// <param name="func">用于定义匹配条件的函数 / Function to define the matching condition</param>
        /// <returns>包含所有匹配对象的列表 / List containing all matching objects</returns>
        [Preserve]
        List<T> FindList(Func<T, bool> func);

        /// <summary>
        /// 对数据表中的每个元素执行指定的操作。
        /// </summary>
        /// <remarks>
        /// Performs the specified action on each element in the data table.
        /// </remarks>
        /// <param name="func">要对每个元素执行的操作 / Action to perform on each element</param>
        [Preserve]
        void ForEach(Action<T> func);

        /// <summary>
        /// 获取数据表中指定属性的最大值。
        /// </summary>
        /// <remarks>
        /// Gets the maximum value of the specified property in the data table.
        /// </remarks>
        /// <param name="func">用于获取比较值的函数 / Function to extract the comparison value</param>
        /// <typeparam name="Tk">比较值的类型，必须实现 <see cref="IComparable{Tk}"/> 接口 / Type of the comparison value, must implement <see cref="IComparable{Tk}"/></typeparam>
        /// <returns>指定属性的最大值 / The maximum value of the specified property</returns>
        [Preserve]
        Tk Max<Tk>(Func<T, Tk> func) where Tk : IComparable<Tk>;

        /// <summary>
        /// 获取数据表中指定属性的最小值。
        /// </summary>
        /// <remarks>
        /// Gets the minimum value of the specified property in the data table.
        /// </remarks>
        /// <param name="func">用于获取比较值的函数 / Function to extract the comparison value</param>
        /// <typeparam name="Tk">比较值的类型，必须实现 <see cref="IComparable{Tk}"/> 接口 / Type of the comparison value, must implement <see cref="IComparable{Tk}"/></typeparam>
        /// <returns>指定属性的最小值 / The minimum value of the specified property</returns>
        [Preserve]
        Tk Min<Tk>(Func<T, Tk> func) where Tk : IComparable<Tk>;

        /// <summary>
        /// 计算数据表中指定 <see cref="int"/> 属性的总和。
        /// </summary>
        /// <remarks>
        /// Computes the sum of the specified <see cref="int"/> property in the data table.
        /// </remarks>
        /// <param name="func">用于获取求和值的函数 / Function to extract the value to sum</param>
        /// <returns>指定属性的总和 / The sum of the specified property</returns>
        [Preserve]
        int Sum(Func<T, int> func);

        /// <summary>
        /// 计算数据表中指定 <see cref="long"/> 属性的总和。
        /// </summary>
        /// <remarks>
        /// Computes the sum of the specified <see cref="long"/> property in the data table.
        /// </remarks>
        /// <param name="func">用于获取求和值的函数 / Function to extract the value to sum</param>
        /// <returns>指定属性的总和 / The sum of the specified property</returns>
        [Preserve]
        long Sum(Func<T, long> func);

        /// <summary>
        /// 计算数据表中指定 <see cref="float"/> 属性的总和。
        /// </summary>
        /// <remarks>
        /// Computes the sum of the specified <see cref="float"/> property in the data table.
        /// </remarks>
        /// <param name="func">用于获取求和值的函数 / Function to extract the value to sum</param>
        /// <returns>指定属性的总和 / The sum of the specified property</returns>
        [Preserve]
        float Sum(Func<T, float> func);

        /// <summary>
        /// 计算数据表中指定 <see cref="double"/> 属性的总和。
        /// </summary>
        /// <remarks>
        /// Computes the sum of the specified <see cref="double"/> property in the data table.
        /// </remarks>
        /// <param name="func">用于获取求和值的函数 / Function to extract the value to sum</param>
        /// <returns>指定属性的总和 / The sum of the specified property</returns>
        [Preserve]
        double Sum(Func<T, double> func);

        /// <summary>
        /// 计算数据表中指定 <see cref="decimal"/> 属性的总和。
        /// </summary>
        /// <remarks>
        /// Computes the sum of the specified <see cref="decimal"/> property in the data table.
        /// </remarks>
        /// <param name="func">用于获取求和值的函数 / Function to extract the value to sum</param>
        /// <returns>指定属性的总和 / The sum of the specified property</returns>
        [Preserve]
        decimal Sum(Func<T, decimal> func);
    }
}