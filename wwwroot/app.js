if (globalThis.BlazorBrowserExtension.BrowserExtension.Mode === globalThis.BlazorBrowserExtension.Modes.ContentScript) {
    const appDiv = document.createElement("div");
    appDiv.id = "TotalScriptBlockerIIApp";
    document.body.appendChild(appDiv);
}