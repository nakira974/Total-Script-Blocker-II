using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.BrowserExtension.Pages;
using Lkhsoft.Utility;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using Total_Script_Blocker_II.Models;

// ReSharper disable TemplateIsNotCompileTimeConstantProblem

namespace Total_Script_Blocker_II.Services;

/// <inheritdoc />
public class Blocker : IBlocker
{
    private readonly IJsonSerializer                _jsonSerializer;
    private readonly ILogger<Blocker>               _logger;
    private readonly IJSRuntime                     _jsRuntime;
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public Blocker(IJsonSerializer jsonSerializer, ILogger<Blocker> logger, IJSRuntime jsRuntime)
    {
        _jsonSerializer = jsonSerializer;
        _logger         = logger;
        _jsRuntime      = jsRuntime;
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() => _jsRuntime.InvokeAsync<IJSObjectReference>(
                                                                           "import",
                                                                           "common/common.js")
                                                                         .AsTask());
    }

    /// <inheritdoc />
    public async Task<bool> SortUrlList(IEnumerable<string> urls)
    {
        try
        {
            var module = await _moduleTask.Value;
            return await module.InvokeAsync<bool>("sortUrlList", urls.ToArray());
        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::SortUrlList(IEnumerable<string> urls) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(logMessage);
            return false;
        }
    }

    /// <inheritdoc />
    public async Task<IEnumerable<string>> ParseUri(string url)
    {
        try
        {
            var module = await _moduleTask.Value;
            return await module.InvokeAsync<IEnumerable<string>>("parseUri", url);
        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::ParseUri(string url) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(logMessage);
            throw;
        }
    }

    /// <inheritdoc />
    public string GetRandomId()
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::GetRandomId() error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(logMessage);
            throw;
        }
    }

    /// <inheritdoc />
    public async Task<string> GetPrimaryDomain(string currentUrl)
    {
        try
        {
            var module = await _moduleTask.Value;
            return await module.InvokeAsync<string>("getPrimaryDomain", currentUrl);
        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::GetPrimaryDomain(string currentUrl) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(logMessage);
            throw;
        }
    }

    /// <inheritdoc />
    public bool IsInvalidDomain(string url)
    {
        try
        {
            return url.Length < 4
                || IBlocker.ReInvalidCharsIPv4.Match(url).Success
                || IBlocker.ReKnownTLDs.Match(url).Success;
        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::IsInvalidDomain(string url) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(logMessage);
            return false;
        }
    }

    /// <inheritdoc />
    public bool PatternMatches(string urlToCompare, string patternUrl)
    {
        try
        {
            var coreUrl = urlToCompare;

            if (string.IsNullOrEmpty(coreUrl) || string.IsNullOrEmpty(patternUrl))
                return false;

            coreUrl    = coreUrl.ToLower();
            patternUrl = patternUrl.ToLower();

            // Ensure that we are not matching a "localhost" type name with something like "example.localhost"
            if (IBlocker.ReSeparators.Match(coreUrl).Success != IBlocker.ReSeparators.Match(patternUrl).Success)
                return false;

            // Check to see if the url or urlPattern ends with .ddd (digits or hex).
            // If so, we ONLY want an exact match since these are IPv4 addresses.
            if (IBlocker.EndWithNums.Match(coreUrl).Success || IBlocker.EndWithNums.Match(patternUrl).Success)
                return coreUrl.Equals(patternUrl);

            var endsMatch    = false;
            var matchedIndex = coreUrl.IndexOf(patternUrl, StringComparison.Ordinal);
            if (matchedIndex >= 0 && (matchedIndex + patternUrl.Length).Equals(coreUrl.Length))
                endsMatch = true;

            if (!endsMatch)
            {
                matchedIndex = patternUrl.IndexOf(coreUrl, StringComparison.Ordinal);
                if (matchedIndex >= 0 && (matchedIndex + coreUrl.Length).Equals(patternUrl.Length))
                    endsMatch = true;
            }

            if (!endsMatch)
                return false;
            if (coreUrl.Length.Equals(patternUrl.Length))
                return true;

            // Check to see that we have a valid separator character where they differ
            return (coreUrl.Length > patternUrl.Length
                 && IBlocker.ReSeparators.Match(coreUrl.ElementAt(coreUrl.Length - patternUrl.Length - 1).ToString())
                            .Success)
                || (patternUrl.Length > coreUrl.Length
                 && IBlocker.ReSeparators.Match(patternUrl.ElementAt(patternUrl.Length - coreUrl.Length - 1).ToString())
                            .Success);
        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::PatternMatches(string urlToCompare, string patternUrl) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(logMessage);
            return false;
        }
    }

    /// <inheritdoc />
    public async Task<bool> IsListed(IEnumerable<string> list, string urlToFind)
    {
        try
        {
            return await FindUrlPatternIndex(list, urlToFind) >= 0;
        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::IsListed(IEnumerable<string> list, string urlToFind) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(logMessage);
            return false;
        }
    }

    /// <inheritdoc />
    public async Task<int> FindUrlPatternIndex(IEnumerable<string> list, string patternUrl)
    {
        try
        {
            if (string.IsNullOrEmpty(patternUrl) || list is null)
                return -1;

            var splitFindVals      = patternUrl.Split('.');
            var bestInsertionIndex = -1;
            if (splitFindVals.Length > 1)
            {
                // See if there is an exact match
                var enumerable = list as string[] ?? list.ToArray();
                var foundIndex = await UrlBSearch(enumerable, patternUrl, CompareWSeparators);
                bestInsertionIndex = foundIndex;

                if (foundIndex >= 0)
                    return foundIndex;

                // Otherwise, see if the end segments match
                foundIndex = await UrlBSearch(enumerable, patternUrl, CompareWSeparatorsLoose);

                if (foundIndex >= 0)
                    return foundIndex;
            }
            else
            {
                // Exact match for "localhost" type domains with no separators (ie: TLDs)
                var foundIndex = await UrlBSearch(list, patternUrl, CompareNoSeparators);
                bestInsertionIndex = foundIndex;

                if (foundIndex >= 0)
                    return foundIndex;
            }

            // Return value of -1 means that we couldn't even find a best insertion index
            // Otherwise, abs(return value + 2) gives the best insertion index to maintain sorted order
            return bestInsertionIndex < 0 ? bestInsertionIndex - 1 : -1;
        }
        catch (Exception e)
        {
            var logMessage =
                $"Blocker::FindUrlPatternIndex(IEnumerable<string> list, string patternUrl) error : {e.Message}\n"
              + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(logMessage);
            throw;
        }
    }

    public async Task<int> UrlBSearch(IEnumerable<string> list, string key, Func<string, string, string> comapre)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<int> UrlBSearch(IEnumerable<string> list, string key, Func<string, string, Task<int>> compare)
    {
        try
        {
            var left       = 0;
            var enumerable = list as string[] ?? list.ToArray();
            var right      = enumerable.ToArray().Length - 1;
            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                var cmp = await compare(key, enumerable.ToArray()[mid]);
                if (cmp < 0)
                    right = mid - 1;
                else if (cmp > 0)
                    left = mid + 1;
                else
                    return mid;
            }

            return -(left + 1);
        }
        catch (Exception e)
        {
            var logMessage =
                $"Blocker::UrlBSearch(IEnumerable<string> list, string key, Func<string, string, string> comapre) error : {e.Message}\n"
              + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(logMessage);
            throw;
        }
    }

    /// <inheritdoc />
    public async Task<int> CompareWSeparators(string a, string b)
    {
        try
        {
            var module = await _moduleTask.Value;
            return await module.InvokeAsync<int>("compareWSeparators", a, b);
        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::CompareWSeparators(string a, string b) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(logMessage);
            throw;
        }

        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<int> CompareWSeparatorsLoose(string a, string b)
    {
        try
        {
            var module = await _moduleTask.Value;
            return await module.InvokeAsync<int>("compareWSeparatorsLoose", a, b);
        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::CompareWSeparatorsLoose(string a, string b) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(logMessage);
            throw;
        }
    }

    /// <inheritdoc />
    public async Task<int> CompareNoSeparators(string a, string b)
    {
        try
        {
            var module = await _moduleTask.Value;
            return await module.InvokeAsync<int>("compareNoSeparators", a, b);
        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::CompareNoSeparators(string a, string b) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(logMessage);
            throw;
        }
    }

    /// <inheritdoc />
    public async Task InjectAnnotation(Func<string> function)
    {
        try
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("injectAnon", function);
        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::InjectAnnotation(Func<string> function) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(logMessage);
            throw;
        }
    }

    /// <inheritdoc />
    public async Task InjectGlobal(Func<string> function)
    {
        try
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("injectGlobal", function);
        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::InjectGlobal(Func<string> function) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(logMessage);
            throw;
        }
    }

    /// <inheritdoc />
    public async Task InjectGlobalWithId(Func<string> function, int id)
    {
        try
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("injectGlobalWithId", function, id);
        }
        catch (Exception e)
        {
            var logMessage =
                $"Blocker::SortUrlList(InjectGlobalWithId(Func<string> function, int id) error : {e.Message}\n"
              + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(logMessage);
            throw;
        }
    }

    /// <inheritdoc />
    public async Task<string> RelativeToAbsoluteUrl(string url)
    {
        try
        {
            var module = await _moduleTask.Value;
            return await module.InvokeAsync<string>("relativeToAbsoluteUrl", url);
        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::RelativeToAbsoluteUrl(string url) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(logMessage);
            throw;
        }
    }

    /// <inheritdoc />
    public async Task<BrowserElementType> GetElementType(ElementReference element)
    {
        try
        {
            var module = await _moduleTask.Value;
            return await module.InvokeAsync<BrowserElementType>("getElType", element);
        }
        catch (Exception e)
        {
            var logMessage = $"Blocker::GetElementType(RenderFragment element) error : {e.Message}\n"
                           + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(logMessage);
            throw;
        }
    }

    /// <inheritdoc />
    public async Task<string> GetElementUrl(RenderFragment element, BrowserElementType elementType)
    {
        try
        {
            var module = await _moduleTask.Value;
            return await module.InvokeAsync<string>("getElUrl", element, (int) elementType);
        }
        catch (Exception e)
        {
            var logMessage =
                $"Blocker::GetElementUrl(RenderFragment element, BrowserElementType elementType) error : {e.Message}\n"
              + $"Trace : {e.StackTrace}";
            if (!string.IsNullOrEmpty(logMessage)) _logger.LogError(logMessage);
            throw;
        }
    }
}