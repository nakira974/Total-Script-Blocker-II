namespace Total_Script_Blocker_II.Models;

/// <summary>
/// Describe all elements operating in the browser
/// <remarks> Look at MDN Documentation for more information about HTML Elements :
/// https://developer.mozilla.org/en-US/docs/Web/HTML/Element
/// </remarks>
/// </summary>

public enum BrowserElementType
{
    /// <summary>
    /// Other elements like network, settings...
    /// </summary>
    Other  = 0x000,
    /// <summary>
    /// The script HTML element is used to embed executable code or data; this is typically used to embed or refer to JavaScript code.
    /// The script element can also be used with other languages, such as WebGL's GLSL shader programming language and JSON.
    /// </summary>
    Script = 0x001,
    /// <summary>
    /// The Object type represents one of JavaScript's data types. It is used to store various keyed collections and more complex entities.
    /// Objects can be created using the Object() constructor or the object initializer / literal syntax.
    /// </summary>
    Object = 0x002,
    /// <summary>
    /// External documents at the specified point in the document
    /// </summary>
    Embed  = 0x003,
    /// <summary>
    /// The IFrame HTML element represents a nested browsing context, embedding another HTML page into the current one.
    /// </summary>
    IFrame = 0x004,
    /// <summary>
    /// The frame HTML element defines a particular area in which another HTML document can be displayed.
    /// A frame should be used within a frameset.
    /// </summary>
    Frame = 0x005,
    /// <summary>
    /// The audio HTML element is used to embed sound content in documents.
    /// It may contain one or more audio sources,
    /// represented using the src attribute or the source element: the browser will choose the most suitable one.
    /// It can also be the destination for streamed media, using a MediaStream.
    /// </summary>
    Audio = 0x006,
    /// <summary>
    /// The video HTML element embeds a media player which supports video playback into the document.
    /// You can use video for audio content as well, but the audio element may provide a more appropriate user experience.
    /// </summary>
    Video = 0x007,
    /// <summary>
    /// The image HTML element is an ancient and poorly supported precursor to the img element.
    /// It should not be used.
    /// </summary>
    Image = 0x008,
    /// <summary>
    /// The body HTML element represents the content of an HTML document.
    /// There can be only one body element in a document.
    /// </summary>
    Body = 0x009,
    /// <summary>
    /// The style HTML element contains style information for a document, or part of a document.
    /// It contains CSS, which is applied to the contents of the document containing the style element.
    /// </summary>
    Style = 0x00A
}
    