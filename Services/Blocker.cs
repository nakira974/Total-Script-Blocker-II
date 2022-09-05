using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Total_Script_Blocker_II.Models;

//TODO Terminate to translate the more js possible into c# code or call JSIterrop if necessary

namespace Total_Script_Blocker_II.Services;

/// <inheritdoc />
public class Blocker : IBlocker
{
    /// <inheritdoc />
    public async Task<bool>                SortUrlList(IEnumerable<string> urls)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<string>> ParseUri(string                 url)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public       string                    GetRandomId()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<string>              GetPrimaryDomain(string                 currentUrl)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public       bool                      IsInvalidDomain(string                  url)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public       bool                      PatternMatches(string                   urlToCompare, string patternUrl)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public       bool                      IsListed(IEnumerable<string>            list,         string urlToFind)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<string>> FindUrlPatternIndex(IEnumerable<string> list,         string patternUrl)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public       IEnumerable<int>          UrlBSearch(IEnumerable<string>          list,         string key, Func<string, string, string> comapre)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public       int                       CompareWSeparators(string               a,            string b)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public       int                       CompareWSeparatorsLoose(string          a,            string b)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public       int                       CompareNoSeparators(string              a,            string b)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task                      InjectAnnotation(Func<string>           function)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task                      InjectGlobal(Func<string>               function)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task                      InjectGlobalWithId(Func<string>         function, int id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public       string                    RelativeToAbsoluteUrl(string            url)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public       BrowserElementType        GetElementType(RenderFragment           element)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<string>                    GetElementUrl(RenderFragment element, BrowserElementType elementType)
    {
        throw new NotImplementedException();
    }
}