using System;

namespace Assets.BotDirectLine
{
    public class EventActivity
    {
        public DateTime Timestamp
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string ChannelId
        {
            get;
            set;
        }

        public string FromId
        {
            get;
            set;
        }

        public string FromName
        {
            get;
            set;
        }

        public string ConversationId
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }

        public string ReplyToId
        {
            get;
            set;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public EventActivity()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="fromId"></param>
        /// <param name="value"></param>
        /// <param name="channelId"></param>
        /// <param name="timestampString"></param>
        /// <param name="fromName"></param>
        /// <param name="conversationId"></param>
        /// <param name="replyToId"></param>
        public EventActivity(string fromId, string value, string channelId,
            string timestampString = null, string fromName = null, string conversationId = null, string replyToId = null)
        {
            if (string.IsNullOrEmpty(timestampString))
            {
                Timestamp = DateTime.Now;
            }
            else
            {
                Timestamp = Convert.ToDateTime(timestampString);
            }

            ChannelId = channelId;
            FromId = fromId;
            FromName = fromName;
            ConversationId = conversationId;
            Value = value;
            ReplyToId = replyToId;
        }

        public static EventActivity FromJson(SimpleJSON.JSONNode activityJsonRootNode)
        {
            EventActivity eventActivity = new EventActivity();
            eventActivity.Id = activityJsonRootNode[BotJsonProtocol.KeyId];
            eventActivity.Timestamp = Convert.ToDateTime(activityJsonRootNode[BotJsonProtocol.KeyTimestamp]);
            eventActivity.ChannelId = activityJsonRootNode[BotJsonProtocol.KeyChannelId];

            SimpleJSON.JSONNode fromJsonRootNode = activityJsonRootNode[BotJsonProtocol.KeyFrom];

            if (fromJsonRootNode != null)
            {
                eventActivity.FromId = fromJsonRootNode[BotJsonProtocol.KeyId];
                eventActivity.FromName = fromJsonRootNode[BotJsonProtocol.KeyName];
            }

            SimpleJSON.JSONNode conversationJsonRootNode = activityJsonRootNode[BotJsonProtocol.KeyConversation];

            if (conversationJsonRootNode != null)
            {
                eventActivity.ConversationId = fromJsonRootNode[BotJsonProtocol.KeyId];
            }

            eventActivity.Value = activityJsonRootNode[BotJsonProtocol.KeyValue];
            eventActivity.ReplyToId = activityJsonRootNode[BotJsonProtocol.KeyReplyToId];

            return eventActivity;
        }

        public string ToJsonString()
        {
            string asJsonString =
                "{ \"" + BotJsonProtocol.KeyActivityType + "\": \"" + BotJsonProtocol.KeyEvent + "\", \""
                + BotJsonProtocol.KeyChannelId + "\": \"" + ChannelId + "\", \""
                + BotJsonProtocol.KeyFrom + "\": { \""
                    + BotJsonProtocol.KeyId + "\": \"" + FromId
                    + (string.IsNullOrEmpty(FromName) ? "" : ("\", \"" + BotJsonProtocol.KeyName + "\": \"" + FromName))
                + "\" }, \""
                + BotJsonProtocol.KeyValue + "\": \"" + Value + "\" }";

            return asJsonString;
        }

        public override string ToString()
        {
            return ToJsonString();
        }
    }
}