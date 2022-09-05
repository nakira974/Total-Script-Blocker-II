using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lkhsoft.Utility;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using MudBlazor;
using Total_Script_Blocker_II.Models;
// ReSharper disable TemplateIsNotCompileTimeConstantProblem

//TODO Terminate to translate the more js possible into c# code or call JSIterrop if necessary

namespace Total_Script_Blocker_II.Services;

/// <inheritdoc />
public class Blocker : IBlocker
{
    private readonly IJsonSerializer  _jsonSerializer;
    private readonly ILogger<Blocker> _logger;

    public Blocker(IJsonSerializer jsonSerializer, ILogger<Blocker> logger)
    {
        _jsonSerializer = jsonSerializer;
        _logger    = logger;
    }

    /// <inheritdoc />
    public async Task<bool>                SortUrlList(IEnumerable<string> urls)
    {
        try
        {

        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::SortUrlList(IEnumerable<string> urls) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(message: logMessage);
            return false;
        }
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<string>> ParseUri(string                 url)
    {
        try
        {

        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::ParseUri(string url) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(message: logMessage);
            throw;
        }
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public       string                    GetRandomId()
    {
        try
        {

        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::GetRandomId() error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(message: logMessage);
            throw;
        }
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<string>              GetPrimaryDomain(string                 currentUrl)
    {
        try
        {

        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::GetPrimaryDomain(string currentUrl) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(message: logMessage);
            throw;
        }
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public       bool                      IsInvalidDomain(string                  url)
    {
        try
        {

        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::IsInvalidDomain(string url) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(message: logMessage);
            return false;
        }
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public       bool                      PatternMatches(string                   urlToCompare, string patternUrl)
    {
        try
        {

        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::PatternMatches(string urlToCompare, string patternUrl) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(message: logMessage);
            return false;
        }
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public       bool                      IsListed(IEnumerable<string>            list,         string urlToFind)
    {
        try
        {

        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::IsListed(IEnumerable<string> list, string urlToFind) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(message: logMessage);
            return false;
        }
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<string>> FindUrlPatternIndex(IEnumerable<string> list,         string patternUrl)
    {
        try
        {

        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::FindUrlPatternIndex(IEnumerable<string> list, string patternUrl) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(message: logMessage);
            throw;
        }
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public       IEnumerable<int>          UrlBSearch(IEnumerable<string>          list,         string key, Func<string, string, string> comapre)
    {
        try
        {

        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::UrlBSearch(IEnumerable<string> list, string key, Func<string, string, string> comapre) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(message: logMessage);
            throw;
        }
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public       int                       CompareWSeparators(string               a,            string b)
    {
        try
        {

        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::CompareWSeparators(string a, string b) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(message: logMessage);
            throw;
        }
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public       int                       CompareWSeparatorsLoose(string          a,            string b)
    {
        try
        {

        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::CompareWSeparatorsLoose(string a, string b) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(message: logMessage);
            throw;
        }
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public       int                       CompareNoSeparators(string              a,            string b)
    {
        try
        {

        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::CompareNoSeparators(string a, string b) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(message: logMessage);
            throw;
        }
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task                      InjectAnnotation(Func<string>           function)
    {
        try
        {

        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::InjectAnnotation(Func<string> function) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(message: logMessage);
            throw;
        }
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task                      InjectGlobal(Func<string>               function)
    {
        try
        {

        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::InjectGlobal(Func<string> function) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(message: logMessage);
            throw;
        }
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task                      InjectGlobalWithId(Func<string>         function, int id)
    {
        try
        {

        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::SortUrlList(InjectGlobalWithId(Func<string> function, int id) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(message: logMessage);
            throw;
        }
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public       string                    RelativeToAbsoluteUrl(string            url)
    {
        try
        {

        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::RelativeToAbsoluteUrl(string url) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(message: logMessage);
            throw;
        }
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public       BrowserElementType        GetElementType(RenderFragment           element)
    {
        try
        {

        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::GetElementType(RenderFragment element) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(message: logMessage);
            throw;
        }
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<string>                    GetElementUrl(RenderFragment element, BrowserElementType elementType)
    {
        try
        {

        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::GetElementUrl(RenderFragment element, BrowserElementType elementType) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(message: logMessage);
            throw;
        }
        throw new NotImplementedException();
    }
}