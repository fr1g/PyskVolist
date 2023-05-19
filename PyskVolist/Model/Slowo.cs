
using System;
namespace PyskVolist.Model
{
	public class Slowo
	{
        // 什么时候能够查询bkrs获取单词///////
        // 纯文本格式: \{[dir]/[udir],}&{[sv]/[nsv].}word;\::type #Translation(patez)
        // 优化纯文本格式: 完成体+未完成体: (或者) 定向%不定向: (或者) 词语本身 : 类型=汉译(接格关系)
        // 类型: 名词, 形容词, 数词, 代词, 动词, 副词, 前置, 连接, 语气, 感叹, 形动
		// 补充类型: (无: 默认的默认, 不作细化特殊标记)
		/* 名词: 阳性, 阴性, 中性, (默认)自动, 无
		 * 形容: 软变, 硬变, 无
		 * 数词: 基数, 序数, 无
		 * 代词: 指示, 物主, 无
		 * 动词: 第一变位, 第二变位, 特殊变位, 无
		 * 副词: 无
		 * 前置: 方位, 其他, 无?
		 * 连接: 无
		 * 其他: 感叹, 语气
		 * 形动: 被动, 主动?
		 */

        public string Translation { get; set; } // 词翻译
		public string Word { get; set; } // 词本体
		public string? WordType { get; set; } // 词类 if null give no tag
		public string? SV { get; set; } // 对应完成体
        public string? Direction { get; set; } // for motivate verbs that have directions.
		public string? Follow { get; set; } // 接格关系



		public Slowo()
		{
		}
	}
}

