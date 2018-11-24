using Prism.Events;

namespace PtaSheet.Infrastructure.Events
{

    /// <summary>
    ///     Defines a pub-sub event for the StatusBar.
    /// </summary>
    public sealed class StatusEvent : PubSubEvent<string> { }

}
