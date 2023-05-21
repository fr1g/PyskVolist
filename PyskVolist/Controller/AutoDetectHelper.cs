//#define Alphabets "al"
using System;
using PyskVolist.Model;
namespace PyskVolist.Controller
{
	public class AutoDetectHelper
	{
        public string? DetectNounGender(string noun)
        {
            /// <summary>
            /// Return whether the income noun is a Male or Female or Middle. 
            /// Positive, Negative, Xentr... null: undetectable or pl
            /// </summary>
            /// 
            string tail = noun.Substring(noun.Length - 3); // 后两个字母
                if ( TailContain(tail, Alphabets.mz)
                  || TailContain(tail, Alphabets.tz)
                  || TailContain(tail, Alphabets.y)
                  || TailContain(tail, Alphabets.i)
                   ) return null; // undetectable filter
            //!!!
                else
                {
                    bool? ret = NextDetectNounGender(tail);
                    switch (ret)
                    {
                        case true:
                            return "Positive";
                        case false:
                            return "Negative";
                        default:
                            return "Xentr";
                    }
                }
            return null;
        }

        public bool? NextDetectNounGender(string tail)
        {
            if (TailContain(tail, (Alphabets.m + Alphabets.ja))
                    || TailContain(tail, Alphabets.e)
                    || TailContain(tail, Alphabets.ee)
                    || TailContain(tail, Alphabets.ju)
                    || TailContain(tail, Alphabets.ae)
                    || TailContain(tail, Alphabets.o)
                    || TailContain(tail, Alphabets.o)
                    // xentr
                    )  return null;

            else if (TailContain(tail, Alphabets.a)
               || TailContain(tail, Alphabets.ja)
               // negative
               ) return false;

            else return true;

            return null;
        }


        /// <summary>
        /// tool to check if the figure inputed is a base or order
        /// </summary>
        /// <param name="figure">123123123</param>
        /// <returns>Nullableboolean yes, no, or cannot detect.</returns>
        public bool? DetectFigureIsBase(string figure)
        {
            string tail = figure.Substring(figure.Length - 3); // 后两个字母
            if (TailContain(tail, (Alphabets.o + Alphabets.j))
                || TailContain(tail, (Alphabets.i + Alphabets.j))
                || TailContain(tail, (Alphabets.y + Alphabets.j))
                ) return false;

            else return true;

            return null;
        }


        /// <summary>
        /// Tail EndsWith Helper
        /// </summary>
        /// <param name="pair">
        /// parameter to be paired if the tail do have these(or, this) ended
        /// </param>
        /// <param name="tail">
        /// the stuff to be checked if it end with pair.
        /// </param>
        ///
        private bool TailContain(string tail, string pair)
        {
            ushort tlen = (ushort)tail.Length,
                   plen = (ushort)pair.Length;

            if (plen == 2)
                if (tail.Equals(pair)) return true;
                else return false;
            else if (plen == 1)
                if (tail.Substring(1).Equals(pair)) return true;
                else return false;            
            else return false;

            return false;
        }

        //private bool TailContain() { }

        public AutoDetectHelper()
		{
		}
	}
}

