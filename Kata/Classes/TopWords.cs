using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kata.Classes
{
    [TestFixture]
    public class TopWordsTest
    {
        [Test]
        public void SampleTests()
        {
            Assert.AreEqual(new List<string> { "e", "d", "a" }, TopWords.Top3("a a a  b  c c  d d d d  e e e e e"));
            Assert.AreEqual(new List<string> { "e", "ddd", "aa" }, TopWords.Top3("e e e e DDD ddd DdD: ddd ddd aa aA Aa, bb cc cC e e e"));
            Assert.AreEqual(new List<string> { "won't", "wont" }, TopWords.Top3("  //wont won't won't "));
            Assert.AreEqual(new List<string> { "e" }, TopWords.Top3("  , e   .. "));
            Assert.AreEqual(new List<string> { }, TopWords.Top3("  ...  "));
            Assert.AreEqual(new List<string> { }, TopWords.Top3("  '  "));
            Assert.AreEqual(new List<string> { }, TopWords.Top3("  '''  "));
            Assert.AreEqual(new List<string> { "a", "of", "on" }, TopWords.Top3(
                string.Join("\n", new string[]{"In a village of La Mancha, the name of which I have no desire to call to",
                  "mind, there lived not long since one of those gentlemen that keep a lance",
                  "in the lance-rack, an old buckler, a lean hack, and a greyhound for",
                  "coursing. An olla of rather more beef than mutton, a salad on most",
                  "nights, scraps on Saturdays, lentils on Fridays, and a pigeon or so extra",
                  "on Sundays, made away with three-quarters of his income." })));
        }

        [Test]
        public void MyMethod()
        {
            Assert.AreEqual(new List<string> { "nxjib", "xttvbq", "bssekwi'wk" }, TopWords.Top3(
                            string.Join("\n", new string[] { "LVG?BsSEkWI'WK TIp TIp!BsSEkWI'WK UhuPtPg;BsSEkWI'WK aiioke mKIHQrEQC NXjib mSWmlqal qpMaddXMhu mKIHQrEQC NXjib:Eyu cudn?XTTVBQ_XTTVBQ XTTVBQ_aiioke TIp.mSWmlqal aiioke;Eyu/lKqx TIp TIp UhuPtPg LBa,XTTVBQ NXjib!BsSEkWI'WK.XTTVBQ.TIp LVG!UhuPtPg!mKIHQrEQC LVG?mSWmlqal XTTVBQ!UhuPtPg qpMaddXMhu;TIp_hyS-lKqx BsSEkWI'WK:mSWmlqal aiioke lKqx:cudn Eyu mSWmlqal bRgjP XTTVBQ_TIp mSWmlqal UhuPtPg;mKIHQrEQC,UhuPtPg VpUcgcjy?GhkjPR:aiioke mKIHQrEQC UhuPtPg;TIp-qpMaddXMhu_XTTVBQ jJibJV LBa/qpMaddXMhu:NXjib?qpMaddXMhu TIp TIp XTTVBQ!BsSEkWI'WK!XTTVBQ BsSEkWI'WK-mKIHQrEQC aiioke/XTTVBQ_aiioke_LVG aiioke/jJibJV!UhuPtPg lKqx/XTTVBQ mKIHQrEQC?mSWmlqal_NXjib NXjib!mSWmlqal:mKIHQrEQC-lKqx-lKqx/NXjib BsSEkWI'WK mKIHQrEQC,XTTVBQ_aiioke!cudn bRgjP LVG NXjib mSWmlqal UhuPtPg UhuPtPg BsSEkWI'WK NXjib bRgjP?LVG.ATNCHHnEqO NXjib_hyS hyS Eyu;lKqx?lKqx aiioke/bRgjP TIp-LVG lKqx_BsSEkWI'WK.XTTVBQ LVG GhkjPR NXjib lKqx?lKqx/cudn/lKqx/NXjib_lKqx/mSWmlqal,XTTVBQ.lKqx LBa UhuPtPg mSWmlqal mKIHQrEQC,mSWmlqal-lKqx hyS-LBa VpUcgcjy mSWmlqal_qpMaddXMhu?TIp/TIp/cudn-TIp NXjib XTTVBQ mKIHQrEQC BsSEkWI'WK-LBa bRgjP/Eyu mKIHQrEQC;LBa NXjib!mSWmlqal VpUcgcjy,BsSEkWI'WK mKIHQrEQC!qpMaddXMhu UhuPtPg.mKIHQrEQC?mSWmlqal NXjib,LVG/LVG mSWmlqal Eyu-aiioke_LVG mSWmlqal-aiioke?NXjib?NXjib;qpMaddXMhu LVG XTTVBQ jJibJV ATNCHHnEqO qpMaddXMhu XTTVBQ_LVG qpMaddXMhu:mSWmlqal BsSEkWI'WK lKqx TIp_NXjib lKqx:XTTVBQ qpMaddXMhu lKqx_aiioke XTTVBQ aiioke qpMaddXMhu qpMaddXMhu GhkjPR,lKqx hyS aiioke TIp cudn/TIp BsSEkWI'WK!XTTVBQ?UhuPtPg?hyS UhuPtPg?XTTVBQ mSWmlqal,UhuPtPg_cudn;VpUcgcjy aiioke XTTVBQ?NXjib/NXjib hyS NXjib_UhuPtPg cudn.NXjib,lKqx hyS!XTTVBQ TIp_TIp mKIHQrEQC TIp Eyu.LBa mSWmlqal:BsSEkWI'WK mKIHQrEQC?BsSEkWI'WK?VpUcgcjy LBa LBa NXjib cudn LVG.mKIHQrEQC UhuPtPg?BsSEkWI'WK!qpMaddXMhu BsSEkWI'WK UhuPtPg!BsSEkWI'WK LVG hyS;mSWmlqal!LVG mSWmlqal BsSEkWI'WK BsSEkWI'WK_bRgjP;BsSEkWI'WK:NXjib,NXjib aiioke/LBa LVG_TIp Eyu:NXjib;NXjib BsSEkWI'WK:jJibJV;Eyu:aiioke/jJibJV;mSWmlqal hyS NXjib Eyu,UhuPtPg LVG BsSEkWI'WK aiioke.ATNCHHnEqO TIp BsSEkWI'WK:XTTVBQ.ATNCHHnEqO UhuPtPg!aiioke aiioke qpMaddXMhu_hyS qpMaddXMhu mSWmlqal_aiioke XTTVBQ aiioke/lKqx XTTVBQ!jJibJV_UhuPtPg_cudn hyS;TIp,NXjib Eyu,qpMaddXMhu;BsSEkWI'WK;UhuPtPg lKqx!XTTVBQ mSWmlqal_mKIHQrEQC.mKIHQrEQC lKqx.TIp mKIHQrEQC BsSEkWI'WK/LBa lKqx-mKIHQrEQC;qpMaddXMhu aiioke aiioke mSWmlqal NXjib!LVG ATNCHHnEqO-XTTVBQ?XTTVBQ jJibJV_qpMaddXMhu hyS?BsSEkWI'WK cudn?mKIHQrEQC hyS LBa!" })));
        }
    }

    internal class TopWords
    {
        public static List<string> Top3(string s) =>
            Regex
                .Matches(string.Concat(s.Select(c => char.IsPunctuation(c) && c != '\'' ? ' ' : c)), @"\'?\b(?:[^\d\W_]|['][^\d\W])+\b\'?", RegexOptions.IgnoreCase)
                .Select(m => m.Value.ToLower())
                .Distinct()
                .ToDictionary(k => k, v => Regex
                    .Matches(string.Concat(s.Select(c => char.IsPunctuation(c) && c != '\'' ? ' ' : c)), @"\'?\b(?:[^\d\W_]|['][^\d\W])+\b\'?", RegexOptions.IgnoreCase)
                    .Where(m => m.Value.ToLower().Equals(v))
                    .Count())
                .OrderByDescending(d => d.Value)
                .Take(3)
                .Select(d => d.Key)
                .ToList();
    }
}