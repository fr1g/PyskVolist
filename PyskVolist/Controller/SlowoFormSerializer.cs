using System;
using PyskVolist.Model;

namespace PyskVolist.Controller
{
	public class SlowoFormSerializer
	{
		// 反序列化: 从文本转换为类?
		// 序列化: 类转换为文本?
		private string? _data, _accWord;
		private int? _hi;
        // 纯文本格式: \{[dir]/[udir],}&{[sv]/[nsv].}word;\::type #Translation(patez)
        // 优化纯文本格式: ,完成体+未完成体: (或者) .定向%不定向: (或者) 词语本身 = 类型#汉译(接格关系)
        // 类型: 名词, 形容词, 数词, 代词, 动词, 副词, 前置, 连接, 语气, 感叹, 形动
        // 具体化类型: (无: 默认的默认, 不作细化特殊标记) 自动: 录入时候自动识别
        /* 名词: 阳性, 阴性, 中性, (默认)自动, 无
		 * 数词: 基数, 序数, (默认)自动, 无
		 * 动词: 第一变位, 第二变位, 特殊变位, 无
		 */
        // 重音所在的字母序号(№ / ^ ) 或者 重音标 (*)
		// @ ,xx:.yy:zz*a=tt#cc(pp)
        public string? Serlize(Slowo S)
		{
			_data = "@";
			if (!S.ForceBasic)
			{
                if (S.Direction is not null) _data += $",{S.Direction}:";
                if (S.SV is not null) _data += $".{S.SV}:";
				if (S.HardIndex is not null) _accWord = S.Word + $"*{++S.HardIndex}";
				else _accWord = S.Word;
            }

			_data += $"{(_accWord is null? S.Word : _accWord)}=";

			if (!S.ForceBasic)
				if (S.WordType is not null) _data += $"{S.WordType}#";
            
            _data += $"{S.Translation}";

            if (!S.ForceBasic)
                if (S.Follow is not null) _data += $"({S.Follow})";            

			return _data;
		}

		public Slowo? Deselize(string cons)
		{



			return null;
		}

		public SlowoFormSerializer()
		{
		}
	}
}

