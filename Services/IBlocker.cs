using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Total_Script_Blocker_II.Models;

namespace Total_Script_Blocker_II.Services;

public interface IBlocker
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="urls"></param>
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
    public bool IsListed(IEnumerable<string> list, string urlToFind);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="list"></param>
    /// <param name="patternUrl"></param>
    /// <returns></returns>
    public Task<IEnumerable<string>> FindUrlPatternIndex(IEnumerable<string> list, string patternUrl);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="list"></param>
    /// <param name="key"></param>
    /// <param name="comapre"></param>
    /// <returns></returns>
    public IEnumerable<int> UrlBSearch(IEnumerable<string> list, string key, Func<string, string, string> comapre);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int CompareWSeparators(string a, string b);


    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int CompareWSeparatorsLoose(string a, string b);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int CompareNoSeparators(string a, string b);

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
    public string RelativeToAbsoluteUrl(string url);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public BrowserElementType GetElementType(RenderFragment element);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="element"></param>
    /// <param name="elementType"></param>
    /// <returns></returns>
    public Task<string> GetElementUrl(RenderFragment element, BrowserElementType elementType);
}