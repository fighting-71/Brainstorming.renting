using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatchApp
{
    /// <summary>
	/// @auth : monster
	/// @since : 12/13/2021 3:58:57 PM
	/// @source : 
	/// @des : 匹配汇总
	/// </summary>
	public partial interface IMatchSummary
    {

        #region faq
        //		为什么匹配不需要结果？
        //			匹配应该是有状态的，无信息的，调用方应只需要知道成功与否，至于内部是否会产生其他信息，应该由匹配的信息&配的策略来决定，而不是由最外层来决定
        //			由外层决定==>暴露匹配决策，产生外层规约内层的情况
        //				举个例子，匹配完后发送通知：
        //					若由外层决定，则内层必须返回符号外层制定的通知信息，显然不合理
        //					
        //      *********以上的说明是错误的......>>>>>>>>>>>>
        //          匹配策略应该只决定，如何去找到符合的匹配项。而不是关注更多的东西。
        //          通知，应该是匹配成功后，由匹配结果中的标记（）
        #endregion

        /// <summary>
        /// 通过筛选器，过滤sources
        /// </summary>
        /// <param name="sources"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<SomeThing> Filter(SomeThing[] sources, SomeThingFilter filter);

        #region 往下衍生... 

        /// <summary>
        /// 一对一匹配（双方的信息一致：双向匹配）
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        Task<MatchResult> Match(SomeThing owner, SomeThing other);

        /// <summary>
        /// 一对一匹配（双方的信息不一致:单向匹配）
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        Task<MatchResult> Match(SomeThing owner, SomeThing2 other);

        #region 往下衍生... 
        /// <summary>
        /// 一对多匹配（双方的信息一致：双向匹配）
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        Task Match(SomeThing owner, SomeThing[] others);

        /// <summary>
        /// 多对多匹配（双方的信息一致）
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        Task Match(SomeThing[] owners, SomeThing[] others);

        #endregion

        #endregion

    }

    #region des
    /**
     * 
     * 简单匹配：
     * 
     *      发布一个需求  ->  通过（需求->处理）匹配策略 -> 处理筛选器 -> 筛选处理集 -> 生成匹配结果
     *      
     *      
     * 
     */
    #endregion

    #region models

    public class SomeThing { }
    public class SomeThing2 { }

	public class SomeThingFilter { }
	public class MatchResult { }

    #endregion

}
