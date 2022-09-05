using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Total_Script_Blocker_II.Models;

namespace Total_Script_Blocker_II.Services;

public interface IBlocker
{
    public static Regex ReStartWProtocol = new(@"/^[^\.\/:]+:\/\//i");

    public static Regex ReSeparators = new(@"/[\.:]/i");

    public static Regex EndWithNums = new(@"/\.[0-9]+([^\.\/]+)*$/i");

    public static Regex ReInvalidCharsIPv4 = new(@"/^[\.\/]|[\+\^\?\|\*\{\}\$\s\<\>\[\]\/\\%&=;:!#~`,']|\.\.|[\/]$/i");

    public static Regex ReKnownTLDs =
        new(
            @"/^(asia|biz|cat|coop|edu|info|eu.int|int|gov|jobs|mil|mobi|name|tel|travel|aaa.pro|aca.pro|acct.pro|avocat.pro|bar.pro|cpa.pro|jur.pro|law.pro|med.pro|eng.pro|pro|ar.com|br.com|cn.com|de.com|eu.com|gb.com|hu.com|jpn.com|kr.com|no.com|qc.com|ru.com|sa.com|se.com|uk.com|us.com|uy.com|za.com|com|ab.ca|bc.ca|mb.ca|nb.ca|nf.ca|nl.ca|ns.ca|nt.ca|nu.ca|on.ca|pe.ca|qc.ca|sk.ca|yk.ca|gc.ca|ca|gb.net|se.net|uk.net|za.net|net|ae.org|za.org|org|[^\.\/]+\.uk|act.edu.au|nsw.edu.au|nt.edu.au|qld.edu.au|sa.edu.au|tas.edu.au|vic.edu.au|wa.edu.au|act.gov.au|nt.gov.au|qld.gov.au|sa.gov.au|tas.gov.au|vic.gov.au|wa.gov.au|[^\.\/]+\.au|de|dk|tv|com.ly|net.ly|gov.ly|plc.ly|edu.ly|sch.ly|med.ly|org.ly|id.ly|ly|xn--55qx5d.hk|xn--wcvs22d.hk|xn--lcvr32d.hk|xn--mxtq1m.hk|xn--gmqw5a.hk|xn--ciqpn.hk|xn--gmq050i.hk|xn--zf0avx.hk|xn--io0a7i.hk|xn--mk0axi.hk|xn--od0alg.hk|xn--od0aq3b.hk|xn--tn0ag.hk|xn--uc0atv.hk|xn--uc0ay4a.hk|com.hk|edu.hk|gov.hk|idv.hk|net.hk|org.hk|hk|ac.cn|com.cn|edu.cn|gov.cn|net.cn|org.cn|mil.cn|xn--55qx5d.cn|xn--io0a7i.cn|xn--od0alg.cn|ah.cn|bj.cn|cq.cn|fj.cn|gd.cn|gs.cn|gz.cn|gx.cn|ha.cn|hb.cn|he.cn|hi.cn|hl.cn|hn.cn|jl.cn|js.cn|jx.cn|ln.cn|nm.cn|nx.cn|qh.cn|sc.cn|sd.cn|sh.cn|sn.cn|sx.cn|tj.cn|xj.cn|xz.cn|yn.cn|zj.cn|hk.cn|mo.cn|tw.cn|cn|edu.tw|gov.tw|mil.tw|com.tw|net.tw|org.tw|idv.tw|game.tw|ebiz.tw|club.tw|xn--zf0ao64a.tw|xn--uc0atv.tw|xn--czrw28b.tw|tw|aichi.jp|akita.jp|aomori.jp|chiba.jp|ehime.jp|fukui.jp|fukuoka.jp|fukushima.jp|gifu.jp|gunma.jp|hiroshima.jp|hokkaido.jp|hyogo.jp|ibaraki.jp|ishikawa.jp|iwate.jp|kagawa.jp|kagoshima.jp|kanagawa.jp|kawasaki.jp|kitakyushu.jp|kobe.jp|kochi.jp|kumamoto.jp|kyoto.jp|mie.jp|miyagi.jp|miyazaki.jp|nagano.jp|nagasaki.jp|nagoya.jp|nara.jp|niigata.jp|oita.jp|okayama.jp|okinawa.jp|osaka.jp|saga.jp|saitama.jp|sapporo.jp|sendai.jp|shiga.jp|shimane.jp|shizuoka.jp|tochigi.jp|tokushima.jp|tokyo.jp|tottori.jp|toyama.jp|wakayama.jp|yamagata.jp|yamaguchi.jp|yamanashi.jp|yokohama.jp|ac.jp|ad.jp|co.jp|ed.jp|go.jp|gr.jp|lg.jp|ne.jp|or.jp|jp|co.in|firm.in|net.in|org.in|gen.in|ind.in|nic.in|ac.in|edu.in|res.in|gov.in|mil.in|in)$/i");

    /// <summary>
    /// In place sort of urls. Returns true if successful, false if there was an error.
    /// If false, you must reload the data in theArray since it is passed by reference.
    /// </summary>
    /// <param name="urls">Valid urls to sort</param>
    /// <returns></returns>
    public Task<bool> SortUrlList(IEnumerable<string> urls);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public Task<IEnumerable<string>> ParseUri(string url);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string GetRandomId();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="currentUrl"></param>
    /// <returns></returns>
    public Task<string> GetPrimaryDomain(string currentUrl);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public bool IsInvalidDomain(string url);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="urlToCompare"></param>
    /// <param name="patternUrl"></param>
    /// <returns></returns>
    public bool PatternMatches(string urlToCompare, string patternUrl);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="list"></param>
    /// <param name="urlToFind"></param>
    /// <returns></returns>
    public Task<bool> IsListed(IEnumerable<string> list, string urlToFind);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="list"></param>
    /// <param name="patternUrl"></param>
    /// <returns></returns>
    public Task<int> FindUrlPatternIndex(IEnumerable<string> list, string patternUrl);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="list"></param>
    /// <param name="key"></param>
    /// <param name="comapre"></param>
    /// <returns></returns>
    public Task<int> UrlBSearch(IEnumerable<string> list, string key, Func<string, string, Task<int>> comapre);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public Task<int> CompareWSeparators(string a, string b);


    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public Task<int> CompareWSeparatorsLoose(string a, string b);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public Task<int> CompareNoSeparators(string a, string b);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="function"></param>
    /// <returns></returns>
    public Task InjectAnnotation(Func<string> @function);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="function"></param>
    /// <returns></returns>
    public Task InjectGlobal(Func<string> @function);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="function"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task InjectGlobalWithId(Func<string> @function, int id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public Task<string> RelativeToAbsoluteUrl(string url);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public Task<BrowserElementType> GetElementType(ElementReference element);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="element"></param>
    /// <param name="elementType"></param>
    /// <returns></returns>
    public Task<string> GetElementUrl(RenderFragment element, BrowserElementType elementType);
}